using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesignationPro.DAL
{
   
   
    public class DAL
    {

        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();

        public DAL()
        {
            string conn = ConfigurationManager.ConnectionStrings["rose"].ConnectionString;
            con = new SqlConnection(conn);
            cmd.Connection = con;



        }
        public DataTable ViewDesig()
        {
            string s = "SELECT DesignationId, Designation.DesignationName, Department.DepartmentName FROM     Department INNER JOIN Designation ON Department.DepartmentId = Designation.DepartmentId";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public SqlConnection Getcon()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public int Desigupdate(BAL.BAL obj)
        {
            string s = "update Designation set DesignationName='" + obj.DesigName + "',DepartmentId=" + obj.DeptID + " where DesignationId='" + obj.DesigID + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }

        public int Desiginsert(BAL.BAL obj)
        {

            string qry = "insert into Designation(DesignationName,DepartmentId) values ('" + obj.DesigName + "','" + obj.DeptID + "')";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            return cmd.ExecuteNonQuery();
        }

        public int DeleteProduct(BAL.BAL obj)
        {
            string qry = "Delete from Designation where DesignationId = '" + obj.ID + "'";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            return cmd.ExecuteNonQuery();
        }
    }
}