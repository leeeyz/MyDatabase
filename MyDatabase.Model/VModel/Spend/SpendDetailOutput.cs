using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Model.VModel.Spend
{
    public class SpendDetailOutput
    {
        /// <summary>
        /// ID
        /// </summary>
        public int? ID
        {
            get;
            set;
        }

        /// <summary>
        /// 花费
        /// </summary>
        public decimal? SpendFee
        {
            get;
            set;
        }

        /// <summary>
        /// 花费时间
        /// </summary>
        public DateTime? SpendDate
        {
            get;
            set;
        }

        /// <summary>
        /// 花费类型
        /// </summary>
        public int? SpendType
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
    }
}
