using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frm_studentprofile : System.Web.UI.Page
{
    db_conn conn = new db_conn();
    General_Function gf = new General_Function();

    protected void Page_Load(object sender, EventArgs e)
    {
        //  txtname.Text = "";
        if (!IsPostBack)
        {
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
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select * from registration_m where email like '" + drpyear.SelectedValue + "%' and f_name like '%" + txtname.Text + "%'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            gf.fill_grid(ds, grdstud);
        }
        else
        {
            Response.Write("<script>alert('No Student Found!!')</script>");
        }
    }


    protected void grdstud_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Roll_No")
            {
                hdnregid.Value = e.CommandArgument.ToString();
                //Determine the RowIndex of the Row whose Button was clicked.
                int index = Convert.ToInt32(hdnregid.Value);
                //Reference the GridView Row.
                //GridViewRow row = grdstud.Rows[index-1];
                //string studemail = row.Cells[1].Text;
                //string studemail = grdstud.Rows[rowIndex].Text;
                //Response.Redirect("frm_student_update_profile.aspx?studrollno=" + hdnregid.Value+"&Email="+studemail, false);
                Response.Redirect("frm_student_update_profile.aspx?studrollno=" + hdnregid.Value, false);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Went Wrong...!')</script>");
        }
    }


    protected void grdstud_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdstud.PageIndex = e.NewPageIndex;
    }

    protected void txtname_TextChanged(object sender, EventArgs e)
    {
        bindgrid();

    }
    //protected void btnsearch_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        bindgrid();
    //    }
    //    catch
    //    {
    //        lbl.Text = "No Data Found";
    //    }
    //}




    protected void drpyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //   bindgrid();
    }
}