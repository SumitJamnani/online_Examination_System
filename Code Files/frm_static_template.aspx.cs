using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frm_static_template : System.Web.UI.Page
{
    db_conn db = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindgrid();
        }
        main_panel();

    }

    public void main_panel()
    {
        pnltemp.Visible = true;
        pnlsection.Visible = false;
        pnlsubsection.Visible = false;
        pnlsubsection1.Visible = false;
        pnlquestion.Visible = false;
        pnlquestion1.Visible = false;
        pnlquestion2.Visible = false;
    }


    public void panel1()
    {
        pnltemp.Visible = false;
        pnlsection.Visible = true;
        pnlsubsection.Visible = false;
        pnlsubsection1.Visible = false;
        pnlquestion.Visible = false;
        pnlquestion1.Visible = false;
        pnlquestion2.Visible = false;
    }

    public void panel2()
    {
        pnltemp.Visible = false;
        pnlsection.Visible = false;
        pnlsubsection.Visible = true;
        pnlsubsection1.Visible = false;
        pnlquestion.Visible = false;
        pnlquestion1.Visible = false;
        pnlquestion2.Visible = false;
    }

    public void panel3()
    {
        pnltemp.Visible = false;
        pnlsection.Visible = false;
        pnlsubsection.Visible = false;
        pnlsubsection1.Visible = true;
        pnlquestion.Visible = false;
        pnlquestion1.Visible = false;
    }
    public void panel4()
    {
        pnltemp.Visible = false;
        pnlsection.Visible = false;
        pnlsubsection.Visible = false;
        pnlsubsection1.Visible = false;
        pnlquestion.Visible = true;
        pnlquestion1.Visible = false;
        pnlquestion2.Visible = false;

    }
    public void panel6()
    {
        pnltemp.Visible = false;
        pnlsection.Visible = false;
        pnlsubsection.Visible = false;
        pnlsubsection1.Visible = false;
        pnlquestion.Visible = false;
        pnlquestion1.Visible = true;
        pnlquestion2.Visible = false;
    }
    public void panel7()
    {
        pnltemp.Visible = false;
        pnlsection.Visible = false;
        pnlsubsection.Visible = false;
        pnlsubsection1.Visible = false;
        pnlquestion.Visible = false;
        pnlquestion1.Visible = false;
        pnlquestion2.Visible = true;
    }
    public void or_show()
    {
        drpor.Visible = true;
        txtormarks.Visible = true;
        rblorquetype.Visible = true;
    }
    public void or_hide()
    {
        drpor.Visible = false;
        txtormarks.Visible = false;
        rblorquetype.Visible = false;
    }


    protected void btnsave1_Click(object sender, EventArgs e)
    {

        Session["marks"] = Convert.ToString(Convert.ToInt32(Session["marks"]) - Convert.ToInt32(txtsecmarks.Text));
        //for section marks



        if (Convert.ToInt32(txtsecmarks.Text) > Convert.ToInt32(Session["marks"]) && Convert.ToInt32(txtsecmarks.Text) == Convert.ToInt32(Session["marks"]))
        {
            lblsecmarks.Text = "There Is No Such Limited Marks Remians In Template";
            panel1();
        }
        else
        {

        
            lblsecmarks.Text = Session["marks"].ToString();
            try
            {

                //section_m
                string temp1 = "insert into section_m(section_name,temp_id,marks,noofquestions) values('" + txtsecname.Text + "'," + Session["temp_id"] + "," + txtsecmarks.Text + "," + txtsubsec.Text + ")";
                db.modify(temp1);
                //section_id
                DataSet ds_sid = new DataSet();
                ds_sid = db.select("select max(section_id) from section_m");
                Session["section_id"] = ds_sid.Tables[0].Rows[0][0];


                //sub_section_m
                Int16 i;
                for (i = 1; i <= Convert.ToInt16(txtsubsec.Text); i++)
                {
                    string temp2 = "insert into sub_section_m(section_id,label,parent_id) values(" + Session["section_id"] + ",'Q." + i + "',0)";
                    db.modify(temp2);
                }
                bindgrid();
                panel1();

            }
            catch
            {

                Response.Write("<script>alert('Please Enter Properly!')</script>");
            }

        }


    }



    protected void btnnext_Click(object sender, EventArgs e)
    {
        Session["marks"] = txtmarks.Text;
        string t_mk = "select * from temp_m where temp_id='" + Session["temp_id"] + "'";
        DataSet ds_t_mk = new DataSet();
        ds_t_mk = db.select(t_mk);
        lblsecmarks.Text = Session["marks"].ToString();
        //try
        //{
        panel1();
        string temp = "insert into temp_m(temp_name,tot_marks,tot_sub_que,tot_obj_que,gen_date) values('" + txttpname.Text + "'," + txtmarks.Text + "," + txtsubjective.Text + "," + txtobjective.Text + ",'" + DateTime.Now.ToShortDateString() + "')";
        db.modify(temp);


        DataSet ds_tid = new DataSet();
        ds_tid = db.select("select max(temp_id) from temp_m");
        Session["temp_id"] = ds_tid.Tables[0].Rows[0][0];
        //}
        //catch
        //{

        //    Response.Write("<script>alert('Please Enter Properly!')</script>");

        //}

    }
    protected void btnsave2_Click(object sender, EventArgs e)
    {
        
        
        Session["marks1"] = Convert.ToString(Convert.ToInt32(Session["marks1"]) - Convert.ToInt32(txtsubsecmarks.Text));

        if (Convert.ToInt32(txtsubsecmarks.Text) < Convert.ToInt32(Session["marks1"]) && Convert.ToInt32(txtsubsecmarks.Text) == Convert.ToInt32(Session["marks1"]) && Convert.ToInt32(Session["marks1"])<=0)
        {
            lblsubsecmarks.Text = "There Is No Such Limited Marks Remians In Template";
        }
        else
        {
            lblsubsecmarks.Text = Session["marks1"].ToString();
            try
            {
                //update in sub_section_m
                string temp3 = "update sub_section_m set noofsections = " + txtsubsec1.Text + ", marks =" + txtsubsecmarks.Text + " where sub_section_id = " + drpsubsection.SelectedValue + " and section_id = " + drpsection.SelectedValue + "";
                db.modify(temp3);


                //parent_id
                DataSet ds2 = new DataSet();
                ds2 = db.select("select sub_section_id,section_id from sub_section_m where sub_section_id = " + drpsubsection.SelectedValue + " and section_id = " + drpsection.SelectedValue + " and label not in (select label from sub_Setion_m where )");
                Session["parent_id"] = ds2.Tables[0].Rows[0][0];
                Session["section_id"] = ds2.Tables[0].Rows[0][1];


                //question 
                Int16 i;
                for (i = 1; i <= Convert.ToInt16(txtsubsec1.Text); i++)
                {
                    string temp2 = "insert into sub_section_m(section_id,label,parent_id) values(" + Session["section_id"] + ", " + i + "," + Session["parent_id"] + ")";
                    db.modify(temp2);
                }

                bindsection("2");
                panel2();
            }
            catch
            {

                Response.Write("<script>alert('Please Enter Properly!')</script>");
            }
        }
    }
    protected void btnnext1_Click(object sender, EventArgs e)
    {

        panel2();

        //section
        DataSet ds = new DataSet();
        string s = "select * from section_m where temp_id = " + Session["temp_id"] + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s, drpsection, "section_name", "section_id", "--select--");

        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from sub_section_m where section_id = " + drpsection.SelectedValue + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s1, drpsubsection, "label", "sub_section_id", "--select--");



    }
    protected void btnnext2_Click(object sender, EventArgs e)
    {
        panel3();
        //section
        DataSet ds = new DataSet();
        string s = "select * from section_m where temp_id = " + Session["temp_id"] + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id
        gf.fillcombo(s, drpsection1, "section_name", "section_id", "--select--");







    }

    public void bindsection(string flag1)
    {
        drpsubsection.Items.Clear();
        //subsection
        DataSet ds1 = new DataSet();
        string s1;
        if (flag1 == "1")
            s1 = "select * from sub_section_m where section_id = " + drpsection.SelectedValue + " and parent_id=0";
        else if (flag1 == "2")
            s1 = "select * from sub_section_m where section_id = " + drpsection.SelectedValue + " and parent_id=0 and label not in (Select label from sub_section_m where sub_section_id='" + drpsection.SelectedValue + "'";
        else
            s1 = "";

        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s1, drpsubsection, "label", "sub_section_id", "--select--");

    }
    protected void drpsection_SelectedIndexChanged(object sender, EventArgs e)
    {

        string s = "select * from section_m where section_id=" + drpsection.SelectedValue + " and temp_id='" + Session["temp_id"] + "'";
        DataSet ds = new DataSet();
        ds = db.select(s);
        Session["marks1"] = ds.Tables[0].Rows[0]["marks"];
        lblsubsecmarks.Text = Convert.ToInt32(Session["marks1"]).ToString();

        bindsection("1");

        panel2();

    }
    protected void drpsection1_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpsubsection1.Items.Clear();
        drpsubsec1.Items.Clear();
        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from sub_section_m where section_id = " + drpsection1.SelectedValue + " and parent_id=0";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s1, drpsubsection1, "label", "sub_section_id", "--select--");

        panel3();

    }
    protected void drpsubsection1_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        string s = "select * from Sub_Section_M s,Section_M ss where s.section_id=ss.section_id and s.parent_id=0 and s.sub_section_id="+drpsubsection1.SelectedValue;
        DataSet ds = new DataSet();
        ds = db.select(s);
        Session["quemks"] = ds.Tables[0].Rows[0]["marks"];
        lblsubquemks.Text = Convert.ToInt32(Session["quemks"]).ToString();


        drpsubsec1.Items.Clear();
        //parent_id
        DataSet ds2 = new DataSet();
        ds2 = db.select("select sub_section_id,section_id from sub_section_m where sub_section_id = " + drpsubsection1.SelectedValue + " and section_id = " + drpsection1.SelectedValue + "");
        Session["parent_id"] = ds2.Tables[0].Rows[0][0];
        Session["section_id"] = ds2.Tables[0].Rows[0][1];


        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from  sub_section_m where section_id = " + drpsection1.SelectedValue + " and parent_id = " + Session["parent_id"] + "";
        gf.fillcombo(s1, drpsubsec1, "label", "sub_section_id", "--select--");

        panel3();
    }
    protected void btnsave3_Click(object sender, EventArgs e)
    {

        Session["quemks"] = Convert.ToString(Convert.ToInt32(Session["quemks"]) - Convert.ToInt32(txtsubsecmarks1.Text));

        if (Convert.ToInt32(txtsubsecmarks1.Text) < Convert.ToInt32(Session["quemks"]) && Convert.ToInt32(txtsubsecmarks1.Text) == Convert.ToInt32(Session["quemks"]) && Convert.ToInt32(Session["marks1"]) <= 0)
        {
            lblsubquemks.Text = "There Is No Such Limited Marks Remians In Template";
        }
        else
        {
            lblsubquemks.Text = Session["quemks"].ToString();
            try
            {
                //update in sub_section_m
                string temp3 = "update sub_section_m set noofsections = " + txtsubsec2.Text + ", marks=" + txtsubsecmarks1.Text + " where sub_section_id = " + drpsubsec1.SelectedValue + " and section_id = " + drpsection1.SelectedValue + " and parent_id = " + drpsubsection1.SelectedValue + "";
                db.modify(temp3);


                //parent_id
                DataSet ds2 = new DataSet();
                ds2 = db.select("select sub_section_id,section_id from sub_section_m where sub_section_id = " + drpsubsec1.SelectedValue + " and section_id = " + drpsection1.SelectedValue + " and parent_id = " + drpsubsection1.SelectedValue + "");
                Session["parent_id"] = ds2.Tables[0].Rows[0][0];
                Session["section_id"] = ds2.Tables[0].Rows[0][1];


                //question 
                Int16 i;
                for (i = 1; i <= Convert.ToInt16(txtsubsec2.Text); i++)
                {
                    string temp2 = "insert into sub_section_m(section_id,label,parent_id) values(" + Session["section_id"] + ", '(" + i + ")'," + Session["parent_id"] + ")";
                    db.modify(temp2);
                }
                panel3();
            }
            catch
            {

                Response.Write("<script>alert('Please Enter Properly!')</script>");
            }
        }
    }
    protected void btnnext3_Click(object sender, EventArgs e)
    {
        panel4();
        or_hide();
        //section
        DataSet ds = new DataSet();
        string s = "select * from section_m where temp_id = " + Session["temp_id"] + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id
        gf.fillcombo(s, drpsection2, "section_name", "section_id", "--select--");
    }
    protected void drpsubsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        panel2();
    }
    protected void drpsubsec1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        panel3();
    }


    protected void btnsave4_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtor.Text == "")
            {
                string temp3 = "update sub_section_m set q_type = '" + rblquetype.SelectedItem + "', marks=" + txtselque.Text + " where sub_section_id = " + drpque.SelectedValue + " and section_id = " + drpsection2.SelectedValue + " and parent_id = " + drpsubsec2.SelectedValue + "";
                db.modify(temp3);
            }
            else
            {
                string temp3 = "update sub_section_m set q_type = '" + rblquetype.SelectedItem + "', marks=" + txtselque.Text + " where sub_section_id = " + drpque.SelectedValue + " and section_id = " + drpsection2.SelectedValue + " and parent_id = " + drpsubsec2.SelectedValue + "";
                db.modify(temp3);

                string temp4 = "update or_table set q_type = '" + rblorquetype.SelectedItem + "', marks=" + txtormarks.Text + " where sub_section_id = " + drpque.SelectedValue + " and label='" + drpor.SelectedItem + "'";
                db.modify(temp4);
            }
            panel4();
        }
        catch
        {

            Response.Write("<script>alert('Please Enter Properly!')</script>");
        }
    }
    protected void drpsection2_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpsubsection2.Items.Clear();
        drpsubsec2.Items.Clear();
        drpque.Items.Clear();
        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from sub_section_m where section_id = " + drpsection2.SelectedValue + " and parent_id=0";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s1, drpsubsection2, "label", "sub_section_id", "--select--");
        panel4();

    }
    protected void drpsubsection2_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpsubsec2.Items.Clear();
        drpque.Items.Clear();
        //parent_id
        DataSet ds2 = new DataSet();
        ds2 = db.select("select sub_section_id,section_id from sub_section_m where sub_section_id = " + drpsubsection2.SelectedValue + " and section_id = " + drpsection2.SelectedValue + "");
        Session["parent_id"] = ds2.Tables[0].Rows[0][0];
        Session["section_id"] = ds2.Tables[0].Rows[0][1];


        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from  sub_section_m where section_id = " + drpsection2.SelectedValue + " and parent_id = " + Session["parent_id"] + "";
        gf.fillcombo(s1, drpsubsec2, "label", "sub_section_id", "--select--");

        panel4();
    }
    protected void drpsubsec2_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpque.Items.Clear();
        //parent_id
        DataSet ds2 = new DataSet();
        ds2 = db.select("select sub_section_id,section_id from sub_section_m where sub_section_id = " + drpsubsec2.SelectedValue + " and section_id = " + drpsection2.SelectedValue + "");
        Session["parent_id"] = ds2.Tables[0].Rows[0][0];
        Session["section_id"] = ds2.Tables[0].Rows[0][1];


        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from  sub_section_m where section_id = " + drpsection2.SelectedValue + " and parent_id = " + Session["parent_id"] + "";
        gf.fillcombo(s1, drpque, "label", "sub_section_id", "--select--");
        panel4();
    }

    protected void drpque_SelectedIndexChanged(object sender, EventArgs e)
    {
        panel4();
        clearall(this);
        or_hide();

    }
    protected void lbor_Click(object sender, EventArgs e)
    {
        string temp3 = "update sub_section_m set or_que = " + txtor.Text + " where sub_section_id = " + drpque.SelectedValue + " and section_id = " + drpsection2.SelectedValue + " and parent_id = " + drpsubsec2.SelectedValue + "";
        db.modify(temp3);
        //section_id
        DataSet ds_sid = new DataSet();
        ds_sid = db.select("select sub_section_id=" + drpque.SelectedValue + " from sub_section_m");
        Session["sub_section_id"] = ds_sid.Tables[0].Rows[0][0];


        //sub_section_m
        Int16 i;
        for (i = 1; i <= Convert.ToInt16(txtor.Text); i++)
        {
            string temp2 = "insert into or_table(sub_section_id,label) values(" + Session["sub_section_id"] + ", '(" + i + ")')";
            // string temp2 = "insert into or_table(sub_section_id,marks,q_type) values(" + Session["sub_section_id"] +","+ txtormarks.Text + ",'"+rblorquetype.SelectedItem+"')";
            db.modify(temp2);
        }
        panel4();
        DataSet ds = new DataSet();
        string s = "select * from or_table where sub_section_id = " + Session["sub_section_id"] + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id
        gf.fillcombo(s, drpor, "label", "or_id", "--select--");
        or_show();
        panel4();
    }
    protected void drpor_SelectedIndexChanged(object sender, EventArgs e)
    {
        panel4();
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



    // Panel 6
    protected void btnno_Click(object sender, EventArgs e)
    {
        panel6();
        DataSet ds = new DataSet();
        string s = "select * from section_m where temp_id = " + Session["temp_id"] + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s, drpsection3, "section_name", "section_id", "--select--");

        //subsection
        //DataSet ds1 = new DataSet();
        //string s1 = "select * from sub_section_m where section_id = " + drpsection3.SelectedValue + "";
        ////ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        //gf.fillcombo(s1, drpque3, "label", "sub_section_id", "--select--");
    }

    protected void drpsection3_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpque3.Items.Clear();
        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from sub_section_m where section_id = " + drpsection3.SelectedValue + " and parent_id=0";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s1, drpque3, "label", "sub_section_id", "--select--");

        panel6();
    }
    protected void btnsave5_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtor1.Text == "")
            {
                string temp3 = "update sub_section_m set q_type = '" + rbnquetype1.SelectedItem + "', marks=" + txtquemarks3.Text + " where sub_section_id = " + drpque3.SelectedValue + " and section_id = " + drpsection3.SelectedValue + "";
                db.modify(temp3);
            }
            else
            {
                string temp3 = "update sub_section_m set q_type = '" + rbnquetype1.SelectedItem + "', marks=" + txtquemarks3.Text + " where sub_section_id = " + drpque3.SelectedValue + " and section_id = " + drpsection3.SelectedValue + "";
                db.modify(temp3);

                string temp4 = "update or_table set q_type = '" + rblorquetype1.SelectedItem + "', marks=" + txtormarks1.Text + " where sub_section_id = " + drpque3.SelectedValue + " and label='" + drpor1.SelectedItem + "'";
                db.modify(temp4);
            }
            panel6();
        }
        catch
        {

            Response.Write("<script>alert('Please Enter Properly!')</script>");
        }
    }
    protected void lbor1_Click(object sender, EventArgs e)
    {
        string temp3 = "update sub_section_m set or_que = " + txtor1.Text + " where sub_section_id = " + drpque3.SelectedValue + " and section_id = " + drpsection3.SelectedValue + "";
        db.modify(temp3);
        //section_id
        DataSet ds_sid = new DataSet();
        ds_sid = db.select("select sub_section_id=" + drpque3.SelectedValue + " from sub_section_m");
        Session["sub_section_id"] = ds_sid.Tables[0].Rows[0][0];


        //sub_section_m
        Int16 i;
        for (i = 1; i <= Convert.ToInt16(txtor1.Text); i++)
        {
            string temp2 = "insert into or_table(sub_section_id,label) values(" + Session["sub_section_id"] + ",'Q." + i + "')";
            // string temp2 = "insert into or_table(sub_section_id,marks,q_type) values(" + Session["sub_section_id"] +","+ txtormarks.Text + ",'"+rblorquetype.SelectedItem+"')";
            db.modify(temp2);
        }
        panel6();
        DataSet ds = new DataSet();
        string s = "select * from or_table where sub_section_id = " + Session["sub_section_id"] + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id
        gf.fillcombo(s, drpor1, "label", "or_id", "--select--");
        or_show();
        panel6();
    }



    //penel 7
    protected void btnno2_Click(object sender, EventArgs e)
    {
        panel7();
        DataSet ds = new DataSet();
        string s = "select * from section_m where temp_id = " + Session["temp_id"] + "";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s, drpsection4, "section_name", "section_id", "--select--");

        //subsection
        //DataSet ds1 = new DataSet();
        //string s1 = "select * from sub_section_m where section_id = " + drpsection4.SelectedValue + "";
        ////ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        //gf.fillcombo(s1, drpsubsection4, "label", "sub_section_id", "--select--");
    }
    protected void drpsection4_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpsubsection4.Items.Clear();
        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from sub_section_m where section_id = " + drpsection4.SelectedValue + " and parent_id=0";
        //ds = db.select("select section_name from section_m where temp_id = "+Session["section_id"]+"");
        gf.fillcombo(s1, drpsubsection4, "label", "sub_section_id", "--select--");
        panel7();
    }
    protected void drpsubsection4_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpsubsec4.Items.Clear();
        //parent_id
        DataSet ds2 = new DataSet();
        ds2 = db.select("select sub_section_id,section_id from sub_section_m where sub_section_id = " + drpsubsection4.SelectedValue + " and section_id = " + drpsection4.SelectedValue + "");
        Session["parent_id"] = ds2.Tables[0].Rows[0][0];
        Session["section_id"] = ds2.Tables[0].Rows[0][1];
        //subsection
        DataSet ds1 = new DataSet();
        string s1 = "select * from  sub_section_m where section_id = " + drpsection4.SelectedValue + " and parent_id = " + Session["parent_id"] + "";
        gf.fillcombo(s1, drpsubsec4, "label", "sub_section_id", "--select--");
        panel7();
    }

    protected void btnsave6_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtor2.Text == "")
            {
                string temp3 = "update sub_section_m set q_type = '" + rblquetype2.SelectedItem + "', marks=" + txtquemarks4.Text + " where sub_section_id = " + drpsubsec4.SelectedValue + " and section_id = " + drpsection4.SelectedValue + " and parent_id = " + drpsubsection4.SelectedValue + "";
                db.modify(temp3);
            }
            else
            {
                string temp3 = "update sub_section_m set q_type = '" + rblquetype2.SelectedItem + "', marks=" + txtquemarks4.Text + " where sub_section_id = " + drpsubsec4.SelectedValue + " and section_id = " + drpsection4.SelectedValue + " and parent_id = " + drpsubsection4.SelectedValue + "";
                db.modify(temp3);

                string temp4 = "update or_table set q_type = '" + rblorquetype2.SelectedItem + "', marks=" + txtormarks2.Text + " where sub_section_id = " + drpsubsection4.SelectedValue + " and label='" + drpor2.SelectedItem + "'";
                db.modify(temp4);
            }
            panel7();
        }
        catch
        {

            Response.Write("<script>alert('Please Enter Properly!')</script>");
        }
    }
    protected void lbor2_Click(object sender, EventArgs e)
    {
        string temp3 = "update sub_section_m set or_que = " + txtor2.Text + " where sub_section_id = " + drpsubsec4.SelectedValue + " and section_id = " + drpsection4.SelectedValue + " and parent_id = " + drpsubsection4.SelectedValue + "";
        db.modify(temp3);
        //section_id
        DataSet ds_sid = new DataSet();
        ds_sid = db.select("select sub_section_id=" + drpsubsec4.SelectedValue + " from sub_section_m");
        Session["sub_section_id"] = ds_sid.Tables[0].Rows[0][0];


        //sub_section_m
        Int16 i;
        for (i = 1; i <= Convert.ToInt16(txtor2.Text); i++)
        {
            string temp2 = "insert into or_table(sub_section_id,label) values(" + Session["sub_section_id"] + ", " + i + ")";
            // string temp2 = "insert into or_table(sub_section_id,marks,q_type) values(" + Session["sub_section_id"] +","+ txtormarks.Text + ",'"+rblorquetype.SelectedItem+"')";
            db.modify(temp2);
        }
        panel7();
        DataSet ds = new DataSet();
        string s = "select * from or_table where sub_section_id = " + Session["sub_section_id"] + "";

        gf.fillcombo(s, drpor2, "label", "or_id", "--select--");
        or_show();
        panel7();
    }
    protected void grdpnl1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Section_Id")
            {
                hdngrdpnl1.Value = e.CommandArgument.ToString();
                string str3 = "select * from Section_M WHERE Section_Id ='" + hdngrdpnl1.Value + "' ";
                DataSet ds = new DataSet();
                ds = db.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtsecname.Text = ds.Tables[0].Rows[0]["Section_Name"].ToString();
                    txtsecmarks.Text = ds.Tables[0].Rows[0]["marks"].ToString();
                    txtsubsec.Text = ds.Tables[0].Rows[0]["noofquestions"].ToString();
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('Please Enter Properly!')</script>");
        }
    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = db.select("select * from section_m");
        gf.fill_grid(ds, grdpnl1);
    }
}