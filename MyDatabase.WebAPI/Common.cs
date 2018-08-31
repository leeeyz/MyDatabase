using MyDatabase.WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MyDatabase.WebAPI
{
    public static class Common
    {
        public static HttpResponseMessage GetHttpResponseMessage(ResponseJson responseJson)
        {
            return new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(responseJson), Encoding.GetEncoding("UTF-8"), "application/json") };
        }
    }
}