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
            string s = "select DesignationId,DesignationName from Designation";
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
            string s = "update Designation set dept_name='" + obj.DesigName + "' where Id='" + obj.DesigID + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }

        public int Desiginsert(BAL.BAL obj)
        {

            string qry = "insert into Designation(DesignationName) values ('" + obj.DesigName + "')";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            return cmd.ExecuteNonQuery();
        }

        public int departmentinsert(BAL.BAL obj)
        {

            string qry = "insert into Designation(DepartmentId) values ('" + obj.DeptID + "')";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            return cmd.ExecuteNonQuery();
        }
    }
}