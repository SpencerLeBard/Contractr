using System;
using System.Collections.Generic;
using ContractorFile.Models;
using ContractorFile.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContractorFile.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorController : ControllerBase

  {
    private readonly ReviewService _reviewService;
    private readonly ContractorService _service;
    public ContractorController(ContractorService service, ReviewService reviewService)
    {
      _service = service;
      _reviewService = reviewService;

    }

    [HttpGet]
    public ActionResult<Contractor> Get()

    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/reviews")] // NOTE api/contractor/:id/reviews
    public ActionResult<IEnumerable<Review>> GetReviews(int id)
    {
      try
      {
        return Ok(_reviewService.GetByContractorId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
      try
      {
        return Ok(_service.Create(newContractor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit([FromBody] Contractor updated, int id)
    {
      try
      {
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Contractor> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}