using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using word = Microsoft.Office.Interop.Word;

public partial class frm_Gen_Paper : System.Web.UI.Page
{
    public string qstr = "<center><table width='50%' border=1>", questionasked;
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    clsEmail mail = new clsEmail();
    Int16 Chld;
    Int16 prnt;

    string que = "", queno = "", subqueno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            questionasked = ".";
            binddrptemp();
            binddrpsem();
            binddrpunit();
        }
    }
    public void binddrptemp()
    {
        string s = "select * from temp_M";
        gf.fillcombo(s, drptemp, "temp_name", "temp_id", "--select--");
    }
    public void binddrpunit()
    {
        string s = "select * from unit_m";
        gf.fillcombo(s, drpunit, "unit_name", "unit_id", "--select--");
    }
    public void binddrpsem()
    {
        string s = "select * from Sem_M";
        gf.fillcombo(s, drpsem, "sem_name", "sem_id", "--select--");
    }
    public void binddrpsub()
    {

        string s = "select * from Sub_M s1,Sem_M s2 where s1.sem_id = s2.sem_id and s1.sem_id=" + drpsem.SelectedValue;
        gf.fillcombo(s, drpsub, "sub_name", "sub_id", "--select--");
    }

    protected void drpsem_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpsub.Items.Clear();
        string s = "select * from Sub_M s1,Sem_M s2 where s1.sem_id = s2.sem_id and s1.sem_id=" + drpsem.SelectedValue;
        gf.fillcombo(s, drpsub, "sub_name", "sub_id", "--select--");
    }
    protected void drptemp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = "select * from temp_m t,section_m s where t.temp_id=s.temp_id and s.temp_id=" + drptemp.SelectedValue;
        gf.fillcombo(s, drpsection, "section_name", "section_id", "--select--");
    }
    protected void drpsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = "select * from section_m s,sub_Section_m s1 where s.section_id=s1.section_id and s1.parent_id=0 and s.section_id=" + drpsection.SelectedValue;
        gf.fillcombo(s, drpque, "label", "sub_section_id", "--select--");
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string temp_id = drptemp.SelectedValue;
        FillParent();
        lblmsg.Text = drpque.SelectedItem + " binded with unit " + drpunit.SelectedItem + " successfully";
       // fetchparents();
    }


    public void FillParent()
    {
        DataSet PrSet = conn.select("with cat_tree as (select sub_section_id,label,parent_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 order by parent_id");
        foreach (DataRow dr in PrSet.Tables[0].Rows)
        {
            if (Convert.ToInt32(dr["sub_section_id"]) == Convert.ToInt32(drpque.SelectedValue))
            {
                string value = dr["sub_section_id"].ToString();
                string s = "update sub_section_m set unit_id = " + drpunit.SelectedValue + " where sub_section_id = " + value + "";
                conn.modify(s);
                FillChild1(dr["label"].ToString(), value);
            }
        }
    }

    public int FillChild1(string parent, string IID)
    {
        DataSet ds = conn.select("SELECT * FROM Sub_Section_M WHERE Parent_ID =" + IID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                string temp = dr["sub_section_id"].ToString();
                string s = "update sub_section_m set unit_id = " + drpunit.SelectedValue + " where sub_section_id = " + temp + "";
                conn.modify(s);
                FillChild1(Convert.ToString(dr["label"]), temp);
            }
            return 0;
        }
        else
        {
            return 0;
        }
    }

    //generate paper with questions
    protected void btngenpaper_Click(object sender, EventArgs e)
    {
        try
        {
            conn.modify(" drop table tmptab; create table tmptab(subsection varchar(10), parent varchar(10), label varchar(100), marks numeric(10) )");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Went Wrong...!')</script>"); 
        }
        fetchparents();
        string marksmismatch = "";
        DataSet dschkmarks = new DataSet();
        dschkmarks = conn.select("Select * from tmptab where parent=0");
        for (int marksR = 0; marksR < dschkmarks.Tables[0].Rows.Count; marksR++)
        {
            //string parentmarks=dschkmarks.
            DataSet dschkmarks1 = new DataSet();
            dschkmarks1 = conn.select("select SUM(marks) from tmptab where parent='" + dschkmarks.Tables[0].Rows[marksR]["subsection"].ToString() + "'");
            if (dschkmarks1.Tables[0].Rows[0][0].ToString().Trim() != dschkmarks.Tables[0].Rows[marksR]["marks"].ToString().Trim())
            {
                marksmismatch += dschkmarks.Tables[0].Rows[marksR]["label"].ToString() + "</br>";
            }
        }
        if (marksmismatch.ToString().Trim().Length > 25)
            lblmismatch.Text = " Marks Mismatch in -> '" + marksmismatch.ToString();
        else
            lblmismatch.Text = "";

    }





    public void fetchparents()
    {
        DataSet PrSet = conn.select("with   cat_tree as (select sub_section_id,label,parent_id,q_type,unit_id,marks,section_id from Sub_Section_M union all select child.sub_section_id,child.label,child.parent_id,child.q_type,child.unit_id,child.marks,child.section_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 and section_id='" + drpsection.SelectedValue + "' order by parent_id");
        TreeView1.Nodes.Clear();
        foreach (DataRow dr in PrSet.Tables[0].Rows)
        {
            //if ((int)dr["Parent_ID"] == 0)
            {
                TreeNode tnParent = new TreeNode();
                tnParent.Text = "<B>" + dr["label"].ToString() + "</B>";
                queno += dr["label"].ToString() + "[" + dr["marks"].ToString() + "]\n";
                string value = dr["sub_section_id"].ToString();
                if (Convert.ToString(dr["q_type"]) == "Subjective")
                {
                    string s = "select * from s_que_m s1 where s1.unit_id = " + dr["unit_id"] + " and s1.sub_id = " + drpsub.SelectedValue + "";
                    DataSet ds = new DataSet();
                    ds = conn.select(s);
                    try
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                string a = questionasked.ToString();
                            }
                            catch (Exception ex)
                            { questionasked = "."; }

                            if (questionasked.ToString().IndexOf(ds.Tables[0].Rows[0]["Que_text"].ToString()) < 0)
                            {
                                tnParent.Text += " : <font color=black> " + ds.Tables[0].Rows[0][3].ToString() + "  </font><b> [" + dr["marks"].ToString() + "] </b> Unit -> " + dr["Unit_Id"].ToString();
                                que += ") <font color=black> " + ds.Tables[0].Rows[0]["Que_text"].ToString() + "  </font> [" + dr["marks"].ToString() + "]  Unit -> " + dr["Unit_Id"].ToString() + "\n";
                                questionasked += ds.Tables[0].Rows[0]["Que_text"].ToString() + " # ";
                                conn.modify("Insert into tmptab values('" + dr["sub_section_id"].ToString() + "','" + dr["parent_id"].ToString() + "','" + dr["label"].ToString() + "','" + dr["marks"].ToString() + "')");
                            }
                            else
                                tnParent.Text += " : Error fetching Question.";
                        }
                    }
                    catch (Exception ex)
                    { tnParent.Text += " : Error Fetching Question " + "#" + dr["marks"].ToString(); }
                }
                else if (Convert.ToString(dr["q_type"]) == "Objective")
                {
                    string s = "select * from que_m q where q.unit_id = " + dr["unit_id"] + " and q.sub_id = " + drpsub.SelectedValue + "";
                    DataSet ds = new DataSet();
                    ds = conn.select(s);
                    try
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                string a = questionasked.ToString();
                            }
                            catch (Exception ex)
                            { questionasked = "."; }

                            if (questionasked.ToString().IndexOf(ds.Tables[0].Rows[0]["Que_text"].ToString()) < 0)
                            {
                                //tnParent.Text += " : <font color=black> " + ds.Tables[0].Rows[0][3].ToString() + "  </font><b> [" + dr["marks"].ToString() + "] </b> Unit -> " + dr["Unit_Id"].ToString();
                                tnParent.Text += " : <font color=black> " + ds.Tables[0].Rows[0][3].ToString() + "  </font><b>[A]" + ds.Tables[0].Rows[0][4].ToString() + " [B] " + ds.Tables[0].Rows[0][5].ToString() + " [C] " + ds.Tables[0].Rows[0][6].ToString() + " [D] " + ds.Tables[0].Rows[0][7].ToString() + " [" + dr["marks"].ToString() + "] </b> Unit -> " + dr["Unit_Id"].ToString();
                                que += " ) <font color=black> " + ds.Tables[0].Rows[0][3].ToString() + " [" + dr["marks"].ToString() + "] </b> Unit -> " + dr["Unit_Id"].ToString() + "  </font>\n[A] " + ds.Tables[0].Rows[0][4].ToString() + "\n[B] " + ds.Tables[0].Rows[0][5].ToString() + "\n[C] " + ds.Tables[0].Rows[0][6].ToString() + "\n[D] " + ds.Tables[0].Rows[0][7].ToString();
                                //questionasked += ds.Tables[0].Rows[0]["Que_text"].ToString() + " # ";
                                questionasked += ds.Tables[0].Rows[0]["Que_text"].ToString() + " [A] " + ds.Tables[0].Rows[0]["O1"].ToString() + " [B] " + ds.Tables[0].Rows[0]["O2"].ToString() + " [C] " + ds.Tables[0].Rows[0]["O3"].ToString() + " [D] " + ds.Tables[0].Rows[0]["O4"].ToString() + " # ";

                                conn.modify("Insert into tmptab values('" + dr["sub_section_id"].ToString() + "','" + dr["parent_id"].ToString() + "','" + dr["label"].ToString() + "','" + dr["marks"].ToString() + "')");
                            }
                            else
                                tnParent.Text += " : Error fetching Question.";
                        }
                    }
                    catch (Exception ex)
                    { tnParent.Text += " : Error Fetching Question " + "#" + dr["marks"].ToString(); }
                }
                tnParent.Expand();
                TreeView1.Nodes.Add(tnParent);
                /* try
                 {
                     word.Application objword = new word.Application();
                     word.Document objdoc = objword.Documents.Add();

                     word.Paragraph objpara;
                     objpara = objdoc.Paragraphs.Add();
                     objpara.Range.Text = queno + que;
                     objdoc.SaveAs2("C:\\Users\\ljadmin\\Documents\\ljcca.docx");
                     objdoc.Close();
                     objword.Quit();
                     lblmsg.Text = "Paperd Generated , you can find the file c:\\document\\ljcca.docx";
                 }
                 catch
                 {
                     lblmsg.Text = "Paper Not Generated OR somthing went wrong!!";
                 }*/
                Filltreechild(tnParent, value);
            }
        }
    }

    public int Filltreechild(TreeNode parent, string IID)
    {

        DataSet ds = conn.select("SELECT * FROM Sub_Section_M WHERE Parent_ID =" + IID);
        if (ds.Tables[0].Rows.Count - 1 > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode child = new TreeNode();

                child.Text = dr["label"].ToString().Trim();
                queno += "\n" + child.Text + "[" + dr["marks"].ToString() + "]";
                string temp = dr["sub_section_id"].ToString();
                if (Convert.ToString(dr["q_type"]) == "Subjective")
                {
                    string s = "select * from s_que_m s1 where s1.unit_id = " + dr["unit_id"] + " and s1.sub_id = " + drpsub.SelectedValue + "";
                    DataSet dsdata = new DataSet();
                    dsdata = conn.select(s);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            string a = questionasked.ToString();
                        }
                        catch (Exception ex)
                        { questionasked = "."; }
                        try
                        {
                            for (int rcnt = 0; rcnt < dsdata.Tables[0].Rows.Count; rcnt++)
                            {
                                if (questionasked.ToString().IndexOf(dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString()) < 0)
                                {
                                    child.Text += "  :  " + dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + "     [" + dr["marks"].ToString() + "] Unit -> " + dr["Unit_Id"].ToString();
                                    queno += ") " + dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + "     [" + dr["marks"].ToString() + "] Unit -> " + dr["Unit_Id"].ToString() + "\n";
                                    conn.modify("Insert into tmptab values('" + dr["sub_section_id"].ToString() + "','" + dr["parent_id"].ToString() + "','" + dr["label"].ToString() + "','" + dr["marks"].ToString() + "')");
                                    questionasked += dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + " # ";

                                    break;
                                }


                            }
                        }
                        catch { }
                    }
                }
                else if (Convert.ToString(dr["q_type"]) == "Objective")
                {
                    string s = "select * from que_m q where q.unit_id = " + dr["unit_id"] + " and q.sub_id = " + drpsub.SelectedValue + "";
                    DataSet dsdata = new DataSet();
                    dsdata = conn.select(s);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            string a = questionasked.ToString();
                        }
                        catch (Exception ex)
                        { questionasked = "."; }
                        for (int rcnt = 0; rcnt < dsdata.Tables[0].Rows.Count; rcnt++)
                        {
                            if (questionasked.ToString().IndexOf(dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString()) < 0)
                            {
                                //child.Text += "  :  " + dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + "     [" + dr["marks"].ToString() + "] Unit -> " + dr["Unit_Id"].ToString();
                                child.Text += "  :  " + dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + " [A] " + dsdata.Tables[0].Rows[rcnt]["O1"].ToString() + " [B] " + dsdata.Tables[0].Rows[rcnt]["O2"].ToString() + " [C] " + dsdata.Tables[0].Rows[rcnt]["O3"].ToString() + " [D] " + dsdata.Tables[0].Rows[rcnt]["O4"].ToString() + "  [" + dr["marks"].ToString() + "] Unit -> " + dr["Unit_Id"].ToString();
                                queno += ") " + dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + "  [" + dr["marks"].ToString() + "] Unit -> " + dr["Unit_Id"].ToString() + " \n[A] " + dsdata.Tables[0].Rows[rcnt]["O1"].ToString() + "\n[B]" + dsdata.Tables[0].Rows[rcnt]["O2"].ToString() + "\n[C] " + dsdata.Tables[0].Rows[rcnt]["O3"].ToString() + "\n[D] " + dsdata.Tables[0].Rows[rcnt]["O4"].ToString();
                                conn.modify("Insert into tmptab values('" + dr["sub_section_id"].ToString() + "','" + dr["parent_id"].ToString() + "','" + dr["label"].ToString() + "','" + dr["marks"].ToString() + "')");
                                //questionasked += dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + " # ";
                                questionasked += dsdata.Tables[0].Rows[rcnt]["Que_text"].ToString() + " [A] " + dsdata.Tables[0].Rows[rcnt]["O1"].ToString() + " [B] " + dsdata.Tables[0].Rows[rcnt]["O2"].ToString() + " [C] " + dsdata.Tables[0].Rows[rcnt]["O3"].ToString() + " [D] " + dsdata.Tables[0].Rows[rcnt]["O4"].ToString() + "#";

                                break;
                            }


                        }
                    }
                }


                child.Expand();
                parent.ChildNodes.Add(child);
                Filltreechild(child, temp);
                //create word document
                try
                {
                    word.Application objword = new word.Application();
                    word.Document objdoc = objword.Documents.Add();

                    word.Paragraph objpara;
                    objpara = objdoc.Paragraphs.Add();

                    for (int i = 1; i <= 20; i++)
                    {
                        queno = queno.ToString().Replace("[" + i.ToString() + "])", ")");
                    }

                    objpara.Range.Text = queno;
                    string s1 = DateTime.Now.ToShortDateString();

                    string s = drpsub.SelectedItem.ToString();


                    string s3 = s1 + s;
                    objdoc.SaveAs2("C:\\Users\\ljadmin\\Documents\\" + s3 + ".docx");
                    objdoc.Close();
                    objword.Quit();                    
                    lblmsg.Text =  "Paperd Generated , you can find the file c:\\document\\" + s3 + ".docx";
                  //  mail.MailPaper("parthgopani0@gmail.com", "paper generated by oes");
                    
                }
                catch
                {
                    lblmsg.Text = "Paper Not Generated OR somthing went wrong...!";
                }


            }
            return 0;
        }
        else
        {
            return 0;
        }
    }

    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            Response.Write("<script>alert('Exception Occured while releasing object')</script>");
        }
        finally
        {
            GC.Collect();
        }
    }
    // protected void btnexcel_Click(object sender, EventArgs e)
    // {

    /*  Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
      Microsoft.Office.Interop.Word.Document doc = app.Documents.Open("C:\\Users\\ljadmin\\Documents\\testdoc1.docx");
      object missing = System.Reflection.Missing.Value;
      //string s = "Hi";
      //Console.WriteLine(s);               
    //  doc.Content.Text = textBox1.Text.ToString();
      doc.Content.Text = "Hello";
      doc.Save();
      doc.Close(ref missing);

      app.Quit(ref missing);*/
    //--------------------------------------------



    //create one word application

    //Microsoft.Office.Interop.Word.ApplicationClass word = new Microsoft.Office.Interop.Word.ApplicationClass();

    //create one document for above word application


    // }
    
}