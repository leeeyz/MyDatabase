﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Model.VModel.Spend
{
    public class SpendTypeDetailOutput
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
        /// 花费类型名称
        /// </summary>
        public string TypeName
        {
            get;
            set;
        }
    }
}
