using AutoMapper;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using System;
using System.Globalization;

namespace Cinema
{
    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            this.CreateMap<MovieImportDTO, Movie>()
                .ForMember(dest => dest.Genre, cfg => cfg.MapFrom(src => Enum.Parse(typeof(Genre), src.Genre)))
                .ForMember(dest => dest.Duration, cfg => cfg.MapFrom(src => TimeSpan.ParseExact(src.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture)));

            this.CreateMap<HallSeatsImportDTO, Hall>().ForMember(dest => dest.Seats,cfg => cfg.Ignore());

            this.CreateMap<ProjectionImportDTO, Projection>()
                .ForMember(dest => dest.DateTime, cfg => cfg.MapFrom(src => DateTime.ParseExact(src.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)));
        }
    }
}
