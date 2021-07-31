using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmsec : System.Web.UI.Page
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
        ds = conn.select("select * from sec_m order by sec_id desc");
        gf.fill_grid(ds, grdsec);
        btnsubmit.Visible = true;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "insert into sec_m (sec_que) values ('" + txtsecque.Text + "')";
            conn.modify(qry);
            Response.Write("<script>alert('Security Question Inserted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Security Question Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    protected void grdsec_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sec_Id")
            {
                hdnsecid.Value = e.CommandArgument.ToString();
                string str3 = "select * from Sec_M WHERE Sec_Id ='" + hdnsecid.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtsecque.Text = ds.Tables[0].Rows[0]["Sec_Que"].ToString();

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
            string qry = "update sec_m set sec_que='" + txtsecque.Text + "' where sec_id=" + hdnsecid.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Security Question Updated Successfully')</script>");
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Security Question Not Updated & Something Went Wrong...!')</script>");
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "delete from sec_m where sec_id=" + hdnsecid.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Security Question Deleted Successfully')</script>");
            bindgrid();
            clearall(this);
            btnsubmit.Visible = true;
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Security Question Not Deleted & Something Went Wrong...!')</script>");
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