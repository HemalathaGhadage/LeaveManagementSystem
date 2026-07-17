using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
       
        public string? Name { get; set; }

        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
    }

}
