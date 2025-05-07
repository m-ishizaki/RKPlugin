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

/*
AddServiceLogEnricher(IServiceCollection)
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

ToFrozenDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� FrozenDictionary<TKey,TValue> ���쐬���܂��B

ToFrozenDictionary<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[����їv�f�Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� FrozenDictionary<TKey,TValue> ���쐬���܂��B

ToFrozenSet<T>(IEnumerable<T>, IEqualityComparer<T>)	
�w�肵���l���g�p���� FrozenSet<T> ���쐬���܂��B

AsReadOnly<T>(IList<T>)	
�w�肵�����X�g�̓ǂݎ���p ReadOnlyCollection<T> ���b�p�[��Ԃ��܂��B

ToImmutableArray<TSource>(IEnumerable<TSource>)	
�w�肵���R���N�V��������ύX�ł��Ȃ��z����쐬���܂��B

ToImmutableDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�ϊ��֐����\�[�X �L�[�ɓK�p���āA�v�f�̊����̃R���N�V��������ύX�ł��Ȃ��f�B�N�V���i�����\�z���܂��B

ToImmutableDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�V�[�P���X�̕ϊ��Ɋ�Â��āA�ύX�ł��Ȃ��f�B�N�V���i�����\�z���܂��B

ToImmutableDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>)	
�V�[�P���X��񋓂��ĕϊ����A���̓��e�̕ύX�ł��Ȃ��f�B�N�V���i���𐶐����܂��B

ToImmutableDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IEqualityComparer<TKey>)	
�V�[�P���X��񋓂��ĕϊ����A�w�肵���L�[��r�q���g�p���Ă��̓��e�̕ύX�ł��Ȃ��f�B�N�V���i���𐶐����܂��B

ToImmutableDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IEqualityComparer<TKey>, IEqualityComparer<TValue>)	
�V�[�P���X��񋓂��ĕϊ����A�w�肵���L�[�ƒl�̔�r�q���g�p���Ă��̓��e�̕ύX�ł��Ȃ��f�B�N�V���i���𐶐����܂��B

ToImmutableHashSet<TSource>(IEnumerable<TSource>)	
�V�[�P���X��񋓂��A���̓��e�̕ύX�ł��Ȃ��n�b�V�� �Z�b�g�𐶐����܂��B

ToImmutableHashSet<TSource>(IEnumerable<TSource>, IEqualityComparer<TSource>)	
�V�[�P���X��񋓂��A���̓��e�̕ύX�ł��Ȃ��n�b�V�� �Z�b�g�𐶐����A�Z�b�g�^�ɑ΂��Ďw�肳�ꂽ���l��r�q���g�p���܂��B

ToImmutableList<TSource>(IEnumerable<TSource>)	
�V�[�P���X��񋓂��A���̓��e�̕ύX�ł��Ȃ����X�g�𐶐����܂��B

ToImmutableSortedDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>)	
�V�[�P���X��񋓂��ĕϊ����A���̓��e�̕ύX�ł��Ȃ����בւ���ꂽ�f�B�N�V���i���𐶐����܂��B

ToImmutableSortedDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IComparer<TKey>)	
�V�[�P���X��񋓂��ĕϊ����A�w�肵���L�[��r�q���g�p���āA���̓��e�̕ύX�ł��Ȃ����בւ���ꂽ�f�B�N�V���i���𐶐����܂��B

ToImmutableSortedDictionary<TSource,TKey,TValue>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TValue>, IComparer<TKey>, IEqualityComparer<TValue>)	
�V�[�P���X��񋓂��ĕϊ����A�w�肵���L�[�ƒl�̔�r�q���g�p���āA���̓��e�̕ύX�ł��Ȃ����בւ���ꂽ�f�B�N�V���i���𐶐����܂��B

ToImmutableSortedSet<TSource>(IEnumerable<TSource>)	
�V�[�P���X��񋓂��A���̓��e�̕ύX�ł��Ȃ����בւ���ꂽ�Z�b�g�𐶐����܂��B

ToImmutableSortedSet<TSource>(IEnumerable<TSource>, IComparer<TSource>)	
�V�[�P���X��񋓂��A���̓��e�̕ύX�ł��Ȃ����בւ���ꂽ�Z�b�g�𐶐����A�w�肳�ꂽ��r�q���g�p���܂��B

CopyToDataTable<T>(IEnumerable<T>)	
�W�F�l���b�N �p�����[�^�[ T �� DataRow����Ă������ IEnumerable<T> �I�u�W�F�N�g���w�肵�āADataRow �I�u�W�F�N�g�̃R�s�[���i�[���� DataTable ��Ԃ��܂��B

CopyToDataTable<T>(IEnumerable<T>, DataTable, LoadOption)	
�W�F�l���b�N �p�����[�^�[ T �� DataRow����Ă������ IEnumerable<T> �I�u�W�F�N�g���w�肳�ꂽ DataTable�� DataRow �I�u�W�F�N�g���R�s�[���܂��B

CopyToDataTable<T>(IEnumerable<T>, DataTable, LoadOption, FillErrorEventHandler)	
�W�F�l���b�N �p�����[�^�[ T �� DataRow����Ă������ IEnumerable<T> �I�u�W�F�N�g���w�肳�ꂽ DataTable�� DataRow �I�u�W�F�N�g���R�s�[���܂��B

Aggregate<TSource>(IEnumerable<TSource>, Func<TSource,TSource,TSource>)	
�A�L�������[�^�֐����V�[�P���X�ɓK�p���܂��B

Aggregate<TSource,TAccumulate>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate,TSource,TAccumulate>)	
�A�L�������[�^�֐����V�[�P���X�ɓK�p���܂��B �w�肳�ꂽ�V�[�h�l�́A�����A�L�������[�^�l�Ƃ��Ďg�p����܂��B

Aggregate<TSource,TAccumulate,TResult>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate,TSource,TAccumulate>, Func<TAccumulate,TResult>)	
�A�L�������[�^�֐����V�[�P���X�ɓK�p���܂��B �w�肵���V�[�h�l�������A�L�������[�^�l�Ƃ��Ďg�p����A�w�肳�ꂽ�֐����g�p���Č��ʒl���I������܂��B

All<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�V�[�P���X�̂��ׂĂ̗v�f�������𖞂������ǂ����𔻒f���܂��B

Any<TSource>(IEnumerable<TSource>)	
�V�[�P���X�ɗv�f���܂܂�Ă��邩�ǂ����𔻒f���܂��B

Any<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�V�[�P���X�̗v�f�������𖞂������ǂ����𔻒f���܂��B

Append<TSource>(IEnumerable<TSource>, TSource)	
�V�[�P���X�̖����ɒl��ǉ����܂��B

AsEnumerable<TSource>(IEnumerable<TSource>)	
IEnumerable<T>�Ƃ��ē��͂��ꂽ���͂�Ԃ��܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Decimal �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Double �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Int32 �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Int64 �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Decimal �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Double �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Int32 �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Int64 �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Single �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Average<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Single �l�̃V�[�P���X�̕��ς��v�Z���܂��B

Cast<TResult>(IEnumerable)	
IEnumerable �̗v�f���w�肵���^�ɃL���X�g���܂��B

Chunk<TSource>(IEnumerable<TSource>, Int32)	
�V�[�P���X�̗v�f���ő� size�T�C�Y�̃`�����N�ɕ������܂��B

Concat<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
2 �̃V�[�P���X��A�����܂��B

Contains<TSource>(IEnumerable<TSource>, TSource)	
����̓��l��r�q���g�p���āA�V�[�P���X�Ɏw�肵���v�f���܂܂�Ă��邩�ǂ����𔻒f���܂��B

Contains<TSource>(IEnumerable<TSource>, TSource, IEqualityComparer<TSource>)	
�w�肵�� IEqualityComparer<T>���g�p���āA�V�[�P���X�Ɏw�肵���v�f���܂܂�Ă��邩�ǂ����𔻒f���܂��B

Count<TSource>(IEnumerable<TSource>)	
�V�[�P���X���̗v�f�̐���Ԃ��܂��B

Count<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�w�肵���V�[�P���X���� 1 �̏����𖞂����v�f�̐���\�����l��Ԃ��܂��B

DefaultIfEmpty<TSource>(IEnumerable<TSource>)	
�V�[�P���X����̏ꍇ�́A�w�肵���V�[�P���X�̗v�f�A�܂��̓V���O���g�� �R���N�V�������̌^�p�����[�^�[�̊���l��Ԃ��܂��B

DefaultIfEmpty<TSource>(IEnumerable<TSource>, TSource)	
�V�[�P���X����̏ꍇ�́A�w�肵���V�[�P���X�̗v�f�A�܂��̓V���O���g�� �R���N�V�������̎w�肵���l��Ԃ��܂��B

Distinct<TSource>(IEnumerable<TSource>)	
����̓��l��r�q���g�p���Ēl���r���邱�Ƃɂ��A�V�[�P���X����ʂ̗v�f��Ԃ��܂��B

Distinct<TSource>(IEnumerable<TSource>, IEqualityComparer<TSource>)	
�w�肵�� IEqualityComparer<T> ���g�p���Ēl���r���邱�Ƃɂ��A�V�[�P���X����ʂ̗v�f��Ԃ��܂��B

DistinctBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āA�V�[�P���X����ʂ̗v�f��Ԃ��܂��B

DistinctBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X����ʂ̗v�f��Ԃ��A�w�肵����r�q���g�p���ăL�[���r���܂��B

ElementAt<TSource>(IEnumerable<TSource>, Index)	
�V�[�P���X���̎w�肵���C���f�b�N�X�ʒu�ɂ���v�f��Ԃ��܂��B

ElementAt<TSource>(IEnumerable<TSource>, Int32)	
�V�[�P���X���̎w�肵���C���f�b�N�X�ʒu�ɂ���v�f��Ԃ��܂��B

ElementAtOrDefault<TSource>(IEnumerable<TSource>, Index)	
�V�[�P���X���̎w�肵���C���f�b�N�X�ʒu�ɂ���v�f��Ԃ��܂��B�C���f�b�N�X���͈͊O�̏ꍇ�͊���l��Ԃ��܂��B

ElementAtOrDefault<TSource>(IEnumerable<TSource>, Int32)	
�V�[�P���X���̎w�肵���C���f�b�N�X�ʒu�ɂ���v�f��Ԃ��܂��B�C���f�b�N�X���͈͊O�̏ꍇ�͊���l��Ԃ��܂��B

Except<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
����̓��l��r�q���g�p���Ēl���r���邱�Ƃɂ��A2 �̃V�[�P���X�̃Z�b�g���𐶐����܂��B

Except<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
�w�肵�� IEqualityComparer<T> ���g�p���Ēl���r���邱�Ƃɂ��A2 �̃V�[�P���X�̃Z�b�g���𐶐����܂��B

ExceptBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>)	
�w�肳�ꂽ�L�[ �Z���N�^�[�֐��ɏ]���āA2 �̃V�[�P���X�̃Z�b�g���𐶐����܂��B

ExceptBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肳�ꂽ�L�[ �Z���N�^�[�֐��ɏ]���āA2 �̃V�[�P���X�̃Z�b�g���𐶐����܂��B

First<TSource>(IEnumerable<TSource>)	
�V�[�P���X�̍ŏ��̗v�f��Ԃ��܂��B

First<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�w�肵�������𖞂����V�[�P���X���̍ŏ��̗v�f��Ԃ��܂��B

FirstOrDefault<TSource>(IEnumerable<TSource>)	
�V�[�P���X�̍ŏ��̗v�f��Ԃ��܂��B�V�[�P���X�ɗv�f���܂܂�Ă���ꍇ�͊���l��Ԃ��܂��B

FirstOrDefault<TSource>(IEnumerable<TSource>, TSource)	
�V�[�P���X�̍ŏ��̗v�f��Ԃ��܂��B�V�[�P���X�ɗv�f���܂܂�Ă���ꍇ�́A�w�肵������l��Ԃ��܂��B

FirstOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�����𖞂����V�[�P���X�̍ŏ��̗v�f�A�܂��͂��̂悤�ȗv�f��������Ȃ��ꍇ�͊���l��Ԃ��܂��B

FirstOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
�����𖞂����V�[�P���X�̍ŏ��̗v�f��Ԃ��܂��B���̂悤�ȗv�f��������Ȃ��ꍇ�́A�w�肵������l��Ԃ��܂��B

GroupBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����܂��B

GroupBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����A�w�肵����r�q���g�p���ăL�[���r���܂��B

GroupBy<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����A�w�肵���֐����g�p���Ċe�O���[�v�̗v�f�𓊉e���܂��B

GroupBy<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
�L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����܂��B �L�[�͔�r�q���g�p���Ĕ�r����A�e�O���[�v�̗v�f�͎w�肳�ꂽ�֐����g�p���ē��e����܂��B

GroupBy<TSource,TKey,TResult>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TKey,IEnumerable<TSource>,TResult>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����A�e�O���[�v�Ƃ��̃L�[���猋�ʒl���쐬���܂��B

GroupBy<TSource,TKey,TResult>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TKey,IEnumerable<TSource>,TResult>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����A�e�O���[�v�Ƃ��̃L�[���猋�ʒl���쐬���܂��B �L�[�́A�w�肳�ꂽ��r�q���g�p���Ĕ�r����܂��B

GroupBy<TSource,TKey,TElement,TResult>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, Func<TKey,IEnumerable<TElement>,TResult>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����A�e�O���[�v�Ƃ��̃L�[���猋�ʒl���쐬���܂��B �e�O���[�v�̗v�f�́A�w�肳�ꂽ�֐����g�p���ē��e����܂��B

GroupBy<TSource,TKey,TElement,TResult>(IEnumerable<TSource>, Func<TSource, TKey>, Func<TSource,TElement>, Func<TKey,IEnumerable<TElement>, TResult>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���ăV�[�P���X�̗v�f���O���[�v�����A�e�O���[�v�Ƃ��̃L�[���猋�ʒl���쐬���܂��B �L�[�l�͎w�肳�ꂽ��r�q���g�p���Ĕ�r����A�e�O���[�v�̗v�f�͎w�肳�ꂽ�֐����g�p���ē��e����܂��B

GroupJoin<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,IEnumerable<TInner>, TResult>)	
�L�[�̓������Ɋ�Â��� 2 �̃V�[�P���X�̗v�f���֘A�t���A���ʂ��O���[�v�����܂��B �L�[�̔�r�ɂ́A����̓��l��r�q���g�p����܂��B

GroupJoin<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,IEnumerable<TInner>, TResult>, IEqualityComparer<TKey>)	
�L�[�̓������Ɋ�Â��� 2 �̃V�[�P���X�̗v�f���֘A�t���A���ʂ��O���[�v�����܂��B �L�[�̔�r�ɂ́A�w�肵�� IEqualityComparer<T> ���g�p����܂��B

Intersect<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
����̓��l��r�q���g�p���Ēl���r���邱�Ƃɂ��A2 �̃V�[�P���X�̏W���ϏW���𐶐����܂��B

Intersect<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
�w�肵�� IEqualityComparer<T> ���g�p���Ēl���r���邱�Ƃɂ��A2 �̃V�[�P���X�̏W���ϏW���𐶐����܂��B

IntersectBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āA2 �̃V�[�P���X�̏W���ϏW���𐶐����܂��B

IntersectBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TKey>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āA2 �̃V�[�P���X�̏W���ϏW���𐶐����܂��B

Join<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,TInner,TResult>)	
��v����L�[�Ɋ�Â��āA2 �̃V�[�P���X�̗v�f���֘A�t���܂��B �L�[�̔�r�ɂ́A����̓��l��r�q���g�p����܂��B

Join<TOuter,TInner,TKey,TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter,TKey>, Func<TInner,TKey>, Func<TOuter,TInner,TResult>, IEqualityComparer<TKey>)	
��v����L�[�Ɋ�Â��āA2 �̃V�[�P���X�̗v�f���֘A�t���܂��B �L�[�̔�r�ɂ́A�w�肵�� IEqualityComparer<T> ���g�p����܂��B

Last<TSource>(IEnumerable<TSource>)	
�V�[�P���X�̍Ō�̗v�f��Ԃ��܂��B

Last<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�w�肵�������𖞂����V�[�P���X�̍Ō�̗v�f��Ԃ��܂��B

LastOrDefault<TSource>(IEnumerable<TSource>)	
�V�[�P���X�̍Ō�̗v�f��Ԃ��܂��B�V�[�P���X�ɗv�f���܂܂�Ă���ꍇ�͊���l��Ԃ��܂��B

LastOrDefault<TSource>(IEnumerable<TSource>, TSource)	
�V�[�P���X�̍Ō�̗v�f��Ԃ��܂��B�V�[�P���X�ɗv�f���܂܂�Ă���ꍇ�́A�w�肵������l��Ԃ��܂��B

LastOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�����𖞂����V�[�P���X�̍Ō�̗v�f�A�܂��͂��̂悤�ȗv�f��������Ȃ��ꍇ�͊���l��Ԃ��܂��B

LastOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
�����𖞂����V�[�P���X�̍Ō�̗v�f��Ԃ��܂��B���̂悤�ȗv�f��������Ȃ��ꍇ�́A�w�肳�ꂽ����l��Ԃ��܂��B

LongCount<TSource>(IEnumerable<TSource>)	
�V�[�P���X���̗v�f�̍��v����\�� Int64 ��Ԃ��܂��B

LongCount<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�����𖞂����V�[�P���X���̗v�f�̐���\�� Int64 ��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>)	
�W�F�l���b�N �V�[�P���X�̍ő�l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, IComparer<TSource>)	
�W�F�l���b�N �V�[�P���X�̍ő�l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ő� Decimal �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ő� Double �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ő� Int32 �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ő� Int64 �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ő� Decimal �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ő� Double �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ő� Int32 �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ő� Int64 �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ő� Single �l��Ԃ��܂��B

Max<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ő� Single �l��Ԃ��܂��B

Max<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)	
�W�F�l���b�N �V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A���ʂ̍ő�l��Ԃ��܂��B

MaxBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āA�W�F�l���b�N �V�[�P���X�̍ő�l��Ԃ��܂��B

MaxBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ƃL�[��r�q�ɏ]���āA�W�F�l���b�N �V�[�P���X�̍ő�l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>)	
�W�F�l���b�N �V�[�P���X�̍ŏ��l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, IComparer<TSource>)	
�W�F�l���b�N �V�[�P���X�̍ŏ��l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ŏ� Decimal �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ŏ� Double �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ŏ� Int32 �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ŏ� Int64 �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ŏ� Decimal �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ŏ� Double �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ŏ� Int32 �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ŏ� Int64 �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���Anull ���e�̍ŏ� Single �l��Ԃ��܂��B

Min<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
�V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A�ŏ� Single �l��Ԃ��܂��B

Min<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)	
�W�F�l���b�N �V�[�P���X�̊e�v�f�ɑ΂��ĕϊ��֐����Ăяo���A���ʂ̍ŏ��l��Ԃ��܂��B

MinBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āA�W�F�l���b�N �V�[�P���X�̍ŏ��l��Ԃ��܂��B

MinBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ƃL�[��r�q�ɏ]���āA�W�F�l���b�N �V�[�P���X�̍ŏ��l��Ԃ��܂��B

OfType<TResult>(IEnumerable)	
�w�肵���^�Ɋ�Â��āAIEnumerable �̗v�f���t�B���^�[�������܂��B

Order<T>(IEnumerable<T>)	
�V�[�P���X�̗v�f�������ŕ��בւ��܂��B

Order<T>(IEnumerable<T>, IComparer<T>)	
�V�[�P���X�̗v�f�������ŕ��בւ��܂��B

OrderBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�L�[�ɏ]���āA�V�[�P���X�̗v�f�������ŕ��בւ��܂��B

OrderBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
�w�肵����r�q���g�p���āA�V�[�P���X�̗v�f�������ŕ��בւ��܂��B

OrderByDescending<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�L�[�ɏ]���ăV�[�P���X�̗v�f���~���ɕ��בւ��܂��B

OrderByDescending<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)	
�w�肵����r�q���g�p���āA�V�[�P���X�̗v�f���~���ŕ��בւ��܂��B

OrderDescending<T>(IEnumerable<T>)	
�V�[�P���X�̗v�f���~���ŕ��בւ��܂��B

OrderDescending<T>(IEnumerable<T>, IComparer<T>)	
�V�[�P���X�̗v�f���~���ŕ��בւ��܂��B

Prepend<TSource>(IEnumerable<TSource>, TSource)	
�V�[�P���X�̐擪�ɒl��ǉ����܂��B

Reverse<TSource>(IEnumerable<TSource>)	
�V�[�P���X���̗v�f�̏����𔽓]���܂��B

Select<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)	
�V�[�P���X�̊e�v�f��V�����t�H�[���ɓ��e���܂��B

Select<TSource,TResult>(IEnumerable<TSource>, Func<TSource,Int32,TResult>)	
�v�f�̃C���f�b�N�X��g�ݍ���ŁA�V�[�P���X�̊e�v�f��V�����t�H�[���ɓ��e���܂��B

SelectMany<TSource,TResult>(IEnumerable<TSource>, Func<TSource,IEnumerable<TResult>>)	
�V�[�P���X�̊e�v�f�� IEnumerable<T> �ɓ��e���A���ʂ̃V�[�P���X�� 1 �̃V�[�P���X�Ƀt���b�g�����܂��B

SelectMany<TSource,TResult>(IEnumerable<TSource>, Func<TSource,Int32,IEnumerable<TResult>>)	
�V�[�P���X�̊e�v�f�� IEnumerable<T>�ɓ��e���A���ʂ̃V�[�P���X�� 1 �̃V�[�P���X�Ƀt���b�g�����܂��B �e�\�[�X�v�f�̃C���f�b�N�X�́A���̗v�f�̓��e�`���Ŏg�p����܂��B

SelectMany<TSource,TCollection,TResult>(IEnumerable<TSource>, Func<TSource,IEnumerable<TCollection>>, Func<TSource,TCollection,TResult>)	
�V�[�P���X�̊e�v�f�� IEnumerable<T>�ɓ��e���A���ʂ̃V�[�P���X�� 1 �̃V�[�P���X�Ƀt���b�g�����A���̒��̊e�v�f�ɑ΂��Č��ʃZ���N�^�[�֐����Ăяo���܂��B

SelectMany<TSource,TCollection,TResult>(IEnumerable<TSource>, Func<TSource,Int32,IEnumerable<TCollection>>, Func<TSource,TCollection,TResult>)	
�V�[�P���X�̊e�v�f�� IEnumerable<T>�ɓ��e���A���ʂ̃V�[�P���X�� 1 �̃V�[�P���X�Ƀt���b�g�����A���̒��̊e�v�f�ɑ΂��Č��ʃZ���N�^�[�֐����Ăяo���܂��B �e�\�[�X�v�f�̃C���f�b�N�X�́A���̗v�f�̒��ԓ��e�`���Ŏg�p����܂��B

SequenceEqual<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
�^�̊���̓��l��r�q���g�p���ėv�f���r���邱�ƂŁA2 �̃V�[�P���X�����������ǂ����𔻒f���܂��B

SequenceEqual<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
�w�肵�� IEqualityComparer<T>���g�p���ėv�f���r���āA2 �̃V�[�P���X�����������ǂ����𔻒f���܂��B

Single<TSource>(IEnumerable<TSource>)	
�V�[�P���X�̗B��̗v�f��Ԃ��A�V�[�P���X���ɗv�f�� 1 �������݂��Ȃ��ꍇ�͗�O���X���[���܂��B

Single<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�w�肵�������𖞂����V�[�P���X�̗B��̗v�f��Ԃ��A���̂悤�ȗv�f���������݂���ꍇ�͗�O���X���[���܂��B

SingleOrDefault<TSource>(IEnumerable<TSource>)	
�V�[�P���X�̗B��̗v�f��Ԃ��܂��B�V�[�P���X����̏ꍇ�͊���l��Ԃ��܂��B�V�[�P���X���ɕ����̗v�f������ꍇ�A���̃��\�b�h�͗�O���X���[���܂��B

SingleOrDefault<TSource>(IEnumerable<TSource>, TSource)	
�V�[�P���X�̗B��̗v�f��Ԃ��܂��B�V�[�P���X����̏ꍇ�́A�w�肵������l��Ԃ��܂��B�V�[�P���X���ɕ����̗v�f������ꍇ�A���̃��\�b�h�͗�O���X���[���܂��B

SingleOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�w�肵�������𖞂����V�[�P���X�̗B��̗v�f�A�܂��͂��̂悤�ȗv�f�����݂��Ȃ��ꍇ�͊���l��Ԃ��܂��B���̃��\�b�h�́A�����̗v�f�������𖞂����ꍇ�ɗ�O���X���[���܂��B

SingleOrDefault<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>, TSource)	
�w�肵�������𖞂����V�[�P���X�̗B��̗v�f�A�܂��͂��̂悤�ȗv�f�����݂��Ȃ��ꍇ�͎w�肳�ꂽ����l��Ԃ��܂��B���̃��\�b�h�́A�����̗v�f�������𖞂����ꍇ�ɗ�O���X���[���܂��B

Skip<TSource>(IEnumerable<TSource>, Int32)	
�V�[�P���X���̎w�肳�ꂽ���̗v�f���o�C�p�X���A�c��̗v�f��Ԃ��܂��B

SkipLast<TSource>(IEnumerable<TSource>, Int32)	
�\�[�X �R���N�V�����̍Ō�� count �v�f���ȗ����� source �̗v�f���܂ސV�����񋓉\�ȃR���N�V������Ԃ��܂��B

SkipWhile<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�w�肵�������� true �ł������A�V�[�P���X���̗v�f���o�C�p�X���A�c��̗v�f��Ԃ��܂��B

SkipWhile<TSource>(IEnumerable<TSource>, Func<TSource,Int32,Boolean>)	
�w�肵�������� true �ł������A�V�[�P���X���̗v�f���o�C�p�X���A�c��̗v�f��Ԃ��܂��B �v�f�̃C���f�b�N�X�́A�q��֐��̃��W�b�N�Ŏg�p����܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Decimal �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Double>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Double �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Int32 �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Int64 �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Decimal �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Double �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Int32 �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Int64 �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� null ���e Single �l�̃V�[�P���X�̍��v���v�Z���܂��B

Sum<TSource>(IEnumerable<TSource>, Func<TSource,Single>)	
���̓V�[�P���X�̊e�v�f�ŕϊ��֐����Ăяo�����Ƃɂ���Ď擾����� Single �l�̃V�[�P���X�̍��v���v�Z���܂��B

Take<TSource>(IEnumerable<TSource>, Int32)	
�V�[�P���X�̐擪����w�肵�����̘A������v�f��Ԃ��܂��B

Take<TSource>(IEnumerable<TSource>, Range)	
�V�[�P���X����w�肵���A������v�f�͈̔͂�Ԃ��܂��B

TakeLast<TSource>(IEnumerable<TSource>, Int32)	
source�̍Ō�� count �v�f���܂ސV�����񋓉\�ȃR���N�V������Ԃ��܂��B

TakeWhile<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�w�肵�������� true �ł������A�V�[�P���X����v�f��Ԃ��܂��B

TakeWhile<TSource>(IEnumerable<TSource>, Func<TSource,Int32,Boolean>)	
�w�肵�������� true �ł������A�V�[�P���X����v�f��Ԃ��܂��B �v�f�̃C���f�b�N�X�́A�q��֐��̃��W�b�N�Ŏg�p����܂��B

ToArray<TSource>(IEnumerable<TSource>)	
IEnumerable<T>����z����쐬���܂��B

ToDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� Dictionary<TKey,TValue> ���쐬���܂��B

ToDictionary<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ƃL�[��r�q�ɏ]���āAIEnumerable<T> ���� Dictionary<TKey,TValue> ���쐬���܂��B

ToDictionary<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>)	
�w�肵���L�[ �Z���N�^�[����їv�f�Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� Dictionary<TKey,TValue> ���쐬���܂��B

ToDictionary<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��A��r�q�A����їv�f�Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� Dictionary<TKey,TValue> ���쐬���܂��B

ToHashSet<TSource>(IEnumerable<TSource>)	
IEnumerable<T>���� HashSet<T> ���쐬���܂��B

ToHashSet<TSource>(IEnumerable<TSource>, IEqualityComparer<TSource>)	
�L�[���r���� comparer ���g�p���āAIEnumerable<T> ���� HashSet<T> ���쐬���܂��B

ToList<TSource>(IEnumerable<TSource>)	
IEnumerable<T>���� List<T> ���쐬���܂��B

ToLookup<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� Lookup<TKey,TElement> ���쐬���܂��B

ToLookup<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ƃL�[��r�q�ɏ]���āAIEnumerable<T> ���� Lookup<TKey,TElement> ���쐬���܂��B

ToLookup<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>)	
�w�肵���L�[ �Z���N�^�[����їv�f�Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� Lookup<TKey,TElement> ���쐬���܂��B

ToLookup<TSource,TKey,TElement>(IEnumerable<TSource>, Func<TSource,TKey>, Func<TSource,TElement>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��A��r�q�A����їv�f�Z���N�^�[�֐��ɏ]���āAIEnumerable<T> ���� Lookup<TKey,TElement> ���쐬���܂��B

TryGetNonEnumeratedCount<TSource>(IEnumerable<TSource>, Int32)	
�񋓂����������ɁA�V�[�P���X���̗v�f�̐�����肵�悤�Ƃ��܂��B

Union<TSource>(IEnumerable<TSource>, IEnumerable<TSource>)	
����̓��l��r�q���g�p���āA2 �̃V�[�P���X�̃Z�b�g�a�W���𐶐����܂��B

Union<TSource>(IEnumerable<TSource>, IEnumerable<TSource>, IEqualityComparer<TSource>)	
�w�肵�� IEqualityComparer<T>���g�p���āA2 �̃V�[�P���X�̃Z�b�g�a�W���𐶐����܂��B

UnionBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TSource>, Func<TSource,TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āA2 �̃V�[�P���X�̃Z�b�g�a�W���𐶐����܂��B

UnionBy<TSource,TKey>(IEnumerable<TSource>, IEnumerable<TSource>, Func<TSource,TKey>, IEqualityComparer<TKey>)	
�w�肵���L�[ �Z���N�^�[�֐��ɏ]���āA2 �̃V�[�P���X�̃Z�b�g�a�W���𐶐����܂��B

Where<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>)	
�q��Ɋ�Â��Ēl�̃V�[�P���X���t�B���^�[�������܂��B

Where<TSource>(IEnumerable<TSource>, Func<TSource,Int32,Boolean>)	
�q��Ɋ�Â��Ēl�̃V�[�P���X���t�B���^�[�������܂��B �e�v�f�̃C���f�b�N�X�́A�q��֐��̃��W�b�N�Ŏg�p����܂��B

Zip<TFirst,TSecond>(IEnumerable<TFirst>, IEnumerable<TSecond>)	
�w�肵�� 2 �̃V�[�P���X�̗v�f���܂ރ^�v���̃V�[�P���X�𐶐����܂��B

Zip<TFirst,TSecond,TThird>(IEnumerable<TFirst>, IEnumerable<TSecond>, IEnumerable<TThird>)	
�w�肳�ꂽ 3 �̃V�[�P���X�̗v�f�����^�v���̃V�[�P���X�𐶐����܂��B

Zip<TFirst,TSecond,TResult>(IEnumerable<TFirst>, IEnumerable<TSecond>, Func<TFirst,TSecond,TResult>)	
�w�肵���֐��� 2 �̃V�[�P���X�̑Ή�����v�f�ɓK�p���A���ʂ̃V�[�P���X�𐶐����܂��B

AsParallel(IEnumerable)	
�N�G���̕��񉻂�L���ɂ��܂��B

AsParallel<TSource>(IEnumerable<TSource>)	
�N�G���̕��񉻂�L���ɂ��܂��B

AsQueryable(IEnumerable)	
IEnumerable �� IQueryable�ɕϊ����܂��B

AsQueryable<TElement>(IEnumerable<TElement>)	
�W�F�l���b�N IEnumerable<T> ���W�F�l���b�N IQueryable<T>�ɕϊ����܂��B

Ancestors<T>(IEnumerable<T>)	
�\�[�X �R���N�V�������̂��ׂẴm�[�h�̐�c���܂ޗv�f�̃R���N�V������Ԃ��܂��B

Ancestors<T>(IEnumerable<T>, XName)	
�\�[�X �R���N�V�������̂��ׂẴm�[�h�̐�c���܂ޗv�f�̃t�B���^�[�������ꂽ�R���N�V������Ԃ��܂��B �R���N�V�����ɂ́A��v���� XName �����v�f�݂̂��܂܂�܂��B

DescendantNodes<T>(IEnumerable<T>)	
�\�[�X �R���N�V�������̂��ׂẴh�L�������g�Ɨv�f�̎q���m�[�h�̃R���N�V������Ԃ��܂��B

Descendants<T>(IEnumerable<T>)	
�\�[�X �R���N�V�������̂��ׂĂ̗v�f�ƃh�L�������g�̎q���v�f���܂ޗv�f�̃R���N�V������Ԃ��܂��B

Descendants<T>(IEnumerable<T>, XName)	
�\�[�X �R���N�V�������̂��ׂĂ̗v�f�ƃh�L�������g�̎q���v�f���܂ޗv�f�̃t�B���^�[�������ꂽ�R���N�V������Ԃ��܂��B �R���N�V�����ɂ́A��v���� XName �����v�f�݂̂��܂܂�܂��B

Elements<T>(IEnumerable<T>)	
�\�[�X �R���N�V�������̂��ׂĂ̗v�f�ƃh�L�������g�̎q�v�f�̃R���N�V������Ԃ��܂��B

Elements<T>(IEnumerable<T>, XName)	
�\�[�X �R���N�V�������̂��ׂĂ̗v�f�ƃh�L�������g�̎q�v�f�̃t�B���^�[�������ꂽ�R���N�V������Ԃ��܂��B �R���N�V�����ɂ́A��v���� XName �����v�f�݂̂��܂܂�܂��B

InDocumentOrder<T>(IEnumerable<T>)	
�h�L�������g�̏����ŕ��בւ���ꂽ�A�\�[�X �R���N�V�������̂��ׂẴm�[�h���܂ރm�[�h�̃R���N�V������Ԃ��܂��B

Nodes<T>(IEnumerable<T>)	
�\�[�X �R���N�V�������̂��ׂẴh�L�������g����їv�f�̎q�m�[�h�̃R���N�V������Ԃ��܂��B

Remove<T>(IEnumerable<T>)	
�\�[�X �R���N�V�������̂��ׂẴm�[�h��e�m�[�h����폜���܂��B
*/

#endregion