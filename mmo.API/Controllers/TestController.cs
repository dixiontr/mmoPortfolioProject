using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace mmo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IStringLocalizer<TestController> _localizer;
        private readonly RequestLocalizationOptions _options;

        public TestController(IStringLocalizer<TestController> localizer, IOptions<RequestLocalizationOptions> options)
        {
            _localizer = localizer;
            _options = options.Value;
        }
        [HttpGet]
        public string Index()
        {
            Console.WriteLine(Request.Headers["Accept-Language"]);
            return _localizer["deneme"].ToString();

        }
        [HttpGet("alllanguages")]
        public IActionResult AllLanguages()
        {
            
            var allCultures = _options.SupportedCultures
                .Select(culture => new
                {
                    Name = culture.Name,
                    Text = culture.DisplayName
                }).ToList();
            
            return Ok(allCultures);
        }
    }
}