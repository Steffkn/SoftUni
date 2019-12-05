namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Globalization;
    using static SoftJail.DataProcessor.ImportDto.OfficerDTO;

    public class SoftJailProfile : Profile
    {
        private const string DateFormat = "dd/MM/yyyy";
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            this.CreateMap<PrisonerDTO, Prisoner>()
                .ForMember(x => x.IncarcerationDate, opt => opt.MapFrom(y => DateTime.ParseExact(y.IncarcerationDate, DateFormat, CultureInfo.InvariantCulture)))
                .ForMember(x => x.ReleaseDate, opt => opt.MapFrom(y => DateTime.ParseExact(y.ReleaseDate, DateFormat, CultureInfo.InvariantCulture)))
                 .ForMember(x => x.Bail, opt => opt.MapFrom(y => y.Bail))
               ;

            this.CreateMap<MailDTO, Mail>();
            this.CreateMap<OfficerDTO, Officer>()
                .ForMember(o => o.Salary, opt => opt.MapFrom(y => y.Money))
                .ForMember(o => o.FullName, otp => otp.MapFrom(y => y.Name));
            this.CreateMap<SimplePrisonerDTO, Prisoner>();
        }
    }
}
