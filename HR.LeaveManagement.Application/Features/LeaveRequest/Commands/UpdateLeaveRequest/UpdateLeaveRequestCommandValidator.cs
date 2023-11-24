﻿using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandValidator(ILeaveRequestRepository leaveRequestRepository, 
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveRequestMustExist)
                .WithMessage("{PropertyName} must be present");
        }

        private async Task<bool> LeaveRequestMustExist(int id, CancellationToken arg2)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveRequest != null;
        }
    }
}
