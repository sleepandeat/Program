using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;

namespace Jackson
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string userName = "";
            string password = "";
            using (var uandp = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (uandp.FileExists("nameandpassword1.txt"))
                {
                    using (StreamReader srr = new StreamReader(uandp.OpenFile(
                        "nameandpassword1.txt", FileMode.Open, FileAccess.Read)))
                    {
                        userName = srr.ReadLine();
                        password = srr.ReadLine();
                        UserName1.Text = userName;
                        Password1.Password = password;
                    }
                }
                if (uandp.FileExists("nameandpassword2.txt"))
                {
                    using (StreamReader srr = new StreamReader(uandp.OpenFile(
                        "nameandpassword2.txt", FileMode.Open, FileAccess.Read)))
                    {
                        userName = srr.ReadLine();
                        password = srr.ReadLine();
                        UserName2.Text = userName;
                        Password2.Password = password;
                    }
                }
                if (uandp.FileExists("nameandpassword3.txt"))
                {
                    using (StreamReader srr = new StreamReader(uandp.OpenFile(
                        "nameandpassword3.txt", FileMode.Open, FileAccess.Read)))
                    {
                        userName = srr.ReadLine();
                        password = srr.ReadLine();
                        UserName3.Text = userName;
                        Password3.Password = password;
                    }
                }
            }
        }

        private void Review_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask mrt = new MarketplaceReviewTask();
            mrt.Show();
        }

        private void Login1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string userName = UserName1.Text;
            string password = Password1.Password;
            //获得独立存储空间
            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

            if (myStore.FileExists("nameandpassword1.txt"))
            {
                myStore.DeleteFile("nameandpassword1.txt");
            }
            using (var isoFileStream = new IsolatedStorageFileStream(
                    "nameandpassword1.txt", FileMode.OpenOrCreate, myStore))
            {
                using (var isoFileWriter = new StreamWriter(isoFileStream))
                {
                    //将fileString写入文件流
                    isoFileWriter.WriteLine(userName);
                    isoFileWriter.WriteLine(password);
                }
            }
            NavigationService.Navigate(new Uri("/SignPage.xaml?username=" + userName + "&password=" + password, UriKind.RelativeOrAbsolute));
        }

        private void Login2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string userName = UserName2.Text;
            string password = Password2.Password;
            //获得独立存储空间
            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

            if (myStore.FileExists("nameandpassword2.txt"))
            {
                myStore.DeleteFile("nameandpassword2.txt");
            }
            using (var isoFileStream = new IsolatedStorageFileStream(
                    "nameandpassword2.txt", FileMode.OpenOrCreate, myStore))
            {
                using (var isoFileWriter = new StreamWriter(isoFileStream))
                {
                    //将fileString写入文件流
                    isoFileWriter.WriteLine(userName);
                    isoFileWriter.WriteLine(password);
                }
            }
            NavigationService.Navigate(new Uri("/SignPage.xaml?username=" + userName + "&password=" + password, UriKind.RelativeOrAbsolute));
        }

        private void Login3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string userName = UserName3.Text;
            string password = Password3.Password;
            //获得独立存储空间
            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

            if (myStore.FileExists("nameandpassword3.txt"))
            {
                myStore.DeleteFile("nameandpassword3.txt");
            }
            using (var isoFileStream = new IsolatedStorageFileStream(
                    "nameandpassword3.txt", FileMode.OpenOrCreate, myStore))
            {
                using (var isoFileWriter = new StreamWriter(isoFileStream))
                {
                    //将fileString写入文件流
                    isoFileWriter.WriteLine(userName);
                    isoFileWriter.WriteLine(password);
                }
            }
            NavigationService.Navigate(new Uri("/SignPage.xaml?username=" + userName + "&password=" + password, UriKind.RelativeOrAbsolute));
        }

    }
}