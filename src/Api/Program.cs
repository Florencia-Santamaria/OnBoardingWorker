using Andreani.ARQ.AMQStreams.Extensions;
using Andreani.ARQ.WebHost.Extension;
using Andreani.Scheme.Onboarding;
using Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using onboardingworker.Application;
using onboardingworker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services
 /*.Services.AddHostedService<WorkerServices>()*/
 // me hospedo en worker services
 .AddKafka(builder.Configuration)
 .CreateOrUpdateTopic(6,"PedidoCreado1")
 .ToProducer<Pedido>("PedidoAsignado1") 
 .ToConsumer<Subscriber, Pedido>("PedidoCreado1") //consume el topico pedidocreado1 y el subscriber maneja los mensajes de tipo pedido
 .Build();

var app = builder.Build();

app.ConfigureAndreani(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.Run();

