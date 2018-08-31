using AutoMapper;
using MyDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDatabase.WebAPI.App_Start
{
    public class EntityMapper
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SpendType, Model.VModel.Spend.SpendTypeIndexOutput>();
                cfg.CreateMap<Model.VModel.Spend.SpendTypeCreateInput, SpendType>();
                cfg.CreateMap<Model.VModel.Spend.SpendTypeDetailInput, SpendType>();
                cfg.CreateMap<SpendType, Model.VModel.Spend.SpendTypeDetailOutput>();
                cfg.CreateMap<Model.VModel.Spend.SpendTypeEditInput, SpendType>();
                cfg.CreateMap<Model.VModel.Spend.SpendTypeDeleteInput, SpendType>();

                cfg.CreateMap<Spend, Model.VModel.Spend.SpendIndexOutput>();
                cfg.CreateMap<Model.VModel.Spend.SpendCreateInput, Spend>();
                cfg.CreateMap<Model.VModel.Spend.SpendDetailInput, Spend>();
                cfg.CreateMap<Spend, Model.VModel.Spend.SpendDetailOutput>();
                cfg.CreateMap<Model.VModel.Spend.SpendEditInput, Spend>();
                cfg.CreateMap<Model.VModel.Spend.SpendDeleteInput, Spend>();
            });
        }
    }
}