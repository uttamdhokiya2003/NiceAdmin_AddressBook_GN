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
using AddEditDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AddEditDemo.Areas.MST_Product.Controllers
{
    [Area("MST_Product")]
    [Route("MST_Product/[Controller]/[action]")]
    public class MST_ProductController : Controller
    {
        MST_DAL dalMST = new MST_DAL();
        EMP_DAL dalEMP = new EMP_DAL();

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
            SetHobbyDropDownList();
            if (ProductID != null)
            {
                DataTable dt = dalMST.dbo_PR_MST_Product_SelectByPK(ProductID);

                MST_ProductModel modelMST_Product = new MST_ProductModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelMST_Product.ProductID = Convert.ToInt32(dr["ProductID"]);
                    modelMST_Product.HID = Convert.ToInt32(dr["HID"]);
                    modelMST_Product.ProductName = dr["ProductName"].ToString();
                    modelMST_Product.Description = dr["Description"].ToString();
                    modelMST_Product.IsActive = dr["IsActive"].ToString();

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

        #region HobbyDropdown

        public void SetHobbyDropDownList()
        {
            DataTable dt2 = dalEMP.dbo_PR_HOB_Hobby_SelectCheckbox();
            List<HOB_HobbyDropdownModel> List2 = new List<HOB_HobbyDropdownModel>();
            foreach (DataRow dr2 in dt2.Rows)
            {
                HOB_HobbyDropdownModel vlst2 = new HOB_HobbyDropdownModel();
                vlst2.HID = Convert.ToInt32(dr2["HID"]);
                vlst2.Hobby = dr2["Hobby"].ToString();
                List2.Add(vlst2);
            }
            var Hobbies = new List<SelectListItem>();
            foreach(var Hobbylist in List2)
            {
                Hobbies.Add(new SelectListItem
                {
                    Value= Hobbylist.Hobby,
                    Text=Hobbylist.Hobby
                });
            }
            ViewBag.HobbyList = Hobbies;
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
                    HID = Convert.ToInt32(dr["HID"]),
                    Hobby = dr["Hobby"].ToString(),
                    Description = dr["Description"].ToString(),
                    IsActive = dr["IsActive"].ToString()
                }) ;
            }

            SetHobbyDropDownList();

            return View("MST_ProductEditMultiple", products);
        }
        #endregion

        #region Edit
        [HttpPost]
        public IActionResult Edit(List<MST_ProductModel> products)
        {
           
            
                foreach (var product in products)
                {
                    if (Convert.ToBoolean(dalMST.dbo_PR_MST_Product_UpdateByPK(product)))
                    {
                        TempData["success"] = "Record Updated successfully.";
                    }
                }
                return RedirectToAction("Index");
            
            return View(products);
        }
        #endregion
    }
}
