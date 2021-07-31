using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_group_m : System.Web.UI.Page
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
        ds = conn.select("select * from group_m");
        gf.fill_grid(ds, grid_group);
        btnsubmit.Visible = true;
    }
    protected void group_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Group_Id")
            {
                hiddengroupid.Value = e.CommandArgument.ToString();
                string str3 = "select * from Group_M WHERE Group_Id ='" + hiddengroupid.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtgroupname.Text = ds.Tables[0].Rows[0]["Group_Name"].ToString();

                }
                enabled_up_del();
                btnsubmit.Visible = false;
            }
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "insert into group_m (group_name) values ('" + txtgroupname.Text + "')";
            conn.modify(qry);
            bindgrid();
            clearall(this);
            disabled_up_del();
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "update group_m set group_name='" + txtgroupname.Text + "' where state_id=" + hiddengroupid.Value;
            conn.modify(qry);
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "delete from group_m where group_id=" + hiddengroupid.Value;
            conn.modify(qry);
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clearall(this);
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
}