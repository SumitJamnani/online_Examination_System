using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class frmreg : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        txtdatecalext.EndDate = Convert.ToDateTime("2010/01/01");
         
        if (!IsPostBack)
        {
            sec_que();
            gender();
            drp_sem();
            binddrp();
            bind_division();
                    
        }
    }

    public void bind_division()
    {
        drpdivision.Items.Add("A");
        drpdivision.Items.Add("B");
        drpdivision.Items.Add("C");
        drpdivision.Items.Add("D");
    }
    public void drp_sem()
    {
        gf.fillcombo("select * from sem_m",drpsem,"sem_name","sem_id","");
    }
    public void sec_que()
    {
        gf.fillcombo("select * from sec_m",drpsecque,"sec_que","sec_id","");
    }
    public void gender()
    {
        rblgender.Items.Add("Male");
        rblgender.Items.Add("Female");
    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select * from registration_m r,city_m c where r.city_id=c.city_id");
        gf.fill_grid(ds, grdreg);
        btnsubmit.Enabled = true;

    }
    public void binddrp()
    {
        gf.fillcombo("select * from city_m", drpcity, "city_name", "city_id", "");
        gf.fillcombo("select * from sec_m", drpsecque, "sec_que", "sec_id", "");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            Int16 id = 0;
            string cyear = DateTime.Now.ToString("yyyy");


            //string email = txtemail.Text;
            //DirectoryInfo thisFolder = new DirectoryInfo(Server.MapPath(DateTime.Now.Year.ToString()));
            //if (thisFolder.Exists)
            //{

            //    DirectoryInfo thisFolder1 = new DirectoryInfo(Server.MapPath(drpsem.SelectedValue));

            //    if (thisFolder1.Exists)
            //    {


            //    }
            //    else
            //    {
            //        DirectoryInfo thisFolder2 = new DirectoryInfo(Server.MapPath(drpsem.SelectedValue));
            //        thisFolder2.Create();
            //    }

            //}
            //else
            //{
            //    DirectoryInfo thisFoldernew = new DirectoryInfo(Server.MapPath(DateTime.Now.Year.ToString()));
            //    thisFoldernew.Create();

            //}



            String s1 = Server.MapPath("photoimage") + "/" + flupload.FileName;
            if (s1.EndsWith(".jpg") || s1.EndsWith(".png"))
            {
                if (flupload.HasFile == true)
                {
                    flupload.SaveAs(s1);
                    Response.Write("File upload successfully");
                    

                }
                else
                {
                    Response.Write("File not uploaded");
                }
            }
            else
            {
                Response.Write("Selected file is not image file");
            }


            string qry = "if not exists select email from registration_m where email = '" + txtemail.Text + "' insert into registration_M (email,f_name,m_name,l_name,gender,dob,add_1,add_2,city_id,photo,recaptcha,semester,division,roll_no) values ('" + txtemail.Text + "','" + txtfname.Text + "','" + txtmname.Text + "','" + txtlname.Text + "','" + rblgender.SelectedValue + "','" + txtdate.Text + "','" + txtadd1.Text + "','" + txtadd2.Text + "'," + drpcity.SelectedValue + ",'" + s1 + "','" + txtrecaptcha.Text + "','" + drpsem.SelectedValue + "','"+drpdivision.SelectedItem+"','"+txtrollno.Text+"')";
            conn.modify(qry);
            
            ds = conn.select("select sec_id from sec_m where sec_id = "+drpsecque.SelectedValue+"");
            id = Convert.ToInt16(ds.Tables[0].Rows[0][0]);

            qry = "if not exists select email from login_m where email = '" + txtemail.Text + "'  insert into login_M (email,password,type_fsd,sec_id,sec_ans) values ('" + txtemail.Text + "','" + txtpassword.Text + "','s'," + id + ",'" + txtsecans.Text + "')";
            conn.modify(qry);
            clearall(this);

            
        }
        catch (Exception ex)
        {
            lbl.Text = ex.ToString();
        }
        //cptCaptcha.ValidateCaptcha(txtrecaptcha.Text.Trim());
        //if (cptCaptcha.UserValidated)
        //{
        //    lblcaptcha.ForeColor = System.Drawing.Color.Green;
        //    lblcaptcha.Text = "Valid text";
        //}
        //else
        //{
        //    lblcaptcha.ForeColor = System.Drawing.Color.Red;
        //    lblcaptcha.Text = "InValid Text";
        //}
        //if (txtrecaptcha.Text == txtrecaptcha.Text.ToUpper())
        //{
        //    cptCaptcha.ValidateCaptcha(txtrecaptcha.Text);
        //    if (cptCaptcha.UserValidated)
        //    {
        //        lblcaptcha.Text = "Valid";
        //    }
        //    else
        //    {
        //        lblcaptcha.Text = "not valid";
        //        txtrecaptcha.Text = "";
        //        txtrecaptcha.Focus();
        //    }
        //}
        //else
        //{
        //    lblcaptcha.Text = "not valid";
        //}
    }
    protected void grdreg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Reg_Id")
            {
                hdnregid.Value = e.CommandArgument.ToString();
                string str3 = "select * from Registration_M WHERE Reg_Id ='" + hdnregid.Value + "' ";
                DataSet ds = new DataSet();
                ds = conn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtfname.Text = ds.Tables[0].Rows[0]["F_Name"].ToString();
                    txtmname.Text = ds.Tables[0].Rows[0]["M_Name"].ToString();
                    txtlname.Text = ds.Tables[0].Rows[0]["L_Name"].ToString();
                    rblgender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                    txtdate.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                    txtadd1.Text = ds.Tables[0].Rows[0]["Add_1"].ToString();
                    txtadd2.Text = ds.Tables[0].Rows[0]["Add_2"].ToString();
                    drpcity.SelectedValue = ds.Tables[0].Rows[0]["City_Id"].ToString();
                    txtpassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                    txtcpassword.Text = ds.Tables[0].Rows[0]["Confirm_Password"].ToString();
                    txtsecans.Text = ds.Tables[0].Rows[0]["Sec_Ans"].ToString();

                }
                btnsubmit.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lbl.Text = ex.ToString();
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

    
}