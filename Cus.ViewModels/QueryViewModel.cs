//using Cus.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cus.ViewModels
{
    public class QueryViewModel
    {
        /// <summary>
        /// 主畫面 Grid
        /// </summary>
        public IEnumerable<CusOrderViewModel> CUS_Ordes { get; set; }
        /// <summary>
        /// 客戶下拉清單
        /// </summary>
        public IEnumerable<CustomerViewModel> CustomerList { get; set; }
        public QueryParam QUERY_PARAM { get; set; }
    }
}