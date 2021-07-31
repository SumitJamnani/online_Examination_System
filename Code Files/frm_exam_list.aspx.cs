using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmexamlist : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //expire exam
    protected void btnexpire_Click(object sender, EventArgs e)
    {
        grd_current_exam.Visible = false;
        grdresult.Visible = false;
        Int16 i;
        DataSet ds = new DataSet();
        //ds = conn.select("SELECT e.Exam_Id, e.Exam_Name, e.Sub_Id, e.Exam_Start_Date, e.Exam_End_Date, e.Tot_Marks, e.Passing_Marks, s.Stud_Id, s.Exam_Id AS Expr1, s.Reg_Date, s.Exam_Date, s.Exam_Given_Date, s.Status_PF, s.Score,                          s.Percentage, s.Result_OD, s1.Sub_Id AS Expr2, s1.Sub_Name, s1.Sub_Code, s1.Sem_Id FROM            Exam_M AS e INNER JOIN  Stud_Exam_Reg AS s ON e.Exam_Id = s.Exam_Id INNER JOIN  Sub_M AS s1 ON e.Sub_Id = s1.Sub_Id WHERE (s.Exam_Given_Date IS NULL) AND (e.Exam_End_Date < { fn NOW() })");  
        ds = conn.select("SELECT DISTINCT(e.Exam_id), e.Exam_Name, s1.Sub_Name, e.Exam_Start_Date, e.Exam_End_Date,s.Reg_Date, e.Tot_Marks, e.Passing_Marks,e.duration,e.tot_que FROM Exam_M AS e INNER JOIN Stud_Exam_Reg AS s ON e.Exam_Id = s.Exam_Id INNER JOIN Sub_M AS s1 ON e.Sub_Id = s1.Sub_Id WHERE (e.Exam_End_Date < { fn NOW() }) AND (s.Exam_Given_Date IS NULL) and s.stud_id=" + Session["Regid"] + " AND DAY(Exam_Start_Date) >= DAY({ FN NOW()}) AND MONTH(EXAM_START_DATE)<= MONTH({FN NOW()})");
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i <= grd_expire_exam.Rows.Count; i++)
            {
                lblmsg.Text = i + " " + "Record Appear in expired exam";
                bindgrid1(ds);
                grd_expire_exam.Visible = true;
            }
        }
        else
        {
            lblmsg.Text = "No Record";
            grd_current_exam.Visible = false;
            grdresult.Visible = false;
        }
        
    }
    public void bindgrid1(DataSet ds)
    {
        gf.fill_grid(ds, grd_expire_exam);
    }
    public void bindgrid(DataSet ds)
    {
        gf.fill_grid(ds, grd_current_exam);
    }



    //current exam
    protected void btncurrent_Click(object sender, EventArgs e)
    {
        grd_current_exam.Visible = true;
        grd_expire_exam.Visible = false;
        grdresult.Visible = false;
        Int16 i;
        DataSet ds = new DataSet();
        //ds = conn.select("SELECT e.Exam_id, e.Exam_Name, s1.Sub_Name, e.Exam_Start_Date, e.Exam_End_Date, s.Reg_Date, e.Tot_Marks, e.Passing_Marks FROM Exam_M AS e INNER JOIN Stud_Exam_Reg AS s ON e.Exam_Id = s.Exam_Id INNER JOIN Sub_M AS s1 ON e.Sub_Id = s1.Sub_Id WHERE (e.Exam_End_Date > { fn NOW() }) AND (s.Exam_Given_Date IS NULL) and s.stud_id='"+Session["regid"]+"'");
        ds = conn.select("SELECT e.Exam_id, e.Exam_Name, s1.Sub_Name, e.Exam_Start_Date, e.Exam_End_Date,s.Reg_Date, e.Tot_Marks, e.Passing_Marks FROM Exam_M AS e INNER JOIN Stud_Exam_Reg AS s ON e.Exam_Id = s.Exam_Id INNER JOIN Sub_M AS s1 ON e.Sub_Id = s1.Sub_Id WHERE (e.Exam_End_Date > { fn NOW() }) AND (s.Exam_Given_Date IS NULL) and s.stud_id='" + Session["regid"] + "' AND DAY(Exam_Start_Date) >= DAY({ FN NOW()}) AND MONTH(EXAM_START_DATE)<= MONTH({FN NOW()})");
        bindgrid(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i <= grd_current_exam.Rows.Count; i++)
            {
                lblmsg.Text = i + " " + "Record Appear in Current exam";
                grd_current_exam.Visible = true;
            }
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Currently No Exam Available For You !!! ";
            grd_current_exam.Visible = false;
        }
        
        
    }

    //results
    protected void btnresult_Click(object sender, EventArgs e)
    
     {

         int i = 0;    
        grd_current_exam.Visible = false;
        grd_expire_exam.Visible = false;
        grdresult.Visible = true;
        DataSet ds = new DataSet();
        //ds = conn.select("select Exam_Name, Reg_Date, Exam_date 'Exam_Reg_Date', Exam_Given_Date, Status_PF 'Result', Score, Percentage , Tot_Marks, Passing_Marks, Tot_Que from Stud_Exam_Reg s, Exam_M e where s.Exam_Id = e.Exam_Id and s.Stud_Id = "+Session["regid"]+"");
        ds = conn.select("select e.Exam_Id,Exam_Name, Reg_Date, Exam_date, Exam_Given_Date, Status_PF 'Result', Score, Percentage , Tot_Marks, Passing_Marks, Tot_Que from Stud_Exam_Reg s, Exam_M e where s.Exam_Id = e.Exam_Id and s.Stud_Id = " + Session["regid"] + " and exam_given_date is not null and score is not null");

        if (ds.Tables[0].Rows.Count > 0)
        {
            gf.fill_grid(ds, grdresult);
            for (i = 0; i <= grdresult.Rows.Count; i++)
            {
                lblmsg.Text = i + " " + "Record Appear in Results";
                grdresult.Visible = true;
            }
          
        }

        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Any Exam Is Not Given By You Yet!!! ";
            grdresult.Visible = false;
        }
    }

    protected void grd_current_exam_list_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Exam_Id")
            {
                hdn_exam_list.Value = e.CommandArgument.ToString();
                string str3 = "select * from Exam_M e,stud_exam_reg s,que_m q WHERE e.Exam_Id ='" + hdn_exam_list.Value + "' and e.exam_id = s.exam_id and e.sub_id = q.sub_id";
                DataSet ds = new DataSet();
                ds = conn.select(str3);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["eid"] = hdn_exam_list.Value;
                    Session["sid"] = ds.Tables[0].Rows[0]["sub_id"].ToString();

                    //Response.Redirect("frm_attempt_que.aspx?exam_id=" + hdn_exam_list.Value + "&sub_id=" + ds.Tables[0].Rows[0]["sub_id"].ToString(),false);
                    Server.Transfer("frm_attempt_que.aspx");
                    
                   
                }
                else if (ds.Tables[0].Rows.Count <= 0)
                {
                    //Response.Write("hello");
                    Response.Redirect("given_exam_error.aspx");
                }
               
            }
        }
        catch (Exception ex)
        {
        }
    }

    //protected void linkbtnexamname_onclick(object sender, EventArgs e)
    //{
    //    Response.Redirect("frm_attempt_que.aspx?exam_id=1&sub_id=2");
    //}

    // previous result

    protected void grd_result_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Exam_Id")
            {
                hdn_exam_list.Value = e.CommandArgument.ToString();
                //string str3 = "select * from Exam_M e,stud_exam_reg s,que_m q WHERE e.Exam_Id ='" + hdn_exam_list.Value + "' and e.exam_id = s.exam_id and e.sub_id = q.sub_id";
                //DataSet ds = new DataSet();
                //ds = conn.select(str3);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                Session["eid"] = hdn_exam_list.Value;
             

                //Response.Redirect("frm_attempt_que.aspx?exam_id=" + hdn_exam_list.Value + "&sub_id=" + ds.Tables[0].Rows[0]["sub_id"].ToString(),false);
                Server.Transfer("frm_view_answer.aspx?"+Session["eid"]+" & "+Session["regid"]+"");


                //    }
                //    else if (ds.Tables[0].Rows.Count <= 0)
                //    {
                //        Response.Write("hello");
                //        //Response.Redirect("given_exam_error.aspx");
                //}

            }
        }
        catch (Exception ex)
        {
        }
    }

}


