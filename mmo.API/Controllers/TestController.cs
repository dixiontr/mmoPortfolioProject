using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using mmo.Application.Exceptions;
using mmo.Application.Exceptions.CustomExceptions;
using mmo.Application.Wrappers;
using mmo.Domain.Entities;

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
        public BaseResponse Index()
        {
            throw new Exception();

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