﻿using System.Threading.Tasks;
using Abp.Application.Services;
using AISPharmacy.Authorization.Accounts.Dto;

namespace AISPharmacy.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
