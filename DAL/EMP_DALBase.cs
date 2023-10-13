using AddEditDemo.Areas.EMP_Department.Models;
using AddEditDemo.Areas.EMP_Employee.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using OnlineMobileShopping.DAL;
using System.Data;
using System.Data.Common;
using System.Runtime.Intrinsics.Arm;

namespace AddEditDemo.DAL
{
    public class EMP_DALBase: DAL_Helper
    {
        #region Employee Table
        #region dbo.PR_EMP_Employee_SelectAll
        public DataTable dbo_PR_EMP_Employee_SelectAll( )
        {
            try
            {
                SqlDatabase sqlDB=new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Employee_SelectAll");

                DataTable dt=new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex) 
            {
                return null;
            }
            
        }
        #endregion

        #region dbo.PR_EMP_Employee_SelectByPK
        public DataTable dbo_PR_EMP_Employee_SelectByPK(int? EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Employee_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "EmployeeID", SqlDbType.Int, EmployeeID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Employee_Insert
        public bool? dbo_PR_EMP_Employee_Insert(EMP_EmployeeModel modelEMP_Employee)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Employee_Insert");
                sqlDB.AddOutParameter(dbCMD, "EmployeeID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "EmployeeName", SqlDbType.NVarChar, modelEMP_Employee.EmployeeName);
                sqlDB.AddInParameter(dbCMD,"DepID",SqlDbType.Int,modelEMP_Employee.DepID);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelEMP_Employee.Address);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelEMP_Employee.Gender);
                sqlDB.AddInParameter(dbCMD, "Mobile", SqlDbType.NVarChar, modelEMP_Employee.Mobile);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelEMP_Employee.Email);
                sqlDB.AddInParameter(dbCMD, "JoiningDate", SqlDbType.DateTime, modelEMP_Employee.JoiningDate);
                sqlDB.AddInParameter(dbCMD, "Salary", SqlDbType.NVarChar, modelEMP_Employee.Salary);



                //DataTable dt = new DataTable();
                //using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                //{
                //    dt.Load(dr);
                //}
                //return dt;
                int vResultvalue = sqlDB.ExecuteNonQuery(dbCMD);
                modelEMP_Employee.EmployeeID = Convert.ToInt32(dbCMD.Parameters["@EmployeeID"].Value);

                return (vResultvalue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region PR_EWH_EmployeeWiseHobby_Insert

        public bool? dbo_PR_EWH_EmployeeWiseHobby_Insert(EMP_EmployeeModel modelEMP_Employee)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EWH_EmployeeWiseHobby_Insert");
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, @CV.UserID());

                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "EmployeeID", SqlDbType.Int, modelEMP_Employee.EmployeeID);
                sqlDB.AddInParameter(dbCMD, "HID", SqlDbType.Int, modelEMP_Employee.Hobby.HID);
                int vResultValue = sqlDB.ExecuteNonQuery(dbCMD);

                return (vResultValue == -1 ? false : true);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region dbo.PR_EMP_Employee_Update
        public bool? dbo_PR_EMP_Employee_Update(EMP_EmployeeModel modelEMP_Employee)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Employee_Update");
                sqlDB.AddInParameter(dbCMD, "EmployeeID ", SqlDbType.Int, modelEMP_Employee.EmployeeID);
                sqlDB.AddInParameter(dbCMD, "EmployeeName", SqlDbType.NVarChar, modelEMP_Employee.EmployeeName);
                sqlDB.AddInParameter(dbCMD, "DepID", SqlDbType.Int, modelEMP_Employee.DepID);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelEMP_Employee.Address);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelEMP_Employee.Gender);
                sqlDB.AddInParameter(dbCMD, "Mobile", SqlDbType.NVarChar, modelEMP_Employee.Mobile);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelEMP_Employee.Email);
                sqlDB.AddInParameter(dbCMD, "JoiningDate", SqlDbType.DateTime, modelEMP_Employee.JoiningDate);
                sqlDB.AddInParameter(dbCMD, "Salary", SqlDbType.NVarChar, modelEMP_Employee.Salary);

                int vResultvalue = sqlDB.ExecuteNonQuery(dbCMD);

                return (vResultvalue == -1 ? false : true);
                //DataTable dt = new DataTable();
                //using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                //{
                //    dt.Load(dr);  
                //}
                //return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Employee_Delete
        public DataTable dbo_PR_EMP_Employee_Delete(int? EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Employee_Delete");
                sqlDB.AddInParameter(dbCMD, "EmployeeID", SqlDbType.Int, EmployeeID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Employee_SelectByPage
        public DataTable dbo_PR_EMP_Employee_SelectByPage(string EmployeeName, string Gender, string Email)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Employee_SelectByPage");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "EmployeeName", SqlDbType.NVarChar, EmployeeName);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, Gender);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, Email);

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #endregion

        #region Department Table
        #region dbo.PR_EMP_Department_SelectAll
        public DataTable dbo_PR_EMP_Department_SelectAll(EMP_DepartmentModel modelEMP_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Department_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Department_SelectByPK
        public DataTable dbo_PR_EMP_Department_SelectByPK(int? DepID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Department_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "DepID", SqlDbType.Int, DepID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Department_Insert
        public DataTable dbo_PR_EMP_Department_Insert(EMP_DepartmentModel modelEMP_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Department_Insert");
                sqlDB.AddInParameter(dbCMD, "Department", SqlDbType.NVarChar, modelEMP_Department.Department);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Department_UpdateByPK
        public DataTable dbo_PR_EMP_Department_UpdateByPK(EMP_DepartmentModel modelEMP_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Department_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "DepID ", SqlDbType.Int, modelEMP_Department.DepID);
                sqlDB.AddInParameter(dbCMD, "Department", SqlDbType.NVarChar, modelEMP_Department.Department);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Department_DeleteByPK
        public DataTable dbo_PR_EMP_Department_DeleteByPK(int? DepID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Department_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "DepID", SqlDbType.Int, DepID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_EMP_Department_SelectByPage
        public DataTable dbo_PR_EMP_Department_SelectByPage(string Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Department_SelectByPage");
                DataTable dt = new DataTable();
                sqlDB.AddInParameter(dbCMD, "Department", SqlDbType.NVarChar, Department);

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #endregion


    }
}
