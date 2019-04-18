using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteForData
{
   public static class SqlHelp
    {
        

        //增删改
        public static int Conn(string strCon,string CmdText) {
            int resualt = 0; ;
            try
            {
                MySqlConnection conn = new MySqlConnection(strCon);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string strsql = CmdText;
                if (strsql.Trim().Length > 1)
                {
                    cmd.CommandText = strsql;
                    resualt  = cmd.ExecuteNonQuery();
                }
               
                return resualt;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        //事务操作
        public static int ExecuteNonQuery(string ConnString,string CmdText,out string ExceptionMsg) {
           int resualt = 0;
           string outerror = "";
           try
           {
               using (MySqlConnection conn = new MySqlConnection(ConnString)) { //需要添加Mysql.data.dll
                   conn.Open();
                   MySqlCommand cmd = new MySqlCommand();
                   cmd.Connection = conn;
                   string strsql = CmdText;
                   if (strsql.Trim().Length>1)
                   {
                       cmd.CommandText = strsql;
                       resualt = cmd.ExecuteNonQuery();
                   }
               }
           }
           catch (System.Exception ex)
           {

               outerror = ex.ToString();
           }
           ExceptionMsg = outerror;
           return resualt;
       }
   



        //查询
        public static System.Data.DataTable ExcuteReader(string ConnString, string CmdText, out string ExceptionMsg)
        {
            string outerror = string.Empty;
            DataTable resualt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = CmdText;
                        cmd.CommandTimeout = 300;
                        DataSet dataset = new DataSet();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dataset);
                        resualt = dataset.Tables[0];
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                outerror = ex.ToString().Trim();
            }
            ExceptionMsg = outerror;
            return resualt;
        }

    }
}
