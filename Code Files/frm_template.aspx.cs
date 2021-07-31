using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frm_temp : System.Web.UI.Page
{
    db_conn db = new db_conn();
    General_Function gf = new General_Function();

    protected void Page_Load(object sender, EventArgs e)
    {
        img1.Visible = false;
        img2.Visible = false;
 
    }


    protected void btnsection_Click1(object sender, EventArgs e)
    {
        Response.Redirect("frm_section.aspx");
    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        try
        {
            string s1 = DateTime.Now.ToString("yyyy/MM/dd").Trim();
            string temp = "insert into temp_m(temp_name,tot_marks,gen_date) values('" + txttempname.Text + "'," + txttempmarks.Text + ",'" + s1 + "')";
            db.modify(temp);
            Response.Write("<script>alert('Template Created Successfully')</script>");

        }
        catch
        {

            Response.Write("<script>alert('Please Enter Properly!')</script>");
        }
    }
    protected void btnsubsection_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_subsection.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        img1.Visible = true;
        img2.Visible = true;
    }
}