using AutoMapper;
using PersonalFinanceTracker.Accounts.Application.Dto;
using PersonalFinanceTracker.Accounts.Domain.Entities;

namespace PersonalFinanceTracker.Accounts.Application.Mapping
{
    class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(dto => dto.AccountType, opt => opt.MapFrom(x => x.AccountType))
                .PreserveReferences();

            CreateMap<AccountType, AccountTypeDto>()
                .PreserveReferences();
        }
    }
}
