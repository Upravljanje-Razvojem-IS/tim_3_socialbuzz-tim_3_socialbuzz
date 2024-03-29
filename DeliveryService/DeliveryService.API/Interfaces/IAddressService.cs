﻿using DeliveryService.API.Models.AddressModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Interfaces
{
    public interface IAddressService
    {
        Task<IReadOnlyCollection<AddressOverview>> BrowseAsync(Guid cityId);
        Task<AddressDetails> FindAsync(Guid cityId, Guid addressId);
        Task<AddressConfirmation> CreateAsync(Guid cityId, AddressPostBody address);
        Task<AddressConfirmation> UpdateAsync(Guid cityId, Guid addressId, AddressPutBody address);
        Task DeleteAsync(Guid cityId, Guid addressId);
    }
}
