using backend_hdeleon.Models.DTOs.Beer;

namespace backend_hdeleon.Services
{
    public interface IBeerService
    {
        Task<IEnumerable<BeerDto>> Get();
        Task<BeerDto> GetById(int id);

        Task<BeerDto> Add(BeerInsertDto beerInsertDto);

        Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto);

        Task Delete(int id);

    }
}
