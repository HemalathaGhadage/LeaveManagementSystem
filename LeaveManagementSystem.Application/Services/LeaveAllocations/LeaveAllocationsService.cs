using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context,
       IUserService _userService,
        IPeriodsService _periodsService,
       IMapper _mapper) : ILeaveAllocationsService
    {


        public async Task AllocateLeave(string employeeId)
        {
            // get all the leave types
            var leaveTypes = await _context.LeaveTypes
                .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
                .ToListAsync();

            //get the current period based on the year

            var period = await _periodsService.GetCurrentPeriod();
            var monthsRemaining = period.EndDate.Month - DateTime.Now.Month;

            //calculate leave based on number of months left in the period

            //foreach leave type , create an allocation entry

            foreach (var leaveType in leaveTypes)
            {

                var accrualRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accrualRate * monthsRemaining)

                };
                _context.Add(leaveAllocation);

            }
            await _context.SaveChangesAsync();
        }



        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId)
                ? await _userService.GetLoggedInUser()
                : await _userService.GetUserById(userId);
            var allocations = await GetAllocations(user.Id);
            var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
            var leaveTypesCount = await _context.LeaveTypes.CountAsync();


            var employeeVm = new EmployeeAllocationVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationVmList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count
            };

            return employeeVm;

        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {

            var users = await _userService.GetEmployees();
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());

            return employees;
        }
        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

            return model;
        }

        public async Task EditAllocation(LeaveAllocationEditVM allocationEditVM)
        {
            //update using db calls
            // var leaveAllocation = await GetEmployeeAllocation(allocationEditVM.Id) ?? throw new Exception("Leave Allocation record does not exist");

            //leaveAllocation.Days = allocationEditVM.Days;


            // opt 1 _context.Update(leaveAllocation);
            // opt 2 _context.Entry(leaveAllocation).State = EntityState.Modified
            // //await _context.SaveChangesAsync();

            //Alternate ways without using db calls

            await _context.LeaveAllocations
                 .Where(q => q.Id == allocationEditVM.Id)
                 .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVM.Days));



        }

        public async Task<LeaveAllocation> GeCurrentAllocation(int leaveTypeId, string employeeId)
        {
            var period = await _periodsService.GetCurrentPeriod();
            var allocation = await _context.LeaveAllocations

               .FirstAsync(q => q.EmployeeId == employeeId
                && q.LeaveTypeId == leaveTypeId
                && q.PeriodId == period.Id);

            return allocation;
        }


        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {

            var period = await _periodsService.GetCurrentPeriod();
            //  var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            //var period = await _context.Periods.SingleAsync(x => x.EndDate.Year == currentDate.Year);
            //var leaveAllocations = await _context.LeaveAllocations
            //    .Include(x => x.LeaveType)
            //    .Include(x => x.Period)
            //    .Where(x => x.EmployeeId == user.Id && x.PeriodId == period.Id)
            //    .ToListAsync();

            var leaveAllocations = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .Include(x => x.Period)
                .Where(x => x.EmployeeId == userId && x.PeriodId == period.Id)
                .ToListAsync();

            return leaveAllocations;
        }

        private async Task<bool> AllocationExists(string userId, int periodId, int leaveTypeId)
        {

            var exists = await _context.LeaveAllocations.AnyAsync(x =>
            x.EmployeeId == userId
            && x.LeaveTypeId == leaveTypeId
            && x.PeriodId == periodId
            );

            return exists;
        }



    }

}
