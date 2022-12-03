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
            if (!Page.IsPostBack)
            {
                GridView1.DataSource = objdept.viewdesig();
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = objdept.viewdesig();
            GridView1.DataBind();
        }



        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            TextBox city = GridView1.Rows[e.RowIndex].FindControl("txt_Dname") as TextBox;
            DropDownList dp= GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;


            //string a= id.ToString();
            //int n = int.Parse(a);

            objdept.DesigID = Convert.ToInt32(id.Text);
            objdept.DesigName = name.Text;
            objdept.DeptID = dp.SelectedItem.Value;
            objdept.updatedesig();
            GridView1.EditIndex = -1;




            GridView1.DataSource = objdept.viewdesig();
            GridView1.DataBind();



        }


       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            objdept.DesigName = TextBox1.Text;
            objdept.DeptID = DropDownList1.SelectedItem.Value;
            int i = objdept.insertdesig();
            
            if (i == 1)
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label);
            objdept.ID = Id;
            int i = objdept.deleteProduct();
            GridView1.DataSource = objdept.viewdesig();
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdept.viewdesig();
            GridView1.DataBind();
        }

        
    }
}