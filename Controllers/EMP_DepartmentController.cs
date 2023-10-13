using AddEditDemo.Areas.EMP_Department.Models;
using AddEditDemo.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AddEditDemo.Controllers
{
    public class EMP_DepartmentController : Controller
    {
        EMP_DAL dalEMP = new EMP_DAL();

        #region SelectAll
        public IActionResult SelectAll(EMP_DepartmentModel modelEMP_Department)
        {
            DataTable dt = dalEMP.dbo_PR_EMP_Department_SelectAll(modelEMP_Department);
            //string str = this.Configuration.GetConnectionString("myConnectionString");
            ////Prepare a Connection
            //DataTable dt = new DataTable();
            //SqlConnection conn = new SqlConnection(str);
            //conn.Open();
            //SqlCommand objCmd = conn.CreateCommand();
            //objCmd.CommandType = CommandType.StoredProcedure;
            //objCmd.CommandText = "PR_Emp_Employee_SelectAll";
            //SqlDataReader objSDR = objCmd.ExecuteReader();
            //dt.Load(objSDR);

            return View("EMP_DepartmentList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int DepID)
        {
            DataTable dt = dalEMP.dbo_PR_EMP_Department_DeleteByPK(DepID);

            //return View("EMP_Department");
            return RedirectToAction("SelectAll");
        }
        #endregion

        #region Add
        public IActionResult Add(int? DepID)
        {
            if (DepID != null)
            {
                DataTable dt = dalEMP.dbo_PR_EMP_Department_SelectByPK(DepID);

                EMP_DepartmentModel modelEMP_Department = new EMP_DepartmentModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelEMP_Department.DepID = Convert.ToInt32(dr["DepID"]);
                    modelEMP_Department.Department = dr["Department"].ToString();

                }
                return View("EMP_DepartmentAddEdit", modelEMP_Department);
            }

            return View("EMP_DepartmentAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(EMP_DepartmentModel modelEMP_Department)
        {
            if (ModelState.IsValid)
            {
                if (modelEMP_Department.DepID == null)
                {
                    #region Insert
                    DataTable dt = dalEMP.dbo_PR_EMP_Department_Insert(modelEMP_Department);
                     
                    TempData["DepartmentInsertMsg"] = "Record Inserted Successfully ! ";
                    #endregion
                }
                else
                {
                    #region Update
                    DataTable dt = dalEMP.dbo_PR_EMP_Department_UpdateByPK(modelEMP_Department);

                    TempData["DepartmentInsertMsg"] = "Record Updated Successfully ! ";
                    #endregion
                }

            }
            return RedirectToAction("ADD");
            //return View("EMP_DepartmentAddEdit");
        }
        #endregion

        #region filter 
        public IActionResult Filter(string Department)
        {
            DataTable dt = dalEMP.dbo_PR_EMP_Department_SelectByPage(Department);
            return View("EMP_DepartmentList", dt);
        }
        #endregion
    }
}
