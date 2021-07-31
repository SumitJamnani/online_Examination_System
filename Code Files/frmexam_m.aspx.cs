using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmexam_m : System.Web.UI.Page
{

    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtsdatecalext.StartDate = DateTime.Now;
        // txtedatecalext.StartDate = txtsdatecalext.SelectedDate;



        if (!IsPostBack)
        {

            bindgrid();
            binddrp();
            bindcheck();
            disabled_up_del();

        }

    }

    public void bindcheck()
    {
        //chkunit.Items.Add("Unit 1");
        //chkunit.Items.Add("Unit 2");
        //chkunit.Items.Add("Unit 3");
        //chkunit.Items.Add("Unit 4");

    }

    public void binddrp()
    {


        gf.fillcombo("select * from sub_m", drpsubject, "sub_name", "sub_id", "");

    }

    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select * from exam_m e,sub_m s where e.sub_id=s.sub_id order by exam_id desc");
        gf.fill_grid(ds, grdexam);


    }

    public void clearall(Control Parent)
    {
        foreach (Control x in Parent.Controls)
        {
            if ((x).GetType() == typeof(TextBox))
            {
                ((TextBox)(x)).Text = "";
            }

            if ((x).GetType() == typeof(DropDownList))
            {
                ((DropDownList)(x)).SelectedIndex = 0;
            }

            if (x.HasControls())
            {
                clearall(x);
            }

        }
        
    }

    public void disabled_up_del()
    {
        btnupdate.Visible = false;
        btndelete.Visible = false;
        //btnupdate.Enabled = false;
        //btndelete.Enabled = false;
    }
    public void enabled_up_del()
    {
        btnupdate.Visible = true;
        btndelete.Visible = true;
        //btnupdate.Enabled = true;
        //btndelete.Enabled = true;
    }


    protected void grdexam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Exam_Id")
            {
                hdnexam.Value = e.CommandArgument.ToString();
                string str3 = "select * from exam_m WHERE exam_id ='" + hdnexam.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtename.Text = ds.Tables[0].Rows[0]["Exam_Name"].ToString();
                    drpsubject.SelectedValue = ds.Tables[0].Rows[0]["Sub_Id"].ToString();
                    txtsdate.Text = ds.Tables[0].Rows[0]["Exam_Start_Date"].ToString();
                    txtedate.Text = ds.Tables[0].Rows[0]["Exam_End_Date"].ToString();
                    txttotmarks.Text = ds.Tables[0].Rows[0]["Tot_Marks"].ToString();
                    txtpassingmarks.Text = ds.Tables[0].Rows[0]["Passing_Marks"].ToString();
                    txtduration.Text = ds.Tables[0].Rows[0]["Duration"].ToString();
                    txttotque.Text = ds.Tables[0].Rows[0]["Tot_Que"].ToString();

                }
                string strt = "select * from exam_unit_t WHERE exam_id ='" + hdnexam.Value + "' ";
                DataSet dst = new DataSet();
                dst = conn.select(strt);
                if (dst.Tables[0].Rows.Count > 0)
                {
                    int r = 0;
                    while (r < dst.Tables[0].Rows.Count)
                    {
                        if (dst.Tables[0].Rows[r]["unit_id"].ToString() == "1")
                            chkunit.Items[0].Selected = true;

                        else if (dst.Tables[0].Rows[r]["unit_id"].ToString() == "2")
                            chkunit.Items[1].Selected = true;
                        else if (dst.Tables[0].Rows[r]["unit_id"].ToString() == "3")
                            chkunit.Items[2].Selected = true;

                        else if (dst.Tables[0].Rows[r]["unit_id"].ToString() == "4")
                            chkunit.Items[3].Selected = true;

                        r++;
                    }
                }


                enabled_up_del();
                btnsubmit.Visible = false;

            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Went Wrong...!')</script>");
        }
    }


    protected void chk(object sender, System.EventArgs e)
    {

        txtsdate.Text = txtsdatecalext.SelectedDate.ToString();

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataSet ds3 = new DataSet();
        Int32 cnt = 0;
        for (int i = 0; i < chkunit.Items.Count; i++)
        {
            if (chkunit.Items[i].Selected)
            {
                //string qry1 = "insert into exam_unit_t (exam_id,unit_id) values(" + eid.ToString() + "," + chkunit.Items[i].Value + ")";
                string qry2 = "select * from que_m where sub_id=" + drpsubject.SelectedValue + " and unit_id = " + chkunit.Items[i].Value + "";
                ds3 = conn.select(qry2);
                cnt += ds3.Tables[0].Rows.Count;
            }
        }







        if (cnt >= Convert.ToInt32(txttotque.Text))
        {
            try
            {

                //string date = "select convert(varchar(20),'"+txtstartdate.Text+'",120)";
                DataSet ds = new DataSet();
                string qry = "insert into exam_m (exam_name, sub_id,exam_start_date,exam_end_date,tot_marks,passing_marks,duration,tot_que) values ('" + txtename.Text + "'," + drpsubject.SelectedValue + ",'" + txtsdate.Text + " 10:00:00','" + txtedate.Text + " 18:00:00'," + txttotmarks.Text + "," + txtpassingmarks.Text + "," + txtduration.Text + "," + txttotque.Text + ");select @@IDENTITY;";
                //  hdnexamid.Value = "select max(exam_id) from exam_m";
                // string qry = "insert into exam_m (exam_name, sub_id,exam_start_date,exam_end_date,tot_marks,passing_marks,duration,tot_que) values ('" + txtename.Text + "'," + drpsubject.SelectedValue + ",'" + txtsdate.Text + " 10:00:00','" + txtedate.Text + " 18:00:00'," + txttotmarks.Text + "," + txtpassingmarks.Text + "," + txtduration.Text + "," + txttotque.Text + ");select max(exam_id) from exam_m";
                ds = conn.select(qry);
                string eid = ds.Tables[0].Rows[0][0].ToString();


                for (int i = 0; i < chkunit.Items.Count; i++)
                {
                    if (chkunit.Items[i].Selected)
                    {
                        string qry1 = "insert into exam_unit_t (exam_id,unit_id) values(" + eid.ToString() + "," + chkunit.Items[i].Value + ")";
                        conn.modify(qry1);
                    }
                }

                bindgrid();
                clearall(this);
                disabled_up_del();

                // Student Exam Registration
                DataSet ds1 = new DataSet();
                //string qry2 = "select s.sem_id from sem_m s,sub_m s1 where s.sem_id = s1.sem_id and s1.sub_name  = '"+drpsubject.SelectedItem+"'";
                string qry2 = "select s.sem_id,e.exam_start_date from sem_m s,sub_m s1,exam_m e where e.sub_id = s1.sub_id and e.exam_id = " + eid + " and s.sem_id = s1.sem_id ";
                ds1 = conn.select(qry2);
                DateTime start_date = Convert.ToDateTime(ds1.Tables[0].Rows[0]["exam_start_date"]);
                Int32 sem = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
                if (sem == 1 || sem == 2)
                {
                    DataSet fyds = new DataSet();

                    string fy = "select reg_id from registration_m where email like '%fy%'";
                    fyds = conn.select(fy);



                    for (int i = 0; i <= fyds.Tables[0].Rows.Count - 1; i++)
                    {
                        string fyinsert = "insert into stud_exam_reg(stud_id,exam_id,reg_date,exam_date) values(" + fyds.Tables[0].Rows[i][0] + "," + eid + ",'" + Convert.ToDateTime(start_date.ToShortDateString()).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(start_date.ToShortDateString()).ToString("yyyy/MM/dd") + "')";
                        conn.modify(fyinsert);
                    }


                }

                else if (sem == 3 || sem == 4)
                {
                    DataSet syds = new DataSet();

                    string sy = "select reg_id from registration_m where email like '%sy%'";
                    syds = conn.select(sy);



                    for (int i = 0; i <= syds.Tables[0].Rows.Count - 1; i++)
                    {
                        string syinsert = "insert into stud_exam_reg(stud_id,exam_id,reg_date,exam_date) values(" + syds.Tables[0].Rows[i][0] + "," + eid + ",'" + Convert.ToDateTime(start_date.ToShortDateString()).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(start_date.ToShortDateString()).ToString("yyyy/MM/dd") + "')";
                        conn.modify(syinsert);
                    }
                }

                else if (sem == 5 || sem == 6)
                {
                    DataSet tyds = new DataSet();

                    string ty = "select reg_id from registration_m where email like '%ty%'";
                    tyds = conn.select(ty);



                    for (int i = 0; i <= tyds.Tables[0].Rows.Count - 1; i++)
                    {
                        string tyinsert = "insert into stud_exam_reg(stud_id,exam_id,reg_date,exam_date) values(" + tyds.Tables[0].Rows[i][0] + "," + eid + ",'" + Convert.ToDateTime(start_date.ToShortDateString()).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(start_date.ToShortDateString()).ToString("yyyy/MM/dd") + "')";
                        conn.modify(tyinsert);
                    }

                }

                Response.Write("<script>alert('Exam Declared Successfully')</script>");

            }




            catch (Exception ex)
            {
                Response.Write("<script>alert('Exam Not Declared & Something Went Wrong...!')</script>");
            }
            

        }
        else
            {
                Response.Write("<script>alert('no questions available')</script>");
            }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "update exam_m set exam_name = '" + txtename.Text + "',sub_id='" + drpsubject.SelectedValue + "',exam_start_date = '" + Convert.ToDateTime(txtsdate.Text).ToString("yyyy/MM/dd") + " 10:00:00',exam_end_date = '" + Convert.ToDateTime(txtedate.Text).ToString("yyyy/MM/dd") + " 18:00:00',tot_marks = " + txttotmarks.Text + ",passing_marks = " + txtpassingmarks.Text + ",duration=" + txtduration.Text + ",tot_que=" + txttotque.Text + " where exam_id = " + hdnexam.Value;

            conn.modify(qry);
            Response.Write("<script>alert('Exam Updated Successfully')</script>");
            bindgrid();
            
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Exam Not Updated & Something Went Wrong...!')</script>");
        }

    }




    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "delete from exam_m where exam_id = " + hdnexam.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Exam Deleted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Exam Not Deleted & Something Went Wrong...!')</script>");
        }
    }

    protected void grdexam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdexam.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void grdexam_Sorting(object sender, GridViewSortEventArgs e)
    {


    }






    protected void calsimgbtn_Click(object sender, ImageClickEventArgs e)
    {
        DateTime sd = Convert.ToDateTime(txtsdatecalext.SelectedDate);
        HiddenField1.Value = txtsdatecalext.SelectedDate.ToString();
        txtedatecalext.StartDate = Convert.ToDateTime(HiddenField1.Value);

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int i = 2;
        if (i < 2)
        {
            DateTime sd = Convert.ToDateTime(txtsdatecalext.SelectedDate);
            HiddenField1.Value = txtsdatecalext.SelectedDate.ToString();
            txtedatecalext.StartDate = Convert.ToDateTime(HiddenField1.Value);
        }
        else
        {
            Timer1.Enabled = false;
        }
    }
}