using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmcity : System.Web.UI.Page
{

    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            binddrp();
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
        ds = conn.select("select * from city_m c,state_m s where c.state_id=s.state_id order by city_id desc");
        gf.fill_grid(ds, grdcity);
        btnsubmit.Visible = true;

    }
    public void binddrp()
    {
        gf.fillcombo("select * from state_m", drpstate, "state_name", "state_id", "");

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "insert into city_m (city_name, state_id) values ('" + txtcityname.Text + "'," + drpstate.SelectedValue + ")";
            conn.modify(qry);
            Response.Write("<script>alert('City Inserted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('City Not Inserted & Something Went Wrong...!')</script>");
        }
    }

    protected void grdcity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "City_Id")
            {
                hdncityid.Value = e.CommandArgument.ToString();
                string str3 = "select * from City_M WHERE City_Id ='" + hdncityid.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtcityname.Text = ds.Tables[0].Rows[0]["City_Name"].ToString();
                    drpstate.SelectedValue = ds.Tables[0].Rows[0]["State_Id"].ToString();
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
            string qry = "update city_m set city_name = '" + txtcityname.Text + "',state_id='" + drpstate.SelectedValue + "' where city_id = " + hdncityid.Value;
            conn.modify(qry);
            Response.Write("<script>alert('City Updated Successfully')</script>");
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('City Not Updated & Something Went Wrong...!')</script>");
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "delete from city_m where city_id = " + hdncityid.Value;
            Response.Write("<script>alert('City Deleted Successfully')</script>");
            conn.modify(qry);
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('City Not Deleted & Something Went Wrong...!')</script>");
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
            //if ((x.GetType() == typeof(DropDownList)))
            //{
            //    ((DropDownList)(x)).Text = "";
            //}
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