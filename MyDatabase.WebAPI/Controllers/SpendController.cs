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
        private ISpendService SpendService = BLLContainer.Container.Resolve<ISpendService>();

        #region SpendType
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

        [Route("SpendTypeSelectItems")]
        [HttpGet]
        public HttpResponseMessage SpendTypeSelectItems()
        {
            try
            {
                var items = SpendTypeService.GetAll();
                return Common.GetHttpResponseMessage(new ResponseSelectItems(selectItems: items.Select(x => new KeyValuePair<int, string>(x.ID.Value, x.TypeName)).ToList()));
            }
            catch (Exception ex)
            {
                return Common.GetHttpResponseMessage(new ResponseSelectItems(false, ex.Message));
            }
        }
        #endregion

        #region Spend
        [Route("SpendIndex")]
        [HttpGet]
        public HttpResponseMessage SpendIndex(int pageIndex, int pageSize, string spendDateFrom, string spendDateTo, string spendTypes)
        {
            try
            {
                int total = 0;
                var rows = SpendService.GetPage_SpendIndexOutput(pageIndex, pageSize, out total, spendDateFrom, spendDateTo, spendTypes);
                return Common.GetHttpResponseMessage(new ResponseData(total: total, rows: rows));
            }
            catch (Exception ex)
            {
                return Common.GetHttpResponseMessage(new ResponseData(false, ex.Message));
            }
        }

        [Route("SpendCreate")]
        [HttpPost]
        public HttpResponseMessage SpendCreate(SpendCreateInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    object result = SpendService.Create_SpendCreateInput(vmodel);
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

        [Route("SpendDetail")]
        [HttpPost]
        public HttpResponseMessage SpendDetail(SpendDetailInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    var vmodel1 = SpendService.Get_SpendDetailInput(vmodel);
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

        [Route("SpendEdit")]
        [HttpPost]
        public HttpResponseMessage SpendEdit(SpendEditInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    bool result = SpendService.Edit_SpendEditInput(vmodel);
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

        [Route("SpendDelete")]
        [HttpPost]
        public HttpResponseMessage SpendDelete(SpendDeleteInput vmodel)
        {
            try
            {
                if (vmodel != null && ModelState.IsValid)
                {
                    bool result = SpendService.Delete_SpendDeleteInput(vmodel);
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
        #endregion
    }
}
