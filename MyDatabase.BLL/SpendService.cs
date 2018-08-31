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
    public partial class SpendService : BaseService<Spend>, ISpendService
    {
        private ISpendDAL SpendDAL = DALContainer.Container.Resolve<ISpendDAL>();
        private ISpendTypeDAL SpendTypeDAL = DALContainer.Container.Resolve<ISpendTypeDAL>();
        public override void SetDal()
        {
            Dal = SpendDAL;
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
        public List<Spend> GetPage(int pageIndex, int pageSize, out int allRowsCount, object predicate = null, IList<ISort> sort = null)
        {
            return SpendDAL.GetPage(pageIndex, pageSize, out allRowsCount, predicate, sort);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="primaryId">主键</param>
        /// <returns></returns>
        public bool DeleteById(object primaryId)
        {
            return SpendDAL.DeleteById(primaryId);
        }

        public List<SpendIndexOutput> GetPage_SpendIndexOutput(int pageIndex, int pageSize, out int allRowsCount, string spendDateFrom, string spendDateTo, string spendTypes)
        {
            var types = SpendTypeDAL.GetAll();
            var pga = new PredicateGroup() { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            if (!string.IsNullOrEmpty(spendDateFrom) && !string.IsNullOrEmpty(spendDateTo))
            {
                DateTime dfrom = DateTime.Parse(spendDateFrom);
                DateTime dto = DateTime.Parse(spendDateTo).AddDays(1);
                pga.Predicates.Add(Predicates.Field<Spend>(f => f.SpendDate, Operator.Ge, dfrom));
                pga.Predicates.Add(Predicates.Field<Spend>(f => f.SpendDate, Operator.Lt, dto));
            }
            if (!string.IsNullOrEmpty(spendTypes))
            {
                var pga1 = new PredicateGroup() { Operator = GroupOperator.Or, Predicates = new List<IPredicate>() };
                spendTypes.Split(',').ToList().ForEach(x => {
                    pga1.Predicates.Add(Predicates.Field<Spend>(f => f.SpendType, Operator.Eq, x));
                });
                pga.Predicates.Add(pga1);
            }
            var model = GetPage(pageIndex, pageSize, out allRowsCount, pga);
            return Mapper.Map<List<SpendIndexOutput>>(model).Select(x =>
            {
                var type = types.FirstOrDefault(y => y.ID == x.SpendType);
                if (type != null)
                    x.SpendTypeFormat = type.TypeName;
                else
                    x.SpendTypeFormat = "";
                return x;
            }).ToList();
        }

        public object Create_SpendCreateInput(SpendCreateInput vmodel)
        {
            var model = Mapper.Map<Spend>(vmodel);
            return Dal.Insert(model);
        }

        public SpendDetailOutput Get_SpendDetailInput(SpendDetailInput vmodel)
        {
            var model = Mapper.Map<Spend>(vmodel);
            var model1 = Dal.GetById(model.ID);
            return Mapper.Map<SpendDetailOutput>(model1);
        }

        public bool Edit_SpendEditInput(SpendEditInput vmodel)
        {
            var model = Mapper.Map<Spend>(vmodel);
            return Dal.Update(model);
        }

        public bool Delete_SpendDeleteInput(SpendDeleteInput vmodel)
        {
            var model = Mapper.Map<Spend>(vmodel);
            return DeleteById(model.ID);
        }
    }
}
