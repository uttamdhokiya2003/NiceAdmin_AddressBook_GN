using AddEditDemo.DAL;
using AddEditDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AddEditDemo.Controllers
{
    public class HomeController : Controller
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


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CountAll()
        {
            return View();
        }
    }
}
