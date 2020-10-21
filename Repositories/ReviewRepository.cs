using System;
using System.Collections.Generic;
using System.Data;
using ContractorFile.Models;
using Dapper;

namespace ContractorFile.Repositories
{
  public class ReviewRepository
  {
    private readonly IDbConnection _db;
    public ReviewRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Review> GetAll()
    {
      string sql = "SELECT * FROM reviews";
      var reviews = _db.Query<Review>(sql);
      return reviews;
    }
    internal Review GetById(int id)
    {
      string sql = "SELECT * FROM reviews WHERE id = @id LIMIT 1";
      return _db.QueryFirstOrDefault<Review>(sql, new { id });
    }
    internal Review Create(Review newReview)
    {
      string sql = @"
      INSERT INTO reviews 
      (title, body, rating, date, contractorId) 
      VALUES 
      (@Title, @Body, @Rating, @Date, @ContractorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newReview);
      newReview.Id = id;
      return newReview;
    }
    internal Review Edit(Review updated)
    {
      string sql = @"
        UPDATE reviews
        SET
         title = @Title,
         body = @Body,
         rating = @Rating,
         date = @Date,
         contractorId = @ContractorId,
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }
    //   internal IEnumerable<WishListProductViewModel> GetProductsByListId(int id)
    // {
    //   string sql = @"
    //   SELECT p.*, wlp.id AS WishListProductId
    //   FROM wishlistproducts wlp
    //   JOIN products p ON p.id = wlp.productId
    //   WHERE wishlistId = @id
    //   ";
    //   return _db.Query<WishListProductViewModel>(sql, new { id });
    // }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM reviews WHERE id = @id";
      _db.Execute(sql, new { id });
    }
    internal IEnumerable<Review> GetByContractorId(int id)
    {
      string sql = "SELECT * FROM reviews WHERE contractorId = @id";
      return _db.Query<Review>(sql, new { id });
    }
  }
}