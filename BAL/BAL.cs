using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DesignationPro.BAL
{
    

    //create two varabiles based on the table
   
    public class BAL
    {
        DAL.DAL obj = new DAL.DAL();
        private string _designame;
        private int _desigid;
        private string _deptid;
        private int _id;

        public string DesigName
        {
            get
            {
                return _designame;
            }

            set
            {
                _designame = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string DeptID
        {
            get
            {
                return _deptid;
            }

            set
            {
                _deptid = value;
            }
        }
        public int DesigID
        {
            get
            {
                return _desigid;
            }

            set
            {
                _desigid = value;
            }
        }

        public DataTable viewdesig()
        {
            return obj.ViewDesig();
        }
        public int insertdesig()
        {
            return obj.Desiginsert(this);
        }
        public int updatedesig()
        {
            return obj.Desigupdate(this);
        }
        public int deleteProduct()
        {
            return obj.DeleteProduct(this);
        }

    }
}