using AutoMapper;

namespace PersonalFinanceTracker.Accounts.Application.Mapping
{
    /// <summary>
    /// Auto mapper application layer configuration
    /// </summary>
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToDtoProfile>();
                cfg.AddProfile<DtoToDomainProfile>();
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            });
        }
    }
}
