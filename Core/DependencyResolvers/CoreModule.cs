using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //uygulama seviyesinde servis bağımlılıklarımızı çözeceğimiz yer
        public void Load(IServiceCollection serviceCollection)
        {
            //IMemoryCache instance ı oluşturur.
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //buraya ilerde redis te ekleyebiliriz artık
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
