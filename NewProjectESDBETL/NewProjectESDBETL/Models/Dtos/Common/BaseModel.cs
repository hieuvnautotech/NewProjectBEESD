namespace NewProjectESDBETL.Models.Dtos.Common
{
    public class BaseModel:PageModel
    {
        public bool? isActived { get; set; } = true;
        public DateTime? createDate { get; set; } = DateTime.UtcNow;
        public long? createBy { get; set; } = default;
        public DateTime? modifiedDate { get; set; } = default;
        public long? modifiedBy { get; set;} = default;
        public byte[]? row_version { get; set; } = default;
        public string? createName { get; set; } = default;
        public string? modifiedName { get; set; } = default;
    }
    }
}
