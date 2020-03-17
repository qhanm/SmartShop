using SmartShop.App.ModelEntity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_Functions")]
    public class QHN_Function : QHN_PrimaryKey<string>
    {
        public QHN_Function()
        {
        }

        public QHN_Function(string id, string name, string parentId,string url, string iconCss, int sortOrder, Status status, bool isRole)
        {
            Id = id;
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = status;
            IsRole = isRole;
            ParentId = parentId;
        }

        public QHN_Function(string name, string url, string iconCss, int sortOrder, Status status, bool isRole)
        {
            Name = name;
            Url = url;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = status;
            IsRole = isRole;
        }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Url { get; set; }

        [MaxLength(100)]
        public string ParentId { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public bool IsRole { get; set; }
        public Status Status { get; set; }
    }
}