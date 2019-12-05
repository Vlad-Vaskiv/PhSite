using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneSite.Data;
using PhoneSite.Dtos;
using PhoneSite.Models;

namespace PhoneSite.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
   // [ApiController]
    public class PhonesController : ControllerBase
    {
    public readonly IPhoneRepository _repo;
    public readonly IMapper _mapper;
    public PhonesController(IPhoneRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;

    }

    [HttpGet]
    public async Task<IActionResult> GetPhones()
    {
      var phones = await _repo.GetPhones();
      var phonesToReturn = _mapper.Map<IEnumerable<ModelForListDto>>(phones);

      return Ok(phonesToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPhone(int id)
    {
      var phone = await _repo.GetPhone(id);
      var phoneToReturn = _mapper.Map<ModelForListDto>(phone);
      return Ok(phoneToReturn);
    }
    
     [HttpPost("registerFirm")]
    public async Task<IActionResult> RegisterPhone(PhonesForRegDto phoneForRegDto)
    {
      phoneForRegDto.Price = phoneForRegDto.Price;
      var phoneToCreate = new ModelPhone
      {
        Price = phoneForRegDto.Price
      };
      var createdPhone = await _repo.RegisterPhone(phoneToCreate);
      return StatusCode(201);
    }
    }
}