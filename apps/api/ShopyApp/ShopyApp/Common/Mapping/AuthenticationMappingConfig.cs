using Mapster;
using ShopyApp.Application.Common;
using ShopyApp.Contracts.Authentication;

namespace ShopyApp.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthResposne>()
                .Map(dest => dest, src => src.User);
        }
    }
}
