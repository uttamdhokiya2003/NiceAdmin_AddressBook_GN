using AddEditDemo.DAL;
using AddEditDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Net;

namespace AddEditDemo.Controllers
{
    public class EMP_EmployeeController : Controller
    {
        EMP_DAL dalEMP = new EMP_DAL();
        MST_DAL dalMST = new MST_DAL();
        #region Index
        public IActionResult Index()
        {
            DataTable dt1 = dalMST.dbo_PR_MST_CountryStateCityEmployee_Count();
            DataTable dt2 = dalMST.dbo_PR_MST_Employee_SelectRecent();
            DataTable dt3 = dalMST.dbo_PR_MST_Country_SelectRecent();

            var viewmodel = new Datatable_ViewModel
            {
                Datatable1 = dt1,
                Datatable2 = dt2,
                Datatable3 = dt3

            };
            return View(viewmodel);
        }
        #endregion

        #region SelectAll
        public IActionResult SelectAll()
        {
            DataTable dt = dalEMP.dbo_PR_EMP_Employee_SelectAll();
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

            return View("EMP_EmployeeList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int EmployeeID)
        {
            DataTable dt = dalEMP.dbo_PR_EMP_Employee_Delete(EmployeeID);

            //return View("EMP_EmployeeList");
            return RedirectToAction("SelectAll");
        }
        #endregion

        #region Add
        public IActionResult Add(int? EmployeeID, EMP_EmployeeModel modelEmp_employee)
        {
            #region Select For Department Dropdown
            DataTable dt1 = dalEMP.dbo_PR_EMP_Department_SelectByDropdown();
            List<DepartmentDropDown> List = new List<DepartmentDropDown>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                DepartmentDropDown vlst = new DepartmentDropDown();
                vlst.DepID = Convert.ToInt32(dr1["DepID"]);
                vlst.Department = dr1["Department"].ToString();
                List.Add(vlst);
            }
            ViewBag.DepartmentList = List;

            #endregion

            #region HobbyDropdown

            DataTable dt2 = dalEMP.dbo_PR_HOB_Hobby_SelectCheckbox();
            List<HOB_HobbyDropdownModel> List2 = new List<HOB_HobbyDropdownModel>();
            foreach (DataRow dr2 in dt2.Rows)
            {
                HOB_HobbyDropdownModel vlst2 = new HOB_HobbyDropdownModel();
                vlst2.HID = Convert.ToInt32(dr2["HID"]);
                vlst2.Hobby = dr2["Hobby"].ToString();
                List2.Add(vlst2);
            }
            ViewBag.HobbyList = List2;
            #endregion


            if (EmployeeID != null)
            {
                DataTable dt = dalEMP.dbo_PR_EMP_Employee_SelectByPK(EmployeeID);

                EMP_EmployeeModel modelEMP_Employee = new EMP_EmployeeModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelEMP_Employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    modelEMP_Employee.EmployeeName = dr["EmployeeName"].ToString();
                    modelEMP_Employee.DepID = Convert.ToInt32(dr["DepID"]);
                    modelEMP_Employee.Address = dr["Address"].ToString();
                    modelEMP_Employee.Gender = dr["Gender"].ToString();
                    modelEMP_Employee.Mobile = dr["Mobile"].ToString();
                    modelEMP_Employee.Email = dr["Email"].ToString();
                    modelEMP_Employee.JoiningDate = Convert.ToDateTime(dr["JoiningDate"]);
                    modelEMP_Employee.Salary = Convert.ToInt32(dr["Salary"]);

                }
                return View("EMP_EmployeeAddEdit", modelEMP_Employee);
            }
            #region Select For Hobby Checkbox
            //DataTable dt2 = dalEMP.dbo_PR_HOB_Hobby_SelectByDropdown();
            //ViewModels modelHobby = new ViewModels();
            //foreach (DataRow dr2 in dt2.Rows)
            //{
            //    modelHobby.HID = Convert.ToInt32(dr2["HID"]);
            //    modelHobby.Hobby = dr2["Hobby"].ToString();
            //}
            //return View("EMP_EmployeeAddEdit", modelHobby);

            ////List<HobbyDropdown> List1 = new List<HobbyDropdown>();
            ////foreach (DataRow dr2 in dt2.Rows)
            ////{
            ////    HobbyDropdown vlst1 = new HobbyDropdown();
            ////    vlst1.HID = Convert.ToInt32(dr2["HID"]);
            ////    vlst1.Hobby = dr2["Hobby"].ToString();
            ////    List1.Add(vlst1);
            ////}
            ////ViewBag.HobbyList = List1;

            #endregion
            return View("EMP_EmployeeAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(EMP_EmployeeModel modelEMP_Employee)
        {
            //if (modelEMP_Employee.EmployeeID == null)
            //{

            #region Insert
            //DataTable dt = dalEMP.dbo_PR_EMP_Employee_Insert(modelEMP_Employee);
            if (modelEMP_Employee.EmployeeID == null)
            {
                if (Convert.ToBoolean(dalEMP.dbo_PR_EMP_Employee_Insert(modelEMP_Employee)))
                    if (Convert.ToBoolean(dalEMP.dbo_PR_EWH_EmployeeWiseHobby_Insert(modelEMP_Employee)))
                        TempData["EmployeeInsertMsg"] = "Record Inserted Successfully";
            }
            #endregion

            #region Update
            else
            {
                if (Convert.ToBoolean(dalEMP.dbo_PR_EMP_Employee_Update(modelEMP_Employee)))
                    if (Convert.ToBoolean(dalEMP.dbo_PR_EWH_EmployeeWiseHobby_Insert(modelEMP_Employee)))
                        TempData["EmployeeInsertMsg"] = "Record Updated Successfully";

                return RedirectToAction("Add");


            }
            //TempData["EmployeeInsertMsg"] = "Record Inserted Successfully ! ";
            #endregion

            //}
            //else
            //{
            //    #region Update
            //    DataTable dt = dalEMP.dbo_PR_EMP_Employee_Update(modelEMP_Employee);

            //    TempData["EmployeeInsertMsg"] = "Record Updated Successfully ! ";
            //    #endregion
            //}

            return RedirectToAction("Add");
            //return View("EMP_EmployeeAddEdit");
        }
        #endregion

        #region filter 
        public IActionResult Filter(string EmployeeName, string Gender, string Email)
        {
            DataTable dt = dalEMP.dbo_PR_EMP_Employee_SelectByPage(EmployeeName, Gender, Email);
            return View("EMP_EmployeeList", dt);
        }
        #endregion

        #region Delete Multiple
        [HttpPost]
        public IActionResult DeleteMultiple(int[] Ids)
        {
            string result = string.Empty;
            if (Ids.Count() > 0)
            {
                foreach (int id in Ids)
                {
                    dalEMP.dbo_PR_EMP_Employee_Delete(id);
                }
                TempData["success"] = "Record deleted successfully.";
                result = "success";
            }
            return new JsonResult(result);
        }
        #endregion
    }
}
