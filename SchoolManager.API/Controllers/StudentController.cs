using Microsoft.AspNetCore.Mvc;
using SchoolManager.Domain.Services.Interfaces;

namespace SchoolManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _studentService.GetAllAsync());
    }

    public async Task<IActionResult> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteAsync()
    {
        throw new NotImplementedException();
    }
}