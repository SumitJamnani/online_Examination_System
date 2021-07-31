using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frm_subsection : System.Web.UI.Page
{
    db_conn db = new db_conn();
    General_Function gf = new General_Function();
    public string[] romanstr={"i","ii","iii","iv","v","vi","vii","viii","ix","x"};
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["alpha"] = "false";
            Session["roman"] = "false";
            Session["startok"] = "false";
            binddrptemp();
        }
    }
    public void binddrptemp()
    {
        string s = "select * from temp_m";
        gf.fillcombo(s, drptemp, "temp_name", "temp_id", "--select--");
    }
    public void binddrpsec()
    {
        string s = "select * from section_m where temp_id = " + drptemp.SelectedValue + "";
        gf.fillcombo(s, drpsec, "section_name", "section_id", "--select--");
    }

    public void binddrpque()
    {
        string s = "select * from section_m s,sub_Section_m s1 where s1.section_id = " + drpsec.SelectedValue + " and s.temp_id = " + drptemp.SelectedValue + "";
        gf.fillcombo(s, drpque, "label", "sub_Section_id", "--select--");

    }

    //same as above
    public void same_as_above()
    {
        

    }














    protected void btnsameas_Click(object sender, EventArgs e)
    {
        try
        {
            //for retreiving new question id 
            same_as_above();

        }
        catch
        {
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //update in sub_section_m 
            //bind noofsections
            string temp3 = "update sub_section_m set noofsections = " + txtsubque.Text + " where sub_section_id = " + drpque.SelectedValue + " and section_id = " + drpsec.SelectedValue + "";
            db.modify(temp3);
            //bind type
            string bindtype = "update sub_section_m set q_type='" + rblquetype.SelectedItem + "' where sub_section_id = " + drpque.SelectedValue + " and section_id = " + drpsec.SelectedValue + "";
            db.modify(bindtype);

            DataSet ds2 = new DataSet();
            ds2 = db.select("select sub_section_id from sub_section_m where sub_section_id = " + drpque.SelectedValue);
            Session["parent_id"] = ds2.Tables[0].Rows[0][0];
            try
            {
                Int16 i;
                for (i = 1; i <= Convert.ToInt16(txtsubque.Text); i++)
                {string temp2 ="";

                    if (Session["alpha"].ToString() == "false") 
                        temp2 = "insert into sub_section_m(section_id,label,parent_id) values(" + drpsec.SelectedValue + ", '" + Convert.ToChar(i+64).ToString() + "'," + Session["parent_id"] + ")";
                    else  if (Session["alpha"].ToString() == "true" && Session["roman"].ToString() == "false")
                        temp2 = "insert into sub_section_m(section_id,label,parent_id) values(" + drpsec.SelectedValue + ", '" + romanstr[i-1].ToString() + "'," + Session["parent_id"] + ")";
                    else
                        temp2 = "insert into sub_section_m(section_id,label,parent_id) values(" + drpsec.SelectedValue + ", " + i  + "," + Session["parent_id"] + ")";
                    db.modify(temp2);


                }
               
                Session["alpha"]= "true";

            }
            catch
            {

            }
            Load_tree1();
            Response.Write("<script>alert('Sub Section Created Successfully')</script>");
            txtsubque.Text = "";
            //rblquetype.ClearSelection();
        }
        catch
        {

            Response.Write("<script>alert('Please Enter Properly!')</script>");
        }
    }
    protected void drptemp_SelectedIndexChanged(object sender, EventArgs e)
    {

        binddrpsec();

    }


    protected void drpsec_SelectedIndexChanged(object sender, EventArgs e)
    {
        //binddrpque();
        try
        {
            Load_tree1();
            string s = "with cat_tree as (select sub_section_id,label,parent_id,section_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id,child.section_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 and section_id= " + drpsec.SelectedValue + " order by parent_id";
            gf.fillcombo(s,drpsame,"label","sub_section_id","select");


        }
        catch (Exception ex)
        { }


    }


    //drpdown in tree style
    public void Load_tree1()
    {
        drpque.Items.Clear();
        //DataSet PrSet = db.select("with cat_tree as (select sub_section_id,label,parent_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 and  order by parent_id");
        DataSet PrSet = db.select("with cat_tree as (select sub_section_id,label,parent_id,section_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id,child.section_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 and section_id = " + drpsec.SelectedValue + " order by parent_id");
        if (PrSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in PrSet.Tables[0].Rows)
            {

                string value = dr["sub_section_id"].ToString();
                ListItem li = new ListItem();
                li.Text = dr["label"].ToString();
                li.Value = value;

                drpque.Items.Add(li);

                FillChild1(dr["label"].ToString(), value);
            }
        }
        else
        {
            Response.Write("There Is No Quesions Available Of This Section!!");
        }


    }


    //drpdown in tree style
    public void Load_tree2()
    {
        drpque.Items.Clear();
        //DataSet PrSet = db.select("with cat_tree as (select sub_section_id,label,parent_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 and  order by parent_id");
        DataSet PrSet = db.select("with cat_tree as (select sub_section_id,label,parent_id,section_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id,child.section_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 and section_id = " + drpque.SelectedValue + " order by parent_id");
        if (PrSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in PrSet.Tables[0].Rows)
            {

                string value = dr["sub_section_id"].ToString();
                ListItem li = new ListItem();
                li.Text = dr["label"].ToString();
                li.Value = value;

                drpque.Items.Add(li);

                FillChild2(dr["label"].ToString(), value);
            }
        }
        else
        {
            Response.Write("There Is No Quesions Available Of This Section!!");
        }

    }










    public int FillChild1(string parent, string IID)
    {
        DataSet ds = db.select("SELECT * FROM Sub_Section_M WHERE Parent_ID =" + IID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                string temp = dr["sub_section_id"].ToString();
                ListItem li = new ListItem();
                li.Text = dr["label"].ToString();
                li.Value = temp;

                drpque.Items.Add(li);

                FillChild1(Convert.ToString(dr["label"]), temp);
            }
            return 0;
        }
        else
        {
            return 0;
        }
    }



    public int FillChild2(string parent, string IID)
    {
        DataSet ds = db.select("SELECT * FROM Sub_Section_M WHERE Parent_ID =" + IID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                string temp = dr["sub_section_id"].ToString();
                //ListItem li = new ListItem();
                //li.Text = dr["label"].ToString();
                //li.Value = temp;

                //drpque.Items.Add(li);
                string s2 = "insert into sub_section_m(sub_section_id,section_id,)";
                FillChild2(Convert.ToString(dr["label"]), temp);
            }
            return 0;
        }
        else
        {
            return 0;
        }
    }






    public void tallymarks()
    {
        // string chkqry ="select * from sub_section_m where parent_id
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //tallymarks(drpque.SelectedValue,);

        string qryupdate = "Update sub_section_M set q_type = '" + rblquetype.SelectedItem + "', marks='" + txtmarks.Text + "' where sub_section_id='" + drpque.SelectedValue + "'";
        db.modify(qryupdate);

        string fetchQlist = "with cat_tree as (select sub_section_id,label,parent_id,section_id, marks, q_type ";
        fetchQlist += " from Sub_Section_M union all ";
        fetchQlist += " select child.sub_section_id, child.label, child.parent_id,child.section_id, child.marks, child.q_type ";
        fetchQlist += " from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id) ";
        fetchQlist += " select distinct* from cat_tree where cat_tree.section_id = '" + drpsec.SelectedValue + "' order by parent_id ";
        //DataSet dsmarks = new DataSet();
        //dsmarks = db.select(fetchQlist);
        //gf.fill_grid(dsmarks, grdmarks);
        fetchtree();
        txtmarks.Text = "";
        rblquetype.ClearSelection();
    }
    public void fetchtree()
    {
        fetchparents();
    }
    public void fetchparents()
    {
        DataSet PrSet = db.select("with   cat_tree as (select sub_section_id,label,parent_id, section_Id, marks,q_type from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id , child.section_Id , child.marks, child.q_type from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 and section_id='" + drpsec.SelectedValue + "' order by parent_id");
        TreeView1.Nodes.Clear();
        foreach (DataRow dr in PrSet.Tables[0].Rows)
        {
            //if ((int)dr["Parent_ID"] == 0)
            {
                TreeNode tnParent = new TreeNode();
                //tnParent.Text = dr["label"].ToString() + "#" + dr["marks"].ToString();
                tnParent.Text = dr["label"].ToString() + "#" + dr["marks"].ToString() + " " + dr["q_type"].ToString();
                string value = dr["sub_section_id"].ToString();
                tnParent.Expand();
                TreeView1.Nodes.Add(tnParent);
                Filltreechild(tnParent, value);
            }
        }
    }

    public int Filltreechild(TreeNode parent, string IID)
    {
        DataSet ds = db.select("SELECT * FROM Sub_Section_M WHERE Parent_ID =" + IID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode child = new TreeNode();
                child.Text = dr["label"].ToString().Trim() + "#" + dr["marks"].ToString().Trim() + " " + dr["q_type"].ToString().Trim();
                string temp = dr["sub_section_id"].ToString();
                child.Expand();
                parent.ChildNodes.Add(child);
                Filltreechild(child, temp);
            }
            return 0;
        }
        else
        {
            return 0;
        }
    }

    protected void drpque_SelectedIndexChanged(object sender, EventArgs e)
    {
        fetchtree();
        txtmarks.Text = "";
        //txtsubque.Text = "";
        //rblquetype.ClearSelection();
    }
    protected void btntemp_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_template.aspx");
    }
    protected void btnsec_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_section.aspx");
    }



    protected void btnnext_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_Gen_Paper.aspx");
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        rblquetype.ClearSelection();
    }
    protected void txtsubque_TextChanged(object sender, EventArgs e)
    {

    }
}