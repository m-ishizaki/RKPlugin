using RkSoftware.RKPlugin;
using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

var pluginPath = Path.Combine(Assembly.GetEntryAssembly()?.Location!, "../../../../../TestPlugin/bin/Debug/net10.0");
var plugins = PluginLoadContext.LoadExtensions(pluginPath);
foreach (var plugin in plugins)
    foreach (var assembly in plugin.Assemblies)
        foreach (var type in assembly.GetTypes())
        {
            var method = type.GetMethod("ConfigureServices");
            if (method != null)
            {
                var result = PluginLoadContext.Invoke(services, method, null, null);
                Debug.Write(result);
            }
        }

services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();


#region

Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions.AddServiceLogEnricher(services);

/*
�T�[�r�X �G�����b�`���[�̃C���X�^���X�� IServiceCollection�ɒǉ����܂��B

AddServiceLogEnricher(IServiceCollection, IConfigurationSection)	
�T�[�r�X �G�����b�`���[�̃C���X�^���X�� IServiceCollection�ɒǉ����܂��B

AddServiceLogEnricher(IServiceCollection, Action<ApplicationLogEnricherOptions>)	
�T�[�r�X �G�����b�`���[�̃C���X�^���X�� IServiceCollection�ɒǉ����܂��B

AddApplicationMetadata(IServiceCollection, IConfigurationSection)	
�ˑ��֌W�}���R���e�i�[�� ApplicationMetadata �̃C���X�^���X��ǉ����܂��B

AddApplicationMetadata(IServiceCollection, Action<ApplicationMetadata>)	
�ˑ��֌W�}���R���e�i�[�� ApplicationMetadata �̃C���X�^���X��ǉ����܂��B

AddAsyncState(IServiceCollection)	
IAsyncState�AIAsyncContext<T>�A����� Microsoft.Extensions.AsyncState.IAsyncLocalContext`1 �T�[�r�X�̊���̎�����ǉ����܂��B �����̃C���^�[�t�F�C�X�̎����̓X���b�h �Z�[�t�ł͂Ȃ����Ƃɒ��ӂ��Ă��������B

ActivateKeyedSingleton(IServiceCollection, Type, Object)	
���s���ł͂Ȃ��A�N�����ɃL�[�t���V���O���g���̃A�N�e�B�u����K�p���܂��B

ActivateKeyedSingleton<TService>(IServiceCollection, Object)	
���s���ł͂Ȃ��A�N�����ɃL�[�t���V���O���g���̃A�N�e�B�u����K�p���܂��B

ActivateSingleton(IServiceCollection, Type)	
���s���ł͂Ȃ��A�N�����ɃV���O���g���A�N�e�B�u����K�p���܂��B

ActivateSingleton<TService>(IServiceCollection)	
���s���ł͂Ȃ��A�N�����ɃV���O���g���A�N�e�B�u����K�p���܂��B

AddActivatedKeyedSingleton(IServiceCollection, Type, Object)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedKeyedSingleton(IServiceCollection, Type, Object, Type)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedKeyedSingleton<TService>(IServiceCollection, Object)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedKeyedSingleton<TService, TImplementation>(IServiceCollection, Object)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedKeyedSingleton<TService, TImplementation>(IServiceCollection, Object, Func<IServiceProvider, Object, TImplementation>)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedSingleton(IServiceCollection, Type)	
serviceType �Ŏw�肳�ꂽ�^�̎����A�N�e�B�u���V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddActivatedSingleton(IServiceCollection, Type, Func<IServiceProvider, Object>)	
�����A�N�e�B�u�����ꂽ�V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedSingleton(IServiceCollection, Type, Type)	
�����A�N�e�B�u�����ꂽ�V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedSingleton<TService>(IServiceCollection)	
�����A�N�e�B�u�����ꂽ�V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedSingleton<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
�����A�N�e�B�u�����ꂽ�V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedSingleton<TService, TImplementation>(IServiceCollection)	
�����A�N�e�B�u�����ꂽ�V���O���g�� �T�[�r�X��ǉ����܂��B

AddActivatedSingleton<TService, TImplementation>(IServiceCollection, Func<IServiceProvider, TImplementation>)	
�����A�N�e�B�u�����ꂽ�V���O���g�� �T�[�r�X��ǉ����܂��B

TryAddActivatedKeyedSingleton(IServiceCollection, Type, Object)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedKeyedSingleton(IServiceCollection, Type, Object, Type)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedKeyedSingleton<TService>(IServiceCollection, Object)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedKeyedSingleton<TService, TImplementation>(IServiceCollection, Object)	
�����A�N�e�B�u���L�[�t���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedSingleton(IServiceCollection, Type)	
�����A�N�e�B�u���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedSingleton(IServiceCollection, Type, Func<IServiceProvider, Object>)	
�����A�N�e�B�u���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedSingleton(IServiceCollection, Type, Type)	
�����A�N�e�B�u���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedSingleton<TService>(IServiceCollection)	
�����A�N�e�B�u���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedSingleton<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
�����A�N�e�B�u���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

TryAddActivatedSingleton<TService, TImplementation>(IServiceCollection)	
�����A�N�e�B�u���V���O���g�� �T�[�r�X�̒ǉ������݂܂��B

AddTelemetryHealthCheckPublisher(IServiceCollection)	
�A�v���P�[�V�����̐��퐫��\���e�����g�����o�͂��鐳�퐫�`�F�b�N���s����o�^���܂��B

AddTelemetryHealthCheckPublisher(IServiceCollection, IConfigurationSection)	
�A�v���P�[�V�����̐��퐫��\���e�����g�����o�͂��鐳�퐫�`�F�b�N���s����o�^���܂��B

AddTelemetryHealthCheckPublisher(IServiceCollection, Action<TelemetryHealthCheckPublisherOptions>)	
�A�v���P�[�V�����̐��퐫��\���e�����g�����o�͂��鐳�퐫�`�F�b�N���s����o�^���܂��B

AddContextualOptions(IServiceCollection)	
�R���e�L�X�g �I�v�V�������g�p���邽�߂ɕK�v�ȃT�[�r�X��ǉ����܂��B

Configure<TOptions>(IServiceCollection, Action<IOptionsContext, TOptions>)	
����̎�ނ̃I�v�V�������\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B

Configure<TOptions>(IServiceCollection, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>>)	
����̎�ނ̃I�v�V�������\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B

Configure<TOptions>(IServiceCollection, String, Action<IOptionsContext, TOptions>)	
����̎�ނ̃I�v�V�������\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B

Configure<TOptions>(IServiceCollection, String, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>>)	
����̎�ނ̃I�v�V�������\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B

ConfigureAll<TOptions>(IServiceCollection, Action<IOptionsContext, TOptions>)	
����̎�ނ̃I�v�V�����̂��ׂẴC���X�^���X���\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B

ConfigureAll<TOptions>(IServiceCollection, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>>)	
����̎�ނ̃I�v�V�����̂��ׂẴC���X�^���X���\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B

AddWebEncoders(IServiceCollection)	
�w�肵�� services�� HtmlEncoder�AJavaScriptEncoder�A����� UrlEncoder ��ǉ����܂��B

AddWebEncoders(IServiceCollection, Action<WebEncoderOptions>)	
�w�肵�� services�� HtmlEncoder�AJavaScriptEncoder�A����� UrlEncoder ��ǉ����܂��B

AddLogEnricher(IServiceCollection, ILogEnricher)	
���O �G�����b�`���[ �C���X�^���X��o�^���܂��B

AddLogEnricher<T>(IServiceCollection)	
���O �G�����b�`���[�̎�ނ�o�^���܂��B

AddStaticLogEnricher(IServiceCollection, IStaticLogEnricher)	
�ÓI���O �G�����b�`���[ �C���X�^���X��o�^���܂��B

AddStaticLogEnricher<T>(IServiceCollection)	
�ÓI���O �G�����b�`���[�̎�ނ�o�^���܂��B

AddExceptionSummarizer(IServiceCollection)	
��O�T�}���C�U�[���ˑ��֌W�}���R���e�i�[�ɓo�^���܂��B

AddExceptionSummarizer(IServiceCollection, Action<IExceptionSummarizationBuilder>)	
��O�T�}���C�U�[���ˑ��֌W�}���R���e�i�[�ɓo�^���܂��B

Add(IServiceCollection, ServiceDescriptor)	
�w�肵�� descriptor �� collection�ɒǉ����܂��B

Add(IServiceCollection, IEnumerable<ServiceDescriptor>)	
collection�Ɉ�A�� ServiceDescriptor ��ǉ����܂��B

RemoveAll(IServiceCollection, Type)	
IServiceCollection�� serviceType �^�̂��ׂẴT�[�r�X���폜���܂��B

RemoveAll<T>(IServiceCollection)	
IServiceCollection�� T �^�̂��ׂẴT�[�r�X���폜���܂��B

RemoveAllKeyed(IServiceCollection, Type, Object)	
collection�� serviceType �^�̂��ׂẴT�[�r�X���폜���܂��B

RemoveAllKeyed<T>(IServiceCollection, Object)	
collection�� T �^�̂��ׂẴT�[�r�X���폜���܂��B

Replace(IServiceCollection, ServiceDescriptor)	
descriptor �Ɠ����T�[�r�X�̎�ނ����� IServiceCollection �̍ŏ��̃T�[�r�X���폜���A�R���N�V������ descriptor ��ǉ����܂��B

TryAdd(IServiceCollection, ServiceDescriptor)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� descriptor �� collection �ɒǉ����܂��B

TryAdd(IServiceCollection, IEnumerable<ServiceDescriptor>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� descriptors �� collection �ɒǉ����܂��B

TryAddEnumerable(IServiceCollection, ServiceDescriptor)	
���� ServiceType ���������̋L�q�q�ƁAservices�ɂ܂����݂��Ȃ�����������ꍇ�́AServiceDescriptor ��ǉ����܂��B

TryAddEnumerable(IServiceCollection, IEnumerable<ServiceDescriptor>)	
���� ServiceType ���������̋L�q�q�ƁAservices�ɂ܂����݂��Ȃ�����������ꍇ�́A�w�肵�� ServiceDescriptor��ǉ����܂��B

TryAddKeyedScoped(IServiceCollection, Type, Object)	
�w�肵�� service �� Scoped �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddKeyedScoped(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� service �� Scoped �T�[�r�X�Ƃ��� collection �ɒǉ����܂��B

TryAddKeyedScoped(IServiceCollection, Type, Object, Type)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� service �� Scoped �T�[�r�X�Ƃ��� implementationType ������ collection �ɒǉ����܂��B

TryAddKeyedScoped<TService>(IServiceCollection, Object)	
�w�肵�� TService �� Scoped �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddKeyedScoped<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� TService �� Scoped �T�[�r�X�Ƃ��� services �ɒǉ����܂��B

TryAddKeyedScoped<TService, TImplementation>(IServiceCollection, Object)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́ATImplementation �Ŏw�肳�ꂽ Scoped �T�[�r�X�����^�Ƃ��Ďw�肵�� TService �� collection �ɒǉ����܂��B

TryAddKeyedSingleton(IServiceCollection, Type, Object)	
�w�肵�� service �� Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� service �� Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂��B

TryAddKeyedSingleton(IServiceCollection, Type, Object, Type)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� service �� Singleton �T�[�r�X�Ƃ��� implementationType ������ collection �ɒǉ����܂��B

TryAddKeyedSingleton<TService>(IServiceCollection, Object)	
�w�肵�� TService �� Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddKeyedSingleton<TService>(IServiceCollection, Object, TService)	
�w�肵�� TService ���Ainstance �Ŏw�肳�ꂽ�C���X�^���X������ Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� TService �� Singleton �T�[�r�X�Ƃ��� services �ɒǉ����܂��B

TryAddKeyedSingleton<TService, TImplementation>(IServiceCollection, Object)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́ATImplementation �Ŏw�肳�ꂽ Singleton �T�[�r�X�����^�Ƃ��Ďw�肵�� TService �� collection �ɒǉ����܂��B

TryAddKeyedTransient(IServiceCollection, Type, Object)	
�w�肵�� service �� Transient �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddKeyedTransient(IServiceCollection, Type, Object, Func<IServiceProvider, Object, Object>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� service �� Transient �T�[�r�X�Ƃ��� collection �ɒǉ����܂��B

TryAddKeyedTransient(IServiceCollection, Type, Object, Type)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� service �� Transient �T�[�r�X�Ƃ��� implementationType ������ collection �ɒǉ����܂��B

TryAddKeyedTransient<TService>(IServiceCollection, Object)	
�w�肵�� TService �� Transient �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddKeyedTransient<TService>(IServiceCollection, Object, Func<IServiceProvider, Object, TService>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� TService �� Transient �T�[�r�X�Ƃ��� services �ɒǉ����܂��B

TryAddKeyedTransient<TService, TImplementation>(IServiceCollection, Object)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́ATImplementation �Ŏw�肳�ꂽ Transient �T�[�r�X�����^�Ƃ��Ďw�肵�� TService �� collection �ɒǉ����܂��B

TryAddScoped(IServiceCollection, Type)	
�w�肵�� service �� Scoped �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddScoped(IServiceCollection, Type, Func<IServiceProvider, Object>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� service �� Scoped �T�[�r�X�Ƃ��� collection �ɒǉ����܂��B

TryAddScoped(IServiceCollection, Type, Type)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� service �� Scoped �T�[�r�X�Ƃ��� implementationType ������ collection �ɒǉ����܂��B

TryAddScoped<TService>(IServiceCollection)	
�w�肵�� TService �� Scoped �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddScoped<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� TService �� Scoped �T�[�r�X�Ƃ��� services �ɒǉ����܂��B

TryAddScoped<TService, TImplementation>(IServiceCollection)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́ATImplementation �Ŏw�肳�ꂽ Scoped �T�[�r�X�����^�Ƃ��Ďw�肵�� TService �� collection �ɒǉ����܂��B

TryAddSingleton(IServiceCollection, Type)	
�w�肵�� service �� Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddSingleton(IServiceCollection, Type, Func<IServiceProvider, Object>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� service �� Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂��B

TryAddSingleton(IServiceCollection, Type, Type)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� service �� Singleton �T�[�r�X�Ƃ��� implementationType ������ collection �ɒǉ����܂��B

TryAddSingleton<TService>(IServiceCollection)	
�w�肵�� TService �� Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddSingleton<TService>(IServiceCollection, TService)	
�w�肵�� TService ���Ainstance �Ŏw�肳�ꂽ�C���X�^���X������ Singleton �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddSingleton<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� TService �� Singleton �T�[�r�X�Ƃ��� services �ɒǉ����܂��B

TryAddSingleton<TService, TImplementation>(IServiceCollection)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́ATImplementation �Ŏw�肳�ꂽ Singleton �T�[�r�X�����^�Ƃ��Ďw�肵�� TService �� collection �ɒǉ����܂��B

TryAddTransient(IServiceCollection, Type)	
�w�肵�� service �� Transient �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddTransient(IServiceCollection, Type, Func<IServiceProvider, Object>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� service �� Transient �T�[�r�X�Ƃ��� collection �ɒǉ����܂��B

TryAddTransient(IServiceCollection, Type, Type)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́A�w�肵�� service �� Transient �T�[�r�X�Ƃ��� implementationType ������ collection �ɒǉ����܂��B

TryAddTransient<TService>(IServiceCollection)	
�w�肵�� TService �� Transient �T�[�r�X�Ƃ��� collection �ɒǉ����܂� (�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ)�B

TryAddTransient<TService>(IServiceCollection, Func<IServiceProvider, TService>)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́AimplementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āA�w�肵�� TService �� Transient �T�[�r�X�Ƃ��� services �ɒǉ����܂��B

TryAddTransient<TService, TImplementation>(IServiceCollection)	
�T�[�r�X�̎�ނ��܂��o�^����Ă��Ȃ��ꍇ�́ATImplementation �Ŏw�肳�ꂽ Transient �T�[�r�X�����^�Ƃ��Ďw�肵�� TService �� collection �ɒǉ����܂��B

AddFakeLogging(IServiceCollection)	
����̃I�v�V�������g�p���ċU�̃��O�L�^���\�����܂��B

AddFakeLogging(IServiceCollection, IConfigurationSection)	
�U�̃��O�L�^���\�����܂��B

AddFakeLogging(IServiceCollection, Action<FakeLogCollectorOptions>)	
�U�̃��O�L�^���\�����܂��B

AddFakeRedaction(IServiceCollection)	
��ɋU�� redactor �C���X�^���X��Ԃ��U�̃��_�N�^�[ �v���o�C�_�[��o�^���܂��B

AddFakeRedaction(IServiceCollection, Action<FakeRedactorOptions>)	
��ɋU�� redactor �C���X�^���X��Ԃ��U�̃��_�N�^�[ �v���o�C�_�[��o�^���܂��B

AddHealthChecks(IServiceCollection)	
�w�肳�ꂽ�f���Q�[�g���g�p���Đ��퐫�`�F�b�N��o�^���āAHealthCheckService ���R���e�i�[�ɒǉ����܂��B

AddHttpClient(IServiceCollection)	
IHttpClientFactory ����ъ֘A����T�[�r�X�� IServiceCollection�ɒǉ����܂��B

AddHttpClient(IServiceCollection, String)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����A���O�t�� HttpClient���\�����܂��B

AddHttpClient(IServiceCollection, String, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����A���O�t�� HttpClient���\�����܂��B

AddHttpClient(IServiceCollection, String, Action<HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����A���O�t�� HttpClient���\�����܂��B

AddHttpClient<TClient>(IServiceCollection)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B �N���C�A���g���́ATClient�̊��S�Ȗ��O�ɐݒ肳��܂��B

AddHttpClient<TClient>(IServiceCollection, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B �N���C�A���g���́ATClient�̌^���ɐݒ肳��܂��B

AddHttpClient<TClient>(IServiceCollection, Action<HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B �N���C�A���g���́ATClient�̌^���ɐݒ肳��܂��B

AddHttpClient<TClient>(IServiceCollection, String)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient>(IServiceCollection, String, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient>(IServiceCollection, String, Action<HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient, TImplementation>(IServiceCollection)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B �N���C�A���g���́ATClient�̌^���ɐݒ肳��܂��B

AddHttpClient<TClient, TImplementation>(IServiceCollection, Action<IServiceProvider, HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B �N���C�A���g���́ATClient�̌^���ɐݒ肳��܂��B

AddHttpClient<TClient, TImplementation>(IServiceCollection, Action<HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B �N���C�A���g���́ATClient�̌^���ɐݒ肳��܂��B

AddHttpClient<TClient,TImplementation>(IServiceCollection, Func<HttpClient,TImplementation>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient,TImplementation>(IServiceCollection, Func<HttpClient,IServiceProvider,TImplementation>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient,TImplementation>(IServiceCollection, String)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B �N���C�A���g���́ATClient�̌^���ɐݒ肳��܂��B

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Action<IServiceProvider,HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Action<HttpClient>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Func<HttpClient,TImplementation>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

AddHttpClient<TClient,TImplementation>(IServiceCollection, String, Func<HttpClient,IServiceProvider,TImplementation>)	
IHttpClientFactory ����ъ֘A�T�[�r�X�� IServiceCollection �ɒǉ����ATClient �^�Ɩ��O�t�� HttpClient�̊Ԃ̃o�C���f�B���O���\�����܂��B

ConfigureHttpClientDefaults(IServiceCollection, Action<IHttpClientBuilder>)	
���ׂĂ� HttpClient �C���X�^���X�̍\���Ɏg�p�����f���Q�[�g��ǉ����܂��B

AddHttpClientLatencyTelemetry(IServiceCollection)	
�ҋ@���ԏ������W���A���ׂĂ� http �N���C�A���g�̑��M�v�����O���������邽�߂� DelegatingHandler ��ǉ����܂��B

AddHttpClientLatencyTelemetry(IServiceCollection, IConfigurationSection)	
�ҋ@���ԏ������W���A���ׂĂ� http �N���C�A���g�̑��M�v�����O���������邽�߂� DelegatingHandler ��ǉ����܂��B

AddHttpClientLatencyTelemetry(IServiceCollection, Action<HttpClientLatencyTelemetryOptions>)	
�ҋ@���ԏ������W���A���ׂĂ� http �N���C�A���g�̑��M�v�����O���������邽�߂� DelegatingHandler ��ǉ����܂��B

AddExtendedHttpClientLogging(IServiceCollection)	
IHttpClientFactory�ō쐬���ꂽ���ׂĂ� HTTP �N���C�A���g�̑��M�v���̃��O���o�͂��� IHttpClientAsyncLogger ��ǉ����܂��B

AddExtendedHttpClientLogging(IServiceCollection, IConfigurationSection)	
IHttpClientFactory�ō쐬���ꂽ���ׂĂ� HTTP �N���C�A���g�̑��M�v���̃��O���o�͂��� IHttpClientAsyncLogger ��ǉ����܂��B

AddExtendedHttpClientLogging(IServiceCollection, Action<LoggingOptions>)	
IHttpClientFactory�ō쐬���ꂽ���ׂĂ� HTTP �N���C�A���g�̑��M�v���̃��O���o�͂��� IHttpClientAsyncLogger ��ǉ����܂��B

AddHttpClientLogEnricher<T>(IServiceCollection)	
T �̃G�����b�`���[ �C���X�^���X�� IServiceCollection �ɒǉ����āAHttpClient ���O���G�����b�`���܂��B

AddDownstreamDependencyMetadata(IServiceCollection, IDownstreamDependencyMetadata)	
�ˑ��֌W���^�f�[�^��ǉ����܂��B

AddDownstreamDependencyMetadata<T>(IServiceCollection)	
�ˑ��֌W���^�f�[�^��ǉ����܂��B

AddHybridCache(IServiceCollection)	
�T�[�r�X�L�q�q�̃R���N�V�����̃R���g���N�g���w�肵�܂��B

AddHybridCache(IServiceCollection, Action<HybridCacheOptions>)	
�T�[�r�X�L�q�q�̃R���N�V�����̃R���g���N�g���w�肵�܂��B

AddKubernetesProbes(IServiceCollection)	
����̃I�v�V�������g�p���āAliveness�Astartup�A����� readiness �v���[�u��o�^���܂��B

AddKubernetesProbes(IServiceCollection, IConfigurationSection)	
�\�����ꂽ�I�v�V�������g�p���āAliveness�Astartup�A����� readiness �v���[�u��o�^���܂��B

AddKubernetesProbes(IServiceCollection, Action<KubernetesProbesOptions>)	
�\�����ꂽ�I�v�V�������g�p���āAliveness�Astartup�A����� readiness �v���[�u��o�^���܂��B

AddConsoleLatencyDataExporter(IServiceCollection)	
�R���\�[���̑ҋ@���ԃf�[�^ �G�N�X�|�[�^�[��ǉ����܂��B

AddConsoleLatencyDataExporter(IServiceCollection, IConfigurationSection)	
�R���\�[���̑ҋ@���ԃf�[�^ �G�N�X�|�[�^�[��ǉ����܂��B

AddConsoleLatencyDataExporter(IServiceCollection, Action<LatencyConsoleOptions>)	
�R���\�[���̑ҋ@���ԃf�[�^ �G�N�X�|�[�^�[��ǉ����܂��B

AddLatencyContext(IServiceCollection)	
�ҋ@���ԃR���e�L�X�g��ǉ����܂��B

AddLatencyContext(IServiceCollection, IConfigurationSection)	
�ҋ@���ԃR���e�L�X�g��ǉ����܂��B

AddLatencyContext(IServiceCollection, Action<LatencyContextOptions>)	
�ҋ@���ԃR���e�L�X�g��ǉ����܂��B

RegisterCheckpointNames(IServiceCollection, String[])	
�ҋ@���ԃR���e�L�X�g�̃`�F�b�N�|�C���g���̃Z�b�g��o�^���܂��B

RegisterMeasureNames(IServiceCollection, String[])	
�ҋ@���ԃR���e�L�X�g�̃��W���[���̃Z�b�g��o�^���܂��B

RegisterTagNames(IServiceCollection, String[])	
�ҋ@���ԃR���e�L�X�g�̃^�O���̃Z�b�g��o�^���܂��B

AddLocalization(IServiceCollection)	
�A�v���P�[�V�����̃��[�J���C�Y�ɕK�v�ȃT�[�r�X��ǉ����܂��B

AddLocalization(IServiceCollection, Action<LocalizationOptions>)	
�A�v���P�[�V�����̃��[�J���C�Y�ɕK�v�ȃT�[�r�X��ǉ����܂��B

AddLogging(IServiceCollection)	
�w�肵�� IServiceCollection�Ƀ��O �T�[�r�X��ǉ����܂��B

AddLogging(IServiceCollection, Action<ILoggingBuilder>)	
�w�肵�� IServiceCollection�Ƀ��O �T�[�r�X��ǉ����܂��B

AddDistributedMemoryCache(IServiceCollection)	
�������ɍ��ڂ��i�[���� IDistributedCache �̊���̎����� IServiceCollection�ɒǉ����܂��B ���U�L���b�V�����@�\������K�v������t���[�����[�N�ł́A�ˑ��֌W���X�g�̈ꕔ�Ƃ��Ă��̈ˑ��֌W�����S�ɒǉ����āA���Ȃ��Ƃ� 1 �̎������g�p�\�ł��邱�Ƃ��m�F�ł��܂��B

AddDistributedMemoryCache(IServiceCollection, Action<MemoryDistributedCacheOptions>)	
�������ɍ��ڂ��i�[���� IDistributedCache �̊���̎����� IServiceCollection�ɒǉ����܂��B ���U�L���b�V�����@�\������K�v������t���[�����[�N�ł́A�ˑ��֌W���X�g�̈ꕔ�Ƃ��Ă��̈ˑ��֌W�����S�ɒǉ����āA���Ȃ��Ƃ� 1 �̎������g�p�\�ł��邱�Ƃ��m�F�ł��܂��B

AddMemoryCache(IServiceCollection)	
IMemoryCache �̔񕪎U������������ IServiceCollection�ɒǉ����܂��B

AddMemoryCache(IServiceCollection, Action<MemoryCacheOptions>)	
IMemoryCache �̔񕪎U������������ IServiceCollection�ɒǉ����܂��B

AddMetrics(IServiceCollection)	
�w�肵�� IServiceCollection�Ƀ��g���b�N �T�[�r�X��ǉ����܂��B

AddMetrics(IServiceCollection, Action<IMetricsBuilder>)	
�w�肵�� IServiceCollection�Ƀ��g���b�N �T�[�r�X��ǉ����܂��B

AddNullLatencyContext(IServiceCollection)	
�ˑ��֌W�}���R���e�i�[�� no-op �ҋ@���ԃR���e�L�X�g��ǉ����܂��B

AddPooled<TService>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
ObjectPool<T> ��ǉ����ADI �� TService�̃X�R�[�v�t���C���X�^���X��Ԃ����Ƃ��ł��܂��B

AddPooled<TService,TImplementation>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
ObjectPool<T> ��ǉ����ADI �� TService�̃X�R�[�v�t���C���X�^���X��Ԃ����Ƃ��ł��܂��B

ConfigurePool<TService>(IServiceCollection, Action<DependencyInjectionPoolOptions>)	
�^�w�肳�ꂽ�v�[���� DependencyInjectionPoolOptions �̍\���Ɏg�p����A�N�V������o�^���܂��B

ConfigurePools(IServiceCollection, IConfigurationSection)	
DI �v�[�����\�����܂��B

Configure<TOptions>(IServiceCollection, IConfiguration)	
TOptions �o�C���h����\���C���X�^���X��o�^���A�\�����ύX���ꂽ�Ƃ��ɃI�v�V�������X�V���܂��B

Configure<TOptions>(IServiceCollection, IConfiguration, Action<BinderOptions>)	
TOptions ���o�C���h����\���C���X�^���X��o�^���܂��B

Configure<TOptions>(IServiceCollection, String, IConfiguration)	
TOptions ���o�C���h����\���C���X�^���X��o�^���܂��B

Configure<TOptions>(IServiceCollection, String, IConfiguration, Action<BinderOptions>)	
TOptions ���o�C���h����\���C���X�^���X��o�^���܂��B

AddOptions(IServiceCollection)	
�I�v�V�������g�p���邽�߂ɕK�v�ȃT�[�r�X��ǉ����܂��B

AddOptions<TOptions>(IServiceCollection)	
�������O�t�� TOptions �� Configure �Ăяo������ɂȂ�T�[�r�X �R���N�V�����ɓ]������I�v�V���� �r���_�[���擾���܂��B

AddOptions<TOptions>(IServiceCollection, String)	
�������O�t�� TOptions �� Configure �Ăяo������ɂȂ�T�[�r�X �R���N�V�����ɓ]������I�v�V���� �r���_�[���擾���܂��B

AddOptionsWithValidateOnStart<TOptions>(IServiceCollection, String)	
�I�v�V�������g�p���邽�߂ɕK�v�ȃT�[�r�X��ǉ����A���s���ł͂Ȃ��N�����ɃI�v�V�������؃`�F�b�N��K�p���܂��B

AddOptionsWithValidateOnStart<TOptions,TValidateOptions>(IServiceCollection, String)	
�I�v�V�������g�p���邽�߂ɕK�v�ȃT�[�r�X��ǉ����A���s���ł͂Ȃ��N�����ɃI�v�V�������؃`�F�b�N��K�p���܂��B

Configure<TOptions>(IServiceCollection, Action<TOptions>)	
�N�����ɓ���̎�ނ̃I�v�V������ 1 ��\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B ����́APostConfigure<TOptions>(IServiceCollection, Action<TOptions>)����O�Ɏ��s����܂��B �\�����X�V���Ă��A�A�N�V�����͍ēx�Ăяo����܂���B

Configure<TOptions>(IServiceCollection, String, Action<TOptions>)	
����̎�ނ̃I�v�V�������\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B �����́APostConfigure<TOptions>(IServiceCollection, Action<TOptions>)����O�Ɏ��s����܂��B

ConfigureAll<TOptions>(IServiceCollection, Action<TOptions>)	
����̎�ނ̃I�v�V�����̂��ׂẴC���X�^���X���\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B

ConfigureOptions(IServiceCollection, Object)	
���ׂĂ� I[Post]ConfigureOptions ���o�^�����I�u�W�F�N�g��o�^���܂��B

ConfigureOptions(IServiceCollection, Type)	
���ׂĂ� I[Post]ConfigureOptions ���o�^�����^��o�^���܂��B

ConfigureOptions<TConfigureOptions>(IServiceCollection)	
���ׂĂ� I[Post]ConfigureOptions ���o�^�����^��o�^���܂��B

PostConfigure<TOptions>(IServiceCollection, Action<TOptions>)	
����̎�ނ̃I�v�V���������������邽�߂Ɏg�p����A�N�V������o�^���܂��B ������ Configure<TOptions>(IServiceCollection, Action<TOptions>)��Ɏ��s����܂��B

PostConfigure<TOptions>(IServiceCollection, String, Action<TOptions>)	
����̎�ނ̃I�v�V�������\�����邽�߂Ɏg�p����A�N�V������o�^���܂��B ������ Configure<TOptions>(IServiceCollection, Action<TOptions>)��Ɏ��s����܂��B

PostConfigureAll<TOptions>(IServiceCollection, Action<TOptions>)	
����̎�ނ̃I�v�V�����̂��ׂẴC���X�^���X���\��������Ɏg�p����A�N�V������o�^���܂��B ������ Configure<TOptions>(IServiceCollection, Action<TOptions>)��Ɏ��s����܂��B

AddProcessLogEnricher(IServiceCollection)	
�v���Z�X �G�����b�`���[�̃C���X�^���X�� IServiceCollection�ɒǉ����܂��B

AddProcessLogEnricher(IServiceCollection, IConfigurationSection)	
�z�X�g �G�����b�`���[�̃C���X�^���X�� IServiceCollection�ɒǉ����܂��B

AddProcessLogEnricher(IServiceCollection, Action<ProcessLogEnricherOptions>)	
�v���Z�X �G�����b�`���[�̃C���X�^���X�� IServiceCollection�ɒǉ����܂��B

AddRedaction(IServiceCollection)	
IServiceCollection�� IRedactorProvider �̎�����o�^���܂��B

AddRedaction(IServiceCollection, Action<IRedactionBuilder>)	
IServiceCollection �� IRedactorProvider �̎�����o�^���A�g�p�\�ȕҏW�@�\���\�����܂��B

AddResilienceEnricher(IServiceCollection)	
�񕜐��G�����b�`���[��ǉ����܂��B

AddResourceMonitoring(IServiceCollection)	
IResourceMonitor �������\�����A�T�[�r�X �R���N�V�����ɒǉ����܂��B

AddResourceMonitoring(IServiceCollection, Action<IResourceMonitorBuilder>)	
IResourceMonitor �������\�����A�T�[�r�X �R���N�V�����ɒǉ����܂��B

BuildServiceProvider(IServiceCollection)	
�w�肳�ꂽ IServiceCollection����T�[�r�X���܂� ServiceProvider ���쐬���܂��B

BuildServiceProvider(IServiceCollection, ServiceProviderOptions)	
�w�肳�ꂽ IServiceCollection ����T�[�r�X���܂� ServiceProvider ���쐬���A�K�v�ɉ����ăT�[�r�X�̍쐬�ƃX�R�[�v�̌��؂�L���ɂ��܂��B

BuildServiceProvider(IServiceCollection, Boolean)	
�w�肵�� IServiceCollection ����T�[�r�X���܂� ServiceProvider ���쐬���A�K�v�ɉ����ăX�R�[�v�̌��؂�L���ɂ��܂��B

AddHostedService<THostedService>(IServiceCollection)	
�w�肵���^�� IHostedService �o�^��ǉ����܂��B

AddHostedService<THostedService>(IServiceCollection, Func<IServiceProvider,THostedService>)	
�w�肵���^�� IHostedService �o�^��ǉ����܂��B

AddKeyedScoped(IServiceCollection, Type, Object)	
�w�肵�� IServiceCollection�ɁAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddKeyedScoped(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped(IServiceCollection, Type, Object, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped<TService>(IServiceCollection, Object)	
�w�肵�� IServiceCollection�ɁATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddKeyedScoped<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped<TService,TImplementation>(IServiceCollection, Object)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedScoped<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^�����ATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object)	
serviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object, Object)	
implementationInstance �Ŏw�肳�ꂽ�C���X�^���X������ serviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton(IServiceCollection, Type, Object, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService>(IServiceCollection, Object)	
TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService>(IServiceCollection, Object, TService)	
implementationInstance �Ŏw�肳�ꂽ�C���X�^���X������ TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService,TImplementation>(IServiceCollection, Object)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedSingleton<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^�����ATService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient(IServiceCollection, Type, Object)	
�w�肵�� IServiceCollection�ɁAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X��ǉ����܂��B

AddKeyedTransient(IServiceCollection, Type, Object, Func<IServiceProvider,Object,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient(IServiceCollection, Type, Object, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient<TService>(IServiceCollection, Object)	
�w�肵�� IServiceCollection�ɁATService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X��ǉ����܂��B

AddKeyedTransient<TService>(IServiceCollection, Object, Func<IServiceProvider,Object,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient<TService,TImplementation>(IServiceCollection, Object)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddKeyedTransient<TService,TImplementation>(IServiceCollection, Object, Func<IServiceProvider,Object,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped(IServiceCollection, Type)	
�w�肵�� IServiceCollection�ɁAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddScoped(IServiceCollection, Type, Func<IServiceProvider,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped(IServiceCollection, Type, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped<TService>(IServiceCollection)	
�w�肵�� IServiceCollection�ɁATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X��ǉ����܂��B

AddScoped<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped<TService,TImplementation>(IServiceCollection)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddScoped<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^�����ATService �Ŏw�肳�ꂽ�^�̃X�R�[�v�T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton(IServiceCollection, Type)	
serviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton(IServiceCollection, Type, Func<IServiceProvider,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton(IServiceCollection, Type, Object)	
implementationInstance �Ŏw�肳�ꂽ�C���X�^���X������ serviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton(IServiceCollection, Type, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton<TService>(IServiceCollection)	
TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton<TService>(IServiceCollection, TService)	
implementationInstance �Ŏw�肳�ꂽ�C���X�^���X������ TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton<TService,TImplementation>(IServiceCollection)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddSingleton<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^�����ATService �Ŏw�肳�ꂽ�^�̃V���O���g�� �T�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddTransient(IServiceCollection, Type)	
�w�肵�� IServiceCollection�ɁAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X��ǉ����܂��B

AddTransient(IServiceCollection, Type, Func<IServiceProvider,Object>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddTransient(IServiceCollection, Type, Type)	
implementationType �Ŏw�肳�ꂽ�^�̎������g�p���āAserviceType �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddTransient<TService>(IServiceCollection)	
�w�肵�� IServiceCollection�ɁATService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X��ǉ����܂��B

AddTransient<TService>(IServiceCollection, Func<IServiceProvider,TService>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddTransient<TService,TImplementation>(IServiceCollection)	
TImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddTransient<TService,TImplementation>(IServiceCollection, Func<IServiceProvider,TImplementation>)	
implementationFactory �Ŏw�肳�ꂽ�t�@�N�g�����g�p���āATImplementation �Ŏw�肳�ꂽ�����^������ TService �Ŏw�肳�ꂽ�^�̈ꎞ�I�ȃT�[�r�X���A�w�肵�� IServiceCollection�ɒǉ����܂��B

AddDistributedSqlServerCache(IServiceCollection, Action<SqlServerCacheOptions>)	
�w�肵�� IServiceCollection�� Microsoft SQL Server ���U�L���b�V�� �T�[�r�X��ǉ����܂��B

AddStackExchangeRedisCache(IServiceCollection, Action<RedisCacheOptions>)	
�w�肵�� IServiceCollection�� Redis ���U�L���b�V�� �T�[�r�X��ǉ����܂��B

AddTcpEndpointProbe(IServiceCollection)	
�T�[�r�X������� IHealthCheck�ƌ��Ȃ����ꍇ�ATCP �|�[�g���g�p���Đ��퐫��ԃ��|�[�g��o�^���܂��B

AddTcpEndpointProbe(IServiceCollection, IConfigurationSection)	
�T�[�r�X������� IHealthCheck�ƌ��Ȃ����ꍇ�ATCP �|�[�g���g�p���Đ��퐫��ԃ��|�[�g��o�^���܂��B

AddTcpEndpointProbe(IServiceCollection, Action<TcpEndpointProbesOptions>)	
�T�[�r�X������� IHealthCheck�ƌ��Ȃ����ꍇ�ATCP �|�[�g���g�p���Đ��퐫��ԃ��|�[�g��o�^���܂��B

AddTcpEndpointProbe(IServiceCollection, String)	
�T�[�r�X������� IHealthCheck�ƌ��Ȃ����ꍇ�ATCP �|�[�g���g�p���Đ��퐫��ԃ��|�[�g��o�^���܂��B

AddTcpEndpointProbe(IServiceCollection, String, IConfigurationSection)	
�T�[�r�X������� IHealthCheck�ƌ��Ȃ����ꍇ�ATCP �|�[�g���g�p���Đ��퐫��ԃ��|�[�g��o�^���܂��B

AddTcpEndpointProbe(IServiceCollection, String, Action<TcpEndpointProbesOptions>)	
�T�[�r�X������� IHealthCheck�ƌ��Ȃ����ꍇ�ATCP �|�[�g���g�p���Đ��퐫��ԃ��|�[�g��o�^���܂��B

AddSystemd(IServiceCollection)	
services ���� SystemdLifetime�Ƀr���h���ꂽ IHost �̗L�����Ԃ��\�����A�A�v���P�[�V�����̋N���ƒ�~�̒ʒm���b�Z�[�W��񋟂��A�V�X�e���`���ɃR���\�[�� ���O���\�����܂��B

AddWindowsService(IServiceCollection)	
services ���� WindowsServiceLifetime �Ƀr���h���ꂽ IHost �̗L�����Ԃ��\�����A�A�v���P�[�V������������̃\�[�X���Ƃ��Ďg�p���ăC�x���g ���O�Ƀ��O���L�^�ł���悤�ɂ��܂��B

AddWindowsService(IServiceCollection, Action<WindowsServiceLifetimeOptions>)	
services ���� WindowsServiceLifetime �Ƀr���h���ꂽ IHost �̗L�����Ԃ��\�����A�A�v���P�[�V������������̃\�[�X���Ƃ��Ďg�p���ăC�x���g ���O�Ƀ��O���L�^�ł���悤�ɂ��܂��B

*/

#endregion