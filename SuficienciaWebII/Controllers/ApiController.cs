using Microsoft.AspNetCore.Mvc;

namespace SuficienciaWebII.Controllers
{
    [ApiController]
    [Route("RestAPIFurb/[controller]")]
    public abstract class ApiController : Controller
    {
    }
}