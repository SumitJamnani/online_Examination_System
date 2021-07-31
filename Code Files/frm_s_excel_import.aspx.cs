using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Data;

public partial class frm_s_excel_import : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    Int32 sub, unitid,gid,tid;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        if (fileuploadsubexcel.FileName.EndsWith(".xls"))
        {
            int r = 0;
            int unit;
            Int64 mk,min,max;
            String que, subcode, g, t;
            String path = Path.GetFileName(fileuploadsubexcel.FileName);
            path = path.Replace(" ", "");
            String query = "";
            fileuploadsubexcel.SaveAs(Server.MapPath("~/excel_file/") + path);
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
                        g = dsExcel.Tables[0].Rows[r][5].ToString();
                        t = dsExcel.Tables[0].Rows[r][6].ToString();
                        DataSet ds=new DataSet();
                        //for sub_id
                        String q = "select sub_id from sub_m where sub_code='" + subcode + "'";            
                        ds = cn.select(q);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            sub = Convert.ToInt32(ds.Tables[0].Rows[0]["Sub_Id"]);
                        }
                        //for group_id
                        String q1 = "select group_id from group_m where group_name='" + g+"'";
                        DataSet ds1 = new DataSet();
                        ds1 = cn.select(q1);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            gid= Convert.ToInt32(ds1.Tables[0].Rows[0]["group_id"]);
                        }
                        //for tag_id
                        String q2 = "select tag_id from tag_m where tag_name='" + t+"'";
                        DataSet ds2 = new DataSet();
                        ds2 = cn.select(q2);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            tid = Convert.ToInt32(ds2.Tables[0].Rows[0]["tag_id"]);
                        }

                        if (subcode != "")
                        {
                            unit = Convert.ToInt16(dsExcel.Tables[0].Rows[r][2].ToString());
                            que = dsExcel.Tables[0].Rows[r][3].ToString().Replace("'", "`");
                            mk = Convert.ToInt64(dsExcel.Tables[0].Rows[r][4]);
                            min = Convert.ToInt64(dsExcel.Tables[0].Rows[r][5]);
                            max = Convert.ToInt64(dsExcel.Tables[0].Rows[r][6]);
                            query = "if not exists (select *from s_que_m where sub_id = '" + sub + "' and que_text ='" + que + "' )insert into s_que_m(sub_id,unit_id,que_text,marks,group_id,tag_id,min_value,max_value) values(" + sub + "," + unit + ",'" + que + "'," + mk + "," + gid + "," + tid + "," +min + "," + max + ")";
                            cn.modify(query);
                        }
                        r++;

                    }

                }
                //lblmsg.Text = "Data Has Been Saved Successfully";
                Response.Write("<script>alert('Data Has Been Saved Successfully')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Total " + r + " Question Imported')</script>");
                
            }
        }
        else
        {
            //lblmsg.Text = "This File Is Not .xsl File!!!";
            Response.Write("<script>alert('This File Is Not .xsl File!!!')</script>");
        }
    }
}