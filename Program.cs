using emma_ultron_chronicler.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<ChroniclerService>();
builder.Services.AddHostedService<ScholarService>();

var host = builder.Build();

host.Run();
