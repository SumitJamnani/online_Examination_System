using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frm_view_answer : System.Web.UI.Page
{
    string ga, ca;
    db_conn conn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
       // hdn_stud_id.Value = Convert.ToInt16(Request.QueryString["regid"]).ToString();
        //hdn_e_id.Value   =  Convert.ToInt16(Request.QueryString["eid"]).ToString();
        bindgrid();
        hdn_e_id.Value = Session["eid"].ToString();
        Int16 marks =Convert.ToInt16(Session["marks"]);
        Int16 pmarks = Convert.ToInt16(Session["passmarks"]);
        Int16 percent = Convert.ToInt16(Session["percent"]);

        //if (marks > pmarks && percent < 90)
        //{
        //    bindgrid();
        //    btnback.Text = "Performance Improvement";
        //}
        //else if (marks > pmarks && percent >= 90)
        //{
        //    bindgrid();
        //    btnback.Text = "Back";
        //}
        //else
        //{
        //    bindgrid();
        //    btnback.Text = "Attempt Exam Again";
        //}
    }
    protected void grdview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        
    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select q.Que_Text,q.O1,q.O2,q.O3,q.O4,q.Correct_Ans,a.Given_Ans from  Que_M q,Attempt_Que a where q.Que_Id = a.Que_Id and a.Stud_Id = "+Session["regid"]+" and a.exam_id = "+Session["eid"]+"");
        gf.fill_grid(ds, grdview);
    }





    protected void grdview_RowDataBound11(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        if ( e.Row.RowType==  DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text.ToUpper() == e.Row.Cells[7].Text.ToUpper())
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.LightGreen;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.Black;
                e.Row.Cells[7].Font.Bold.ToString();
            }
            else
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.Orange;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.Black;
                e.Row.Cells[7].Font.Bold.ToString();
            }

        }
    }

    protected void btnback_Click(object sender, EventArgs e)
     {

         if (btnback.Text == "Back")
         {
             Server.Transfer("frm_result.aspx?stud_id=" + Session["regid"] + "&exam_id=" + Session["eid"] + "&sub_id=" + Session["sid"] + "", false);
         }
         //else if (btnback.Text == "Performance Improvement")
         //{
         //    // UPDATE : 1 To 1_attempt1
         //   //string s1 = "update stud_exam_reg"
         //}
    }
}