#region アセンブリ Microsoft.Extensions.WebEncoders, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.WebEncoders;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for setting up web encoding services in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class EncoderServiceCollectionExtensions
    {
        //
        // 概要:
        //     Adds System.Text.Encodings.Web.HtmlEncoder, System.Text.Encodings.Web.JavaScriptEncoder
        //     and System.Text.Encodings.Web.UrlEncoder to the specified services.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddWebEncoders(this IServiceCollection services);
        //
        // 概要:
        //     Adds System.Text.Encodings.Web.HtmlEncoder, System.Text.Encodings.Web.JavaScriptEncoder
        //     and System.Text.Encodings.Web.UrlEncoder to the specified services.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   setupAction:
        //     An System.Action`1 to configure the provided Microsoft.Extensions.WebEncoders.WebEncoderOptions.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddWebEncoders(this IServiceCollection services, Action<WebEncoderOptions> setupAction);
    }
}