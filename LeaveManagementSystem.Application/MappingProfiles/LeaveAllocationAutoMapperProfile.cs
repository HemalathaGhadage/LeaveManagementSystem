using AutoMapper;

namespace LeaveManagementSystem.Application.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {
        public LeaveAllocationAutoMapperProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationVM>();
            CreateMap<Period, PeriodVM>();
            CreateMap<ApplicationUser, EmployeeListVM>();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();

        }

    }
}
