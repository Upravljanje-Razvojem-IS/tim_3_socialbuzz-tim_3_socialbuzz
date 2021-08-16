using DeliveryService.API.Models.PriceDistanceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Interfaces
{
    public interface IPriceDistance
    {
        Task<IReadOnlyCollection<PriceDistanceOverview>> BrowseAsync();
        Task<PriceDistanceDetails> FindAsync(Guid id);
        Task<PriceDistanceConfirmation> CreateAsync(PriceDistancePostBody priceDistance);
        Task<PriceDistanceConfirmation> UpdateAsync(Guid id, PriceDistancePutBody priceDistance);
        Task DeleteAsync(Guid id);
    }
}
