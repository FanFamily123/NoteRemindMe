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

namespace NoteForData
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        String str = "Database=datagriptest;Data Source=106.12.10.56;User Id=root;Password=qwer1234.;port=3306;CharSet=utf8;";
        SQLSearch database = new SQLSearch();
        public MainWindow()
        {
            InitializeComponent();
            ImageBrush b = new ImageBrush();
            b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/source/timg.jpg"));
            b.Stretch = Stretch.Fill;
            this.Background = b;

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string uName = this.userN.Text.Trim();
            string uPwd = this.userPwd.Text.Trim();
            System.Data.DataTable dt = database.loginTrue(uName);
            string pw = dt.Rows[0]["pwd"].ToString();

            if (pw.Equals(uPwd))
            {
                MainW mw = new MainW(uName);
                mw.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误");
            }

        }


        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

