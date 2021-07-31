    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmstate : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            disabled_up_del();       
        }
    }
    public void disabled_up_del()
    {
        btnupdate.Visible = false;
        btndelete.Visible = false;
    }

    public void enabled_up_del()
    {
        btnupdate.Visible = true;
        btndelete.Visible = true;
    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select * from state_m order by state_id desc");
        gf.fill_grid(ds, grdstate);
        btnsubmit.Visible = true;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "insert into state_m (state_name) values ('" + txtstatename.Text + "')";
            conn.modify(qry);
            Response.Write("<script>alert('State Inserted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('State Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    protected void grdstate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "State_Id")
            {
                hdnstateid.Value = e.CommandArgument.ToString();
                string str3 = "select * from State_M WHERE State_Id ='" + hdnstateid.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtstatename.Text = ds.Tables[0].Rows[0]["State_Name"].ToString();

                }
                enabled_up_del();
                btnsubmit.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Went Wrong...!')</script>");
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "update state_m set state_name='" + txtstatename.Text + "' where state_id=" + hdnstateid.Value;
            conn.modify(qry);
            Response.Write("<script>alert('State Updated Successfully')</script>");
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('State Not Updated & Something Went Wrong...!')</script>");
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "delete from state_m where state_id=" + hdnstateid.Value;
            conn.modify(qry);
            Response.Write("<script>alert('State Deleted Successfully')</script>");
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('State Not Deleted & Something Went Wrong...!')</script>");
        }
    }
    public void clearall(Control parent)
    {
        foreach (Control x in parent.Controls)
        {
            if ((x.GetType() == typeof(TextBox)))
            {
                ((TextBox)(x)).Text = "";
            }
            if ((x.GetType() == typeof(DropDownList)))
            {
                ((DropDownList)(x)).Text = "";
            }
            if (x.HasControls())
            {
                clearall(x);
            }
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clearall(this);
    }
}