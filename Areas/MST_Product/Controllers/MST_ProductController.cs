using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using AddEditDemo.DAL;
using AddEditDemo.Areas.MST_Product.Models;
using AddEditDemo.Areas.LOC_Country.Models;
using AddEditDemo.Areas.LOC_State.Models;
using AddEditDemo.Areas.EMP_Employee.Models;

namespace AddEditDemo.Areas.MST_Product.Controllers
{
    [Area("MST_Product")]
    [Route("MST_Product/[Controller]/[action]")]
    public class MST_ProductController : Controller
    {
        MST_DAL dalMST = new MST_DAL();

        #region Index
        public IActionResult Index()
        {
            DataTable dt = dalMST.dbo_PR_MST_Product_SelectAll();

            return View("MST_ProductList", dt);
        }
        #endregion

        #region Add
        public IActionResult Add(int? ProductID)
        {
            if (ProductID != null)
            {
                DataTable dt = dalMST.dbo_PR_MST_Product_SelectByPK(ProductID);

                MST_ProductModel modelMST_Product = new MST_ProductModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelMST_Product.ProductID = Convert.ToInt32(dr["ProductID"]);
                    modelMST_Product.ProductName = dr["ProductName"].ToString();
                    modelMST_Product.Description = dr["Description"].ToString();

                }
                return View("MST_ProductAddEdit", modelMST_Product);
            }
            return View("MST_ProductAddEdit");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ProductID)
        {
            DataTable dt = dalMST.dbo_PR_MST_Product_Delete(ProductID);

            //return View("EMP_EmployeeList");
            return RedirectToAction("Index");
        }
        #endregion

        #region Insert
        public IActionResult Insert(MST_ProductModel modelMST_Product)
        {
            #region Insert
            if (modelMST_Product.ProductID == null)
            {
                if (Convert.ToBoolean(dalMST.dbo_PR_MST_Product_Insert(modelMST_Product)))
                    TempData["ProductInsertMsg"] = "Record Inserted Successfully";
                return RedirectToAction("Add");

            }
            #endregion

            #region Update
            else
            {
                if (Convert.ToBoolean(dalMST.dbo_PR_MST_Product_UpdateByPK(modelMST_Product)))
                    TempData["ProductInsertMsg"] = "Record Updated Successfully";
                return RedirectToAction("Add");
            }
            #endregion
        }
        #endregion

        #region EditMultiple
        public IActionResult EditMultiple()
        {
            List<MST_ProductModel> products = new List<MST_ProductModel>();

            DataTable dt = dalMST.dbo_PR_MST_Product_SelectAll();

            foreach (DataRow dr in dt.Rows)
            {
                products.Add(new MST_ProductModel
                {
                    ProductID = Convert.ToInt32(dr["ProductID"]),
                    ProductName = dr["ProductName"].ToString(),
                    Description = dr["Description"].ToString()
                });

            }

            return View("MST_ProductEditMultiple", products);
        }
        #endregion

        #region Edit
        [HttpPost]
        public IActionResult Edit(List<MST_ProductModel> products)
        {
            if (ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    if (Convert.ToBoolean(dalMST.dbo_PR_MST_Product_UpdateByPK(product)))
                    {
                        TempData["success"] = "Record Updated successfully.";
                    }
                }
                return RedirectToAction("Index");
            }
            return View(products);
        }
        #endregion
    }
}
