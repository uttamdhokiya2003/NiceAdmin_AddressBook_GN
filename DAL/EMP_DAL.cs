using AddEditDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace AddEditDemo.DAL
{
    public class EMP_DAL : EMP_DALBase
    {
        #region dbo.PR_EMP_Department_SelectByDropdown
        public DataTable dbo_PR_EMP_Department_SelectByDropdown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_EMP_Department_SelectByDropdown");

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

        #region  dbo.PR_HOB_Hobby_SelectCheckbox
        public DataTable dbo_PR_HOB_Hobby_SelectCheckbox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_HOB_Hobby_SelectCheckbox");
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
