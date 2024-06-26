﻿using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {

        }

        public async Task<LeaveRequest?> GetLeaveRequestWithDetailsAsync(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync()
        {
            var leaveRequests = await _context.LeaveRequests
                .Include(x => x.LeaveType).ToListAsync();

            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync(string userId)
        {
            var leaveRequests = await _context.LeaveRequests
                .Include(x => x.LeaveType)
                .Where(x => x.RequestingEmployeeId == userId)
                .ToListAsync();

            return leaveRequests;
        }
    }
}
