using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TTT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum BOX_VALUE { X, O, EMPTY };
        BOX_VALUE[,] gameBoxes;
        BOX_VALUE whoseTurn;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            gameBoxes = new BOX_VALUE[3, 3] { { BOX_VALUE.EMPTY, BOX_VALUE.EMPTY, BOX_VALUE.EMPTY }, { BOX_VALUE.EMPTY, BOX_VALUE.EMPTY, BOX_VALUE.EMPTY }, { BOX_VALUE.EMPTY, BOX_VALUE.EMPTY, BOX_VALUE.EMPTY } };
            whoseTurn = BOX_VALUE.X;
            reportTurn();
            resetButtons();
        }

        private void disableButtons()
        {
            foreach (Button b in uxGrid.Children)
            {
                b.IsEnabled = false;
            }
        }

        private void resetButtons()
        {
            foreach (Button b in uxGrid.Children)
            {
                b.Content = string.Empty;
                b.IsEnabled = true;
            }
        }

        private void changeTurn()
        {
            if (whoseTurn == BOX_VALUE.X)
                whoseTurn = BOX_VALUE.O;
            else
                whoseTurn = BOX_VALUE.X;

            reportTurn();
        }

        private void reportTurn()
        {
            uxTurn.Text = Enum.GetName(typeof(BOX_VALUE), whoseTurn) + "'s turn";
        }

        private void reportWinner()
        {
            uxTurn.Text = Enum.GetName(typeof(BOX_VALUE), whoseTurn) + " is a winner";
        }

        private void reportTie()
        {
            uxTurn.Text = "It is a tie";
        }

        private bool isFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (gameBoxes[row, col] == BOX_VALUE.EMPTY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool isWinner()
        {
            // rows
            for (int row = 0; row < 3; row++)
            {
                BOX_VALUE val = gameBoxes[row, 0];

                if (val == BOX_VALUE.EMPTY)
                {
                    continue;
                }

                bool sameInRow = true;
                for (int col = 0; col < 3; col++)
                {
                    if (gameBoxes[row, col] != val)
                        sameInRow = false;
                }

                if (sameInRow)
                {
                    return true;
                }
            }

            // columns
            for (int col = 0; col < 3; col++)
            {
                BOX_VALUE val = gameBoxes[0, col];

                if (val == BOX_VALUE.EMPTY)
                {
                    continue;
                }

                bool sameInCol = true;
                for (int row = 0; row < 3; row++)
                {
                    if (gameBoxes[row, col] != val)
                        sameInCol = false;
                }

                if (sameInCol)
                {
                    return true;
                }
            }

            // only thing left is diagonals
            return gameBoxes[0, 0] != BOX_VALUE.EMPTY && gameBoxes[0, 0] == gameBoxes[1, 1] && gameBoxes[0, 0] == gameBoxes[2, 2]
                || gameBoxes[0, 2] != BOX_VALUE.EMPTY && gameBoxes[0, 2] == gameBoxes[1, 1] && gameBoxes[0, 2] == gameBoxes[2, 0];
        }

        void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] from = ((Button)sender).Tag.ToString().Split(',');
            int row = Int32.Parse(from[0]);
            int col = Int32.Parse(from[1]);

            if (gameBoxes[row, col] == BOX_VALUE.EMPTY)
            {
                gameBoxes[row, col] = whoseTurn;
                ((Button)sender).Content = Enum.GetName(typeof(BOX_VALUE), whoseTurn);
                if (isWinner())
                {
                    reportWinner();
                    disableButtons();
                }
                else if (isFull())
                {
                    reportTie();
                    disableButtons();
                }
                else
                {
                    changeTurn();
                }
            }
        }

    }
}
