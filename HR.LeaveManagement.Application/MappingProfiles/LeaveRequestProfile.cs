using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestsDetail;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestsList;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
        }
    }
}
