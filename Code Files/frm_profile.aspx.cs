using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frm_profile : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtdatecalext.EndDate = Convert.ToDateTime("2010/01/01");
        if (!IsPostBack)
        {
            gender();
        }
        DataSet ds = new DataSet();
        string qry = "select * from registration_m r, login_m l where r.reg_id = " + Session["regid"] + " and l.email=r.email";
        ds = conn.select(qry);
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            txtfname.Text = ds.Tables[0].Rows[0]["F_Name"].ToString();
            txtmname.Text = ds.Tables[0].Rows[0]["M_Name"].ToString();
            txtlname.Text = ds.Tables[0].Rows[0]["L_Name"].ToString();
            txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txtdob.Text = ds.Tables[0].Rows[0]["dob"].ToString();
            if (ds.Tables[0].Rows[0]["Gender"].ToString().ToLower() == "m")
                rblgender.SelectedIndex = 0;
            else if (ds.Tables[0].Rows[0]["Gender"].ToString().ToLower() == "f")
                rblgender.SelectedIndex = 1;
            txtadd1.Text = ds.Tables[0].Rows[0]["Add_1"].ToString();
            txtadd2.Text = ds.Tables[0].Rows[0]["Add_2"].ToString();
            
        }
    }
    public void gender()
    {
        rblgender.Items.Add("Male");
        rblgender.Items.Add("Female");
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "update registration_m set F_Name='" + txtfname.Text + "', M_Name='" + txtmname.Text + "', L_Name='" + txtlname.Text + "', email='" + txtemail.Text + "', dob='" + txtdob.Text + "', Gender='" + rblgender.SelectedValue + "', Add_1='" + txtadd1.Text + "', Add_2='" + txtadd2.Text + "' where reg_id = " + Session["regid"];
            conn.modify(qry);
            Response.Write("<script>alert('Profile Updated Successfully')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Profile Not Updated & Something Went Wrong...!')</script>");
        }
    }
}