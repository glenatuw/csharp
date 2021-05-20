using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace ZipCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }
        
        // check for valid zip code on entry
        public void onChanged(object sender, TextChangedEventArgs args)
        {
            string text = ((TextBox) args.Source).Text;
            bool valid = false;
            
            // valid US zip code
            Regex rgxUSZipCode = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
            MatchCollection matches = rgxUSZipCode.Matches(text);
            if (matches.Count > 0)
            {
                valid = true;
            }

            // valid Canadian zip code
            Regex rgxCAZipCode = new Regex(@"^(?!.*[DFIOQU])[A-VXY][0-9][A-Z]?[0-9][A-Z][0-9]$");
            matches = rgxCAZipCode.Matches(text);
            if (matches.Count > 0)
            {
                valid = true;
            }

            uxSubmit.IsEnabled = valid;
        }



    }

}
