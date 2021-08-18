using DeliveryService.API.Models.CityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Interfaces
{
    public interface ICityService
    {
        Task<IReadOnlyCollection<CityOverview>> BrowseAsync();
        Task<CityDetails> FindAsync(Guid id);
        Task<CityConfirmation> CreateAsync(CityPostBody city);
        Task<CityConfirmation> UpdateAsync(Guid id, CityPutBody city);
        Task DeleteAsync(Guid id);
    }
}
