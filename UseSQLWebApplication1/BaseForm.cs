using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cus.WebForm
{
    public class BaseForm: System.Web.UI.Page
    {
        #region 顯示 JavaScript Alert
        /// <summary>
        /// 顯示 JavaScript Alert
        /// </summary>
        /// <param name="Message"></param>
        protected virtual void Alert(string Message)
        {
            ClientScript.RegisterClientScriptBlock(
                Page.GetType(),
                "_JAVASCRIPT_ALERT",
                string.Format("alert('{0}');",
                Message),
                true);
        }
        #endregion
    }
}