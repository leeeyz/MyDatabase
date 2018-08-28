
///=========================================================================
/// 版    权： Coypright 2012 - 2018 @ lyz
/// 文件名称： Spend.cs
/// 模版作者： zhumingming(berton) 最后修改于 2016-5-27 16:10:10
/// 作者邮箱： zhumingming1040@163.com,937553351@qq.com
/// 描    述： 单独生成的代码，请在代码生成后手动添加【描述】信息
/// 创 建 人： zhumingming(Berton) (CodeSmith V6.5.0 自动生成的代码 模板V4.0)
/// 创建时间： 2018/8/28 14:57:08
///=========================================================================

using System;
using System.Text;
using MDORM.DapperExt.Mapper;

namespace MyDatabase.Model
{
    /// <summary>
 	/// Spend 实体类,包括:属性，重写的ToString方法
 	/// </summary>
    /// 创建人：zhumingming(Berton)
    /// 创建时间：2018/8/28 14:57:08
	[Serializable]
    public class Spend
    {
        #region 成员变量
        private int? _iD;
        private decimal? _spendFee;
        private DateTime? _spendDate;
        private int? _spendType;
        private string _remark;
        #endregion

        #region 属性
        /// <summary>
        /// 主键
        /// </summary>
        public int? ID
        {
            get { return this._iD; }
            set { this._iD = value; }
        }

        /// <summary>
        /// 花费
        /// </summary>
        public decimal? SpendFee
        {
            get { return this._spendFee; }
            set { this._spendFee = value; }
        }

        /// <summary>
        /// 花费时间
        /// </summary>
        public DateTime? SpendDate
        {
            get { return this._spendDate; }
            set { this._spendDate = value; }
        }

        /// <summary>
        /// 花费类型
        /// </summary>
        public int? SpendType
        {
            get { return this._spendType; }
            set { this._spendType = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        #endregion

        #region 扩展的变量、属性、方法
        /// <summary>
        /// 返回这个对象的JSON格式字符串，方便记录日志
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            temp.Append("[{ ");
            temp.AppendFormat("\"ID\":\"{0}\", ", this.ID);
            temp.AppendFormat("\"SpendFee\":\"{0}\", ", this.SpendFee);
            temp.AppendFormat("\"SpendDate\":\"{0}\", ", this.SpendDate);
            temp.AppendFormat("\"SpendType\":\"{0}\", ", this.SpendType);
            temp.AppendFormat("\"Remark\":\"{0}\", ", this.Remark);
            int lastPos = temp.ToString().LastIndexOf(',');
            if (lastPos != -1)
                temp = temp.Remove(lastPos, 1);
            temp.Append("}]");
            return temp.ToString();
        }
        #endregion
    }

    /// <summary>
    /// Spend 映射类
    /// </summary>
    /// 创建人：朱明明
    /// 创建时间：2016/5/23 15:03:02

    [Serializable]
    public class SpendMapper : ClassMapper<Spend>
    {
        /// <summary>
 	    /// Spend Mapper构造函数（可自定义Mapper）
 	    /// </summary>
        public SpendMapper()
        {
            base.Table("Spend");
            Map(f => f.ID).Key(KeyType.Identity);
            AutoMap();
        }
    }
}