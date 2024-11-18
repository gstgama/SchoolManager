using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Domain.DTOs;
using SchoolManager.Domain.Services.Interfaces;
using SchoolManager.Domain.Utilities;

namespace SchoolManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        Result<IEnumerable<StudentDTO>> data = await _studentService.GetAllAsync();

        if (!data.IsSuccess)
        {
            return StatusCode(500, data.Errors);
        }

        return Ok(data.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        Result<StudentDTO> data = await _studentService.GetByIdAsync(id);

        if (!data.IsSuccess)
        {
            return NotFound();
        }

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateStudentRequest request)
    {
        Result<StudentDTO> data = await _studentService.CreateAsync(request.Name, request.Age);

        if (!data.IsSuccess) 
        {
            return StatusCode(500, data.Errors);
        }

        return Ok(data);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateStudentRequest request)
    {
        Result<StudentDTO> data = await _studentService.UpdateAsync(id, request.Name, request.Age);

        if (!data.IsSuccess) 
        {
            return StatusCode(500, data.Errors);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync()
    {
        //Adicionar prop Active e fazer um soft delete
        throw new NotImplementedException();
    }
}

public record CreateStudentRequest(string Name, int Age);
public record UpdateStudentRequest(string Name, int Age);
