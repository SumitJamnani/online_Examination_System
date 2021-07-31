using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_que_m : System.Web.UI.Page
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

    protected void grdquestion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Que_Id")
        {
            hdnquestion.Value = e.CommandArgument.ToString();
            string str3 = "select * from Que_m WHERE Que_Id ='" + hdnquestion.Value + "' ";
            DataSet ds = new DataSet();
            ds = conn.select(str3);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpunit.SelectedValue = ds.Tables[0].Rows[0]["Unit_Id"].ToString();
                    drpsub.SelectedValue = ds.Tables[0].Rows[0]["Sub_Id"].ToString();
                    // drpcomplexity.SelectedValue = ds.Tables[0].Rows[0]["Complex_Id"].ToString();
                    txtquestion.Text = ds.Tables[0].Rows[0]["Que_Text"].ToString();
                    txto1.Text = ds.Tables[0].Rows[0]["o1"].ToString();
                    txto2.Text = ds.Tables[0].Rows[0]["o2"].ToString();
                    txto3.Text = ds.Tables[0].Rows[0]["o3"].ToString();
                    txto4.Text = ds.Tables[0].Rows[0]["o4"].ToString();
                    txt_c_ans.Text = ds.Tables[0].Rows[0]["Correct_Ans"].ToString();

                }

                enabled_up_del();
                btnsubmit.Visible = false;
            }
            catch
            {
                Response.Write("<script>alert('Please Select Semester First Which Conints This Subject.. ')</script>");
            }

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
        ds = conn.select("select * from que_m q,sub_m s,sem_m sem where q.sub_id = s.sub_id and sem.sem_id = s.sem_id order by q.que_id desc");
        gf.fill_grid(ds, Grdquestion);


    }

    public void binddrp()
    {
        gf.fillcombo("select * from sem_m", drpsem, "sem_name", "sem_id", "");
        
        gf.fillcombo("select * from unit_m", drpunit, "unit_name", "unit_id", "");
        gf.fillcombo("select * from complex_que_m", drpcomplexity, "complex_type", "complex_id", "");
    }

   
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      
        try
        {
            DataSet ds = new DataSet();
            string qry = "insert into que_m (unit_id,sub_id,complex_id,que_text,o1,o2,o3,o4,correct_ans) values (" + drpunit.SelectedValue + "," + drpsub.SelectedValue + "," + drpcomplexity.SelectedValue + ",'" + txtquestion.Text + "','" + txto1.Text + "','" + txto2.Text + "','" + txto3.Text + "','" + txto4.Text + "','" + txt_c_ans.Text + "')";
             conn.modify(qry);
             Response.Write("<script>alert('Objective Question Inserted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Objective Question Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "update que_m set unit_id = '" + drpunit.SelectedValue + "',sub_id='" + drpsub.SelectedValue + "',complex_id='" + drpcomplexity.SelectedValue + "',que_text = '" + txtquestion.Text + "',o1='" + txto1.Text + "',o2='" + txto2.Text + "',o3='" + txto3.Text + "',o4='" + txto4.Text + "',correct_ans = '" + txt_c_ans.Text + "'  where que_id = " + hdnquestion.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Objective Question Updated Successfully')</script>");

            bindgrid();
            clearall(this);
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Objective Question Not Updated & Something Went Wrong...!')</script>");
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "delete from que_m where que_id = " + hdnquestion.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Objective Question Deleted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Objective Question Not Deleted & Something Went Wrong...!')</script>");
        }
    }
    protected void drptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(drptype.SelectedItem) == "True False")
        {
            txto3.Enabled = false;
            txto4.Enabled = false;
        }
        else
        {
            txto3.Enabled = true;
            txto4.Enabled = true;
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
    protected void Grdquestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grdquestion.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void Grdquestion_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clearall(this);
    }
    protected void drpsem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gf.fillcombo("select * from sub_m s,sem_m s1 where s.sem_id=" + drpsem.SelectedValue + " and s.sem_id=s1.sem_id", drpsub, "sub_name", "sub_id", "");
        }
        catch
        {
            Response.Write("<script>alert('Please Select Semester First Which Conints This Subject.. ')</script>");
        }
    }
}