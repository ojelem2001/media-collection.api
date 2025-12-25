using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MediaCollection.Core.Extensions;

public static class EnumExtensions
{
    public static T? GetEnumFromDisplayName<T>(this string displayName) where T : Enum
    {
        if (string.IsNullOrWhiteSpace(displayName))
            return default;

        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<DisplayAttribute>();
            if (attribute?.Name?.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
            {
                return (T)field.GetValue(null)!;
            }
        }

        throw new Exception($"Can't parse {displayName} to enum {nameof(T)}");
    }
}
