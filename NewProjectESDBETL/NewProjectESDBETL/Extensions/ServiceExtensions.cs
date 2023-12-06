﻿using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace NewProjectESDBETL.Extensions
{
    public static class ServiceExtensions
    {
        //Defining a set of attribute
        public class ScopedRegistrationAttribute : Attribute { }
        public class SingletonRegistrationAttribute: Attribute { }
        public class TransientRegistrationAttribute: Attribute { }
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // define types that need matching
            Type scopedRegistration = typeof(ScopedRegistrationAttribute);
            Type singletonRegistration = typeof(SingletonRegistrationAttribute);
            Type transientRegistration = typeof(TransientRegistrationAttribute);

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(p => p.IsDefined(scopedRegistration, true) || p.IsDefined(transientRegistration, true) || p.IsDefined(singletonRegistration, true) && !p.IsInterface.Select(singletonRegistration => new
                {
                    Service = scopedRegistration.GetInterface($"I{s.Name}"),
                    Implementation = s
                }).Where(x => x.Service != null);
            foreach (var type in types) 
            {
                if (type.Implementation.IsDefined(scopedRegistration, false)) 
                {
                    services.AddScoped(type.Service, type.Implementation);
                }

                if (type.Implementation.IsDefined(transientRegistration, false))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }

                if (type.Implementation.IsDefined(singletonRegistration, false))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
            }

        }
    }
}
