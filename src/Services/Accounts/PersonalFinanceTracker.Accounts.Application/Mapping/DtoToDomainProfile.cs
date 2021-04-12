using AutoMapper;
using PersonalFinanceTracker.Accounts.Application.Dto;
using PersonalFinanceTracker.Accounts.Domain.Entities;

namespace PersonalFinanceTracker.Accounts.Application.Mapping
{
    class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<AccountDto, Account>()
                .PreserveReferences();
            CreateMap<AccountForCreationDto, Account>()
                .PreserveReferences();
            CreateMap<AccountForUpdateDto, Account>()
                .PreserveReferences();

            CreateMap<AccountTypeDto, AccountType>()
                .PreserveReferences();
            CreateMap<AccountTypeForCreationDto, AccountType>()
                .PreserveReferences();
            CreateMap<AccountTypeForUpdateDto, AccountType>()
                .PreserveReferences();
        }
    }
}
