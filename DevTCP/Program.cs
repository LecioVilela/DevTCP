using DevTCP;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Aplicação iniciada.");

var server = new TCPServer();
server.StartServerAsync(8080).Wait();

Log.Information("Aplicação encerrada.");
Log.CloseAndFlush();