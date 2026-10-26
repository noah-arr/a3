using Microsoft.AspNetCore.Mvc;
using School.Data.Models;
using System.Net;

namespace School.Portal.Controllers;

public class InstructorController : Controller
{
    private readonly HttpClient _httpClient;
    public InstructorController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("SchoolApi");

    public async Task<IActionResult> Index()
    {
        using var response = await _httpClient.GetAsync("api/instructor");
        response.EnsureSuccessStatusCode();

        var instructors = await response.Content.ReadFromJsonAsync<List<Instructor>>();
        return View(instructors);
    }

    public async Task<IActionResult> Details(int id)
    {
        using var response = await _httpClient.GetAsync($"api/instructor/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return NotFound();
        response.EnsureSuccessStatusCode();

        var instructors = await response.Content.ReadFromJsonAsync<Instructor>();
        return View(instructors);
    }

    public async Task<IActionResult> Edit(int id)
    {
        using var response = await _httpClient.GetAsync($"api/instructor/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return NotFound();
        response.EnsureSuccessStatusCode();

        var instructors = await response.Content.ReadFromJsonAsync<Instructor>();
        return View(instructors);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Instructor instructor)
    {
        if (!ModelState.IsValid) return View(instructor);

        using var response = await _httpClient.PatchAsync($"api/instructor/{id}", JsonContent.Create(instructor));

        if (response.StatusCode == HttpStatusCode.NotFound)
            return NotFound();

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            ModelState.AddModelError(string.Empty, "The API rejected these values.");
            return View(instructor);
        }

        response.EnsureSuccessStatusCode();
        return RedirectToAction(nameof(Index));
    }
}
