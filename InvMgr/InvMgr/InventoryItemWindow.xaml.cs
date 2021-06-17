using InvMgr.Models;
using System;
using System.Windows;

namespace InvMgr
{
    /// <summary>
    /// Interaction logic for InventoryItemWindow.xaml
    /// </summary>
    public partial class InventoryItemWindow : Window
    {
        public InventoryItemWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public InventoryItemModel InventoryItem { get; set; }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (InventoryItem != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                InventoryItem = new InventoryItemModel();
                InventoryItem.description = "Enter Description";
                InventoryItem.location = "Enter Location";
                InventoryItem.createDate = DateTime.Now;
            }

            uxGrid.DataContext = InventoryItem;
        }


        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //InventoryItem = new InventoryItemModel();

            //InventoryItem.description = uxDescription.Text;
            //InventoryItem.location = uxLocation.Text;
            //InventoryItem.price = float.Parse(uxPrice.Text);
            //InventoryItem.cost = float.Parse(uxCost.Text);
            //InventoryItem.quantity = Int32.Parse(uxQuantity.Text);
            //InventoryItem.createDate = DateTime.Now;

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }
    }
}
