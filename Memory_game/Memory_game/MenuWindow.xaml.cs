using Memory_game.UserData;
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
using System.Windows.Shapes;

namespace Memory_game
{ 
    public partial class MenuWindow : Window
    {
        MainWindow parent;
        public int numberOfPairs;
        public User player;
        public MenuWindow(MainWindow parent)
        {
            InitializeComponent();
            numberOfPairs = 0;
            this.parent = parent;
            player = parent.m_player;
            playerName.Content = parent.m_player.Name;
            playerGamesPlayed.Content = parent.m_player.NumberOfGames;
            playerGamesWon.Content = parent.m_player.NumberOfWonGames;
            var imagePath = parent.m_player.Image;
            var imageSource = new BitmapImage(new Uri(imagePath));
            playerImage.Source = imageSource;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.parent.Show();
        }

        private void btn_start_game_Click(object sender, RoutedEventArgs e)
        {
            if (charNumberOfPairs.Text.Length == 1)
            {
                numberOfPairs = charNumberOfPairs.Text[0] - '0';
            }
            else
            {
                if (charNumberOfPairs.Text.Length == 2)
                {
                    numberOfPairs = (charNumberOfPairs.Text[0] - '0') * 10;
                    numberOfPairs += charNumberOfPairs.Text[1] - '0';
                }
            }
            if (numberOfPairs < 2 || numberOfPairs > 13) 
            {
                MessageBox.Show("Invalid number!");
            }
            else
            {
                GameWindow w = new GameWindow(this);
                w.Show();
                this.Hide();
            }
        }

        private void MenuItem_Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Jocul a fost facut de Nicu Valentin Cosmin din grupa 312.");
        }

        private void MenuItem_Rules_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Scopul jocului este sa gasiti toate perechile in timpul dat.\n" +
                "Se da click pe o carte pentru a se intoarce. \n" +
                "Daca sa gasesc 2 carti pereche, acestea raman cu fata in sus, altfel sunt intoarse inapoi.");
        }
    }
}
