using System;

namespace PersonalFinanceTracker.Accounts.Application.Dto
{
    public class AccountDto
    {
        public long Id { get; set; }

        public Guid UserGuid { get; set; }

        public string Name { get; set; }

        public AccountTypeDto AccountType { get; set; }

        public string Description { get; set; }
    }
}
