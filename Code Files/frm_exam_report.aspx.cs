using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Net;
using System.Net.Mail;  
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;

public partial class exam_report : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (!IsPostBack)
        {
            drpf.Items.Add(new ListItem("Select", "0", true)); 
            binddrpexam();
            
        binddrp();
        }
    }

    public void bindlabel()
    {
        string eid = "select max(exam_id) from exam_m where exam_name = '"+drpexamname.SelectedItem+"'";
        DataSet ds1 = new DataSet();
        ds1 = conn.select(eid);
        Int64 exam_id = Convert.ToInt64(ds1.Tables[0].Rows[0][0]);


        string report = "select  case when s.status_pf  is null then 'Absent' else s.status_pf end as 'Result Status' ,COUNT(*) as 'Total' from  stud_exam_reg s,exam_m e,registration_m r where e.exam_id=s.exam_id and s.stud_id=r.reg_id and e.Exam_Id = "+exam_id+" group by s.status_pf	";
        DataSet ds = new DataSet();
        ds = conn.select(report);

        if (ds.Tables[0].Rows.Count > 1)
            lblpass.Text = "PASS : " + ds.Tables[0].Rows[1][1].ToString() + "<br/>";
        else
            lblpass.Text = "PASS : 0" +  "<br/>";
        if (ds.Tables[0].Rows.Count > 2)
            lblfail.Text = "FAIL : " + ds.Tables[0].Rows[2][1].ToString() + "<br/>";
        else
            lblfail.Text = "FAIL :   0"  + "<br/>";
        lblab.Text = "ABSENT : " + ds.Tables[0].Rows[0][1].ToString() + "<br/>";
        


    }
    public void binddrp()
    {
        string s = "select * from Sem_M";
        gf.fillcombo(s, drpsem , "sem_name", "sem_id", "--select--");
      
    }
    public void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = conn.select("select r.roll_no 'Roll No',r.f_name 'Name',s.status_pf 'Status',s.score 'Marks Obtained' , Tot_Marks 'Total Marks', PAssing_Marks 'Passing '  from  stud_exam_reg s,exam_m e,registration_m r where e.exam_id=s.exam_id and s.stud_id=r.reg_id and e.exam_name='"+drpexamname.SelectedItem +"'");
        gf.fill_grid(ds, grd_result);
    }


    protected void btnresult_Click(object sender, EventArgs e)
    {
        try
        {
            bindgrid();
            bindlabel();
        }
        catch
        {
            Response.Write("<script>alert('There Is No Exam Taken Of This Subject!')</script>");
        }
    }
    protected void grd_result_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void btngenerateexcel_Click(object sender, EventArgs e)
    {
        //SqlConnection cnn;
       // string connectionString = null;
        string sql = null;
        string data = null;
        int i = 0;
        int j = 0;

        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;

        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Add(misValue);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //connectionString = "data source=servername;initial catalog=databasename;user id=username;password=password;";
        //cnn = new SqlConnection(connectionString);
        //cnn.Open();
        sql = "select r.roll_no 'Roll No',r.f_name 'Name',s.score 'Marks'   from  stud_exam_reg s,exam_m e,registration_m r where e.exam_id=s.exam_id and s.stud_id=r.reg_id and e.exam_name='" + drpexamname.SelectedItem + "'";
      //  SqlDataAdapter dscmd = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
      ds=  conn.select(sql);
       
    //    dscmd.Fill(ds);

        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
           
            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
               data = ds.Tables[0].Rows[i].ItemArray[j].ToString();

                    xlWorkSheet.Cells[i + 1, j + 1] = data;
                    
                    //if (ds.Tables[0].Rows[i]["Marks"].ToString() == "")
                    //{
                    //    xlWorkSheet.Cells[i+1,j+1]= "AB";
                    //}
            }
            if (ds.Tables[0].Rows[i]["Marks"].ToString() == "")
            {
                xlWorkSheet.Cells[i + 1, 3] = "AB";
            }
        }

      //  xlWorkBook.SaveAs("aa.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        string  s1 =  DateTime.Now.ToString("dd/mm/yy hh-mm-ss").Trim();

        string s = drpexamname.SelectedItem.ToString();
       
   
        string s3 = s1 + s;
        xlWorkBook.SaveAs(s3, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();

        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlApp);
      //  lblmsg.Text = "Excel file created , you can find the file c:\\document\\" + s3 + ".xls";
        Response.Write("<script>alert('Excel file created , you can find the file c->document->" + s3 + ".xls')</script>");
     
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
  /* protected void btnsendmail_Click(object sender, EventArgs e)
    {
       /* string to = "toaddress@gmail.com"; //To address    
        string from = "fromaddress@gmail.com"; //From address    
        MailMessage message = new MailMessage(from, to);

        string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
        message.Subject = "Sending Email Using Asp.Net & C#";
        message.Body = mailbody;
      //  message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
        System.Net.NetworkCredential basicCredential1 = new
        System.Net.NetworkCredential("yourmail id", "Password");
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = basicCredential1;
        try
        {
            client.Send(message);
        }

        catch (Exception ex)
        {
            throw ex;
        }
        */
        
      //  mail.To.Add(txtTo.Text);
     //    string to = mailto.Text; //To address    
    /*    string from = mailfrom.Text; //From address    
        MailMessage mail = new MailMessage(from, to);
     //   mail.From = new MailAddress("sourabh9303@gmail.com");
        mail.Subject = "Result Email";
    //    string Body = txtmessage.Text;
      //  mail.Body = Body;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential
        ("parthgopani0@gmail.com", "parth@007");
        smtp.UseDefaultCredentials = false;
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }
*/
    protected void drpsem_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddrpfact();
    }

    //protected void drpfaculty11_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //examlist of particular faculty
    //    string s = "select MAX(Exam_Name) from Exam_M e,Faculty_Sub f where e.Sub_Id=f.Sub_Id and f.Fact_Id=" + drpfaculty.SelectedValue;
    //    gf.fillcombo(s, drpexamname, "exam_name", "exam_id", "--select--");
    //}
   
    public void binddrpexam()
    {

        //  string s = "select distinct(e.Exam_Name) from Exam_M e,Faculty_Sub f where e.Sub_Id=f.Sub_Id and f.Fact_Id=" + drpf.SelectedValue;
        string s = "select distinct(e.exam_name),e.exam_id from exam_m e,Faculty_Sub f,attempt_que a where e.exam_id=a.exam_id and e.Sub_Id=f.Sub_Id and f.Fact_Id=" + drpf.SelectedValue;
        gf.fillcombo(s, drpexamname, "exam_name", "exam_id", "--select--");
    }
    protected void drpf_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = "select distinct(e.exam_name),e.exam_id from exam_m e,Faculty_Sub f,attempt_que a where e.exam_id=a.exam_id and e.Sub_Id=f.Sub_Id and f.Fact_Id=" + drpf.SelectedValue;
        gf.fillcombo(s, drpexamname, "exam_name", "exam_id", "--select--");
       // drpexamname.Items.Clear();
    }
    public void binddrpfact()
    {
       
    //   string s1 = "select * from Registration_M r,Faculty_Sub f,sem_m se,Sub_M sb,Login_M l where r.Email=l.Email and se.Sem_Id=" + drpsem.SelectedValue + " and f.Sub_Id=sb.Sub_Id  and l.Type_FSD='f' and sb.Sem_Id=se.Sem_Id and f.Fact_Id=r.Reg_Id";
        string s1 = "select distinct(F_Name),Fact_Id  from Registration_M r,Faculty_Sub f,sem_m se,Sub_M sb,Login_M l where r.Email=l.Email and se.Sem_Id=" + drpsem.SelectedValue + " and f.Sub_Id=sb.Sub_Id  and l.Type_FSD='f' and sb.Sem_Id=se.Sem_Id and f.Fact_Id=r.Reg_Id";
        gf.fillcombo(s1, drpf, "f_name", "fact_id", "--select--");
    }
}
/*
  private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn ;
            string connectionString = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0; 

            Excel.Application xlApp ;
            Excel.Workbook xlWorkBook ;
            Excel.Worksheet xlWorkSheet ;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            connectionString = "data source=servername;initial catalog=databasename;user id=username;password=password;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT * FROM Product";
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 1, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
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
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
 
*/