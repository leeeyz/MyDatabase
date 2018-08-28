using MDORM.DapperExt;
using MyDatabase.IBLL;
using MyDatabase.IDAL;
using MyDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.BLL
{
    public partial class SpendTypeService : BaseService<SpendType>, ISpendTypeService
    {
        private ISpendTypeDAL SpendTypeDAL = DALContainer.Container.Resolve<ISpendTypeDAL>();
        public override void SetDal()
        {
            Dal = SpendTypeDAL;
        }

        /// <summary>
        /// 分页获取,默认按照时间降序排序
        /// </summary>
        /// <param name="pageIndex">页索引页索引（从0开始）</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="allRowsCount">全部记录数</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public List<SpendType> GetPage(int pageIndex, int pageSize, out int allRowsCount, object predicate = null, IList<ISort> sort = null)
        {
            return SpendTypeDAL.GetPage(pageIndex, pageSize, out allRowsCount, predicate, sort);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="primaryId">主键</param>
        /// <returns></returns>
        public bool DeleteById(object primaryId)
        {
            return SpendTypeDAL.DeleteById(primaryId);
        }
    }
}
