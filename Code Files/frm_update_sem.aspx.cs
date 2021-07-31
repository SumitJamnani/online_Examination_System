using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class frm_update_sem : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn conn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             bindolddrp();
             bindnewdrp();
        }
    }
    public void bindolddrp()
    {
        string s = "select * from Sem_M";
        gf.fillcombo(s, drpoldsem, "sem_name", "sem_id", "--select--");

    }
    public void bindnewdrp()
    {
        string s = "select * from Sem_M";
        gf.fillcombo(s, drpnewsem, "sem_name", "sem_id", "--select--");
        drpnewsem.Items.Add("Pass Out");

    }
}