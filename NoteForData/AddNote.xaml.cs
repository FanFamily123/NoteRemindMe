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

namespace NoteForData
{
    /// <summary>
    /// AddNote.xaml 的交互逻辑
    /// </summary>
    public partial class AddNote : Window
    {
        Note note = new Note();
        SQLSearch sqlsearch = new SQLSearch();
        public AddNote(string user)
        {
            InitializeComponent();
            note.userName = user;
        }
        //通过委托 插入成功则调用主界面刷新函数

        public delegate void ReafeshM();
        public event ReafeshM rea;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_Note.Text != null)
                {

                    note.thingName = txt_Note.Text.Trim();
                    note.dtime = System.DateTime.Now;
                    bool re = sqlsearch.InsertNote(note);
                    if (re)
                    {
                        MessageBox.Show("插入成功");
                        rea();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("插入失败");
                    }

                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
    }
}
