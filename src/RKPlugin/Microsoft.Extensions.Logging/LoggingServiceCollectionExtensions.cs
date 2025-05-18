#region アセンブリ Microsoft.Extensions.Logging, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Logging;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for setting up logging services in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class LoggingServiceCollectionExtensions
    {
        //
        // 概要:
        //     Adds logging services to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddLogging(this IServiceCollection services);
        //
        // 概要:
        //     Adds logging services to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        //   configure:
        //     The Microsoft.Extensions.Logging.ILoggingBuilder configuration delegate.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddLogging(this IServiceCollection services, Action<ILoggingBuilder> configure);
    }
}