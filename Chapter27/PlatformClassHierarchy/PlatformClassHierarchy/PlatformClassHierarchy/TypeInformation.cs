using System;
using System.Reflection;

namespace PlatformClassHierarchy
{
    class TypeInformation
    {
        bool isBaseGenericType;
        Type baseGenericTypeDef;

        public TypeInformation(Type type, bool isXamarinForms)
        {
            Type = type;

            if (type.FullName.Length > 100)
                System.Diagnostics.Debug.WriteLine(type.FullName);


            IsXamarinForms = isXamarinForms;
            TypeInfo typeInfo = type.GetTypeInfo();
            BaseType = typeInfo.BaseType;

            if (BaseType != null)
            {
                TypeInfo baseTypeInfo = BaseType.GetTypeInfo();
                isBaseGenericType = baseTypeInfo.IsGenericType;

                if (isBaseGenericType)
                {
                    baseGenericTypeDef = baseTypeInfo.GetGenericTypeDefinition();
                }
            }
        }

        public Type Type { private set; get; }
        public Type BaseType { private set; get; }
        public bool IsXamarinForms { private set; get; }

        public bool IsDerivedDirectlyFrom(Type parentType)
        {
            if (BaseType != null && isBaseGenericType)
            {
                if (baseGenericTypeDef == parentType)
                {
                    return true;
                }
            }
            else if (BaseType == parentType)
            {
                return true;
            }
            return false;
        }
    }
}
