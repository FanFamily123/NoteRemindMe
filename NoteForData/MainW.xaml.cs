using System;
using System.Collections.Generic;
using System.Data;
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

namespace NoteForData
{
    /// <summary>
    /// MainW.xaml 的交互逻辑
    /// </summary>
    public partial class MainW : Window
    {
        string user = string.Empty;
        SQLSearch sh = new SQLSearch();
        public MainW(string username)
        {
            InitializeComponent();
            user = username;
        }

        //刷新
        private void Referesh_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote(user);
            addNote.Show();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           
            
     
       
          
        }

    

        private void dg1_Loaded_1(object sender, RoutedEventArgs e)
        {

         //   dg1.ItemsSource = sh.srarchNoteList(user).DefaultView;
            System.Data.DataTable dtable = sh.srarchNoteList(user);
            dtable.Columns.Add(new DataColumn("id", typeof(int)));

        }




    }
}
