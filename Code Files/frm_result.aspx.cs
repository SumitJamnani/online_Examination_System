using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_result : System.Web.UI.Page
{
    Int32 right = 0;
    Int32 wrong = 0;
    Int32 tot = 0;

    Int32 tot_percentage = 0,passing_marks = 0 ;
    string status;
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString != null)
            {
                Session["sid"] = Convert.ToInt16(Request.QueryString["stud_id"]);
                Session["eid"] = Convert.ToInt16(Request.QueryString["exam_id"]);
                Session["s_id"] = Convert.ToInt16(Request.QueryString["sub_id"]);


            }
            calculate_result();
            insert();
            display();
        }
        catch
        {
            Response.Redirect("frm_exam_list.aspx?stud_id=" + Session["regid"] + "&exam_id=" + Session["eid"]);
        }
    }


public void display()
{
        DataSet ds = new DataSet();
        //string qry = "select exam_name,status_pf,score,percentage,tot_que,passing_marks from stud_exam_reg s,exam_m e,registration_m r  where  s.Stud_Id = "+Session["regid"]+" and s.Exam_Id = "+Session["eid"]+" and s.stud_id = r.reg_id and s.exam_id = e.exam_id";
        //string qry = "select exam_name,status_pf,score,percentage,tot_que,passing_marks from stud_exam_reg s,exam_m e,registration_m r  where  s.Stud_Id = " + Session["regid"] + " and s.Exam_Id = " + Session["eid"] + "";
          //string qry = "select exam_name,status_pf,score,percentage,tot_que,passing_marks , e.exam_id from stud_exam_reg s,exam_m e where e.Exam_Id = s.Exam_Id and s.Stud_Id = "+Session["regid"]+" and s.Exam_Id = "+Session["eid"]+"";
        string qry = "select exam_name,status_pf,score,percentage,tot_que,passing_marks,tot_marks , e.exam_id from stud_exam_reg s inner join exam_m e  on e.exam_id = s.exam_id where s.Stud_Id = " + Session["regid"] + " and s.Exam_Id = " + Session["eid"] + "";
        //string qry = "select exam_name,status_pf,score,percentage,tot_que,passing_marks,e.exam_id from Attempt_Que where Exam_Id = " + Session["eid"] + " select * from stud_exam_reg s inner join  attempt_que a on s.Exam_Id = a.Exam_Id inner join que_m q on a.que_id = q.que_id where s.stud_id = " + Session["regid"] + " and a.exam_id = " + Session["eid"] + " and a.given_ans = q.correct_ans";
        ds = conn.select(qry);
        int mks = Convert.ToInt32(ds.Tables[0].Rows[0]["score"]) * 2;
        Session["marks"] = ds.Tables[0].Rows[0]["score"];
        Session["passmarks"] = ds.Tables[0].Rows[0]["passing_marks"];
        Session["percent"] = ds.Tables[0].Rows[0]["percentage"];
        if (ds.Tables[0].Rows.Count > 0)
        {
           
            lbl_exam_name.Text = ds.Tables[0].Rows[0]["exam_name"].ToString();
            tot_questions.Text = ds.Tables[0].Rows[0]["tot_que"].ToString();
            lbl_right_ans.Text = right.ToString();
            lbl_wrong_ans.Text = wrong.ToString();
            lbl_status.Text = ds.Tables[0].Rows[0]["status_pf"].ToString();
          //  lbl_score.Text = Convert.ToInt32(ds.Tables[0].Rows[0]["score"]).ToString();
            lbl_score.Text = mks.ToString();
            lbl_passing.Text = ds.Tables[0].Rows[0]["passing_marks"].ToString();
            lbl_totalmarks.Text = ds.Tables[0].Rows[0]["tot_marks"].ToString();
            lbl_percentage.Text = ds.Tables[0].Rows[0]["percentage"].ToString()+ "%";
        }
}


    public void calculate_result()
    {
        
        DataSet ds1 = new DataSet();
        
        string qry = "select * from exam_m e where e.exam_id = "+Session["eid"]+"";
        ds1 = conn.select(qry);
        tot = Convert.ToInt32(ds1.Tables[0].Rows[0]["tot_que"]);
       

        DataSet ds = new DataSet();
        string qry1 = "select COUNT(*) from Attempt_Que a, Que_M b where a.Que_Id = b.Que_Id and a.Exam_Id="+Session["eid"]+" and a.Stud_Id="+Session["regid"]+" and a.Given_Ans=b.Correct_Ans";
        ds = conn.select(qry1);
        right = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

        wrong = tot - right; 
      
        
        tot_percentage = right * 100 / tot; 
        
        passing_marks = Convert.ToInt32(ds1.Tables[0].Rows[0]["passing_marks"]);
        if (right >= passing_marks)
        {
            status = "Congratulations!!! You Are PASS.";
            lbl_status.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            status = "Sorry!!! Better Luck Next Time You Are FAIL.";
            lbl_status.ForeColor = System.Drawing.Color.Red;
        }



    }


   public void insert()
     {
        DataSet ds = new DataSet();
        string gd = DateTime.Now.ToString("yyyy/MM/dd");
        string qry = "update stud_exam_reg set status_pf = '" + status + "', score = " + right + ", percentage = '" + tot_percentage + "',exam_given_date = '" + gd + "'  where stud_id = " + Session["sid"] + " and Exam_Id = " + Session["eid"].ToString() ; 
        conn.modify(qry);
    }

   protected void btnview_Click(object sender, EventArgs e)
   {
       Response.Redirect("frm_view_answer.aspx");
   }
}