using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frm_changelogin_status : System.Web.UI.Page
{
    db_conn conn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnstatus_Click(object sender, EventArgs e)
    {
    
        string qry1 = "update login_m set status=0 where email like '" + txtemail.Text + "%'";
        conn.modify(qry1);
        Response.Write("<script>alert('Status Updated Successfully!!')</script>");
    }
}