using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteForData
{
   public class SQLSearch
    {
        String strconn ="Database=datagriptest;Data Source=106.12.10.56;User Id=root;Password=qwer1234.;port=3306;CharSet=utf8;";

        //登陆
        public System.Data.DataTable loginTrue(string username) {
            string expMsg;
            string strsql = "select pwd from userinfo where name='"+username+"'";
            System.Data.DataTable dt = SqlHelp.ExcuteReader(strconn,strsql,out expMsg);
            if (dt != null &&expMsg.Trim().Equals(""))
            {
                return dt;
            }
            return null;
        }

       //插入
        public bool InsertNote(Note note) {
            string exMsg;
            string strsql = "insert into notedetail(thingname,time,usern) values (' "+ note.thingName+"','"+note.dtime+"','"+note.userName+"')";
           int resualt=SqlHelp.ExecuteNonQuery(strconn,strsql,out exMsg);
           if (resualt==1)
           {
               return true;
           }
           else
           {
               return false;
           }
        }


        //通过账户来查找所有文件
        public System.Data.DataTable srarchNoteList(string username) {
            string expMsg;
            string strsql = "select * from notedetail where usern =' "+username+"'";
            System.Data.DataTable dt = SqlHelp.ExcuteReader(strconn, strsql, out expMsg);
            if (dt != null && expMsg.Trim().Equals(""))
            {
                return dt;
            }
            return null;
        
        }


    }
}
