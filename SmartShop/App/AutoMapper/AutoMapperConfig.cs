using AutoMapper;

namespace SmartShop.App.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperViewModelToEntity());
                config.AddProfile(new MapperEntityToViewModel());
            });
        }
    }
}
