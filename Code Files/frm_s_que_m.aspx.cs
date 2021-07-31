using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frm_s_que_m : System.Web.UI.Page
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
    protected void grdsquestion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "S_Que_Id")
        {
            hdnsquestion.Value = e.CommandArgument.ToString();
            string str3 = "select * from S_Que_m WHERE S_Que_Id ='" + hdnsquestion.Value + "' ";
            DataSet ds = new DataSet();
            ds = conn.select(str3);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpunit.SelectedValue = ds.Tables[0].Rows[0]["Unit_Id"].ToString();
                drpsub.SelectedValue = ds.Tables[0].Rows[0]["Sub_Id"].ToString();
                txtquestion.Text = ds.Tables[0].Rows[0]["Que_Text"].ToString();
                txtmarks.Text = ds.Tables[0].Rows[0]["min_value"].ToString();
                txtmarksm.Text = ds.Tables[0].Rows[0]["max_value"].ToString();
                //drpgroup.SelectedValue = ds.Tables[0].Rows[0]["group_id"].ToString();
                //drptag.SelectedValue = ds.Tables[0].Rows[0]["tag_id"].ToString();

            }
            enabled_up_del();
            btnsubmit.Visible = false;


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
        ds = conn.select("select * from s_que_m q,sub_m s,sem_m sem where q.sub_id = s.sub_id and sem.sem_id = s.sem_id order by q.s_que_id desc");
        gf.fill_grid(ds, Grdsquestion);


    }

    public void binddrp()
    {
        gf.fillcombo("select * from sem_m", drpsem, "sem_name", "sem_id", "");
        gf.fillcombo("select * from sub_m", drpsub, "sub_name", "sub_id", "");
        gf.fillcombo("select * from unit_m", drpunit, "unit_name", "unit_id", "");
        //gf.fillcombo("select * from group_m", drpgroup, "group_name", "group_id", "");
        //gf.fillcombo("select * from tag_m", drptag, "tag_name", "tag_id", "");
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
    protected void Grdsquestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grdsquestion.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            string qry = "insert into s_que_m (unit_id,sub_id,que_text,min_value,max_value) values (" + drpunit.SelectedValue + "," + drpsub.SelectedValue + ",'" + txtquestion.Text + "'," + txtmarks.Text + "," + txtmarksm.Text + ")";
            conn.modify(qry);
            Response.Write("<script>alert('Subjective Question Inserted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Subjective Question Not Inserted & Something Went Wrong...!')</script>");
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "update s_que_m set unit_id = '" + drpunit.SelectedValue + "', sub_id='" + drpsub.SelectedValue + "', que_text = '" + txtquestion.Text + "', min_value=" + txtmarks.Text + ", max_value=" + txtmarks.Text + " where s_que_id = " + hdnsquestion.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Subjective Question Updated Successfully')</script>");

            bindgrid();
            clearall(this);
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Subjective Question Not Updated & Something Went Wrong...!')</script>");
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clearall(this);
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string qry = "delete from s_que_m where s_que_id = " + hdnsquestion.Value;
            conn.modify(qry);
            Response.Write("<script>alert('Subjective Question Deleted Successfully')</script>");
            bindgrid();
            clearall(this);
            disabled_up_del();
            btnsubmit.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Subjective Question Not Deleted & Something Went Wrong...!')</script>");
        }
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