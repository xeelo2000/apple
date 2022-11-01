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

/****
 * 
 * Author: 
 * Description: Starter code for lab 10
 * Date: November 28, 2021
 * 
 *****/
namespace Lab10Starter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicTacToeGame ticTacToe;
        Button[,] grid;

        
        /// <summary>
        /// initializes the component
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ticTacToe = new TicTacToeGame();
            grid = new Button[TicTacToeGame.GRID_SIZE, TicTacToeGame.GRID_SIZE] { { Tile00, Tile01, Tile02 }, { Tile10, Tile11, Tile12 }, { Tile20, Tile21, Tile22 } };
        }

        /// <summary>
        /// Handles button clicks - changes the button to an X or O (depending on whose turn it is)
        /// Checks to see if there is a victory - if so, invoke 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleButtonClick(object sender, RoutedEventArgs e)
        {
            Player victor;
            Player currentPlayer = ticTacToe.CurrentPlayer;

            Button button = (Button)sender;
            string buttonIndices = button.Name.Substring(button.Name.Length - 2); // contains "00", "01", ,,, "22"
            int row = int.Parse(buttonIndices.Substring(0, 1));
            int col = int.Parse(buttonIndices.Substring(1));

            if (button.Content.ToString() != "")
            { // if the button has an X or O, bail
                MessageBox.Show("Illegal move");
                return;
            }
            button.Content = currentPlayer;
            Boolean gameOver = ticTacToe.ProcessTurn(row, col, out victor);

            if (gameOver)
            {
                CelebrateVictory(victor);
                
            }
        }

        /// <summary>
        /// Celebrates victory, displaying a message box and resetting the game
        /// </summary>
        private void CelebrateVictory(Player victor)
        {
            MessageBox.Show(Application.Current.MainWindow, String.Format("Congratulations, {0}, you're the big winner today", victor.ToString()));
            XScoreLBL.Content = String.Format("X's Score: {0}", ticTacToe.XScore);
            OScoreLBL.Content = String.Format("O's Score: {0}", ticTacToe.OScore);

            ResetGame();
        }

        /// <summary>
        /// Resets the grid buttons so their content is all ""
        /// </summary>
        private void ResetGame()
        {

        }

    }

}
