using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class MasterPageAdmin : System.Web.UI.MasterPage
{
    db_conn conn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string qry = "select * from login_m where email='" + Session["email"] + "'";
            DataSet ds = new DataSet();
            ds = conn.select(qry);
            string usertype = ds.Tables[0].Rows[0]["type_fsd"].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (usertype.ToString().ToLower().Trim() == "d")
                {


                    pnladmin.Visible = false;
                    pnlfaculty.Visible = false;
                }
                else if (usertype.ToString().ToLower().Trim() == "f")
                {


                    pnladmin.Visible = false;
                    pnldirector.Visible = false;

                }
                else if (usertype.ToString().ToLower().Trim() == "a")
                {


                    pnlfaculty.Visible = false;
                    pnldirector.Visible = false;
                }
            }

            DataSet ds1 = new DataSet();
            string qry1 = "select f_name,m_name,l_name,division,semester,roll_no from registration_m where reg_id = " + Session["regid"] + "";
            ds1 = conn.select(qry1);
            if (ds1.Tables[0].Rows.Count >= 0)
            {
                lblname.Text = ds1.Tables[0].Rows[0]["f_name"].ToString() + " ";
                lblname1.Text = ds1.Tables[0].Rows[0]["f_name"].ToString() + " ";
                lblname2.Text = ds1.Tables[0].Rows[0]["f_name"].ToString() + " ";
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("frmlogin_m.aspx", false);
        }
    }
}
