using AutoMapper;
using MDORM.DapperExt;
using MyDatabase.IBLL;
using MyDatabase.IDAL;
using MyDatabase.Model;
using MyDatabase.Model.VModel.Spend;
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

        public List<SpendTypeIndexOutput> GetPage_SpendTypeIndexOutput(int pageIndex, int pageSize, out int allRowsCount)
        {
            var model = GetPage(pageIndex, pageSize, out allRowsCount);
            return Mapper.Map<List<SpendTypeIndexOutput>>(model);
        }

        public object Create_SpendTypeCreateInput(SpendTypeCreateInput vmodel)
        {
            var model = Mapper.Map<SpendType>(vmodel);
            return Dal.Insert(model);
        }

        public SpendTypeDetailOutput Get_SpendTypeDetailInput(SpendTypeDetailInput vmodel)
        {
            var model = Mapper.Map<SpendType>(vmodel);
            var model1 = Dal.GetById(model.ID);
            return Mapper.Map<SpendTypeDetailOutput>(model1);
        }

        public bool Edit_SpendTypeEditInput(SpendTypeEditInput vmodel)
        {
            var model = Mapper.Map<SpendType>(vmodel);
            return Dal.Update(model);
        }

        public bool Delete_SpendTypeDeleteInput(SpendTypeDeleteInput vmodel)
        {
            var model = Mapper.Map<SpendType>(vmodel);
            return DeleteById(model.ID);
        }
    }
}
