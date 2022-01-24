using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace LibraryDecimalApplication.Windows
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private string value = "x";
        private int xWins = 0;
        private int oWins = 0;
        private int currentUser;
        private static readonly Brush DEFAULTBRUSH = new SolidColorBrush(Color.FromArgb(255, 142, 147, 166));

       
        public Game()
        {
            InitializeComponent();
        }

        //Menu Click Events
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            xWins = 0;
            oWins = 0;
            lbXWins.Content = "X: 0";
            lboWins.Content = "O: 0";

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a X_O game .\nCreated by Jordan Molefe", "Game X_O_ and is 2 Player", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Buttons Events
        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Foreground = Brushes.Black;
            bt.IsEnabled = false;
            

            if (IsWin(btA1, btA2, btA3)) GameOver(btA1.Content.ToString());
            if(IsWin(btB1, btB2, btB3)) GameOver(btB1.Content.ToString());
            if(IsWin(btC1, btC2, btC3)) GameOver(btC1.Content.ToString());
            if(IsWin(btA1, btB1, btC1)) GameOver(btA1.Content.ToString());
            if(IsWin(btA2, btB2, btC3)) GameOver(btA2.Content.ToString());
            if(IsWin(btA3, btB3, btC3)) GameOver(btA3.Content.ToString());
            if(IsWin(btA1, btB2, btC3)) GameOver(btA1.Content.ToString());
            if(IsWin(btA3, btB2, btC1)) GameOver(btA3.Content.ToString());

            if (!btA1.IsEnabled && !btA2.IsEnabled && !btA3.IsEnabled &&
                !btB1.IsEnabled && !btB2.IsEnabled && !btB3.IsEnabled &&
                !btC1.IsEnabled && !btC2.IsEnabled && !btC3.IsEnabled)
                GameOver("");

            value = value == "X" ? "o" : "X";
        }

        private void GameOver(string who)
        {
            if (lbWinner.IsEnabled) return;
            if (who == "x")
            {
                lbWinner.Content = "Player X Wins!";
                lbXWins.Content = $" X: {++xWins}";
            }
            else if (who == "o")
            {
                lbWinner.Content = "Player o Win!";
                lboWins.Content = $"o: {++oWins}";
            }
            else lbWinner.Content = "No Winner !?";
            lbWinner.Visibility = Visibility.Visible;
            Wait1SecAndRestart();
        
        }

        private async void Wait1SecAndRestart()
        {
            await Task.Delay(1000);
            lbWinner.Visibility = Visibility.Hidden;
            ResetButtons();
        }

        private void ResetButtons()
        {
            ResetButton(btA1);
            ResetButton(btA2);
            ResetButton(btA3);
            ResetButton(btB1);
            ResetButton(btB2);
            ResetButton(btB3);
            ResetButton(btC1);
            ResetButton(btC2);
            ResetButton(btC3);
        }

        private void ResetButton(Button bt)
        {
            bt.Content = "";
            bt.IsEnabled = true;
            bt.Foreground = DEFAULTBRUSH;


        }

        private bool IsWin(Button bt1, Button bt2, Button bt3) =>
            !bt1.IsEnabled && bt1.Content == bt2.Content && bt1.Content == bt3.Content;
        private void bt_Enter(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Content = value;

        }
        private void bt_Leave(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.IsEnabled)
                bt.Content = "";
        }

        //Link Events
        private void link_Click(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo 
            { 
                FileName = "cmd.exe",
                Arguments = "/c start www.youtube.com",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }

        private void BtToMain_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to return to main menu? If a game is still in session all current progress will be lost ", "Return to Main Menu Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MainMenu mm = new MainMenu(currentUser);
                mm.Show();
                this.Close();
            }
        }
    }
}
