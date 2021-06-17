using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using InvMgr.Models;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace InvMgr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InventoryItemModel selectedInventoryItem;

        private GridViewColumnHeader listViewSortCol = null;

        public MainWindow()
        {
            InitializeComponent();

            LoadInventory();
        }

        private void LoadInventory()
        {
            var inventory = App.InventoryRepository.GetSome(uxSearchInput.Text);

            uxInventoryList.ItemsSource = inventory
                .Select(t => InventoryItemModel.ToModel(t))
                .ToList();

            uxItemCount.Text = uxInventoryList.Items.Count + " Inventory Items";
        }



        // Click Ctrl-N to execute the shortcut.
        private void OnNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Set this to false if the New command is not available
            e.CanExecute = true;
        }
        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new InventoryItemWindow();

            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                var uiInventoryItemModel = window.InventoryItem;

                var repositoryInventoryItemModel = uiInventoryItemModel.ToRepositoryModel();

                App.InventoryRepository.Add(repositoryInventoryItemModel);

                LoadInventory();
            }
        }


        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedInventoryItem = (InventoryItemModel)uxInventoryList.SelectedValue;
            uxEditChange_Click(sender, (RoutedEventArgs) e);
        }

        private void uxInventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedInventoryItem = (InventoryItemModel)uxInventoryList.SelectedValue;
        }

        private void uxSearch_Changed(object sender, TextChangedEventArgs e)
        {
            LoadInventory();
        }

        private void uxEditDelete_Click(object sender, RoutedEventArgs e)
        {
            App.InventoryRepository.Remove(selectedInventoryItem.id);
            selectedInventoryItem = null;
            LoadInventory();
        }

        private void uxEditDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxEditDelete.IsEnabled = (selectedInventoryItem != null);
            uxContextEditDelete.IsEnabled = (selectedInventoryItem != null);
        }

        private void uxEditChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new InventoryItemWindow();
            
            window.Owner = this;

            window.InventoryItem = selectedInventoryItem.Clone();

            if (window.ShowDialog() == true)
            {
                App.InventoryRepository.Update(window.InventoryItem.ToRepositoryModel());
                LoadInventory();
            }
        }

        private void uxEditChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxEditChange.IsEnabled = (selectedInventoryItem != null);
            uxContextEditChange.IsEnabled = (selectedInventoryItem != null);
        }

        private void changeSortOrder(string field)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxInventoryList.ItemsSource);
            ListSortDirection newOrder = ListSortDirection.Ascending;

            if (view.SortDescriptions.Count > 0)
            {
                if (view.SortDescriptions[0].Direction == ListSortDirection.Ascending)
                    newOrder = ListSortDirection.Descending;
                view.SortDescriptions.RemoveAt(0);
            }
            view.SortDescriptions.Add(new SortDescription(field, newOrder));
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            changeSortOrder(sortBy);
        }

        private void OnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
