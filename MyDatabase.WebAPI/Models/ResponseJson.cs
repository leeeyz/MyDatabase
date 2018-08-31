using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDatabase.WebAPI.Models
{
    /// <summary>
    /// 返回用于字符串
    /// </summary>
    public class ResponseJson
    {
        public ResponseJson(bool isSuccess = true, string msg = "")
        {
            this.IsSuccess = isSuccess;
            this.Msg = msg;
        }

        public bool IsSuccess { get; }
        public string Msg { get; }
    }

    /// <summary>
    /// 返回用于表格
    /// </summary>
    public class ResponseData : ResponseJson
    {
        public ResponseData(bool isSuccess = true, string msg = "", int total = 0, object rows = null)
            : base(isSuccess, msg)
        {
            this.Total = total;
            this.Rows = rows;
        }

        public int Total { get; }
        public object Rows { get; }
    }

    /// <summary>
    /// 返回用于实体
    /// </summary>
    public class ResponseVModel : ResponseJson
    {
        public ResponseVModel(bool isSuccess = true, string msg = "", object vmodel = null)
            : base(isSuccess, msg)
        {
            this.VModel = vmodel;
        }

        public object VModel { get; }
    }

    /// <summary>
    /// 返回用于下拉框
    /// </summary>
    public class ResponseSelectItems : ResponseJson
    {
        public ResponseSelectItems(bool isSuccess = true, string msg = "", List<KeyValuePair<int, string>> selectItems = null)
            : base(isSuccess, msg)
        {
            this.SelectItems = selectItems;
        }

        public List<KeyValuePair<int,string>> SelectItems { get; }
    }
}