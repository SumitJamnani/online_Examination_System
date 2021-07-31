using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frm_section : System.Web.UI.Page
{
    db_conn db = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            binddrptemp();

        }
    }

    public void binddrptemp()
    {
        string s = "select * from temp_m";
        gf.fillcombo(s, drptemp, "temp_name", "temp_id", "--select--");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //section_m
            string temp1 = "insert into section_m(section_name,temp_id,marks,noofquestions) values('" + txtsecname.Text + "'," + drptemp.SelectedValue + "," + txtsecmarks.Text + "," + txtqueno.Text + ")";
            db.modify(temp1);

            //section_id
            DataSet ds_sid = new DataSet();
            ds_sid = db.select("select max(section_id) from section_m");
            Session["section_id"] = ds_sid.Tables[0].Rows[0][0];

            //sub_section_m
            Int16 i;
            for (i = 1; i <= Convert.ToInt16(txtqueno.Text); i++)
            {
                string temp2 = "insert into sub_section_m(section_id,label,parent_id) values(" + Session["section_id"] + ",'Q." + i + "',0)";
                db.modify(temp2);
            }

            Response.Write("<script>alert('Section Created Successfully')</script>");
        }
        catch
        {

            Response.Write("<script>alert('Please Enter Properly!')</script>");
        }

    }
    protected void btntemp_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_template.aspx");
    }
    protected void btnsubsec_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_subsection.aspx");
    }

}