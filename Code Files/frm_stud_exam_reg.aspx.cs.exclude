using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_stud_exam_reg : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldrp();
            bindgrid();
            calender_exam_type.Visible = true;
        }
    }

    public void filldrp()
    {      
        gf.fillcombo("select * from exam_m", drpexamname, "exam_name", "exam_id", "select exam");    
     
    }

    public void bindgrid()
    {
        DataSet ds = new DataSet();       
            
            string qry="SELECT        s.Stud_Id, s.Exam_Id, s.Reg_Date, s.Exam_Date, s.Exam_Given_Date, s.Status_PF, s.Score, s.Percentage, s.Result_OD, e.Exam_Id AS Expr1, e.Exam_Name, e.Sub_Id, e.Exam_Start_Date, e.Exam_End_Date, e.Tot_Marks, " ;
               qry +="       e.Passing_Marks, s1.Sub_Id AS Expr3, s1.Sub_Name, s1.Sub_Code, s1.Sem_Id, r.Reg_Id, r.Email, r.F_Name, r.M_Name, r.L_Name, r.Gender, r.DOB, r.Add_1, r.Add_2, r.City_Id, r.Password, r.Confirm_Password, r.Photo FROM  ";
        qry +=" Registration_M AS r INNER JOIN ";
                qry +="         Stud_Exam_Reg AS s ON r.Reg_Id = s.Stud_Id INNER JOIN ";
                 qry +="        Exam_M AS e ON s.Exam_Id = e.Exam_Id RIGHT OUTER JOIN ";
                  qry +="       exam_unit_t AS u ON u.exam_id = e.Exam_Id INNER JOIN ";
                  qry +="       Sub_M AS s1 ON s1.Sub_Id = e.Sub_Id AND e.Exam_Id = 1 ";
                  ds = conn.select(qry);
        gf.fill_grid(ds, grdexamstud);
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string dt = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            DateTime dt1 = Convert.ToDateTime(txtdate.Text);
            string edate = dt1.ToString("yyyy/MM/dd");
            string qry = "insert into stud_exam_reg (stud_id,exam_id,reg_date,exam_date) values (1,'" + drpexamname.SelectedValue + "','"+dt+"','"+edate+"')";
            conn.modify(qry);
            bindgrid();
            
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
    protected void drpexamname_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds=conn.select ("select * from sub_m where sub_id in (select sub_id from exam_m  where exam_id ='" + drpexamname.SelectedValue +"')");
        
        if (ds.Tables[0].Rows.Count > 0)
            lblsubname.Text = ds.Tables[0].Rows[0]["sub_name"].ToString();

        lblunit.Text = "";
        ds = conn.select("select unit_id from exam_unit_t where exam_id ='" + drpexamname.SelectedValue + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            int r = 0;
            while (r < ds.Tables[0].Rows.Count)
            {
                lblunit.Text += ds.Tables[0].Rows[r]["unit_id"].ToString() + " ";
                r = r + 1;
            }
        }    
       
    }
 
    protected void calender_exam_type_DayRender(object sender, DayRenderEventArgs e)
    {
        String s;
        DataSet ds = new DataSet();
        s = "Select exam_start_date,exam_end_date from exam_m where exam_id='" + drpexamname.SelectedValue + "'";
        ds = conn.select(s);
        DateTime start = Convert.ToDateTime(ds.Tables[0].Rows[0]["exam_start_date"]);
        DateTime end = Convert.ToDateTime(ds.Tables[0].Rows[0]["exam_end_date"]);
        if (e.Day.Date >= start && e.Day.Date <= end)
        {
            e.Day.IsSelectable = true;
        }
        else
        {
            e.Day.IsSelectable = false;
            e.Cell.Font.Strikeout = true;
            
        }
        
    }
    protected void calender_exam_type_SelectionChanged(object sender, EventArgs e)
    {
        txtdate.Text = calender_exam_type.SelectedDate.ToString("yyyy/MM/dd");
        
    }
    protected void grdexamstud_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdexamstud.PageIndex = e.NewPageIndex;
        bindgrid();

    }
}