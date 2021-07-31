using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_tag_m : System.Web.UI.Page
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
        ds = conn.select("select * from tag_m");
        gf.fill_grid(ds, grid_tag);
        btnsubmit.Visible = true;
    }   

    protected void tag_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Tag_Id")
            {
                hiddentagid.Value = e.CommandArgument.ToString();
                string str3 = "select * from Tag_M WHERE Tag_Id ='" + hiddentagid.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txttagname.Text = ds.Tables[0].Rows[0]["Tag_Name"].ToString();

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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "insert into tag_m (tag_name) values ('" + txttagname.Text + "')";
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
            String qry = "update tag_m set tag_name='" + txttagname.Text + "' where state_id=" + hiddentagid.Value;
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
            String qry = "delete from tag_m where tag_id=" + hiddentagid.Value;
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
}