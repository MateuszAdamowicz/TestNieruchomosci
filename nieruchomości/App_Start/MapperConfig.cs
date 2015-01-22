using System;
using System.Linq;
using AutoMapper;
using Models;
using Models.EntityModels;
using Models.ViewModels;

namespace nieruchomości
{
    public class MapperConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Flat, AdminAdvertToShow>().ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.Flat)).ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 12))); 
            Mapper.CreateMap<House, AdminAdvertToShow>().ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.House)).ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 14))); 
            Mapper.CreateMap<Land, AdminAdvertToShow>().ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.Land)).ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 18)));
            Mapper.CreateMap<AdminFlat, Flat>().ForMember(dest => dest.Visible, opts => opts.UseValue(true));
            Mapper.CreateMap<AdminLand, Land>().ForMember(dest => dest.Visible, opts => opts.UseValue(true));
            Mapper.CreateMap<AdminHouse, House>().ForMember(dest => dest.Visible, opts => opts.UseValue(true));
            Mapper.CreateMap<Flat, ShowFlat>().ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}",src.Id*9999,12)));
            Mapper.CreateMap<House, ShowHouse>().ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 14))); ;
            Mapper.CreateMap<Land, ShowLand>().ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 18))); ;
            Mapper.CreateMap<Photo, ShowListPhoto>();
            Mapper.CreateMap<Flat, ShowListFlat>()
                .ForMember(dest => dest.Picture,
                    opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault())))
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id*9999, 12)))
                .ForMember(dest => dest.ToLet, opts => opts.MapFrom(src => (src.ToLet == true) ? "Wynajem" : "Sprzedaż"));
            Mapper.CreateMap<House, ShowListHouse>()
                .ForMember(dest => dest.Picture, opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault())))
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 14)))
                .ForMember(dest => dest.ToLet, opts => opts.MapFrom(src => (src.ToLet == true) ? "Wynajem" : "Sprzedaż"));
            Mapper.CreateMap<Land, ShowListLand>()
                .ForMember(dest => dest.Picture, opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault()))).ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 18)));

            Mapper.CreateMap<Flat, EditFlat>();
            Mapper.CreateMap<House, EditHouse>();
            Mapper.CreateMap<Land, EditLand>();

            Mapper.CreateMap<CreateOffer, Offer>().ForMember(dest => dest.Status, opts => opts.UseValue(OfferStatus.New));

            Mapper.CreateMap<ContactEmail, Mail>().ForMember(dest => dest.OrderLink, opts => opts.MapFrom(src => src.OfferLink));

            Mapper.CreateMap<Offer, ContactEmail>()
                .ForMember(dest => dest.Body, opts => opts.MapFrom(src => src.Description));

            Mapper.CreateMap<Flat, NewestAdvert>()
                .ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.Flat))
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id*9999, 12)))
                .ForMember(dest => dest.Picture,
                    opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault())));
            Mapper.CreateMap<House, NewestAdvert>()
                .ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.House))
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id*9999, 14)))
                .ForMember(dest => dest.Picture,
                    opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault())));
            Mapper.CreateMap<Land, NewestAdvert>()
                .ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.Land))
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id*9999, 18)))
                .ForMember(dest => dest.Picture,
                    opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault())));


            Mapper.CreateMap<Flat, ShowAdvertList>().ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.Flat)).ForMember(dest => dest.Image, opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault()))).ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id * 9999, 12)));
            Mapper.CreateMap<House, ShowAdvertList>()
                .ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.House))
                .ForMember(dest => dest.Image,
                    opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault())))
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id*9999, 14)))
                .ForMember(dest => dest.Area, opts => opts.MapFrom(src => src.LandArea));
            Mapper.CreateMap<Land, ShowAdvertList>()
                .ForMember(dest => dest.AdType, opts => opts.UseValue(AdType.Land))
                .ForMember(dest => dest.Image,
                    opts => opts.MapFrom(src => Mapper.Map<ShowListPhoto>(src.Pictures.FirstOrDefault())))
                .ForMember(dest => dest.Number, opts => opts.MapFrom(src => String.Format("{0}{1}", src.Id*9999, 18)))
                .ForMember(dest => dest.Area, opts => opts.MapFrom(src => src.Area));

            //Mapper.CreateMap<Worker,Flat>().ForMember(dest => src.)
        }
    }
}