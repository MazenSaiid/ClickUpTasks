using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibary.GeneralFunctions
{
    public static class EnumExtensions
    {
        public static object GetAmbientValue(this Enum enumVal)
        {
            Type type = enumVal.GetType();
            TypeInfo typeInfo = type.GetTypeInfo();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(AmbientValueAttribute), false);

            if (attributes == null || attributes.Length == 0)
                return default;

            return ((AmbientValueAttribute)attributes[0]).Value;
        }
        public static object GetEnumAmbientValue(this Type _enum)
        {
            TypeInfo typeInfo = _enum.GetTypeInfo();
            object[] attributes = typeInfo.GetCustomAttributes(typeof(AmbientValueAttribute), false);

            if (attributes == null || attributes.Length == 0)
                return default;

            return ((AmbientValueAttribute)attributes[0]).Value;
        }
    }
}
