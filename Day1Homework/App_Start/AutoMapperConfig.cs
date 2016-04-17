using AutoMapper;
using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<AccountBook, MoneyRecordViewModels>()
                .ForMember(target => target.accountBookID, option => option.MapFrom(source => source.Id))
                .ForMember(target => target.category, option => option.MapFrom(source => source.Categoryyy))
                .ForMember(target => target.money, option => option.MapFrom(source => source.Amounttt))
                .ForMember(target => target.date, option => option.MapFrom(source => source.Dateee))
                .ForMember(target => target.description, option => option.MapFrom(source => source.Remarkkk));
            });

            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<AccountBookProfile>();
            //});
        }

        //public class AccountBookProfile : Profile
        //{
        //    public override string ProfileName
        //    {
        //        get
        //        {
        //            return "AccountBookProfile";
        //        }
        //    }

        //    protected override void Configure()
        //    {
        //        //Dynamically creating maps will be removed in version 5.0. 
        //        //Use a MapperConfiguration instance and store statically as needed, 
        //        //or Mapper.Initialize. Use CreateMapper to create a mapper instance.
        //        Mapper.CreateMap<AccountBook, MoneyRecordViewModels>()
        //        .ForMember(target => target.accountBookID, option => option.MapFrom(source => source.Id))
        //        .ForMember(target => target.category, option => option.MapFrom(source => source.Categoryyy))
        //        .ForMember(target => target.money, option => option.MapFrom(source => source.Amounttt))
        //        .ForMember(target => target.date, option => option.MapFrom(source => source.Dateee))
        //        .ForMember(target => target.description, option => option.MapFrom(source => source.Remarkkk));
        //    }
        //}
    }
}