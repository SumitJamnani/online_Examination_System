using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for db_conn
/// </summary>
public class db_conn
{
//    SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\ljadmin\\Documents\\Visual Studio 2010\\Projects\\OES_Project\\App_Data\\database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
   
   SqlConnection cn = new SqlConnection("server=.;Database=Online;user id=sa;password=ljbca1234");

   // SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\BCA\\Project\\OES_Project\\App_Data\\Online.mdf;Integrated Security=True;User Instance=True");

    SqlCommand cmd = new SqlCommand();
    public void modify(string q)
    {
        try
        {

        cmd.CommandText = q;
        cmd.Connection = cn;
        cn.Open();        
        cmd.ExecuteNonQuery();
        cn.Close();
        }
        catch 
        {
            cn.Close();
            
        }
    }

    public DataSet select(string q)
    {
        try
        {
            DataSet ds = new DataSet();

            cmd.CommandText = q;
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          
            cn.Open();
            
            cmd.ExecuteNonQuery();
            da.Fill(ds);
            cn.Close();
            return ds;
        }
        catch (Exception ex)
        {
            cn.Close();
            return null;
        }
    }
    public int getid(string q)
    {
        cmd.CommandText = q;
        cmd.Connection = cn;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cn.Open();
        int id = (int)cmd.ExecuteNonQuery();
        cn.Close();
        return id;
    }
}