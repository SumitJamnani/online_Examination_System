using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class frm_change_user_type : System.Web.UI.Page
{

    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string type = "select * from login_m l,registration_m r where r.reg_id = " + Session["Regid"] + " and r.email = l.email";
            DataSet ds = conn.select(type);
            string type1 = ds.Tables[0].Rows[0][2].ToString();
            if (type1 == "a")
            {
                drp_type.Items.Add("D");
                drp_type.Items.Add("F");
                drp_type.Items.Add("S");
            }

            else if (type1 == "d")
            {
                drp_type.Items.Add("F");
                drp_type.Items.Add("S");
            }

            else if (type1 == "f")
            {
                drp_type.Items.Add("S");
            }
        }

    }
    protected void btn_type_Click(object sender, EventArgs e)
    {
        string type2 = "update login_m set type_fsd = '"+drp_type.SelectedValue.ToLower()+"'  where email = '"+txt_email.Text+"'";
        conn.modify(type2);
        Response.Write("<script>alert('User Type Changed Successfully!!!!')</script>");
        txt_email.Text = "";
    }
}