
namespace gregsharp.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Cars create(Cars carData)
  {
    string sql = @"
    INSERT INTO cars
    (make, model, year, price, imgUrl, description, color)
    VALUES
    (@make, @model, @year, @price, @imgUrl, @description, @color);
    
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, carData);
    carData.Id = id;
    return carData;
  }

  internal List<Cars> Get()
  {
    string sql = @"
    SELECT
    *
    FROM cars;
    ";
    List<Cars> cars = _db.Query<Cars>(sql).ToList();
    return cars;
  }

  internal Cars Get(int id)
  {
    string sql = @"
    SELECT
    *
    FROM cars
    WHERE id = @id;

    
    ";
    Cars car = _db.Query<Cars>(sql, new { id }).FirstOrDefault();

    return car;


  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM cars
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;

  }

  internal bool Update(Cars original)
  {
    string sql = @"
    UPDATE cars
    SET
    make = @make,
    model = @model,
    year = @year,
    price = @price,
    imgUrl = @imgUrl,
    description = @description,
    color = @color
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, original);
    return rows > 0;

  }



}
