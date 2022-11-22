using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesignationPro
{
    public partial class desig : System.Web.UI.Page
    {
        BAL.BAL objdept = new BAL.BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = objdept.viewdesig();
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = objdept.viewdesig();
            GridView1.DataBind();
        }



        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox txt = new TextBox();
            txt = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0];




            objdept.DesigID = id.ToString();
            objdept.DesigName = txt.Text;
            int i = objdept.updatedesig();
            GridView1.EditIndex = -1;




            GridView1.DataSource = objdept.viewdesig();
            GridView1.DataBind();



        }


       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            objdept.DesigName = TextBox1.Text;
            objdept.DeptID = DropDownList1.SelectedItem.Value;
            int i = objdept.insertdesig();
            int j = objdept.insertdepartmet();
            if (i == 1&&j==1)
            {
                Response.Write("<script language=javascript>alert('Sucess');</script>");
                GridView1.DataSource = objdept.viewdesig();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('ERROR');</script>");
                GridView1.DataSource = objdept.viewdesig();
                GridView1.DataBind();
            }
        }
    }
}