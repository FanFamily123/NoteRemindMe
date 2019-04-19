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
            System.Data.DataTable dtable = sh.srarchNoteList(user);
            dg1.ItemsSource = dtable.AsDataView();
            dg1.SelectedValuePath = "id";
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote(user);
            addNote.Show();
            addNote.rea += Refesh;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           
            
     
       
          
        }

    

        private void dg1_Loaded_1(object sender, RoutedEventArgs e)
        {
            System.Data.DataTable dtable = sh.srarchNoteList(user);
            dg1.ItemsSource = dtable.AsDataView();
            dg1.SelectedValuePath = "id";
        }

        //第一个按钮点击事件  
        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {
            //修改这个记录的flag
          
            string a = dg1.SelectedValue.ToString();  //获取id值
            int thingid = Convert.ToInt32(a);
            bool x = sh.UpdateDone(thingid);
            if (x == true)
            {
                MessageBox.Show("完成目标+1");
            }
            Refesh();

        }
        //第二个按钮点击事件 
        private void BtnAction1_Click(object sender, RoutedEventArgs e)
        {
            string a = dg1.SelectedValue.ToString();  //获取id值
            int thingid = Convert.ToInt32(a);
           bool x =sh.UpdateDone(thingid);
            if (x==true)
            {
                MessageBox.Show("删除完成");
            }
            Refesh();
        }

        private void Refesh() {
            System.Data.DataTable dtable = sh.srarchNoteList(user);
            dg1.ItemsSource = dtable.AsDataView();
            dg1.SelectedValuePath = "id";

        }
      
    }
}
