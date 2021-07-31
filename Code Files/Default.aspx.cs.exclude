using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {binddrpexam();
        if (!IsPostBack)
        {


            binddrp();
        }
    }

    public void bindlabel()
    {
        


    }
    public void binddrp()
    {
        string s = "select * from Sem_M";
        gf.fillcombo(s, drpsem, "sem_name", "sem_id", "--select--");

    }
    public void bindgrid()
    {
        
    }


    protected void btnresult_Click(object sender, EventArgs e)
    {
       
    }
   
    protected void btngenerateexcel_Click(object sender, EventArgs e)
    {
          //Response.Write("<script>alert('Excel file created , you can find the file c:\\document"+s+".xls')</script>");

    }
    private void releaseObject(object obj)
    {
       
    }
 
    
    protected void drpsem_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        string s1 = "select * from Registration_M r,Faculty_Sub f,sem_m se,Sub_M sb,Login_M l where r.Email=l.Email and se.Sem_Id=" + drpsem.SelectedValue + " and f.Sub_Id=sb.Sub_Id  and l.Type_FSD='f' and sb.Sem_Id=se.Sem_Id";
        gf.fillcombo(s1, drpf, "f_name", "fact_id", "--select--");
    }

    protected void drpf_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        string s = "select MAX(Exam_Name) from Exam_M e,Faculty_Sub f where e.Sub_Id=f.Sub_Id and f.Fact_Id=" + drpf.SelectedValue;
        gf.fillcombo(s, drpe, "exam_name", "exam_id", "--select--");
    }
    public void binddrpexam()
    {
    
      //  string s = "select distinct(e.Exam_Name) from Exam_M e,Faculty_Sub f where e.Sub_Id=f.Sub_Id and f.Fact_Id=" + drpf.SelectedValue;
        string s = "select distinct(e.exam_name),e.exam_id from exam_m e,Faculty_Sub f,attempt_que a where e.exam_id=a.exam_id and e.Sub_Id=f.Sub_Id and f.Fact_Id=" + drpf.SelectedValue;
        gf.fillcombo(s, drpe, "exam_name", "exam_id", "--select--");
    }
}