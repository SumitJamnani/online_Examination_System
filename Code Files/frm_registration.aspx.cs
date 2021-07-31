using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class frm_registration : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtdatecalext.EndDate = Convert.ToDateTime("2010/01/01");
        if (!IsPostBack)
        {
            binddrp();
            drp_sem();
            sec_que();
            gender();
            bind_division();
        }
    }
    public void binddrp()
    {
        gf.fillcombo("select * from city_m", drpcity, "city_name", "city_id", "");
        gf.fillcombo("select * from sec_m", drpsecque, "sec_que", "sec_id", "");
    }
    public void drp_sem()
    {
        gf.fillcombo("select * from sem_m", drpsem, "sem_name", "sem_id", "");
    }
    public void sec_que()
    {
        gf.fillcombo("select * from sec_m", drpsecque, "sec_que", "sec_id", "");
    }
    public void bind_division()
    {
        drpdivision.Items.Add("A");
        drpdivision.Items.Add("B");
        drpdivision.Items.Add("C");
        drpdivision.Items.Add("D");
    }
    public void gender()
    {
        rblgender.Items.Add("Male");
        rblgender.Items.Add("Female");
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



            //String s1 = Server.MapPath("photoimage") + "/" + flupload.FileName;
            //if (s1.EndsWith(".jpg") || s1.EndsWith(".png"))
            //{
            //    if (flupload.HasFile == true)
            //    {
            //        flupload.SaveAs(s1);
            //        Response.Write("File upload successfully");


            //    }
            //    else
            //    {
            //        Response.Write("File not uploaded");
            //    }
            //}
            //else
            //{
            //    Response.Write("Selected file is not image file");
            //}


            string qry = "if not exists select email from registration_m where email = '" + txtemail.Text + "' (insert into registration_M (email,f_name,m_name,l_name,gender,dob,add_1,add_2,city_id,semester,division) values ('" + txtemail.Text + "','" + txtfname.Text + "','" + txtmname.Text + "','" + txtlname.Text + "','" + rblgender.SelectedValue + "','" + txtdate.Text + "','" + txtadd1.Text + "','" + txtadd2.Text + "'," + drpcity.SelectedValue + ",'" + drpsem.SelectedValue + "','" + drpdivision.SelectedItem + "'))";
            conn.modify(qry);

            ds = conn.select("select sec_id from sec_m where sec_id = " + drpsecque.SelectedValue + "");
            id = Convert.ToInt16(ds.Tables[0].Rows[0][0]);

            qry = "if not exists select email from login_m where email = '" + txtemail.Text + "'  insert into login_M (email,password,type_fsd,sec_id,sec_ans) values ('" + txtemail.Text + "','" + txtpassword.Text + "','s'," + id + ",'" + txtsans.Text + "')";
            conn.modify(qry);
            Response.Write("<script>alert('Student Inserted Successfully')</script>");
            clearall(this);


        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Student Not Inserted & Something Went Wrong...!')</script>");
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