using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmcourse_m : System.Web.UI.Page
{
    db_conn conn = new db_conn();
    General_Function gf = new General_Function();
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




    public void binddrp()
    {


        gf.fillcombo("select * from registration_m r,login_m l where r.email = l.email and l.type_fsd='d'", drpcname, "f_name", "reg_id", "");

    }

    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select * from course_m c,registration_m r where c.dir_id=r.reg_id order by c.c_id desc");
        gf.fill_grid(ds, Grdcourse);


    }

    protected void grdcourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "C_Id")
            {
                hdncourse.Value = e.CommandArgument.ToString();
                string str3 = "select * from Course_M WHERE C_Id ='" + hdncourse.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtcname.Text = ds.Tables[0].Rows[0]["C_Name"].ToString();
                    drpcname.SelectedValue = ds.Tables[0].Rows[0]["dir_id"].ToString();
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
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "insert into course_m (c_name,dir_id) values('" + txtcname.Text + "','" + drpcname.SelectedValue + "')";
            conn.modify(qry);
            Response.Write("<script>alert('Course Inserted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Course Not Inserted & Something Went Wrong...!')</script>");
        }
    }

    public void clearall(Control Parent)
    {
        foreach (Control x in Parent.Controls)
        {
            if ((x).GetType() == typeof(TextBox))
            {
                ((TextBox)(x)).Text = "";
            }

            if ((x).GetType() == typeof(DropDownList))
            {
                ((DropDownList)(x)).SelectedIndex = 0;
            }

            if (x.HasControls())
            {
                clearall(x);
            }

        }

    }
    protected void Grdcourse_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Grdcourse.PageIndex = e.NewSelectedIndex;
        bindgrid();

    }
    protected void Grdcourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grdcourse.PageIndex = e.NewPageIndex;
        bindgrid();

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "update course_m set c_name='" + txtcname.Text + "',dir_id=" + drpcname.SelectedValue + " where c_id=" + hdncourse.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Course Updated Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Course Not Updated & Something Went Wrong...!')</script>");
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "delete from course_m where c_id=" + hdncourse.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Course Deleted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Course Not Deleted & Something Went Wrong...!')</script>");
        }
    }
}

