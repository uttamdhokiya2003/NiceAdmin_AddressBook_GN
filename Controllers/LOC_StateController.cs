using AddEditDemo.DAL;
using AddEditDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AddEditDemo.Controllers
{
    public class LOC_StateController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region SelectAll
        public IActionResult SelectAll(LOC_StateModel modelLOC_State)
        {
            #region Select For Country Dropdown
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectByDropdown();
            List<Countrydropdown> List = new List<Countrydropdown>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                Countrydropdown vlst = new Countrydropdown();
                vlst.CountryID = Convert.ToInt32(dr1["CountryID"]);
                vlst.CountryName = dr1["CountryName"].ToString();
                List.Add(vlst);
            }
            ViewBag.CountryList = List;

            #endregion

            DataTable dt = dalLOC.dbo_PR_LOC_State_SelectAll(modelLOC_State);
            return View("LOC_StateList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StateID)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_State_Delete(StateID);

            //return View("EMP_EmployeeList");
            return RedirectToAction("SelectAll");
        }
        #endregion

        #region Add
        public IActionResult Add(int? StateID)
        {
            #region Select For Country Dropdown
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectByDropdown();
            List<Countrydropdown> List = new List<Countrydropdown>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                Countrydropdown vlst = new Countrydropdown();
                vlst.CountryID = Convert.ToInt32(dr1["CountryID"]);
                vlst.CountryName = dr1["CountryName"].ToString();
                List.Add(vlst);
            }
            ViewBag.CountryList = List;

            #endregion


            if (StateID != null)
            {
                DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByPK(StateID);

                LOC_StateModel modelLOC_State = new LOC_StateModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_State.StateName = dr["StateName"].ToString();

                }
                return View("LOC_StateAddEdit", modelLOC_State);
            }

            return View("LOC_StateAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {
            if (modelLOC_State.StateID == null)
            {
                #region Insert
                DataTable dt = dalLOC.dbo_PR_LOC_State_Insert(modelLOC_State);

                TempData["StateInsertMsg"] = "Record Inserted Successfully ! ";
                #endregion
            }
            else
            {
                #region Update
                DataTable dt = dalLOC.dbo_PR_LOC_State_Update(modelLOC_State);

                TempData["StateInsertMsg"] = "Record Updated Successfully ! ";
                #endregion
            }

            return RedirectToAction("ADD");
            //return View("LOC_StateAddEdit");
        }
        #endregion

        #region filter 
        //public IActionResult Filter(string Countryname, string Statename)
        //{
        //    DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByStateNameCountryName(Countryname, Statename);
        //    return View("LOC_StateList", dt);
        //}
        #endregion 

        #region New filter
        public IActionResult Filter(int CountryID, string StateName)
        {
           DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByStateNameCountryID(CountryID, StateName);
           return View("LOC_StateList", dt);
        }
        #endregion

    }
}
