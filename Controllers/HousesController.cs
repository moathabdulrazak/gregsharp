

namespace gregsharp.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{

  private readonly HousesService _housesService;

  public HousesController(HousesService housesService)
  {
    _housesService = housesService;
  }


  [HttpGet]

  public ActionResult<List<Houses>> Get()
  {
    try
    {
      List<Houses> houses = _housesService.Get();
      return Ok(houses);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }


  [HttpPost]

  public ActionResult<Houses> Create([FromBody] Houses houseData)
  {
    try
    {
      Houses house = _housesService.Create(houseData);
      return Ok(house);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]

  public ActionResult<Houses> Get(int id)
  {
    try
    {
      Houses houses = _housesService.Get(id);
      return Ok(houses);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]

  public ActionResult<string> Remove(int id)
  {
    try
    {
      string message = _housesService.Remove(id);
      return Ok(message);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]

  public ActionResult<Houses> Update([FromBody] Houses houseData, int id)
  {
    try
    {
      Houses house = _housesService.Update(houseData, id);
      return Ok(house);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
}
