using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListView
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        private void changeSortOrder(string field)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            ListSortDirection newOrder = ListSortDirection.Ascending;

            if (view.SortDescriptions.Count > 0)
            {
                if (view.SortDescriptions[0].Direction == ListSortDirection.Ascending)
                    newOrder = ListSortDirection.Descending;
                view.SortDescriptions.RemoveAt(0);
            }
            view.SortDescriptions.Add(new SortDescription(field, newOrder));
        }

        private void nameColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            changeSortOrder("Name");
        }

        private void passwordColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            changeSortOrder("Password");
        }
    }
}
