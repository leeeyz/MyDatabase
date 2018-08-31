using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Model.VModel.Spend
{
    public class SpendCreateInput
    {
        /// <summary>
        /// 花费
        /// </summary>
        [Required]
        public decimal? SpendFee
        {
            get;
            set;
        }

        /// <summary>
        /// 花费时间
        /// </summary>
        [Required]
        public DateTime? SpendDate
        {
            get;
            set;
        }

        /// <summary>
        /// 花费类型
        /// </summary>
        [Required]
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
