

namespace gregsharp.Services;

public class CarsService
{

  private readonly CarsRepository _repo;

  public CarsService(CarsRepository repo)
  {
    _repo = repo;
  }

  internal Cars create(Cars carData)
  {
    Cars car = _repo.create(carData);
    return car;
  }

  internal List<Cars> Get()
  {
    List<Cars> cars = _repo.Get();
    return cars;
  }

  internal Cars Get(int id)
  {
    Cars car = _repo.Get(id);
    if (car == null)
    {
      throw new Exception("no car by that id");
    }
    return car;
  }

  internal string Remove(int id)
  {
    Cars car = Get(id);
    bool deleted = _repo.Remove(id);
    if (deleted == false)
    {
      throw new Exception("no car was deleted");
    }
    return $"{car.Make} {car.Model} was earsed";
  }

  internal Cars Update(Cars carUpdate, int id)
  {
    Cars original = Get(id);
    original.Make = carUpdate.Make ?? original.Make;
    original.Model = carUpdate.Model ?? original.Model;
    original.Year = carUpdate.Year ?? original.Year;
    original.Price = carUpdate.Price ?? original.Price;
    original.Description = carUpdate.Description ?? original.Description;
    original.ImgUrl = carUpdate.ImgUrl ?? original.ImgUrl;
    original.Color = carUpdate.Color ?? original.Color;
    bool edited = _repo.Update(original);

    if (edited == false)
    {
      throw new Exception("car was not edited");
    }
    return original;
  }
}
