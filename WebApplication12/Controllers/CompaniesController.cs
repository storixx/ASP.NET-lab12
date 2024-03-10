using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication12.Data;

public class CompaniesController : Controller
{
    private readonly SecondDbContext _context;

    public CompaniesController(SecondDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var companies = await _context.Companies.ToListAsync();
        return View(companies);
    }
}