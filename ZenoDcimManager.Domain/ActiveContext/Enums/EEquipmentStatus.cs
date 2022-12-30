using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ZenoDcimManager.Domain.ZenoContext.Enums
{
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    // [DataContract]
    public enum EEquipmentStatus
    {
        [EnumMember(Value = "Arquivado")]
        // [Description("Arquivado")]
        // [Display(Name = "Arquivado")]
        ARCHIVED = 0,

        [EnumMember(Value = "Instalado")]
        // [Description("Instalado")]
        // [Display(Name = "Instalado")]
        INSTALLED = 1,

        [EnumMember(Value = "Fora da planta")]
        // [Description("Fora da planta")]
        // [Display(Name = "Fora da planta")]
        OFF_SITE = 2,

        [EnumMember(Value = "Planejado")]
        // [Description("Planejado")]
        // [Display(Name = "Planejado")]
        PLANNED = 3,

        [EnumMember(Value = "Desligado")]
        // [Description("Desligado")]
        // [Display(Name = "Desligado")]
        POWERED_OFF = 4,

        [EnumMember(Value = "Armazenado")]
        // [Description("Armazenado")]
        // [Display(Name = "Armazenado")]
        STORAGE = 5,
    }
}

