using DeliveryService.API.Models.SaleModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Interfaces
{
    public interface ISaleService
    {
        Task<IReadOnlyCollection<SaleOverview>> BrowseAsync();
        Task<SaleDetails> FindAsync(Guid id);
        Task<SaleConfirmation> CreateAsync(SalePostBody sale);
        Task<SaleConfirmation> UpdateAsync(Guid id, SalePutBody sale);
        Task RemoveAsync(Guid id);


    }
}
