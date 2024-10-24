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
using System.Windows.Threading;

namespace Memory_game
{
    public partial class GameWindow : Window
    {
        MenuWindow parent;
        Button firstButton;
        Button secondButton;
        int numberOfClickedCards;
        int numberOfFoundPairs;
        int numberOfWonGames;
        string backImage = "D://An_2_sem2//MVP/Memory_game//Memory_game//Photos//Basic_Back.jpg";

        private DispatcherTimer timer;
        private int remainingTime;
        private int timeMultiplier;
        public GameWindow(MenuWindow parent)
        {
            InitializeComponent();
            timeMultiplier = 8;
            this.parent = parent;
            firstButton = new Button();
            secondButton = new Button();
            numberOfClickedCards = 0;
            numberOfFoundPairs = 0;
            numberOfWonGames = 0;


            var imagePath = parent.player.Image;
            var imageSource = new BitmapImage(new Uri(imagePath));
            imgPlayer.Source = imageSource;
            labelPlayerName.Content = parent.player.Name;
            labelRound.Content = "Round " + (numberOfWonGames + 1);

            Game new_cards = new Game();
            new_cards.GenerateCards(parent.numberOfPairs);
            Board.ItemsSource = new_cards.cards;
            remainingTime = timeMultiplier * parent.numberOfPairs;
            RemainingTime.Content = remainingTime.ToString();
            StartTimer();

        }

        private void cardButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Card card = button.DataContext as Card;
            button.Content = new Image() { Source = new BitmapImage(new Uri(card.image)) };
            if(numberOfClickedCards==0)
            {
                firstButton.IsEnabled = true;
                secondButton.IsEnabled = true;
                firstButton.Content = new Image() { Source = new BitmapImage(new Uri(backImage)) };
                secondButton.Content = new Image() { Source = new BitmapImage(new Uri(backImage)) };

                firstButton = sender as Button;
                firstButton.IsEnabled = false;
                numberOfClickedCards++;
            }
            else
            {
                secondButton = sender as Button;
                secondButton.IsEnabled = false;
                numberOfClickedCards = 0;
                Card card1 = firstButton.DataContext as Card;
                Card card2 = secondButton.DataContext as Card;
                if(card1.image==card2.image)
                {
                    numberOfFoundPairs++;
                    firstButton = new Button();
                    secondButton = new Button();
                    if (numberOfFoundPairs == parent.numberOfPairs)
                    {
                        if (numberOfWonGames < 2)
                        {
                            Game new_cards = new Game();
                            new_cards.GenerateCards(parent.numberOfPairs);
                            Board.ItemsSource = new_cards.cards;
                            numberOfFoundPairs = 0;
                            timer.Stop();
                            MessageBox.Show("Round won \nTake a break.");
                            timeMultiplier-=2;
                            remainingTime = timeMultiplier * parent.numberOfPairs;
                            RemainingTime.Content = remainingTime.ToString();
                            StartTimer();
                        }
                        else
                        {
                            timer.Stop();
                            parent.player.NumberOfWonGames++;
                            MessageBox.Show("Game won!!!");
                            this.Close();
                        }
                        numberOfWonGames++;
                        labelRound.Content = "Round " + (numberOfWonGames + 1);
                    }

                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            RemainingTime.Content = remainingTime.ToString();
            if (remainingTime == 0)
            {
                timer.Stop();
                MessageBox.Show("Game lost :(");
                this.Close();
            }
        }
        private void StartTimer()
        {
            if (timer != null)
            {
                timer.Stop();
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

       
        private void UpdateStats()
        {
            List<User> users = new List<User>();
            string xmlPath = "../../UserData/Users.xml";
            users = (List<User>)Serialization.Deserialize<List<User>>(xmlPath); ;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name == parent.player.Name)
                {
                    users[i].NumberOfGames = parent.player.NumberOfGames;
                    users[i].NumberOfWonGames = parent.player.NumberOfWonGames;
                }
            }

            Serialization.Serialize(users, xmlPath);

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            parent.player.NumberOfGames++;
            parent.playerGamesPlayed.Content = parent.player.NumberOfGames;
            parent.playerGamesWon.Content = parent.player.NumberOfWonGames;
            UpdateStats();
            this.parent.Show();
        }
    }
}
