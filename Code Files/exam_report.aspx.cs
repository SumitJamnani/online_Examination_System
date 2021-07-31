using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class exam_report : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
            binddrp();
         
        }
    }
    public void binddrp()
    {
        string s = "select distinct(e.exam_name),e.exam_id from exam_m e,attempt_que a where e.exam_id=a.exam_id";
        gf.fillcombo(s, drpexamname, "exam_name", "exam_id", "--select--");

    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
       ds = conn.select("select r.roll_no 'Roll No',r.f_name 'Name',s.status_pf 'Status',s.score 'Marks Obtained' , Tot_Marks 'Total Marks', PAssing_Marks 'Passing '  from  stud_exam_reg s,exam_m e,registration_m r where e.exam_id=s.exam_id and s.stud_id=r.reg_id and e.exam_name='"+drpexamname.SelectedItem +"'");
  
        
        gf.fill_grid(ds, grd_result);
    }


    protected void btnresult_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void grd_result_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
}