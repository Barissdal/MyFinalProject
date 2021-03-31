using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //Core katmanıda dahil olmak üzere ekleyeceğimiz bütün injectionları bir arada tutacak bir yapı
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, 
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
