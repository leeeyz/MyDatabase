using MyDatabase.IBLL;
using MyDatabase.Model.VModel.Spend;
using MyDatabase.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDatabase.WebAPI.Controllers
{
    [RoutePrefix("api/Spend")]
    public class SpendController : ApiController
    {
        private ISpendTypeService SpendTypeService = BLLContainer.Container.Resolve<ISpendTypeService>();

        [Route("SpendTypeIndex")]
        [HttpGet]
        public HttpResponseMessage SpendTypeIndex(int pageIndex, int pageSize)
        {
            try
            {
                int total = 0;
                var rows = SpendTypeService.GetPage_SpendTypeIndexOutput(pageIndex, pageSize, out total);
                return Common.GetHttpResponseMessage(new ResponseData(total: total, rows: rows));
            }
            catch (Exception ex)
            {
                return Common.GetHttpResponseMessage(new ResponseData(false, ex.Message));
            }
        }

        [Route("SpendTypeCreate")]
        [HttpPost]
        public HttpResponseMessage SpendTypeCreate(SpendTypeCreateInput vmodel)
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
                    return Common.GetHttpResponseMessage(new ResponseJson());
                }
                else
                {
                    throw new Exception("增加失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                return Common.GetHttpResponseMessage(new ResponseJson(false, ex.Message));
            }
        }

        [Route("SpendTypeDetail")]
        [HttpPost]
        public HttpResponseMessage SpendTypeDetail(SpendTypeDetailInput vmodel)
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
                    return Common.GetHttpResponseMessage(new ResponseVModel(vmodel: vmodel1));
                }
                else
                {
                    throw new Exception("获取失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                return Common.GetHttpResponseMessage(new ResponseVModel(false, ex.Message));
            }
        }

        [Route("SpendTypeEdit")]
        [HttpPost]
        public HttpResponseMessage SpendTypeEdit(SpendTypeEditInput vmodel)
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
                    return Common.GetHttpResponseMessage(new ResponseJson());
                }
                else
                {
                    throw new Exception("修改失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                return Common.GetHttpResponseMessage(new ResponseJson(false, ex.Message));
            }
        }

        [Route("SpendTypeDelete")]
        [HttpPost]
        public HttpResponseMessage SpendTypeDelete(SpendTypeDeleteInput vmodel)
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
                    return Common.GetHttpResponseMessage(new ResponseJson());
                }
                else
                {
                    throw new Exception("删除失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                return Common.GetHttpResponseMessage(new ResponseJson(false, ex.Message));
            }
        }
    }
}
