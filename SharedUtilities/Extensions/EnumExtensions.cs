using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SharedUtilities.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this Enum e)
        {
            Type type = e.GetType();
            Array values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val == Convert.ToInt32(e))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }
            return string.Empty;
        }

        public static T GetEnumValueFromDescription<T>(this string description)
        {
            MemberInfo[] fis = typeof(T).GetFields();

            foreach (var fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
                    return (T)Enum.Parse(typeof(T), fi.Name);
            }

            return default;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                         .GetMember(enumValue.ToString())
                         .First()
                         .GetCustomAttribute<DisplayAttribute>()
                         .GetName();
        }
    }
}
