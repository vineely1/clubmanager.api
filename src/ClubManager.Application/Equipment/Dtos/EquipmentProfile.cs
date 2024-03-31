using AutoMapper;

namespace ClubManager.Application.Equipment.Dtos;
public class EquipmentProfile : Profile
{
    public EquipmentProfile()
    {
        CreateMap<Domain.Entities.Equipment, EquipmentDto>();
    }
}
