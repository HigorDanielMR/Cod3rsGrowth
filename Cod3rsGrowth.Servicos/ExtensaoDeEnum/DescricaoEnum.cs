using System.ComponentModel;
using System.Reflection;

namespace Cod3rsGrowth.Servicos.ExtensaoDeEnum
{
    public static class DescricaoEnum
    {
        public static string ObterDescricaoEnum(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
