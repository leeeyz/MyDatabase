﻿using MDORM.DapperExt;
using MyDatabase.Model;
using MyDatabase.Model.VModel.Spend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.IBLL
{
    public partial interface ISpendService : IBaseService<Spend>
    {
        /// <summary>
        /// 分页获取,默认按照时间降序排序
        /// </summary>
        /// <param name="pageIndex">页索引页索引（从0开始）</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="allRowsCount">全部记录数</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        List<Spend> GetPage(int pageIndex, int pageSize, out int allRowsCount, object predicate = null, IList<ISort> sort = null);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="primaryId">主键</param>
        /// <returns></returns>
        bool DeleteById(object primaryId);

        List<SpendIndexOutput> GetPage_SpendIndexOutput(int pageIndex, int pageSize, out int allRowsCount, string spendDateFrom, string spendDateTo, string spendTypes);

        object Create_SpendCreateInput(SpendCreateInput vmodel);

        SpendDetailOutput Get_SpendDetailInput(SpendDetailInput vmodel);

        bool Edit_SpendEditInput(SpendEditInput vmodel);

        bool Delete_SpendDeleteInput(SpendDeleteInput vmodel);
    }
}
