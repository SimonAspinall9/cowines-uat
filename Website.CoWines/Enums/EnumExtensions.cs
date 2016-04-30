namespace Website.CoWines.Enums
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes == null || !descriptionAttributes.Any()) return value.ToString();

            return descriptionAttributes[0].Description;
        }
    }
}
