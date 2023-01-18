
namespace gregsharp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;

  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }


  [HttpGet]
  public ActionResult<List<Cars>> Get()
  {
    try
    {
      List<Cars> cars = _carsService.Get();
      return Ok(cars);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }


  [HttpPost]
  public ActionResult<Cars> create([FromBody] Cars carData)
  {
    try
    {
      Cars car = _carsService.create(carData);
      return Ok(car);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]

  public ActionResult<Cars> Get(int id)
  {
    try
    {
      Cars car = _carsService.Get(id);
      return Ok(car);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]

  public ActionResult<Cars> Update([FromBody] Cars carUpdate, int id)
  {
    try
    {
      Cars car = _carsService.Update(carUpdate, id);
      return Ok(car);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
      throw;
    }
  }



  [HttpDelete("{id}")]
  public ActionResult<string> Remove(int id)
  {
    try
    {
      string Message = _carsService.Remove(id);
      return Ok(Message);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }

  }
}
