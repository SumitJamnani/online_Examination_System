using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lbldate.Text = DateTime.Now.ToShortDateString() + "<br / > " + " Day : " + DateTime.Now.DayOfWeek;
            DataSet ds = new DataSet();
            string qry = "select f_name,m_name,l_name,division,semester,roll_no from registration_m where reg_id = " + Session["regid"] + "";
            ds = conn.select(qry);

            if (ds.Tables[0].Rows.Count >= 0)
            {
                lblname.Text = ds.Tables[0].Rows[0]["f_name"].ToString() + " ";
                lblname.Text += ds.Tables[0].Rows[0]["m_name"].ToString() + " ";
                lblname.Text += ds.Tables[0].Rows[0]["l_name"].ToString();
                lblsem.Text = ds.Tables[0].Rows[0]["Semester"].ToString();
                lblrollno.Text = ds.Tables[0].Rows[0]["Roll_no"].ToString();
                lbldiv.Text = ds.Tables[0].Rows[0]["division"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("frmlogin_m.aspx", false);
        }
        }
    
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session["eid"] = "";
        Session["sid"] = "";
        Session["stime"] = "";
        Session["totq"] = "";
        Session["regid"] = "";
        string qry2 = "update login_m set status=0 where email = '"+Session["email"]+"'";
        conn.modify(qry2);
        Response.Redirect("frmlogin_m.aspx");
        


    }
}
