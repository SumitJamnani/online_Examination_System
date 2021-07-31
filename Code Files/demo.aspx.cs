using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class demo : System.Web.UI.Page
{
    clsEmail mail = new clsEmail();
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        if (!IsPostBack)
        {
            Panel2.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    
        string path = Server.MapPath("~/Videos/videoplayback.mp4");
        //String link = "Videos/" + path;
        Literal1.Text = "<Video width=400 Controls><Source src=" + path + " type=video/mp4></video>";
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        mail.sendEMail("devanshisoni150@gmail.com","hello how are you?");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "Q1")
        {
            Panel2.Visible = true;   
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Yes")
        {
            Response.Write("you have selected yes");
        }
        else
        {
            Response.Write("you have selected no");
        }
    }
}