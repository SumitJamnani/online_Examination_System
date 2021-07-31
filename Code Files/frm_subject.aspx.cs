using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Frm_subject : System.Web.UI.Page
{
    db_conn con = new db_conn(); 
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_grid();
            bind_drop();
        }
        UpdateDeleteHide();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "insert into sub_m(sub_name,sub_code,sem_id) values('" + txtsubname.Text + "','" + txtsubcode.Text + "'," + dropsem.SelectedValue + ")";
            con.modify(qry);
            Response.Write("<script>alert('Subject Inserted Successfully')</script>");
            bind_grid();
            ClearAll(this);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Subject Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    public void bind_grid()
    {
        DataSet ds = new DataSet();
        ds = con.select("select * from sub_m sub,sem_m sem where sub.sem_id=sem.sem_id order by sub.sub_id desc");
        gf.fill_grid(ds, grid_subject);
    }
    public void bind_drop()
    {
        gf.fillcombo("select * from sem_m", dropsem, "sem_name", "sem_id", "select semester");
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
            String qry = "update sub_m set sub_name='" + txtsubname.Text + "',sub_code='" + txtsubcode.Text + "',sem_id=" + dropsem.SelectedValue + " where sub_id=" + hiddensubid.Value;
            con.modify(qry);
            Response.Write("<script>alert('Subject Updated Successfully')</script>");
            bind_grid();
            SubmitShow();
            ClearAll(this);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Subject Not Updated & Something Went Wrong...!')</script>");
        }
    }
    protected void sub_rowcmd(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Sub_Id")
            {
                hiddensubid.Value = e.CommandArgument.ToString();
                string str3 = "select * from sub_m WHERE sub_id ='" + hiddensubid.Value + "' ";
                DataSet ds = new DataSet();
                ds = con.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtsubname.Text = ds.Tables[0].Rows[0]["Sub_Name"].ToString();
                    txtsubcode.Text = ds.Tables[0].Rows[0]["Sub_Code"].ToString();
                    dropsem.SelectedValue = ds.Tables[0].Rows[0]["Sem_Id"].ToString();
                }
                UpdateDeleteShow();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Went Wrong...!')</script>");
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            String qry = "delete from sub_m where sub_id=" + hiddensubid.Value;
            con.modify(qry);
            Response.Write("<script>alert('Subject Deleted Successfully')</script>");
            bind_grid();
            SubmitShow();
            ClearAll(this);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Subject Not Deleted & Something Went Wrong...!')</script>");
        }
    }
    public void ClearAll(Control parent)
    {
        //below loop will called in recursive manner.if control is container it will loop inside that container.
        // if it is control then it will check if it is textbox it will clear the text.

            foreach (Control x in parent.Controls)
            {
                if ((x.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(x)).Text ="";
                }
                if ((x.GetType() == typeof(DropDownList)))
                {
                    ((DropDownList)(x)).SelectedIndex =0;
                }
                
                if (x.HasControls())
                {
                    ClearAll(x);
                }
                
             }
        //txtsubcode.Text = " ";
        //txtsubname.Text = " ";
        //dropsem.SelectedIndex = 0;
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
    protected void grid_subject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_subject.PageIndex = e.NewPageIndex;
    }
}