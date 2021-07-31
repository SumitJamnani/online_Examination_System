using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;


public partial class reg_excel_import : System.Web.UI.Page
{
     db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         if (fileuploadreg.FileName.EndsWith(".xls"))
        {int r = 0;
        int cityid, city = 0, sem = 0, rollno, semid,seqid;
             DateTime dob;
            String email,fnm,mnm,lnm,gender,add1,add2,div;
            String path = Path.GetFileName(fileuploadreg.FileName);
            path = path.Replace(" ", "");
            String query = "";
            fileuploadreg.SaveAs(Server.MapPath("~/excel_file/") + path);
            String ExcelPath = Server.MapPath("~/excel_file/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataAdapter Adapter = new OleDbDataAdapter();
            Adapter.SelectCommand = cmd;
            DataSet dsExcel = new DataSet();
            Adapter.Fill(dsExcel);
            try
            {
                
                if (dsExcel.Tables.Count > 0)
                {
                    
                    while (r < dsExcel.Tables[0].Rows.Count)
                    {
                        cityid = Convert.ToInt16 (dsExcel.Tables[0].Rows[r][8].ToString());
                        semid = Convert.ToInt16 (dsExcel.Tables[0].Rows[r][9].ToString());
                     
                        DataSet ds,ds1,ds2 = new DataSet();
                        String q = "select city_id from city_m where city_id=" + cityid;
                        String q1 = "select sem_id from sem_m where sem_id=" + semid;
                        ds = cn.select(q);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            city = Convert.ToInt32(ds.Tables[0].Rows[0]["City_Id"]);
                        }
                         ds1 = cn.select(q1);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            sem = Convert.ToInt32(ds1.Tables[0].Rows[0]["Sem_Id"]);
                        }
                        

                        if (cityid != 0 || semid != 0)
                        {
                           

                            email = dsExcel.Tables[0].Rows[r][0].ToString();
                            fnm = dsExcel.Tables[0].Rows[r][1].ToString();
                            mnm = dsExcel.Tables[0].Rows[r][2].ToString();
                            lnm = dsExcel.Tables[0].Rows[r][3].ToString();
                            gender = dsExcel.Tables[0].Rows[r][4].ToString();
                            dob = Convert.ToDateTime (dsExcel.Tables[0].Rows[r][5].ToString());
                            add1=dsExcel.Tables[0].Rows[r][6].ToString();
                            add2=dsExcel.Tables[0].Rows[r][7].ToString();
                            div = dsExcel.Tables[0].Rows[r][10].ToString();
                            rollno=Convert.ToInt16(dsExcel.Tables[0].Rows[r][11].ToString());
                            //if (o1 == "" && o2 == "" && o3 == "" && o4 == "" && ca == "TRUE" || ca == "FALSE")
                            //{
                            //    o1 = "TRUE";
                            //    o2 = "FALSE";
                            //}
                            query = "if not exists (select * from registration_m where email ='" + email + "' )insert into registration_m(email,f_name,m_name,l_name,gender,dob,add_1,add_2,city_id,semester,division,roll_no) values('" + email + "','" + fnm + "','" + mnm + "','" + lnm + "','" + gender + "','" + dob + "','" + add1 + "','" + add2 + "',"+city+","+sem+",'"+div+"',"+rollno+")";
                            cn.modify(query);
                         
                        }
                        r++;
                       
                    }
                  
                }
                lblmsg.Text = "Data Has Been Saved Successfully";//  ::: Total " + r + " Question Imported";
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.ToString() + " Total " + r + " Records Imported";
            }
        }
        else
        {
            lblmsg.Text = "This File Is Not .xsl File!!!";
        }
    }
}
