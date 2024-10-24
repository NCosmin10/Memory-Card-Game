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
using Memory_game.UserData;
using System.Diagnostics;

namespace Memory_game
{

    public partial class NewUserWindow : Window
    {
        public MainWindow parent_page;
        List<string> images;
        int imgIndex = 0;
        const int NUMBER_OF_IMAGES = 4;
        /*public NewUserWindow()
        {
            InitializeComponent();
        }*/
        public NewUserWindow(MainWindow parent_page)
        {
            InitializeComponent();
            this.parent_page = parent_page;
            images = new List<string>();
            //string imgPath = "..\\..\\UserData\\Images\\image";
            string imgPath = "D:/An_2_sem2/MVP/Memory_game/Memory_game/UserData/Images/image";
            for (int i = 0; i < NUMBER_OF_IMAGES; i++)
            {
                images.Add(imgPath + i + ".png");
            }

            BitmapImage imageBitmap = new BitmapImage(new Uri(images[0], UriKind.RelativeOrAbsolute));
            image_new_user.Source = imageBitmap;
        }

        private void btn_img_right_Click(object sender, RoutedEventArgs e)
        {
            if(imgIndex < NUMBER_OF_IMAGES-1)
                imgIndex++;
            BitmapImage imageBitmap = new BitmapImage(new Uri(images[imgIndex], UriKind.RelativeOrAbsolute));
            image_new_user.Source = imageBitmap;
        }

        private void btn_img_left_Click(object sender, RoutedEventArgs e)
        {
            if(imgIndex > 0)
                imgIndex--;
            BitmapImage imageBitmap = new BitmapImage(new Uri(images[imgIndex], UriKind.RelativeOrAbsolute));
            image_new_user.Source = imageBitmap;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            User new_user = new User(txtBox_username.Text, images[imgIndex]);
            List<User> users = new List<User>();
            string xmlPath = "../../UserData/Users.xml";
            users = (List<User>)Serialization.Deserialize<List<User>>(xmlPath);
            users.Add(new_user);
            txtBox_username.Text = "";
            Serialization.Serialize(users, xmlPath);
            parent_page.create_users_list(users);
            MessageBox.Show("User successfully created");

        }
    }
}
