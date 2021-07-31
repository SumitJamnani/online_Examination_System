using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class select_exam : System.Web.UI.Page
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
        string s = "select exam_name,exam_id from exam_m where exam_end_date >= { fn now() } ";
        gf.fillcombo(s, drpexamname, "exam_name", "exam_id", "--select--");

    }


    protected void btnexam_Click(object sender, EventArgs e)
    {
            string s = "update exam_m set startstop=" + drpstartstop.SelectedValue +" where exam_id="+ drpexamname.SelectedValue;
            conn.modify(s);
        
    }
}