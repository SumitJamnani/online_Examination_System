using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class frm_attempt_que : System.Web.UI.Page
{
    Int32 tot_q = 0;
    string ans="";
    DateTime nw;


    public void uncheck()
    {
        o1.Checked = false;
        o2.Checked = false;
        o3.Checked = false;
        o4.Checked = false;
    }
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    Int16 lastduration;
    protected void Page_Load(object sender, EventArgs e)
      
    {
        if (!IsPostBack)
        {
            if (Request.QueryString != null)
            {
                Session["stime"] = DateTime.Now.ToString();
                Session["totq"] = 0;

                DataSet ds1 = new DataSet();
                ds1 = conn.select("select s_duration from stud_exam_reg where stud_id = " + Session["regid"] + " and exam_id = " + Session["eid"] + "");
                lastduration = 0;
                //if (ds1.Tables[0].Rows[0][0].ToString() == "")
                //    lastduration = 0;
                //else
                //    lastduration = Convert.ToInt16(ds1.Tables[0].Rows[0][0].ToString());

                //if (Convert.ToInt16(Session["dur"]) > 0)
                //{

                //    TimeSpan span = DateTime.Now.Subtract(Convert.ToDateTime(Session["stime"]));
                //    Session["dur"] = (span.Seconds + lastduration);

                //    lblstarttime.Text = " Time Spent-----> " + Session["dur"];               

                //    //Session["dur"] = 0;
                //    //lblstarttime.Text = " Time Spent  ----->0";
                //}
            }
            else
            {
                Response.Redirect("frm_exam_list.aspx");
            }
            check_exam();
            display();
            
            uncheck();
        
                       
        }

    }


    public void check_exam()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select * from attempt_que where stud_id = '"+Session["regid"].ToString()+"' and exam_id='" + Session["eid"].ToString() + "'");
        Session["totq"] = ds.Tables[0].Rows.Count - 1;

        DataSet ds1 = new DataSet();
        //ds1 = conn.select("select count(*) from attempt_que a,que_m q,stud_exam_reg s where a.stud_id = "+Session["regid"]+" and a.que_id = q.que_id and a.exam_id = s.exam_id group by a.que_id ");
        ds1 = conn.select("select count(*) from attempt_que a,que_m q,stud_exam_reg s where a.stud_id = " + Session["regid"] + " and a.que_id = q.que_id and a.exam_id = "+Session["eid"]+" group by a.que_id ");
        DataSet ds2 = new DataSet();
        string str = "select tot_que from exam_m where exam_id = " + Session["eid"] + "";
        ds2 = conn.select(str);

        if (Convert.ToInt16(ds1.Tables[0].Rows.Count) >= Convert.ToInt16(ds2.Tables[0].Rows[0]["tot_que"]))
        {
            Response.Redirect("given_exam_error.aspx");
       
        }

        else if (Convert.ToInt16(ds1.Tables[0].Rows.Count) <= Convert.ToInt16(ds2.Tables[0].Rows[0]["tot_que"]))
        {
            display();
        
        }
        
    }

    public void increment()
    {
        DataSet ds = new DataSet();
        string str = "select tot_que, duration from exam_m where exam_id = "+Session["eid"]+"";
        ds = conn.select(str);
       
        tot_q = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        Session["totq"] = Convert.ToInt16(Session["totq"])+1;
        if (hdntotQ.Value == "0" && Session["totq"].ToString() != "-1" )
        {
            if (Convert.ToInt16(Session["totq"].ToString()) > 0) 
                hdntotQ.Value = Convert.ToInt16(Session["totq"].ToString()).ToString();
        }

      // hdntotQ.Value = (Convert.ToInt32(hdn_number.Value)+1).ToString();

       lbl_questions.Text = "Question : "+ hdntotQ.Value+"/"+tot_q+"";
       //if (Convert.ToInt16(Session["totq"].ToString()) > tot_q)
       //{
       //    Response.Redirect("frm_result.aspx?stud_id=" + Session["regid"] + "&exam_id=" + Session["eid"] + "&sub_id=" + Session["sid"] + "");          
       //}
       ////else if ((Convert.ToDouble(Session["dur"].ToString())) > (Convert.ToDouble(ds.Tables[0].Rows[0]["duration"].ToString())))
       //{
       //    Response.Write("<script>alert('Time Is Over!!')</script>");
       //    Response.Redirect("frm_result.aspx?stud_id=" + Session["regid"] + "&exam_id=" + Session["eid"] + "&sub_id=" + Session["sid"] + "");
       //}

     
      // else 
        if (Convert.ToInt16(hdntotQ.Value) > tot_q)
       {
            Response.Redirect("frm_result.aspx?stud_id=" + Session["regid"] + "&exam_id=" + Session["eid"] + "&sub_id=" + Session["sid"] + "");          
       }
       else if (Convert.ToInt32(hdntotQ.Value) == tot_q)
       {
           btnsubmit.Visible = false;
           btn_end.Visible = true;
       }
       else if (hdntotQ.Value == "2")
       {
       }
    }
    public void display()
    {
        DataSet ds1 = new DataSet();
        string startstop = "select startstop from exam_m where exam_id="+Session["eid"];
        ds1 = conn.select(startstop);
        if(ds1.Tables[0].Rows[0][0].ToString() == "True")
        {
            
            DataSet dslastQ = new DataSet();
            dslastQ = conn.select("select count(*)+1 from attempt_que where stud_id = '" + Session["Regid"].ToString() + "'      and exam_id = " + Session["eid"] + "");
            hdntotQ.Value = dslastQ.Tables[0].Rows[0][0].ToString();
            increment();
            Session["stime"] = DateTime.Now.ToString();
            Random rnd = new Random();
            DataSet ds = new DataSet();
            string dt = DateTime.Now.ToString("yyyy/MM/dd");

            ds = conn.select("select MIN(Que_Id), MAX(Que_Id)  from que_m where sub_id = " + Session["sid"] + "");
            Int16 tot;

            //tot = Convert.ToInt16(rnd.Next(Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString()), Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString())));
            tot = Convert.ToInt16(rnd.Next(1, 10));


        
            // generate rndome betwern 1 to n
            // and check tht random generated is noot ask to tht student


            //INPERFECT RANDOM LOGIC 
                //ds = conn.select("select * from que_m where sub_id = '" + Session["sid"] + "' and unit_id in (select unit_id from exam_unit_t where exam_id = " + Session["eid"] + " ) AND ( QUE_ID NOT IN (sELECT QUE_ID FROM ATTEMPT_QUE where Stud_Id='" + Session["Regid"].ToString() + "' AND EXAM_ID ='" + Session["eid"] + "' ))  and que_id = '" + tot + "' order by que_id ");
            //  ds = conn.select("select * from que_m where  que_id = '" + tot + "'  and QUE_ID NOT IN (sELECT QUE_ID FROM ATTEMPT_QUE where Stud_Id='" + Session["Regid"].ToString() + "' AND EXAM_ID ='" + Session["eid"] + "' )  order by que_id ");

        if (tot %2==0)
           ds = conn.select("select * from que_m where sub_id = '" + Session["sid"] + "' and unit_id in (select unit_id from exam_unit_t where exam_id = " + Session["eid"] + " ) AND ( QUE_ID NOT IN (sELECT QUE_ID FROM ATTEMPT_QUE where Stud_Id='" + Session["Regid"].ToString() + "' AND EXAM_ID ='" + Session["eid"] + "' ))order by que_id ");
        else
           ds = conn.select("select * from que_m where sub_id = '" + Session["sid"] + "' and unit_id in (select unit_id from exam_unit_t where exam_id = " + Session["eid"] + " ) AND ( QUE_ID NOT IN (sELECT QUE_ID FROM ATTEMPT_QUE where Stud_Id='" + Session["Regid"].ToString() + "' AND EXAM_ID ='" + Session["eid"] + "' ))order by que_id Desc");

        if (ds.Tables[0].Rows.Count < 0 )
        { Response.Write("<script>alert('There Is No Question Availaible!')</script>"); }

        else 
            
            {
                string m1, m2, m3, m4;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int r = 0;
                    
                    m1 = ds.Tables[0].Rows[r]["o1"].ToString();
                    m2 = ds.Tables[0].Rows[r]["o2"].ToString();
                    m3 = ds.Tables[0].Rows[r]["o3"].ToString();
                    m4 = ds.Tables[0].Rows[r]["o4"].ToString();

                    if (m1.Trim().ToLower() == "true" && m2.Trim().ToLower() == "false" || m2.Trim().ToLower() == "false" && m1.Trim().ToLower() == "true")
                    {
                        o1.Text = m1;
                        o2.Text = m2;
                        o3.Visible = false;
                        o4.Visible = false;
                    }

                    else
                    {
                        o3.Visible = true;
                        o4.Visible = true;
                        o1.Text = m1;
                        o2.Text = m2;
                        o3.Text = m3;
                        o4.Text = m4;
                    }


                    string s = ds.Tables[0].Rows[0]["que_text"].ToString();
                    string s1 =  s.Substring(0, 1).ToUpper();
                    string s2 =  s.Substring(1);


                    hdn_que_id.Value = ds.Tables[0].Rows[0]["Que_id"].ToString();

                    //lblquestion.Text =  "Q. " + ds.Tables[0].Rows[0]["que_text"].ToString() + "<br /> Please Select Any One Option.";
                    lblquestion.Text = "Q. " + s1 + s2 + "<br /><br/> <font size=3 color=red> Please Select Any One Option.</font>";
                    
                  
                 }



            }
            }
        else
        {
             Response.Write("<script>alert('Please Wait Exam Is Not Started!!')</script>");
        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (o1.Checked == false && o2.Checked == false && o3.Checked == false && o4.Checked == false)
        {
            Response.Write("<script>alert('Please select any option!!')</script>");
        }
        else
        {

            DataSet ds = new DataSet();
            try
            {



                if (o1.Checked)
                {
                    ans = "a";
                }
                else if (o2.Checked)
                {
                    ans = "b";
                }
                else if (o3.Checked)
                {
                    ans = "c";
                }
                else if (o4.Checked)
                {
                    ans = "d";
                }


                string qry = "if not exists (select  * from attempt_que  where stud_id = '" + Session["Regid"].ToString() + "' and exam_id ='" + Session["eid"].ToString() + "' and que_id = '" + hdn_que_id.Value  + "' )insert into attempt_que (stud_id,que_id,given_ans,exam_id,start_time) values ('" + Session["Regid"].ToString() + "','" + hdn_que_id.Value + "','" + ans + "','" + Session["eid"] + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
                conn.modify(qry);
                qry = "update stud_exam_reg set s_duration = '" + Session["dur"] + "' where stud_id = '" + Session["Regid"] + "' and exam_id='" + Session["eid"] + "'";
                conn.modify(qry);

            }

            catch (Exception ex)
            {
                lblmsg.Text = ex.ToString();
            }
            uncheck();
            display();         
            

        }
    }

    protected void grdcity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }



    public void clearall(Control Parent)
    {
        foreach (Control x in Parent.Controls)
        {
            if ((x).GetType() == typeof(CheckBox))
            {
                ((CheckBox)(x)).Checked = false;
            }
            if (x.HasControls())
            {
                clearall(x);
            }

        }
        lblmsg.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    
      
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        uncheck();

    }
    
       
       
        protected void btn_end_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
        try
        {
            string dt = DateTime.Now.ToString("yyyy/MM/dd");


       
           

                if (o1.Checked )
                {
                    ans = "a";
                }
                else if (o2.Checked )
                {
                    ans = "b";
                }
                else if (o3.Checked )
                {
                    ans = "c";
                }
                else if (o4.Checked )
                {
                    ans = "d";
                }
           
            //string qry = "insert into attempt_que (stud_id,que_id,given_ans,exam_id,start_time) values ('" + Session["Regid"].ToString() + "','" + hdn_que_id.Value + "','" + ans +  "','" + Session["eid"] + "','" + dt + "')";
           //string qry = " if not exists (select  * from attempt_que  where stud_id = '" + Session["Regid"].ToString() + "' and exam_id ='" + Session["eid"].ToString() + "' and que_id = '" + hdn_que_id.Value  + "' )insert into attempt_que (stud_id,que_id,given_ans,exam_id,start_time) values ('" + Session["Regid"].ToString() + "','" + hdn_que_id.Value + "','" + ans +  "','" + Session["eid"] + "','" + dt + "')";
            string qry = "if not exists (select  * from attempt_que  where stud_id = '" + Session["Regid"].ToString() + "' and exam_id ='" + Session["eid"].ToString() + "' and que_id = '" + hdn_que_id.Value + "' )insert into attempt_que (stud_id,que_id,given_ans,exam_id,start_time) values ('" + Session["Regid"].ToString() + "','" + hdn_que_id.Value + "','" + ans + "','" + Session["eid"] + "','" +dt + "')";
            conn.modify(qry);
            ds = conn.select("select start_time from attempt_que where stud_id = '" + Session["Regid"] + "' and que_id = " + hdn_que_id.Value + " and exam_id='" + Session["eid"] + "'");

            string qry1 = "update attempt_que set given_ans= '" + ans + "' where stud_id = '" + Session["Regid"] + "' and que_id = " + hdn_que_id.Value + " and exam_id='" + Session["eid"] + "'";
            conn.modify(qry1);
            Server.Transfer("frm_result.aspx?stud_id=" + Session["regid"] + "&exam_id=" + Session["eid"] + "&sub_id=" + Session["sid"] + "",false );

        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }

        string qry2 = "update stud_exam_reg set s_duration = '" + Session["dur"] + "' where stud_id = '" + Session["Regid"] + "' and exam_id='" + Session["eid"] + "'";
        conn.modify(qry2);
        }
}