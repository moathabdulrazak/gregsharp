
namespace gregsharp.Repositories;


public class HousesRepository
{

  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Houses> Get()
  {
    string sql = @"
    SELECT 
    *
    FROM houses
    ";
    List<Houses> houses = _db.Query<Houses>(sql).ToList();
    return houses;

  }

  internal Houses Create(Houses houseData)
  {
    string sql = @"
INSERT INTO houses
(year, name, imgUrl, price, bedrooms, bathrooms, sqft, description)
VALUES
(@year, @name, @imgUrl, @price, @bedrooms, @bathrooms, @sqft, description);

SELECT LAST_INSERT_ID();
";
    int id = _db.ExecuteScalar<int>(sql, houseData);

    houseData.Id = id;

    return houseData;
  }

  internal Houses Get(int id)
  {
    string sql = @"
    SELECT 
    *
FROM houses
WHERE ID = @id;
    ";
    Houses house = _db.Query<Houses>(sql, new { id }).FirstOrDefault();
    return house;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM houses
    WHERE ID = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;


  }

  internal bool Update(Houses orignal)
  {
    string sql = @"
    UPDATE houses 
    SET
    name = @name,
    year = @year,
    price = @price,
    bedrooms = @bedrooms,
    bathrooms = @bathrooms,
    description = @description,
    sqft = @sqft,
    imgUrl = @imgUrl
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, orignal);

    return rows > 0;

  }
}
