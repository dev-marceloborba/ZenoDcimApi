using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ZenoDcimManager.Infra.Contexts.Conversions
{
    public class UtcValueConverter : ValueConverter<DateTime, DateTime>
    {
        public UtcValueConverter()
            : base(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {
        }
    }
}