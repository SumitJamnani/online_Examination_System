using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmlogin_m : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
  
    public void clearall()
    {
        txtemail.Text = "";
        txtpassword.Text = "";
       
    }
  
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

   
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
         

            DataSet ds = new DataSet();

            string qry = "select l.email,l.status ,type_fsd, reg_id  from login_m l, registration_m r where l.email = '" + txtemail.Text + "' and l.password = '" + txtpassword.Text + "' and l.email=r.email";
            ds = conn.select(qry);
            string type = ds.Tables[0].Rows[0][2].ToString();
            if (type == "s")
            {
                string qry1 = "update login_m set status=1 where email = '" + txtemail.Text + "' and password = '" + txtpassword.Text + "'";
                conn.modify(qry1);
            }
            //if (ds.Tables[0].Rows[0]["type_fsd"] == "f" || ds.Tables[0].Rows[0]["type_fsd"] == "d" || ds.Tables[0].Rows[0]["type_fsd"] == "a")
            //{

            //    string qry3 = "select l.email,l.status ,type_fsd, reg_id  from login_m l, registration_m r where l.type_fsd in('a','d','f') and l.email=r.email";
            //    ds = conn.select(qry3);

            //    for (Int32 i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //    {
            //        string qry2 = "update login_m set status=0 where email like '" + ds.Tables[0].Rows[i][0] + "'";
            //        conn.modify(qry2);
            //    }

            //}
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt16(ds.Tables[0].Rows[0]["status"]) == 0)
                {
                    Session["email"] = txtemail.Text;
                    Session["Regid"] = ds.Tables[0].Rows[0]["reg_id"].ToString();
                    string usertype = ds.Tables[0].Rows[0]["type_fsd"].ToString();
                    lblmsg.Text = "Login success";
                    if (usertype.ToString().ToLower().Trim() == "s")
                        //Response.Redirect("frm_exam_list.aspx");
                        Server.Transfer("frm_exam_list.aspx", false);
                    else if (usertype.ToString().ToLower().Trim() == "f")
                        Response.Redirect("frm_admin_main.aspx");
                    else if (usertype.ToString().ToLower().Trim() == "d")
                        Response.Redirect("frm_admin_main.aspx");
                    else if (usertype.ToString().ToLower().Trim() == "a")
                        Response.Redirect("frm_admin_main.aspx");

                }
                else
                {
                    Response.Write("<script>alert('You Are Already LoggedIn!!')</script>");
                }

            }
            else
            {
                lblmsg.Text = "Incorrect Email Or Password!!";
                lblmsg.ForeColor = System.Drawing.Color.Black;
                Response.Write("<script>alert('Incorrect Email Or Password!!')</script>");
                
            }
           
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Incorrect Email Or Password!!";
            lblmsg.ForeColor = System.Drawing.Color.Black;
        }
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        clearall();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}