using MyDatabase.IBLL;
using MyDatabase.Model.VModel.Spend;
using MyDatabase.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDatabase.Web.Controllers
{
    public class SpendController : Controller
    {
        private ISpendTypeService SpendTypeService = BLLContainer.Container.Resolve<ISpendTypeService>();

        [HttpPost]
        public JsonResult SpendTypeIndex(int pageIndex, int pageSize)
        {
            try
            {
                int total = 0;
                var rows = SpendTypeService.GetPage_SpendTypeIndexOutput(pageIndex, pageSize, out total);
                return Json(new ResponseData(total: total, rows: rows), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseData(false, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SpendTypeCreate(SpendTypeCreateInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    object result = SpendTypeService.Create_SpendTypeCreateInput(vmodel);
                    if (result == null)
                    {
                        throw new Exception("增加失败，请重试！");
                    }
                    return Json(new ResponseJson(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("增加失败，请重试！");
                }
            }
            catch(Exception ex)
            {
                return Json(new ResponseJson(false, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SpendTypeDetail(SpendTypeDetailInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    var vmodel1 = SpendTypeService.Get_SpendTypeDetailInput(vmodel);
                    if (vmodel1 == null)
                    {
                        throw new Exception("获取失败，请重试！");
                    }
                    return Json(new ResponseVModel(vmodel: vmodel1), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("获取失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                return Json(new ResponseVModel(false, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SpendTypeEdit(SpendTypeEditInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    bool result = SpendTypeService.Edit_SpendTypeEditInput(vmodel);
                    if (!result)
                    {
                        throw new Exception("修改失败，请重试！");
                    }
                    return Json(new ResponseJson(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("修改失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                return Json(new ResponseJson(false, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SpendTypeDelete(SpendTypeDeleteInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    bool result = SpendTypeService.Delete_SpendTypeDeleteInput(vmodel);
                    if (!result)
                    {
                        throw new Exception("删除失败，请重试！");
                    }
                    return Json(new ResponseJson(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("删除失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                return Json(new ResponseJson(false, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}