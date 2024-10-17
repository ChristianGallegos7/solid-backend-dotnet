using backend_hdeleon.Models;
using backend_hdeleon.Models.DTOs;
using backend_hdeleon.Services;
using backend_hdeleon.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_hdeleon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private DBContext _contexto;
        private IValidator<BeerInsertDto> _beerInsertValidator;
        private IValidator<BeerUpdateDto> _beerUpdateValidator;
        private IBeerService _beerService;
        public BeerController(DBContext contexto, IValidator<BeerInsertDto> beerValidator, IValidator<BeerUpdateDto> beerUpdateDto, IBeerService beerService)
        {
            _contexto = contexto;
            _beerInsertValidator = beerValidator;
            _beerUpdateValidator = beerUpdateDto;
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> GetAll() =>
          await _beerService.Get();


        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
           var beerDto = await _beerService.GetById(id);

            return beerDto == null ? NotFound() : Ok();

        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                Alcohol = beerInsertDto.Alcohol,
                BrandId = beerInsertDto.BrandId
            };

            await _contexto.Beers.AddAsync(beer);
            await _contexto.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                BeerId = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };

            return CreatedAtAction(nameof(GetById), new {id = beer.BeerId}, beerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beer = await _contexto.Beers.FindAsync(id);

            if(beer == null)
            {
                return NotFound();
            }

            beer.Name = beerUpdateDto.Name;
            beer.Alcohol = beerUpdateDto.Alcohol;
            beer.BrandId = beerUpdateDto.BrandId;

            await _contexto.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                BeerId = beer.BeerId,
                BrandId = beer.BrandId,
                Name = beer.Name,
                Alcohol = beer.Alcohol
            };

            return Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {

            var beer = await _contexto.Beers.FindAsync(id);

            if(beer == null){
                return NotFound();
            }

            _contexto.Beers.Remove(beer);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
    }
}
