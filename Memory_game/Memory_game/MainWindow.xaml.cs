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
using Memory_game.UserData;

namespace Memory_game
{
    public partial class MainWindow : Window
    {
        public User m_player;
        public MainWindow()
        {
            InitializeComponent();
            btn_delete_user.IsEnabled = false;
            btn_play.IsEnabled = false;
            List<User> users = new List<User>();
            string xmlPath = "../../UserData/Users.xml";
            users = (List<User>)Serialization.Deserialize<List<User>>(xmlPath);
            create_users_list(users);
            
        }
        public void create_users_list(List<User> user)
        {
            listBox_users.ItemsSource = user;
        }

        private void btn_new_user_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow w = new NewUserWindow(this);
            var result = w.ShowDialog();
        }

        private void btn_delete_user_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = listBox_users.SelectedItem as User;
            List<User> users = new List<User>();
            string xmlPath = "../../UserData/Users.xml";
            users = (List<User>)Serialization.Deserialize<List<User>>(xmlPath); ;

            for(int i=0;i<users.Count;i++)
            {
                if(users[i].Name==selectedItem.Name)
                {
                    users.RemoveAt(i);
                }
            }

            Serialization.Serialize(users, xmlPath);

            MessageBox.Show("User successfully deleted");

            create_users_list(users);
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            m_player = listBox_users.SelectedItem as User;
            MenuWindow w = new MenuWindow(this);
            w.Show();
            this.Hide();
        }

        private void listBox_users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = listBox_users.SelectedItem as User;

            if (selectedItem != null)
            {

                var imagePath = selectedItem.Image;
                var imageSource = new BitmapImage(new Uri(imagePath));
                image_profile_picture.Source = imageSource;

                btn_play.IsEnabled = true;
                btn_delete_user.IsEnabled = true;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to close the window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; 
            }
        }
    }
}
