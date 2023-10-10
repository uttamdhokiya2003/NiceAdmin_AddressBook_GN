﻿using AddEditDemo.DAL;
using AddEditDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AddEditDemo.Controllers
{
    public class LOC_CountryController : Controller
    {
        LOC_DAL dalLOC=new LOC_DAL();

        #region SelectAll
        public IActionResult SelectAll() 
        {
            DataTable dt=dalLOC.dbo_PR_LOC_Country_SelectAll();
            return View("LOC_CountryList",dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_Delete(CountryID);

            //return View("EMP_EmployeeList");
            return RedirectToAction("SelectAll");
        }
        #endregion

        #region Add
        public IActionResult Add(int? CountryID)
        {
            if (CountryID != null)
            {
                DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByPK(CountryID);

                LOC_CountryModel modelLOC_Country = new LOC_CountryModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelLOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_Country.CountryName = dr["CountryName"].ToString();

                }
                return View("LOC_CountryAddEdit", modelLOC_Country);
            }
            
            return View("LOC_CountryAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(LOC_CountryModel modelLOC_Country)
        {
            if (modelLOC_Country.CountryID == null)
            {
                #region Insert
                DataTable dt = dalLOC.dbo_PR_LOC_Country_Insert(modelLOC_Country);

                TempData["CountryInsertMsg"] = "Record Inserted Successfully ! ";
                #endregion
            }
            else
            {
                #region Update
                DataTable dt = dalLOC.dbo_PR_LOC_Country_Update(modelLOC_Country);

                TempData["CountryInsertMsg"] = "Record Updated Successfully ! ";
                #endregion
            }

            return RedirectToAction("ADD");
            //return View("LOC_CountryAddEdit");
        }
        #endregion

        #region filter 
        public IActionResult Filter(string CountryName)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByCountryName(CountryName);
            return View("LOC_CountryList", dt);
        }
        #endregion
    }
}
