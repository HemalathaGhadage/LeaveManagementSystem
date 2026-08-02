using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services.LeaveTypes
{
    public interface ILeaveTypesServices
    {
        Task<bool> CheckIfLeaveTypeExistsForEdit(LeaveTypeEditVM leaveTypeEditVM);
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task Create(LeaveTypeCreateVM model);
        Task<bool> DaysExceedMaximun(int leaveTypeId, int days);
        Task Edit(LeaveTypeEditVM model);
        Task<T?> Get<T>(int? id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAll();
        bool LeaveTypeExists(int? id);
        Task Remove(int Id);
    }
}