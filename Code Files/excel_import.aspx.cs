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


public partial class excel_import : System.Web.UI.Page
{
    db_conn cn = new db_conn();
   
    Int32 sub,unitid;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {

        if (fileuploadexcel.FileName.EndsWith(".xls"))
        {int r = 0;
            int unit;
            String que, subcode, o1, o2, o3, o4, ca;
            String path = Path.GetFileName(fileuploadexcel.FileName);
            path = path.Replace(" ", "");
            String query = "";
            fileuploadexcel.SaveAs(Server.MapPath("~/excel_file/") + path);
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
                        subcode = dsExcel.Tables[0].Rows[r][1].ToString();
                        DataSet ds,ds1 = new DataSet();
                        String q = "select sub_id from sub_m where sub_code='" + subcode + "'";
                        ds = cn.select(q);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            sub = Convert.ToInt32(ds.Tables[0].Rows[0]["Sub_Id"]);
                        }
                        

                        if (subcode != "")
                        {
                           

                            unit = Convert.ToInt16(dsExcel.Tables[0].Rows[r][2].ToString());
                            que = dsExcel.Tables[0].Rows[r][3].ToString();
                            o1 = dsExcel.Tables[0].Rows[r][4].ToString();
                            o2 = dsExcel.Tables[0].Rows[r][5].ToString();
                            o3 = dsExcel.Tables[0].Rows[r][6].ToString();
                            o4 = dsExcel.Tables[0].Rows[r][7].ToString();
                            ca = dsExcel.Tables[0].Rows[r][8].ToString().ToLower();
                            if (o1 != "" && o2 != "" && (o3 == "" && o4 == "") || (o3.Replace("-", "").Trim() == "" && o4.Replace("-", "").Trim() == ""))
                            {
                                if (ca == "a" || ca == "b")
                                {
                                    o1 = "TRUE";
                                    o2 = "FALSE";
                                    o3 = o3.Replace("-", "").Trim();
                                    o4 = o4.Replace("-", "").Trim();

                                }
                            }
                            query = "if not exists (select *from que_m where sub_id = '" + sub + "' and que_text ='" + que + "' )insert into que_m(sub_id,unit_id,que_text,o1,o2,o3,o4,correct_ans) values(" + sub + "," + unit + ",'" + que + "','" + o1 + "','" + o2 + "','" + o3 + "','" + o4 + "','" + ca + "')";
                            cn.modify(query);
                         
                        }
                        r++;
                       
                    }
                  
                }
                lblmsg.Text = "Data Has Been Saved Successfully";//  ::: Total " + r + " Question Imported";
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.ToString() + " Total " + r + " Question Imported";
            }
        }
        else
        {
            lblmsg.Text = "This File Is Not .xsl File!!!";
        }
    }
 
    
}