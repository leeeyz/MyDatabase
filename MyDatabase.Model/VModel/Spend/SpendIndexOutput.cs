using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Model.VModel.Spend
{
    public class SpendIndexOutput
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

        public string SpendFeeFormat
        {
            get
            {
                if (SpendFee.HasValue)
                {
                    return decimal.Round(SpendFee.Value, 2).ToString() + "元";
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 花费时间
        /// </summary>
        public DateTime? SpendDate
        {
            get;
            set;
        }

        public string SpendDateFormat
        {
            get
            {
                if (SpendDate.HasValue)
                {
                    return SpendDate.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 花费类型
        /// </summary>
        public int? SpendType
        {
            get;
            set;
        }

        public string SpendTypeFormat
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
