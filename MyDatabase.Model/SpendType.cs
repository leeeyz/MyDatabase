
///=========================================================================
/// 版    权： Coypright 2012 - 2018 @ lyz
/// 文件名称： SpendType.cs
/// 模版作者： zhumingming(berton) 最后修改于 2016-5-27 16:10:10
/// 作者邮箱： zhumingming1040@163.com,937553351@qq.com
/// 描    述： 单独生成的代码，请在代码生成后手动添加【描述】信息
/// 创 建 人： zhumingming(Berton) (CodeSmith V6.5.0 自动生成的代码 模板V4.0)
/// 创建时间： 2018/8/28 14:55:28
///=========================================================================

using System;
using System.Text;
using MDORM.DapperExt.Mapper;

namespace MyDatabase.Model
{
    /// <summary>
 	/// SpendType 实体类,包括:属性，重写的ToString方法
 	/// </summary>
    /// 创建人：zhumingming(Berton)
    /// 创建时间：2018/8/28 14:55:28
	[Serializable]
    public class SpendType
    {
        #region 成员变量
        private int? _iD;
        private string _typeName;
        #endregion

        #region 属性
        /// <summary>
        /// ID
        /// </summary>
        public int? ID
        {
            get { return this._iD; }
            set { this._iD = value; }
        }

        /// <summary>
        /// 花费类型
        /// </summary>
        public string TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
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
            temp.AppendFormat("\"TypeName\":\"{0}\", ", this.TypeName);
            int lastPos = temp.ToString().LastIndexOf(',');
            if (lastPos != -1)
                temp = temp.Remove(lastPos, 1);
            temp.Append("}]");
            return temp.ToString();
        }
        #endregion
    }

    /// <summary>
    /// SpendType 映射类
    /// </summary>
    /// 创建人：朱明明
    /// 创建时间：2016/5/23 15:03:02

    [Serializable]
    public class SpendTypeMapper : ClassMapper<SpendType>
    {
        /// <summary>
 	    /// SpendType Mapper构造函数（可自定义Mapper）
 	    /// </summary>
        public SpendTypeMapper()
        {
            base.Table("SpendType");
            Map(f => f.ID).Key(KeyType.Identity);
            AutoMap();
        }
    }
}