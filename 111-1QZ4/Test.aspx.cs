using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace _111_1QZ4
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_Str = "";
            s_Str = "Data Source = (localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog = Test;" +
                    "Integrated Security = True;" +
                    "Connect Timeout = 30;"+
                    "Encrypt = False;"+ 
                    "TrustServerCertificate = False;"+
                    "ApplicationIntent = ReadWrite;"+
                    "MultiSubnetFailover = False;" +
                    "User ID = sa; Password = 12345";
            try
            {
                //SqlConnection SQL連線物件名稱 = new SqlConnection(連線字串或連線字串變數);
                SqlConnection o_Str = new SqlConnection(s_Str);
                o_Str.Open();//開起資料庫
                //SQL指令到連結物件o_Str裡也就是(s_Str)再給o_Cmd
                string s_sql = "select * from Users";
                SqlCommand o_Cmd = new SqlCommand(s_sql, o_Str);
                SqlDataReader o_DR = o_Cmd.ExecuteReader();//抓取資料集
                //o_DR.Read() 讀取資料，只要可以讀取就繼續執行
                for (; o_DR.Read();)
                {
                    //o_DR.FieldCount 用來取得資料列中資料行的數目
                    for (int i_ColInd = 0; i_ColInd < o_DR.FieldCount; i_ColInd++)
                    {
                        Response.Write(o_DR.GetValue(i_ColInd).ToString() + "&nbsp;&nbsp;");
                    }
                    Response.Write("<br />");
                }
                o_Str.Close();//關閉資料庫
            }
            catch (Exception o_Exc)
            {
                Response.Write(o_Exc.ToString());
            }
        }
    }
}