using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frm_semupdate : System.Web.UI.Page
{
    db_conn con = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindsemdrp();
            bindyeardrp();
        }
    }
    public void bindyeardrp()
    {
        drpyear.Items.Add("Select");
        drpyear.Items.Add("FY");
        drpyear.Items.Add("SY");
        drpyear.Items.Add("TY");
    }
    public void bindsemdrp()
    {
        string s = "select * from Sem_M";
        gf.fillcombo(s, drpsem, "sem_name", "sem_id", "--select--");

    }
    protected void btnupdatesem_Click(object sender, EventArgs e)
    {
        try
        {
            string y = drpyear.SelectedValue;
            if (y == "FY")
            {
                string updatefysem = "update registration_m set Semester=" + drpsem.SelectedValue + " where Email like 'fy%'";
                con.modify(updatefysem);
                Response.Write("<script>alert('Semester Update Successfully!!!!')</script>");
            }
            else if (y == "SY")
            {
                string updatesysem = "update registration_m set Semester=" + drpsem.SelectedValue + " where Email like 'sy%'";
                con.modify(updatesysem);
                Response.Write("<script>alert('Semester Update Successfully!!!!')</script>");
            }
            else if (y == "TY")
            {
                string updatetysem = "update registration_m set Semester=" + drpsem.SelectedValue + " where Email like 'ty%'";
                con.modify(updatetysem);
                Response.Write("<script>alert('Semester Update Successfully!!!!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Semester Not Updated!!!!')</script>");
            }
        }
        catch
        {
            Response.Write("<script>alert('Something went wrong!!!!')</script>");
        }
    }
}