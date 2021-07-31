using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frm_student_update_profile : System.Web.UI.Page
{
    db_conn conn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
            int studrollno = Convert.ToInt16(Request.QueryString["studrollno"]);
            //string email = (Request.QueryString["email"]);
            //for reg_id
            //string regid = "select reg_id from registration_m where roll_no=" + studrollno+" and email ='"+email+"'";
            string regid = "select reg_id from registration_m where roll_no=" + studrollno + "";
            DataSet dsregid = new DataSet();
            dsregid = conn.select(regid);
            hdnregid.Value = dsregid.Tables[0].Rows[0]["reg_id"].ToString();
            //for student data
            //string studemail = Request.QueryString["studemail"];
            string s = "select * from registration_m where reg_id=" + dsregid.Tables[0].Rows[0]["reg_id"] + "and roll_no=" + studrollno;// +" and email like '" + studemail + "'";
            DataSet ds = new DataSet();
            ds = conn.select(s);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtrollno.Text = ds.Tables[0].Rows[0]["roll_no"].ToString();
                txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                txtname.Text = ds.Tables[0].Rows[0]["f_name"].ToString();
            }
        }
    
    }
    
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //for student update data
        string updatedata = "update registration_m set email='" + txtemail.Text + "',f_name='" + txtname.Text + "' where reg_id=" + hdnregid.Value;
        conn.modify(updatedata);
        Response.Write("<script>alert('update data succesfully!!!')</script>");
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_studentprofile.aspx");
    }
}