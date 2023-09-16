using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core
{
    /// <summary>
    /// Provides registration and retrieval of instances of classes that inherit from CoreBase.
    /// </summary>
    public class Registrar
    {
        private static readonly Dictionary<Type, CoreBase> registeredInstances = new Dictionary<Type, CoreBase>();
        private static readonly object lockObject = new object(); // For thread safety

        /// <summary>
        /// Initializes the Registrar by scanning assemblies and registering compatible instances.
        /// </summary>
        /// <param name="os">The target operating system string for filtering.</param>
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
                    //TODO: Handle loading issues gracefully
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
                        }
                    }
                }
            }

            // Register and start the classes once they are instantiated.
            foreach (var inst in registeredInstances.Values)
            {
                inst.RegisterClass();
            }

            foreach (var inst in registeredInstances.Values)
            {
                inst.StartClass();
            }
        }

        /// <summary>
        /// Gets the active instance of the specified interface type.
        /// </summary>
        /// <typeparam name="T">The interface type to retrieve an instance of.</typeparam>
        /// <returns>The active instance of the specified interface, or null if not found.</returns>
        public static T GetInstance<T>() where T : class
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
