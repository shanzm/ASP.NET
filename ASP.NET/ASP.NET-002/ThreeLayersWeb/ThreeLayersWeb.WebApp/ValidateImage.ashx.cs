using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayersWeb.Common;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// ValidateImage -调用ValidateCode.cs生成验证码图片
    /// </summary>
    public class ValidateImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string validateCode= ValidateCode.CreateValidateCode(4);//生成4位数的验证码
            ValidateCode.CreateValidateGraphic(validateCode, context);//生成验证码图片
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}