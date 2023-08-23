using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core
{
    public class Registrar
    {
        private static readonly Dictionary<Type, CoreBase> registeredInstances = new Dictionary<Type, CoreBase>();
        private static readonly object lockObject = new object(); // For thread safety

        public static void Initialize(string os)
        {
            Assembly[] cachedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in cachedAssemblies)
            {
                Type[] allTypes;
                try
                {
                    allTypes = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException)
                {
                    // Handle loading issues gracefully
                    continue;
                }

                foreach (Type type in allTypes)
                {
                    if (!type.IsAbstract && typeof(CoreBase).IsAssignableFrom(type))
                    {
                        if (type.BaseType != null && type.BaseType.FullName.Contains(os))
                        {
                            CoreBase instance = (CoreBase)Activator.CreateInstance(type);
                            lock (lockObject)
                            {
                                if (!registeredInstances.ContainsKey(type))
                                {
                                    registeredInstances.Add(type, instance);
                                }
                            }
                            instance.RegisterClass();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the active Instace of the interface 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? GetInstance<T>() where T : class
        {
            lock (lockObject)
            {
                foreach (var kvp in registeredInstances)
                {
                    if (typeof(T).IsAssignableFrom(kvp.Key))
                    {
                        return kvp.Value as T;
                    }
                }
            }
            return null;
        }
    }
}
