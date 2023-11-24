using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestsList
{
    public class GetLeaveRequestsListQueryHandler : IRequestHandler<GetLeaveRequestsListQuery, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestsListQueryHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestsListQuery request, CancellationToken cancellationToken)
        {
            var leaveRequests = _leaveRequestRepository.GetLeaveRequestWithDetails();
            var requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
            return requests;
        }
    }
}
