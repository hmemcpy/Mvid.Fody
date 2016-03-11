using System.Linq;
using Mono.Cecil;

static class Extensions
{
    public static bool TryGetAttribute(this ICustomAttributeProvider definition, string attributeName, out CustomAttribute attribute)
    {
        var attributes = definition.CustomAttributes;

        attribute = attributes.FirstOrDefault(x => x.AttributeType.Name == attributeName);
        return attribute != null;
    }
}