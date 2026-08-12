using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController(ILeaveTypesServices _leaveTypeService,
        ILeaveRequestsService _leaveRequestsService) : Controller
    {
        //employee View Requests
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestsService.GetEmployeeLeaveRequests();
            return View(model);
        }

        //employee Create Requests
        public async Task<IActionResult> Create(int? leaveTypeId)
        {
            // if(leaveTypeId !=null)
            var leaveTypes = await _leaveTypeService.GetAll();
            var leaveTYpesList = new SelectList(leaveTypes, "Id", "Name", leaveTypeId);
            var model = new LeaveRequestCreateVM
            {
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                LeaveTypes = leaveTYpesList
            };



            return View(model);
        }

        //employee Create Requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            //validate that the days dont exceed the allocation

            if (await _leaveRequestsService.RequestDatesExceedAllocation(model))
            {
                ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
                ModelState.AddModelError(nameof(model.EndDate), "The number of days requested is invalid");
            }

            if (ModelState.IsValid)
            {
                await _leaveRequestsService.CreateLeaveRequest(model);
                return RedirectToAction(nameof(Index));
            }
            var leaveTypes = await _leaveTypeService.GetAll();

            model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");


            return View(model);
        }

        //employee Cancel Requests
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            await _leaveRequestsService.CancelLeaveRequest(id);
            return RedirectToAction(nameof(Index));
        }

        //Admin/Supervisor review Requests
        [Authorize(Policy = "AdminSupervisorOnly")]

        public async Task<IActionResult> ListRequests()
        {
            var model = await _leaveRequestsService.AdminGetAllLeaveRequests();
            return View(model);
        }

        //Admin/Supervisor review Requests
        [Authorize(Policy = "AdminSupervisorOnly")]
        public async Task<IActionResult> Review(int id)
        {
            var model = await _leaveRequestsService.GetLeaveRequestForReview(id);
            return View(model);
        }

        //Admin/Supervisor review Requests
        [Authorize(Policy = "AdminSupervisorOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int id, bool approved)
        {
            await _leaveRequestsService.ReviewLeaveRequest(id, approved);
            return RedirectToAction(nameof(ListRequests));
        }


    }
}
