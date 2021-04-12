using System;

namespace PersonalFinanceTracker.Accounts.Application.Dto
{
    public class AccountForCreationDto
    {
        public string Name { get; set; }

        public Guid UserGuid { get; set; }

        public string Description { get; set; }

        public long AccountTypeId { get; set; }
    }
}
