using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneSite.Data;
using PhoneSite.Dtos;
using PhoneSite.Models;

namespace PhoneSite.Controllers
{
    [Route("api/[controller]")]
    public class FirmController : ControllerBase
    {
    public readonly IFirmRepository _repo;
    public readonly IMapper _mapper;
    public FirmController(IFirmRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;

    }

    [HttpGet]
    public async Task<IActionResult> GetFirms()
    {
      var firms = await _repo.GetFirms();
      var firmsToReturn = _mapper.Map<IEnumerable<FirmForListDto>>(firms);

      return Ok(firmsToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFirm(int id)
    {
      var firm = await _repo.GetFirm(id);
      var firmToReturn = _mapper.Map<FirmForDetailedDto>(firm);
      return Ok(firmToReturn);
    }
    
     [HttpPost("registerFirm")]
    public async Task<IActionResult> RegisterFirm(FirmsForRegDto firmForRegDto)
    {
      firmForRegDto.NameFirm = firmForRegDto.NameFirm;
      var firmToCreate = new FirmPhone
      {
        NameFirm = firmForRegDto.NameFirm
      };
      var createdFirm = await _repo.RegisterFirm(firmToCreate);
      return StatusCode(201);
    }
}
}