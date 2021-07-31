﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

public partial class frm_excel_reg : System.Web.UI.Page
{

    db_conn cn = new db_conn();

    Int32 cid, semid;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {

        if (fileuploadexcel.FileName.EndsWith(".xls"))
        {
            int r = 0;
            int roll, sid;
            // char div;
            String em, fnm, mnm, lnm, dob, gen, cnm, div, sem, a1, a2, pw, tp, sans;
            String path = Path.GetFileName(fileuploadexcel.FileName);
            path = path.Replace(" ", "");
            String query = "", lg = "";
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
                        cnm = dsExcel.Tables[0].Rows[r][8].ToString();
                        //  sem = dsExcel.Tables[0].Rows[r][9].ToString();
                        DataSet ds = new DataSet();
                        //city
                        String q = "select city_id from city_m where city_name='" + cnm + "'";
                        ds = cn.select(q);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cid = Convert.ToInt32(ds.Tables[0].Rows[0]["City_Id"]);
                        }
                        //semester

                        //String q1 = "select sem_id from sem_m where sem_id=" + sem ;
                        //ds1 = cn.select(q1);
                        //if (ds1.Tables[0].Rows.Count > 0)
                        //{
                        //    semid = Convert.ToInt32(ds1.Tables[0].Rows[0]["Sem_Id"]);
                        //}


                     //     if (cnm != "")
                        //   {


                        em = dsExcel.Tables[0].Rows[r][0].ToString();
                        fnm = dsExcel.Tables[0].Rows[r][1].ToString();
                        mnm = dsExcel.Tables[0].Rows[r][2].ToString();
                        lnm = dsExcel.Tables[0].Rows[r][3].ToString();
                        gen = dsExcel.Tables[0].Rows[r][4].ToString();
                        dob = dsExcel.Tables[0].Rows[r][5].ToString();
                        a1 = dsExcel.Tables[0].Rows[r][6].ToString();
                        a2 = dsExcel.Tables[0].Rows[r][7].ToString();
                        sem = dsExcel.Tables[0].Rows[r][9].ToString();
                        div = dsExcel.Tables[0].Rows[r][10].ToString();
                        roll = Convert.ToInt32(dsExcel.Tables[0].Rows[r][11].ToString());
                        pw = dsExcel.Tables[0].Rows[r][12].ToString();
                        tp = dsExcel.Tables[0].Rows[r][13].ToString();
                        sid = Convert.ToInt32(dsExcel.Tables[0].Rows[r][14].ToString());
                        sans = dsExcel.Tables[0].Rows[r][15].ToString();
                        //if (o1 != "" && o2 != "" && (o3 == "" && o4 == "") || (o3.Replace("-", "").Trim() == "" && o4.Replace("-", "").Trim() == ""))
                        //{
                        //    if (ca == "a" || ca == "b")
                        //    {
                        //        o1 = "TRUE";
                        //        o2 = "FALSE";
                        //        o3 = o3.Replace("-", "").Trim();
                        //        o4 = o4.Replace("-", "").Trim();

                        //    }
                        //}
                        // query = "if not exists (select * from registration_m where city_id = " + cid + ")insert into registration_m(email,f_name,m_name,l_name,gender,dob,add_1,add_2,city_id,semester,division,roll_no) values('" + em + "','" + fnm + "','" + mnm + "','" + lnm + "','" + gen + "','" + dob + "','" + a1 + "','" + a2 + "'," + cid + ",'" + sem + "','" + div + "'," + roll + ")";
                        query = "insert into registration_m(email,f_name,m_name,l_name,gender,dob,add_1,add_2,city_id,semester,division,roll_no) values('" + em + "','" + fnm + "','" + mnm + "','" + lnm + "','" + gen + "','" + dob + "','" + a1 + "','" + a2 + "'," + cid + ",'" + sem + "','" + div + "'," + roll + ")";
                        cn.modify(query);
                        lg = "insert into login_m(email,password,type_fsd,sec_id,sec_ans) values('" + em + "','" + pw + "','" + tp + "'," + sid + ",'" + sans + "')";
                        cn.modify(lg);

                        //   }
                        r++;

                    }

                }
                //lblmsg.Text = "Data Has Been Saved Successfully";//  ::: Total " + r + " Question Imported";
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Total " + r + " Question Imported')</script>");  
            }
        }
        else
        {
          //  lblmsg.Text = "This File Is Not .xsl File!!!";
        }
    }
}