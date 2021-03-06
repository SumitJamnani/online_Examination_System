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


public partial class frm_reg_import : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    Int32 sub;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnimport_Click(object sender, EventArgs e)
    {
        if (fileuploadreg.FileName.EndsWith(".xls"))
        {
            int r = 0, k = 0, j = 0;
            string citynm;
            int cityid, city = 0, sem = 0, seq = 0, rollno, semid, seqid, unit;
            DateTime dob;
            String email, fnm, mnm, lnm, gender, add1, add2, div, pwd, type, seqans, que, subcode, o1, o2, o3, o4, ca;
            String path = Path.GetFileName(fileuploadreg.FileName);
            path = path.Replace(" ", "");
            String query = "";
            fileuploadreg.SaveAs(Server.MapPath("~/excel_file/") + path);
            String ExcelPath = Server.MapPath("~/excel_file/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            //for regiatration data
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataAdapter Adapter = new OleDbDataAdapter();
            Adapter.SelectCommand = cmd;
            DataSet dsExcel = new DataSet();
            Adapter.Fill(dsExcel);
            //for login data
            //OleDbCommand cmd1 = new OleDbCommand("select * from [Sheet2$]", mycon);
            //OleDbDataAdapter Adapter1 = new OleDbDataAdapter();
            //Adapter1.SelectCommand = cmd1;
            //DataSet dsExcel1 = new DataSet();
            //Adapter1.Fill(dsExcel1);
            ////for question data
            //OleDbCommand cmd2 = new OleDbCommand("select * from [Sheet3$]", mycon);
            //OleDbDataAdapter Adapter2 = new OleDbDataAdapter();
            //Adapter1.SelectCommand = cmd2;
            //DataSet dsExcel3 = new DataSet();
            //Adapter1.Fill(dsExcel3);
            try
            {
                //registration   
                if (dsExcel.Tables.Count > 0)
                {

                    while (r < dsExcel.Tables[0].Rows.Count)
                    {
                        citynm = dsExcel.Tables[0].Rows[r][8].ToString();
                        semid = Convert.ToInt16(dsExcel.Tables[0].Rows[r][9].ToString());
                        seqid = Convert.ToInt16(dsExcel.Tables[0].Rows[r][14].ToString());
                        DataSet ds = new DataSet();
                        String q = "select city_id from city_m where city_name='" + citynm + "'";
                        ds = cn.select(q);
                        // String q1 = "select sem_id from sem_m where sem_id=" + semid;


                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            city = Convert.ToInt32(ds.Tables[0].Rows[0]["City_Id"]);
                        }

                        //    ds1 = cn.select(q1);
                        //if (ds1.Tables[0].Rows.Count > 0)
                        //{
                        //    sem = Convert.ToInt32(ds1.Tables[0].Rows[0]["Sem_Id"]);
                        //}


                        if (citynm != null || semid != 0)
                        {


                            email = dsExcel.Tables[0].Rows[r][0].ToString();
                            fnm = dsExcel.Tables[0].Rows[r][1].ToString();
                            mnm = dsExcel.Tables[0].Rows[r][2].ToString();
                            lnm = dsExcel.Tables[0].Rows[r][3].ToString();
                            gender = dsExcel.Tables[0].Rows[r][4].ToString();
                            dob = Convert.ToDateTime(dsExcel.Tables[0].Rows[r][5].ToString());
                            add1 = dsExcel.Tables[0].Rows[r][6].ToString();
                            add2 = dsExcel.Tables[0].Rows[r][7].ToString();
                            div = dsExcel.Tables[0].Rows[r][10].ToString();
                            rollno = Convert.ToInt16(dsExcel.Tables[0].Rows[r][11].ToString());
                            pwd = dsExcel.Tables[0].Rows[k][12].ToString();
                            type = dsExcel.Tables[0].Rows[k][13].ToString();
                            seqans = dsExcel.Tables[0].Rows[k][15].ToString();

                            //insert in registration
                            query = "if not exists (select * from registration_m where email ='" + email + "' )insert into registration_m(email,f_name,m_name,l_name,gender,dob,add_1,add_2,city_id,semester,division,roll_no) values('" + email + "','" + fnm + "','" + mnm + "','" + lnm + "','" + gender + "','" + dob + "','" + add1 + "','" + add2 + "'," + city + "," + semid + ",'" + div + "'," + rollno + ")";
                            cn.modify(query);
                            //insert in login
                            query = "if not exists (select * from login_m where email ='" + email + "' )insert into Login_M(Email,Password,Type_FSD,Sec_Id,Sec_Ans)  values('" + email + "','" + pwd + "','" + type + "'," + seqid + ",'" + seqans + "')";
                            cn.modify(query);

                        }
                        r++;

                    }
                    Response.Write("<script>alert('Data Has Been Imported Successfully')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Total " + r + " Question Imported')</script>");
            }
            //    //login
            //  try
            //  {
            //    if (dsExcel1.Tables.Count > 0)
            //    {

            //        while (k < dsExcel1.Tables[0].Rows.Count)
            //        {

            //            seqid = Convert.ToInt16(dsExcel1.Tables[0].Rows[k][3].ToString());
            //            String q = "select sec_id from sec_m where sec_id=" + seqid;
            //            DataSet ds = new DataSet();

            //            ds = cn.select(q);
            //            if (ds.Tables[0].Rows.Count > 0)
            //            {
            //                seq = Convert.ToInt32(ds.Tables[0].Rows[0]["Sec_Id"]);
            //            }


            //            if (seqid != 0)
            //            {


            //                email = dsExcel1.Tables[0].Rows[k][0].ToString();
            //                pwd = dsExcel1.Tables[0].Rows[k][1].ToString();
            //                type = dsExcel1.Tables[0].Rows[k][2].ToString();
            //                seqans = dsExcel1.Tables[0].Rows[k][4].ToString();

            //                if (type == "")
            //                {
            //                    type = "S";
            //                }
            //                query = "if not exists (select * from login_m where email ='" + email + "' )insert into registration_m(email,password,types_fsd,sec_id,sec_ans) values('" + email + "','" + pwd + "','" + type + "'," + seq  + ",'" + seqans  + "')";
            //                cn.modify(query);

            //            }
            //            k++;

            //        }//while over

            //    }//if over

            //   lblmsg.Text = "Data Has Been Saved Successfully";//  ::: Total " + r + " Question Imported";
            //}

            //catch (Exception ex)
            //{
            //    lblmsg.Text = ex.ToString() + " Total " + k + " Records Imported";
            //}
            //question
            //try
            //{

            //    if (dsExcel3.Tables.Count > 0)
            //    {

            //        while (j < dsExcel3.Tables[0].Rows.Count)
            //        {
            //            subcode = dsExcel3.Tables[0].Rows[j][1].ToString();
            //            DataSet ds, ds1 = new DataSet();
            //            String q = "select sub_id from sub_m where sub_code='" + subcode + "'";
            //            ds = cn.select(q);
            //            if (ds.Tables[0].Rows.Count > 0)
            //            {
            //                sub = Convert.ToInt32(ds.Tables[0].Rows[0]["Sub_Id"]);
            //            }


            //            if (subcode != "")
            //            {


            //                unit = Convert.ToInt16(dsExcel3.Tables[0].Rows[j][2].ToString());
            //                que = dsExcel3.Tables[0].Rows[j][3].ToString();
            //                o1 = dsExcel3.Tables[0].Rows[j][4].ToString();
            //                o2 = dsExcel3.Tables[0].Rows[j][5].ToString();
            //                o3 = dsExcel3.Tables[0].Rows[j][6].ToString();
            //                o4 = dsExcel3.Tables[0].Rows[j][7].ToString();
            //                ca = dsExcel3.Tables[0].Rows[j][8].ToString();
            //                if (o1 == "" && o2 == "" && o3 == "" && o4 == "" && ca == "TRUE" || ca == "FALSE")
            //                {
            //                    o1 = "TRUE";
            //                    o2 = "FALSE";
            //                }
            //                query = "if not exists (select *from que_m where que_text ='" + que + "' )insert into que_m(sub_id,unit_id,que_text,o1,o2,o3,o4,correct_ans) values(" + sub + "," + unit + ",'" + que + "','" + o1 + "','" + o2 + "','" + o3 + "','" + o4 + "','" + ca + "')";
            //                cn.modify(query);

            //            }
            //            r++;

            //        }

            //    }
            //    lblmsg.Text = "Data Has Been Saved Successfully";//  ::: Total " + r + " Question Imported";
            //}
            //catch (Exception ex)
            //{
            //    lblmsg.Text = ex.ToString() + " Total " + r + " Question Imported";
            //}
        }
        else
        {
            Response.Write("<script>alert('This File Is Not .xsl File!!!')</script>");
        }

    }

}