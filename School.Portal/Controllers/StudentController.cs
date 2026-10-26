using Microsoft.AspNetCore.Mvc;

namespace School.Portal.Controllers;

public class StudentController : Controller
{
    private readonly HttpClient _httpClient;
    public StudentController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("SchoolApi");
}
