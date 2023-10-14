using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using OnlineMobileShopping.DAL;
using AddEditDemo.Areas.EMP_Employee.Models;
using AddEditDemo.Areas.MST_Product.Models;

namespace AddEditDemo.DAL
{
	public class MST_DALBase : DAL_Helper
    {
		#region PR_MST_CountryStateCityEmployee_Count
		public DataTable dbo_PR_MST_CountryStateCityEmployee_Count()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_CountryStateCityEmployee_Count");
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

        #region PR_MST_Employee_SelectRecent
        public DataTable dbo_PR_MST_Employee_SelectRecent()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Employee_SelectRecent");
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

        #region PR_MST_Country_SelectRecent
        public DataTable dbo_PR_MST_Country_SelectRecent()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Country_SelectRecent");
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


        #region MST_Product
        
        #region PR_MST_Product_SelectAll
        public DataTable dbo_PR_MST_Product_SelectAll() 
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Product_SelectAll");

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

        #region dbo.PR_MST_Product_Insert
        public bool? dbo_PR_MST_Product_Insert(MST_ProductModel modelMST_ProductModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Product_Insert");
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, modelMST_ProductModel.ProductName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelMST_ProductModel.Description);

                int vResultvalue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vResultvalue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_MST_Product_UpdateByPK
        public bool? dbo_PR_MST_Product_UpdateByPK(MST_ProductModel modelMST_Product)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Product_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "ProductID ", SqlDbType.Int, modelMST_Product.ProductID);
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, modelMST_Product.ProductName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelMST_Product.Description);

                int vResultvalue = sqlDB.ExecuteNonQuery(dbCMD);

                return (vResultvalue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region dbo.PR_MST_Product_Delete
        public DataTable dbo_PR_MST_Product_Delete(int? ProductID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Product_Delete");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, ProductID);

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

        #region dbo.PR_MST_Product_SelectByPK
        public DataTable dbo_PR_MST_Product_SelectByPK(int? ProductID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Product_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, ProductID);

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

        #endregion
    }
}
