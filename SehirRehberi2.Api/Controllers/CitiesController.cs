using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi2.Api.Data;
using SehirRehberi2.Api.Dtos;
using SehirRehberi2.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi2.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository appRepository,IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetCities()
        {
            try
            {
                var citiesRepo = _appRepository.GetCities();
                var citiesMapper = _mapper.Map<List<CityForListDto>>(citiesRepo);
                return Ok(citiesMapper);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }  
        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            try
            {
                _appRepository.Add(city);
                _appRepository.SaveAll();

                return Ok($"{city.Name} başarıyla Eklendi");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
