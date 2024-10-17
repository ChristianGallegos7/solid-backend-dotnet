using backend_hdeleon.Models;
using backend_hdeleon.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace backend_hdeleon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private DBContext _contexto;

        public BeerController(DBContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> GetAll() =>
           await _contexto.Beers.Select(bear => new BeerDto
            {
                BeerId = bear.BeerId,
                Name = bear.Name,
                Alcohol = bear.Alcohol,
                BrandId = bear.BrandId
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _contexto.Beers.FindAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            var beerDto = new BeerDto
            {
                BeerId = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };

            return Ok(beerDto);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
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
    }
}
