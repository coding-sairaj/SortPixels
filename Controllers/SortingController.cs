using Microsoft.AspNetCore.Mvc;
using SortPixels.Services;

namespace SortPixels.Controllers;
[ApiController]
[Route("[controller]")]
public class SortingController: ControllerBase
{
    SortingService _service;
    public SortingController(SortingService service)
    {
      _service = service;
    }
    [Route("[action]")]
    [HttpPost]
    public ActionResult<int[]> SortPixels(IEnumerable<int> pixels)
    {
      if (pixels is null)
      {
        throw new ArgumentNullException(nameof(pixels));
      }
      return Ok(_service.getSortPixels(pixels.ToArray()));
    }
    [Route("[action]")]
    [HttpPost]
    public ActionResult<int[]> RandomPixels(IEnumerable<int> pixels)
    {
      if (pixels is null)
      {
        throw new ArgumentNullException(nameof(pixels));
      }
      return Ok(_service.getRandomPixels(pixels.ToArray()));
    }
}