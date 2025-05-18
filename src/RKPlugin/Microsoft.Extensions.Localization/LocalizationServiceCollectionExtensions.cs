#region アセンブリ Microsoft.Extensions.Localization, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Localization;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for setting up localization services in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class LocalizationServiceCollectionExtensions
    {
        //
        // 概要:
        //     Adds services required for application localization.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddLocalization(this IServiceCollection services);
        //
        // 概要:
        //     Adds services required for application localization.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   setupAction:
        //     An System.Action`1 to configure the Microsoft.Extensions.Localization.LocalizationOptions.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddLocalization(this IServiceCollection services, Action<LocalizationOptions> setupAction);
    }
}