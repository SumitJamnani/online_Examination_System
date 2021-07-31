using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmfactsub : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
            binddrp();
        }
        UpdateDeleteHide();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try{
        string qry = "insert into faculty_sub(fact_id,sub_id) values("+drpfact.SelectedValue+","+drpsub.SelectedValue+")";
        conn.modify(qry);
        bindgrid();
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
        }
    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select * from faculty_sub f,registration_m r,sub_m s2 , sem_m s1 where f.fact_id=r.reg_id and f.sub_id=s2.sub_id and s2.sem_id = s1.sem_id order by id desc   ");
        gf.fill_grid(ds, grdfactsub);
        btnsubmit.Visible = true;

    }
    public void binddrp()
    {
        gf.fillcombo("select * from registration_m r,login_m l where r.email=l.email and l.type_fsd='f'", drpfact, "f_name", "reg_id", "");
        gf.fillcombo("select * from sub_m", drpsub, "sub_name", "sub_id", "");
        gf.fillcombo("select * from sem_m", drpsem, "sem_name", "sem_id", "Select semester");
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try{
        String qry = "update faculty_sub set fact_id=" + drpfact.SelectedValue + ",sub_id=" + drpsub.SelectedValue+ " where id="+hiddenfactsubid.Value ;
       conn.modify(qry);
       bindgrid();
       SubmitShow();
       ClearAll(this);
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
        }
     
    }
    protected void  btndelete_Click(object sender, EventArgs e)
{
        try{
        String qry = "delete from faculty_sub where id=" + hiddenfactsubid.Value;
        conn.modify(qry);
        bindgrid();
        SubmitShow();
        ClearAll(this);
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
        }
}

    protected void grid_factsub_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try{
        
            if (e.CommandName == "Id")
            {
                hiddenfactsubid.Value = e.CommandArgument.ToString();
                string str3 = "select * from sub_m s,faculty_sub f WHERE s.sub_id=f.sub_id and id='" + hiddenfactsubid.Value +"'";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpsem.SelectedValue = ds.Tables[0].Rows[0]["Sem_Id"].ToString();
                    drpfact.SelectedValue = ds.Tables[0].Rows[0]["Fact_Id"].ToString();
                    drpsub.SelectedValue = ds.Tables[0].Rows[0]["Sub_Id"].ToString();
                }
                UpdateDeleteShow();
            }
        }
        catch (Exception ex)
        {
            label_error.Text = ex.ToString();
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

    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearAll(this);
        SubmitShow();
    }

    protected void grdfactsub_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdfactsub.PageIndex = e.NewPageIndex;
    }

}