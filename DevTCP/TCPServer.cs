using Serilog;

namespace DevTCP
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The tcp server.
    /// </summary>
    public class TCPServer
    {
        private ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TCPServer"/> class.
        /// </summary>
        public TCPServer()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        /// <summary>
        /// Starts the server async.
        /// </summary>
        /// <param name="port">The port.</param>
        /// <returns>A Task.</returns>
        public async Task StartServerAsync(int port)
        {
            var ipAddress = IPAddress.Any;
            var listener = new TcpListener(ipAddress, port);
            listener.Start();

            _logger.Information($"Server started. Listening on port {port}...");

            try
            {
                while (true)
                {
                    var client = await listener.AcceptTcpClientAsync();
                    await HandleClientAsync(client);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }
        }

        /// <summary>
        /// Handles the client async.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>A Task.</returns>
        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                await using var stream = client.GetStream();
                var buffer = new byte[1024];
                var bytesRead = await stream.ReadAsync(buffer);
                var requestData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                var dataParts = requestData.Split(';');
                var prices = Array.ConvertAll(dataParts[5].Split(','), double.Parse);
                var sma = CalculateSMA(prices);
                var macd = CalculateMACD(prices);

                var responseData = $"SMA: {sma}, MACD: {macd}";
                var responseDataBytes = Encoding.ASCII.GetBytes(responseData);
                await stream.WriteAsync(responseDataBytes);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        /// <summary>
        /// Calculates the sma.
        /// </summary>
        /// <param name="prices">The prices.</param>
        /// <returns>A double.</returns>
        public static double CalculateSMA(IEnumerable<double> prices)
        {
            return prices.TakeLast(5).Average();
        }

        /// <summary>
        /// Calculates the macd.
        /// </summary>
        /// <param name="prices">The prices.</param>
        /// <returns>A double.</returns>
        public static double CalculateMACD(double[] prices)
        {
            var shortTermEMA = prices.TakeLast(5).Average();
            var longTermEMA = prices.TakeLast(10).Average();

            return shortTermEMA - longTermEMA;
        }
    }
}