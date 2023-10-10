using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using OnlineMobileShopping.DAL;

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
    }
}
