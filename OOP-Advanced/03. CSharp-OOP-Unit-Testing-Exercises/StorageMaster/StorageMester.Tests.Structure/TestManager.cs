namespace StorageMester.Tests.Structure
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class TestManager
    {
        public static bool HasMethod(Type classType, Type methodType, string methodName, Type[] methodArg)
        {
            var parametresArray = classType
                .GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.Name == methodName && m.ReturnType == methodType)
                .Select(m => m.GetParameters());

            var parametres = parametresArray
                .FirstOrDefault(p => p.All(a => a.ParameterType == methodArg[Array.IndexOf(p, a)]));

            if (parametres != null)
            {
                return true;
            }

            return false;
        }

        public static bool HasConstructor(Type classType, Type[] constructorArg)
        {
            var parametresArray = classType
                .GetConstructors(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(c => c.GetParameters());

            var parametres = parametresArray
                .FirstOrDefault(p => p.All(a => a.ParameterType == constructorArg[Array.IndexOf(p, a)]));

            if (parametres != null)
            {
                return true;
            }

            return false;
        }

        public static bool HasField(Type classType, Type type, string name)
        {
            var fild = classType
                .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == name && f.FieldType == type);

            if (fild != null)
            {
                return true;
            }

            return false;
        }

        public static bool HasProperty(Type classType, Type type, string name, bool getter, bool setter)
        {
            var property = classType
                .GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == name && f.PropertyType == type);

            if (property != null)
            {
                if (property.CanRead == getter && property.CanWrite == setter)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
