using Microsoft.AspNetCore.Mvc;
using hrd.Models;
using hrd.Data.Services;

namespace hrd.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeServices _service;

    public EmployeeController(IEmployeeServices service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var listEmployeeReligions = await _service.GetListEmployeeReligion();
        return View(listEmployeeReligions);
    }

    public async Task<PartialViewResult> GetReligions(string name) 
    {
        var religions = await _service.GetReligions();
        return PartialView("~/Views/Employee/ContentPanels/_ReligionLookup.cshtml", religions);
    }
    public async Task<PartialViewResult> GetEmployee(int id) 
    {
        var employee = await _service.GetEmployee(id);
        return PartialView("~/Views/Employee/ContentPanels/_Form.cshtml", employee);
    }

    [HttpPost]
    public async Task<IActionResult> Submit(vwEmployeeReligion model)
    {
        // if(ModelState.IsValid) 
        // {
        //     return View(model)
        // }
        //return RedirectToAction(nameof(Index));

        if(model.ID == 0) 
           await _service.AddEmployee(model);
        else
           await _service.UpdateEmployee(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEmployee(string ids)
    {
        await _service.DeleteEmployee(ids);
        return RedirectToAction(nameof(Index));
    }
}
