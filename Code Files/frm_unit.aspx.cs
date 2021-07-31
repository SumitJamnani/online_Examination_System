using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Frm_unit : System.Web.UI.Page
{
    db_conn con = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_grid();
        }
        UpdateDeleteHide();
    }

    public void bind_grid()
    {
        DataSet ds = new DataSet();
        ds = con.select("select * from unit_m order by unit_id desc");
        gf.fill_grid(ds, grid_unit);
    }

    protected void unit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Unit_Id")
            {
                hiddenunitid.Value = e.CommandArgument.ToString();
                string str3 = "select * from unit_m WHERE unit_id ='" + hiddenunitid.Value + "' ";
                DataSet ds = new DataSet();
                ds = con.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtunitname.Text = ds.Tables[0].Rows[0]["Unit_Name"].ToString();
                }
                UpdateDeleteShow();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Went Wrong...!')</script>");
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "insert into unit_m (unit_name) values ('" + txtunitname.Text + "')";
            con.modify(qry);
            Response.Write("<script>alert('Unit Inserted Successfully')</script>");
            bind_grid();
            ClearAll(this);
        }

        catch (Exception ex)
        {
            Response.Write("<script>alert('Unit Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearAll(this);
        SubmitShow();

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "update unit_m set unit_name = '" + txtunitname.Text + "' where unit_id = " + hiddenunitid.Value;
            con.modify(qry);
            Response.Write("<script>alert('Unit Updated Successfully')</script>");
            bind_grid();
            SubmitShow();
            ClearAll(this);
        }

        catch (Exception ex)
        {
            Response.Write("<script>alert('Unit Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "delete from unit_m where unit_id = " + hiddenunitid.Value;
            con.modify(qry);
            Response.Write("<script>alert('Unit Deleted Successfully')</script>");
            bind_grid();
            SubmitShow();
            ClearAll(this);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Unit Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    public void ClearAll(Control parent)
    {
        foreach (Control x in parent.Controls)
        {
            if ((x.GetType() == typeof(TextBox)))
            {
                ((TextBox)(x)).Text = "";
            }
            if ((x.GetType() == typeof(DropDownList)))
            {
                ((DropDownList)(x)).SelectedIndex = 0;
            }
            if (x.HasControls())
            {
                ClearAll(x);
            }

        }
    }
    public void UpdateDeleteHide()
    {
        btnupdate.Visible = false;
        btndelete.Visible = false;
    }
    public void UpdateDeleteShow()
    {
        btnupdate.Visible = true;
        btndelete.Visible = true;
        btnsubmit.Visible = false;
    }
    public void SubmitShow()
    {
        btnsubmit.Visible = true;
    }
}