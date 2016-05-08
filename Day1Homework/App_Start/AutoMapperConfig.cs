using AutoMapper;
using Day1Homework.Models;
using Day1Homework.Models.ViewModels;
using Day1Homework.Utility;
using PagedList;
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
                cfg.CreateMap<AccountBook, MoneyRecordViewModel>()
                .ForMember(target => target.accountBookID, option => option.MapFrom(source => source.Id))
                .ForMember(target => target.category, option => option.MapFrom(source => source.Categoryyy))
                .ForMember(target => target.money, option => option.MapFrom(source => source.Amounttt))
                .ForMember(target => target.date, option => option.MapFrom(source => source.Dateee))
                .ForMember(target => target.description, option => option.MapFrom(source => source.Remarkkk));
               cfg.CreateMap<MoneyRecordViewModel, AccountBook>()
                .ForMember(target => target.Id, option => option.MapFrom(source => source.accountBookID))
                .ForMember(target => target.Categoryyy, option => option.MapFrom(source => source.category))
                .ForMember(target => target.Amounttt, option => option.MapFrom(source => source.money))
                .ForMember(target => target.Dateee, option => option.MapFrom(source => source.date))
                .ForMember(target => target.Remarkkk, option => option.MapFrom(source => source.description));
                cfg.CreateMap<PagedList<AccountBook>, PagedList<MoneyRecordViewModel>>()
                        .ConvertUsing<PagedListConverter>();
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