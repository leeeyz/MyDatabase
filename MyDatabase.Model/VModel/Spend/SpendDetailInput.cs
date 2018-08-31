using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.Model.VModel.Spend
{
    public class SpendDetailInput
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public int? ID
        {
            get;
            set;
        }
    }
}
