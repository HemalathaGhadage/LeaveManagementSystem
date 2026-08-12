using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


[Authorize(Roles = Roles.Administrator)]
public class LeaveTypesController(ILeaveTypesServices _leaveTypesServices , ILogger<LeaveTypesController> _logger) : Controller
{


    private const string NameExistsValidationMessage = "This Leave type already exists in database";




    // GET: LEAVETYPES
    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Loading Leave types");
        var viewData = await _leaveTypesServices.GetAll();
        return View(viewData);
    }

    // GET: LEAVETYPES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leavetype = await _leaveTypesServices.Get<LeaveTypeReadOnlyVM>(id.Value);
        if (leavetype == null)
        {
            return NotFound();
        }

        return View(leavetype);
    }

    // GET: LEAVETYPES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LEAVETYPES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreateVM)
    {
        if (await _leaveTypesServices.CheckIfLeaveTypeNameExists(leaveTypeCreateVM.Name))
        {
            ModelState.AddModelError(nameof(leaveTypeCreateVM.Name), NameExistsValidationMessage);

        }
        if (ModelState.IsValid)
        {
            
            await _leaveTypesServices.Create(leaveTypeCreateVM);
            return RedirectToAction(nameof(Index));
        }
        _logger.LogWarning("Leave type attempt failed due to invalidity");
        return View(leaveTypeCreateVM);
    }



    // GET: LEAVETYPES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leavetype = await _leaveTypesServices.Get<LeaveTypeEditVM>(id.Value);
        if (leavetype == null)
        {
            return NotFound();
        }


        return View(leavetype);
    }

    // POST: LEAVETYPES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEditVM)
    {
        if (id != leaveTypeEditVM.Id)
        {
            return NotFound();
        }

        if (await _leaveTypesServices.CheckIfLeaveTypeExistsForEdit(leaveTypeEditVM))
        {
            ModelState.AddModelError(nameof(leaveTypeEditVM.Name), NameExistsValidationMessage);

        }

        if (ModelState.IsValid)
        {
            try
            {
                await _leaveTypesServices.Edit(leaveTypeEditVM);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_leaveTypesServices.LeaveTypeExists(leaveTypeEditVM.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(leaveTypeEditVM);
    }



    // GET: LEAVETYPES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leavetype = await _leaveTypesServices.Get<LeaveTypeReadOnlyVM>(id.Value);
        if (leavetype == null)
        {
            return NotFound();
        }



        return View(leavetype);
    }

    // POST: LEAVETYPES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        await _leaveTypesServices.Remove(id.Value);
        return RedirectToAction(nameof(Index));
    }


}
