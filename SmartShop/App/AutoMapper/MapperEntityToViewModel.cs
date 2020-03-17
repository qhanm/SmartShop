using AutoMapper;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ViewModel;

namespace SmartShop.App.AutoMapper
{
    public class MapperEntityToViewModel : Profile
    {
        public MapperEntityToViewModel()
        {
            CreateMap<QHN_AppUserRole, QHN_AppUserRoleViewModel>();
            CreateMap<QHN_Color, QHN_ColorViewModel>();
            CreateMap<QHN_Function, QHN_FunctionViewModel>();
            CreateMap<QHN_Image, QHN_ImageViewModel>();
            CreateMap<QHN_LoggerAction, QHN_LoggerActionViewModel>();
            CreateMap<QHN_LoggerData, QHN_LoggerDataViewModel>();
            CreateMap<QHN_Permisson, QHN_PermissionViewModel>();
            CreateMap<QHN_Product, QHN_ProductViewModel>();
            CreateMap<QHN_ProductCategory, QHN_ProductCategoryViewModel>();
            CreateMap<QHN_ProductColor, QHN_ProductColorViewModel>();
            CreateMap<QHN_ProductComment, QHN_ProductCommentViewModel>();
            CreateMap<QHN_ProductImage, QHN_ProductImageViewModel>();
            CreateMap<QHN_ProductTag, QHN_ProductTagViewModel>();
            CreateMap<QHN_SettingMetaData, QHN_SettingMetaDataViewModel>();
        }
    }
}
