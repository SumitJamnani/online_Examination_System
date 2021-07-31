using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frm_generated_temp : System.Web.UI.Page
{
    public string qstr = "<center><table width='50%' border=1>";
    db_conn conn = new db_conn();
    Int16 Chld;
    Int16 prnt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string temp_id = Convert.ToString(26);// Request.QueryString["temp_id"].ToString();
            Load_tree1();
            //fetchdata(temp_id);
        }
    }
    //public void recursion()
    //{
     
    //    DataSet ds = new DataSet(string pid);
    //    string str = "with cat_tree as (select sub_section_id,section_id,label,marks,q_type,noofsections,or_que,parent_id from Sub_Section_M union all select child.sub_section_id,child.section_id,child.label,child.marks,child.q_type,child.noofsections,child.or_que,child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select * from Section_M s,cat_tree c order by parent_id";

    //}
    DataSet ds1 = new DataSet();
    public void Load_tree()
    {
       
        //string str = "with cat_tree as (select sub_section_id,section_id,label,marks,q_type,noofsections,or_que,parent_id from Sub_Section_M union all select child.sub_section_id,child.section_id,child.label,child.marks,child.q_type,child.noofsections,child.or_que,child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select * from Section_M s,cat_tree c order by parent_id";
        string str = "with   cat_tree as (select sub_section_id,label,parent_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 order by parent_id";
        ds1 = conn.select(str);
        Int32 tot_rec = ds1.Tables[0].Rows.Count;
       
        for (int k = 0; k <= tot_rec-1; k++)
        {
//            if (Convert.ToInt16(ds1.Tables[0].Rows[k]["parent_id"]) == 0)
            {
                int sub_sec = Convert.ToInt16(ds1.Tables[0].Rows[k]["sub_section_id"]);
                int parent = Convert.ToInt16(ds1.Tables[0].Rows[k]["parent_id"]);
                FillChild(parent, sub_sec);
                //FillChild(sub_sec,0,'1');
            }
/*
            else
            {
                int sub_sec = Convert.ToInt16(ds1.Tables[0].Rows[k]["sub_section_id"]);
                int parent = Convert.ToInt16(ds1.Tables[0].Rows[k]["parent_id"]);
                FillChild(parent, sub_sec);
            }
*/           
        }
    }
    /////
    public void Load_tree1()
    {
        DataSet PrSet = conn.select("with   cat_tree as (select sub_section_id,label,parent_id from Sub_Section_M union all select child.sub_section_id, child.label, child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from cat_tree where parent_id=0 order by parent_id");
        TreeView1.Nodes.Clear();
        foreach (DataRow dr in PrSet.Tables[0].Rows)
        {
            //if ((int)dr["Parent_ID"] == 0)
            {
                TreeNode tnParent = new TreeNode();
                tnParent.Text = dr["label"].ToString();
                string value = dr["sub_section_id"].ToString();
                tnParent.Expand();
                TreeView1.Nodes.Add(tnParent);
                FillChild1(tnParent, value);
            }
        }
    }

    public int FillChild1(TreeNode parent, string IID)
    {
        DataSet ds = conn.select("SELECT * FROM Sub_Section_M WHERE Parent_ID =" + IID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TreeNode child = new TreeNode();
                child.Text = dr["label"].ToString().Trim();
                string temp = dr["sub_section_id"].ToString();
                child.Collapse();
                parent.ChildNodes.Add(child);
                FillChild1(child, temp);
            }
            return 0;
        }
        else
        {
            return 0;
        }
    }
    /////
    //demo
    public int FillChild(int parent, int sub_sec)
    {
        Int16 cnt = 0 ;
        cnt++;
        DataSet ds,dd = new DataSet();

            string qry1 = "SELECT * FROM sub_section_m WHERE parent_id ="+sub_sec;
            ds = conn.select(qry1);
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r <= ds.Tables[0].Rows.Count - 1; r++)
                {
                    sub.Text += ds.Tables[0].Rows[r]["label"].ToString() + "<br/>";
                    Chld = Convert.ToInt16(ds.Tables[0].Rows[r]["sub_section_id"]);
                    prnt = Convert.ToInt16(ds.Tables[0].Rows[r]["parent_id"]);
                    FillChild(Convert.ToInt16(ds.Tables[0].Rows[r]["parent_id"]), Convert.ToInt16(ds.Tables[0].Rows[r]["sub_section_id"]));
                    return 1;
                }
            }
            else
            {
                return 1;
                ;//FillChild(Convert.ToInt16(ds.Tables[0].Rows[r]["parent_id"]), Convert.ToInt16(ds.Tables[0].Rows[r]["sub_section_id"]));
            }
            return 1;
        }
        catch(Exception ex)
        { 
            return 2; 
        }
    }

    //actual
    public int FillChild(int sub_sec,int look,char a)
    {
        int r = 0;
        Int16 cnt = 0;
        cnt++;
        DataSet ds, dd = new DataSet();
        string qry1 ;
        if (look == 0)
        {
            qry1 = "SELECT * FROM sub_section_m WHERE parent_id =" + sub_sec;
        }
        else
        {
            qry1 = "SELECT * FROM sub_section_m WHERE sub_section_id =" + sub_sec;
        }

        if (dd == null)
        {
            ds = conn.select(qry1);
            for (Int16 i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                sub.Text += ds.Tables[0].Rows[r]["label"].ToString() + "<br/>";
                FillChild(Convert.ToInt16(ds.Tables[0].Rows[r + 1]["sub_section_id"].ToString()), 0, '1');
            }
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (r = 0; r <= ds.Tables[0].Rows.Count - 1; r++)
                    {
                        //sub.Text += ds.Tables[0].Rows[r]["label"].ToString();
                        sub.Text += ds.Tables[0].Rows[r]["label"].ToString() + "<br/>";
                        Int16 subid = Convert.ToInt16(ds.Tables[0].Rows[r]["sub_section_id"].ToString());
                        //FillChild(subid,0,'1');

                        FillChild(Convert.ToInt16(ds.Tables[0].Rows[r + 1]["sub_section_id"].ToString()), 0, '1'); // -------- THINK!!!!!!!!!!!!!!!!!!!!
                        return 1;
                    }
                }
                else
                {
                    try
                    {
                        sub.Text += ds.Tables[0].Rows[r]["label"].ToString() + "<br/>";

                    }
                    catch (Exception ex1)
                    {
                        FillChild(Convert.ToInt16(sub_sec), 1, '1'); // -------- THINK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        return 0;
                    }

                    return 0;
                }
                //     sub.Text += ds.Tables[0].Rows[r]["label"].ToString() + "<br/>";

                return 0;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        else
        {
            dd = conn.select(qry1);
            for (Int16 i = 0; i <= dd.Tables[0].Rows.Count - 1; i++)
            {
                sub.Text += dd.Tables[0].Rows[r]["label"].ToString() + "<br/>";
                FillChild(Convert.ToInt16(dd.Tables[0].Rows[r + 1]["sub_section_id"].ToString()), 0, '1');
            }
            try
            {
                if (dd.Tables[0].Rows.Count > 0)
                {
                    for (r = 0; r <= dd.Tables[0].Rows.Count - 1; r++)
                    {
                        //sub.Text += ds.Tables[0].Rows[r]["label"].ToString();
                        sub.Text += dd.Tables[0].Rows[r]["label"].ToString() + "<br/>";
                        Int16 subid = Convert.ToInt16(dd.Tables[0].Rows[r]["sub_section_id"].ToString());
                        //FillChild(subid,0,'1');

                        FillChild(Convert.ToInt16(dd.Tables[0].Rows[r + 1]["sub_section_id"].ToString()), 0, '1'); // -------- THINK!!!!!!!!!!!!!!!!!!!!
                        return 1;
                    }
                }
                else
                {
                    try
                    {
                        sub.Text += dd.Tables[0].Rows[r]["label"].ToString() + "<br/>";

                    }
                    catch (Exception ex1)
                    {
                        FillChild(Convert.ToInt16(sub_sec), 1, '1'); // -------- THINK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        return 0;
                    }

                    return 0;
                }
                //     sub.Text += ds.Tables[0].Rows[r]["label"].ToString() + "<br/>";

                return 0;
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

            
    }

    //public void fetchdata(string temp_id)
    //{
       // Int16 i,j,k,l,m;
    /*   
        DataSet ds=new DataSet();
        //string str = "select * from section_m s,sub_Section_m ss,or_table or1 where s.temp_id = "+temp_id+" and s.section_id = ss.section_id or ss.sub_section_id = or1.sub_section_id";
        //ds = conn.select(str);
        //string str = "with cat_tree as (select sub_section_id,section_id,label,marks,q_type,noofsections,or_que,parent_id from Sub_Section_M union all select child.sub_section_id,child.section_id,child.label,child.marks,child.q_type,child.noofsections,child.or_que,child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select * from Section_M s,cat_tree c order by parent_id";
        //ds = conn.select(str);

            //section 
            //string section = "select * from section_m where temp_id = "+Session["temp_id"]+"";
            string section = "select * from section_m where temp_id = "+temp_id+"";
            DataSet ds_tot_sec = new DataSet();
            ds_tot_sec = conn.select(section);
            Int32 tot_sec = ds_tot_sec.Tables[0].Rows.Count;

            //Q1 Q2
            //string section1 = "select * from section_m s,sub_section_m ss where s.section_id = ss.section_id and s.temp_id = " + temp_id + " and parent_id = 0";
            string section1 = "with cat_tree as (select sub_section_id,section_id,label,marks,q_type,noofsections,or_que,parent_id from Sub_Section_M union all select child.sub_section_id,child.section_id,child.label,child.marks,child.q_type,child.noofsections,child.or_que,child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select * from Section_M s,cat_tree c where c.section_id=s.section_id and temp_id=" + temp_id + " and parent_id=0";
            DataSet ds_sec = new DataSet();
            ds_sec = conn.select(section1);
            Int32 tot_sub_sec = ds_sec.Tables[0].Rows.Count;


            //Q1A Q1B 
            //string section2 = "select * from section_m s,sub_section_m ss,sub_section_m s1 where s.section_id = ss.section_id and temp_id=" + temp_id + " and ss.sub_section_id=s1.parent_id and ss.parent_id=0";
            string section2 = "with cat_tree as (select sub_section_id,section_id,label,marks,q_type,noofsections,or_que,parent_id from Sub_Section_M union all select child.sub_section_id,child.section_id,child.label,child.marks,child.q_type,child.noofsections,child.or_que,child.parent_id from Sub_Section_M as child join cat_tree as parent on parent.sub_section_id = child.parent_id)select distinct* from  Section_M s, cat_tree c ,cat_tree c1 where  c.parent_id=0 and s.section_id=c.section_id and s.temp_id=" + temp_id + " and c.sub_section_id=c1.parent_id";
            DataSet ds_sec1 = new DataSet();
            ds_sec1 = conn.select(section2);
            Int32 tot_sub_sec1 = ds_sec1.Tables[0].Rows.Count;


            //Q1A (1) Q1B (1)(2) 
            string section3 = "select * from section_m s,sub_section_m ss,sub_section_m s1 where s.section_id = ss.section_id and temp_id=" + temp_id + " and ss.sub_section_id=s1.parent_id and s1.sub_section_id = ss.parent_id";
            DataSet ds_sec2 = new DataSet();
            ds_sec2 = conn.select(section3);
            Int32 tot_sub_sec2 = ds_sec2.Tables[0].Rows.Count;


            //Or Questions 
            //Q1 Q2 Or
            string section4 = "select * from or_table o,section_m s,sub_section_m ss where ss.or_que>0 and s.section_id = ss.section_id and s.temp_id = " + temp_id + " and o.sub_section_id = ss.sub_section_id and ss.parent_id=0";
            DataSet ds_sec3 = new DataSet();
            ds_sec3 = conn.select(section4);
            Int32 tot_sub_sec_or = ds_sec3.Tables[0].Rows.Count;

            //Q1A Q1B OR

            string section5 = "select * from section_m s,sub_section_m ss,sub_section_m s1,or_table o where s.section_id = ss.section_id and temp_id=" + temp_id + " and ss.sub_section_id=s1.parent_id and s1.sub_section_id = o.sub_section_id and ss.label not like '(%' and o.label not like '(%'";
            DataSet ds_sec4 = new DataSet();
            ds_sec4 = conn.select(section5);
            Int32 tot_sub_sec_or1 = ds_sec4.Tables[0].Rows.Count;


            //Q1A (1) (2) Q1B (1)(2) OR
            string section6 = "select * from section_m s,sub_section_m ss,sub_section_m s1,or_table o where s.section_id = ss.section_id and temp_id=" + temp_id + " and ss.sub_section_id=s1.parent_id and s1.sub_section_id = o.sub_section_id and o.label like '(%'";
            DataSet ds_sec5 = new DataSet();
            ds_sec5 = conn.select(section6);
            Int32 tot_sub_sec_or2 = ds_sec5.Tables[0].Rows.Count;







          for (i = 0; i <= tot_sec -1 ; i++)
        {
            Int16 sec_id = Convert.ToInt16(ds_tot_sec.Tables[0].Rows[i][0]);
            
            qstr += "<tr>";
            qstr += "<td align='center' colspan=2>" + ds_tot_sec.Tables[0].Rows[i][1] + "</td>";
            //qstr += "<td align='center'>" + ds_sec1.Tables[0].Rows[i][8] + "</td>";

            for (j = 0; j <= ds_sec.Tables[0].Rows.Count-1; j++)
            {
                Int16 sub_sec_id = Convert.ToInt16(ds_sec.Tables[0].Rows[i][5]);
                //Q1 Q2
                if (sec_id == Convert.ToInt16(ds_sec.Tables[0].Rows[j][0]))
                {

                    qstr += "<tr>";
                    qstr += "<td>" + ds_sec.Tables[0].Rows[j][7] + "</td><td width=4%>" + ds_sec1.Tables[0].Rows[i][8] + "</td>";
                    qstr += "</tr>";

                    if (ds_sec3.Tables[0].Rows[j][2] == ds_sec.Tables[0].Rows[j][5])

                    
                    //Q1A Q2A
                    
                    
                    
                    for (k = 0; k <= ds_sec1.Tables[0].Rows.Count - 1; k++)
                    {
                        if (sub_sec_id == Convert.ToInt16(ds_sec1.Tables[0].Rows[k][5]))
                        {

                            qstr += "<tr>";
                            qstr += "<td>" + "&nbsp&nbsp&nbsp&nbsp&nbsp" + ds_sec1.Tables[0].Rows[k][15] + "</td><td width=4%>" + ds_sec1.Tables[0].Rows[i][16] + "</td>";
                            qstr += "</tr>";
                        }
                    }



                    




                }
            }

           
            qstr += "</tr>";
           }
        qstr += "</table></center>";*/
   // }
}

