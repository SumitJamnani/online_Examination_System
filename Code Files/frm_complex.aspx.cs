using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Frm_complex : System.Web.UI.Page
{
    db_conn con = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {

        bind_grid();
        UpdateDeleteHide();

    }
    public void bind_grid()
    {
        DataSet ds = new DataSet();
        ds = con.select("select * from complex_que_m order by complex_id desc");
        gf.fill_grid(ds, grid_complex);

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "insert into complex_que_m(complex_type) values('" + txtcomplexity.Text + "')";
            con.modify(qry);
            Response.Write("<script>alert('Complexity Inserted Successfully')</script>");
            bind_grid();
            ClearAll(this);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Complexity Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "update complex_que_m set complex_type='" + txtcomplexity.Text + "' where complex_id=" + hiddencomplexid.Value;
            con.modify(qry);
            Response.Write("<script>alert('Complexity Updated Successfully')</script>");
            bind_grid();
            SubmitShow();
            ClearAll(this);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Complexity Not Updated & Something Went Wrong...!')</script>");
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "delete from complex_que_m where complex_id=" + hiddencomplexid.Value;
            con.modify(qry);
            Response.Write("<script>alert('Complexity Deleted Successfully')</script>");
            bind_grid();
            SubmitShow();
            ClearAll(this);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Complexity Not Deleted & Something Went Wrong...!')</script>");
        }
    }
    protected void complex_rowcmd(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Complex_Id")
            {
                hiddencomplexid.Value = e.CommandArgument.ToString();
                string str3 = "select * from complex_que_m WHERE complex_id ='" + hiddencomplexid.Value + "'";
                DataSet ds = new DataSet();
                ds = con.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtcomplexity.Text = ds.Tables[0].Rows[0]["Complex_Type"].ToString();
                }
            }
            UpdateDeleteShow();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Went Wrong...!')</script>");
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
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearAll(this);
        SubmitShow();
    }
}