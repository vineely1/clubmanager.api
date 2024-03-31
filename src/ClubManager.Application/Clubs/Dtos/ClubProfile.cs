using AutoMapper;
using ClubManager.Application.Clubs.Command.CreateClub;
using ClubManager.Application.Clubs.Command.UpdateClub;
using ClubManager.Domain.Entities;

namespace ClubManager.Application.Clubs.Dtos;
public class ClubProfile : Profile
{
    public ClubProfile()
    {
        CreateMap<CreateClubCommand, Club>()
            .ForMember(d => d.Address, o => o.MapFrom(
                s => new Address
                {
                    Line1 = s.AddressLine1,
                    Line2 = s.AddressLine2,
                    City = s.City,
                    PostalCode = s.PostalCode
                }));

        CreateMap<UpdateClubCommand, Club>()
            .ForMember(d => d.Address, o => o.MapFrom(
                s => new Address
                {
                    Line1 = s.AddressLine1,
                    Line2 = s.AddressLine2,
                    City = s.City,
                    PostalCode = s.PostalCode
                }));

        CreateMap<Club, ClubDto>()
            .ForMember(d => d.AddressLine1, o =>
                o.MapFrom(s => s.Address == null ? null : s.Address.Line1))
            .ForMember(d => d.AddressLine2, o =>
                o.MapFrom(s => s.Address == null ? null : s.Address.Line2))
            .ForMember(d => d.City, o =>
                o.MapFrom(s => s.Address == null ? null : s.Address.City))
            .ForMember(d => d.PostalCode, o =>
                o.MapFrom(s => s.Address == null ? null : s.Address.PostalCode))
            .ForMember(d => d.Equipment, o =>
                o.MapFrom(s => s.Equipment));
    }
}
