
namespace gregsharp.Services;

public class HousesService
{

  private readonly HousesRepository _repo;

  public HousesService(HousesRepository repo)
  {
    _repo = repo;
  }

  internal List<Houses> Get()
  {
    List<Houses> house = _repo.Get();
    return house;

  }

  internal Houses Create(Houses houseData)
  {
    Houses houses = _repo.Create(houseData);
    return houses;
  }

  internal Houses Get(int id)
  {
    Houses house = _repo.Get(id);
    if (house == null)
    {
      throw new Exception("nou house at id");
    }
    return house;
  }

  internal string Remove(int id)
  {
    Houses house = Get(id);
    bool deleted = _repo.Remove(id);
    if (deleted == false)
    {
      throw new Exception("no house got earsed");
    }
    return $"{house.Name} got earsed";
  }

  internal Houses Update(Houses houseData, int id)
  {
    Houses orignal = Get(id);
    orignal.Name = houseData.Name ?? orignal.Name;
    orignal.Bedrooms = houseData.Bedrooms ?? orignal.Bedrooms;
    orignal.Bathrooms = houseData.Bathrooms ?? orignal.Bathrooms;
    orignal.Price = houseData.Price ?? orignal.Price;
    orignal.Sqft = houseData.Sqft ?? orignal.Sqft;
    orignal.ImgUrl = houseData.ImgUrl ?? orignal.ImgUrl;
    orignal.Description = houseData.Description ?? orignal.Description;
    orignal.Year = houseData.Year ?? orignal.Year;

    bool edited = _repo.Update(orignal);
    if (edited == false)
    {
      throw new Exception("house was no edit");
    }
    return orignal;
  }
}
