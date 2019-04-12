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

    }
}
