using Microsoft.AspNetCore.Mvc;
using School.Data.Models;
using System.Net;

namespace School.Portal.Controllers;

public class CourseController : Controller
{
    private readonly HttpClient _httpClient;
    public CourseController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("SchoolApi");

    public async Task<IActionResult> Index()
    {
        using var response = await _httpClient.GetAsync("api/course");
        response.EnsureSuccessStatusCode();

        var courses = await response.Content.ReadFromJsonAsync<List<Course>>();
        return View(courses);
    }

    public async Task<IActionResult> Details(int id)
    {
        using var response = await _httpClient.GetAsync($"api/course/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return NotFound();                       
        response.EnsureSuccessStatusCode();

        var courses = await response.Content.ReadFromJsonAsync<Course>();
        return View(courses);
    }
}
