using System.ComponentModel;

namespace Core.Helpers
{
    public static class EnumHelper
    {

        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }
    }
}
