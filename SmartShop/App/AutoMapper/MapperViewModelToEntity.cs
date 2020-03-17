using AutoMapper;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ViewModel;

namespace SmartShop.App.AutoMapper
{
    public class MapperViewModelToEntity : Profile
    {
        public MapperViewModelToEntity()
        {
            CreateMap<QHN_AppUserRoleViewModel, QHN_AppUserRole>().ConstructUsing(x => new QHN_AppUserRole(x.UserId, x.RoleId));
            CreateMap<QHN_ColorViewModel, QHN_Color>().ConstructUsing(x => new QHN_Color(x.Id, x.Name, x.Code));
            CreateMap<QHN_FunctionViewModel, QHN_Function>().ConstructUsing(x => new QHN_Function(x.Id, x.Name, x.ParentId,x.Url, x.IconCss, x.SortOrder, x.Status, x.IsRole));
            CreateMap<QHN_ImageViewModel, QHN_Image>().ConstructUsing(x => new QHN_Image(x.Id, x.Name, x.Size, x.Url, x.Alt, x.Description));
            CreateMap<QHN_LoggerActionViewModel, QHN_LoggerAction>().ConstructUsing(x => new QHN_LoggerAction(x.Id, x.Type, x.Controller, x.Action, x.Message));
            CreateMap<QHN_LoggerDataViewModel, QHN_LoggerData>().ConstructUsing(x => new QHN_LoggerData(x.Id, x.UserId, x.CodeId, x.Action, x.Message));
            CreateMap<QHN_PermissionViewModel, QHN_Permisson>().ConstructUsing(x => new QHN_Permisson(x.Id, x.RoleId, x.FunctionId, x.Create, x.Read, x.Delete, x.Update, x.Approved, x.Temp));
            CreateMap<QHN_ProductViewModel, QHN_Product>().ConstructUsing(x => new QHN_Product(x.Id, x.ProductCategoryId, x.Name, x.Description, x.Price, x.PromotionPrice, x.OriginalPrice, x.Content, x.HomeFlag, x.HotFlag, x.IsNew, x.IsSale, x.ViewCount, x.Rating, x.SeoTitle, x.SeoDescription, x.SeoAlias, x.SeoKeyword, x.Status, x.IsDelete));
            CreateMap<QHN_ProductCategoryViewModel, QHN_ProductCategory>().ConstructUsing(x => new QHN_ProductCategory(x.Id, x.Name, x.ImageId, x.Description, x.SeoTitle, x.SeoDescription, x.SeoAlias, x.SeoKeyword));
            CreateMap<QHN_ProductColorViewModel, QHN_ProductColor>().ConstructUsing(x => new QHN_ProductColor(x.Id, x.ProductId, x.ColorId));
            CreateMap<QHN_ProductCommentViewModel, QHN_ProductComment>().ConstructUsing(x => new QHN_ProductComment(x.Id, x.ProductId, x.Name, x.Email, x.Content));
            CreateMap<QHN_ProductImageViewModel, QHN_ProductImage>().ConstructUsing(x => new QHN_ProductImage(x.Id, x.ProductId, x.ImageId));
            CreateMap<QHN_ProductTagViewModel, QHN_ProductTag>().ConstructUsing(x => new QHN_ProductTag(x.Id, x.TagName, x.ProductId));
            CreateMap<QHN_SettingMetaDataViewModel, QHN_SettingMetaData>().ConstructUsing(x => new QHN_SettingMetaData(x.Id, x.MetaKey, x.MetaValue, x.MetaType, x.Setting1, x.Setting2));

        }
    }
}
