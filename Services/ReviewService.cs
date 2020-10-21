using System;
using System.Collections.Generic;
using ContractorFile.Models;
using ContractorFile.Repositories;

namespace ContractorFile.Services
{
  public class ReviewService
  {
    private readonly ReviewRepository _repo;
    private readonly ContractorRepository _conRepo;

    public ReviewService(ReviewRepository repo, ContractorRepository conRepo)
    {
      _repo = repo;
      _conRepo = conRepo;
    }
    internal IEnumerable<Review> GetAll()
    {
      return _repo.GetAll();
    }
    internal Review GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal Review Create(Review newReview)
    {
      return _repo.Create(newReview);
    }

    internal Review Edit(Review updated)
    {
      var data = GetById(updated.Id);

      // updated.ConstractorId = original.ContractorId;


      updated.Title = updated.Title != null ? updated.Title : data.Title;

      updated.Body = updated.Body != null ? updated.Body : data.Body;

      updated.Rating = updated.Rating != null ? updated.Rating : data.Rating;

      updated.ContractorId = updated.ContractorId != null ? updated.ContractorId : data.ContractorId;

      updated.Datee = updated.Datee != null && updated.Datee.Length > 2 ? updated.Datee : data.Datee;


      return _repo.Edit(updated);
    }
    internal IEnumerable<Review> GetByContractorId(int id)
    {
      var con = _conRepo.GetById(id);
      if (con == null)
      {
        throw new Exception("Invalid Product Id");
      }
      return _repo.GetByContractorId(id);
    }

    internal string Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return "delorted";
    }
  }
}