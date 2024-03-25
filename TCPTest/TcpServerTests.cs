using DevTCP;

namespace TCPTest
{
    /// <summary>
    /// The tcp server tests.
    /// </summary>
    public class TcpServerTests
    {
        /// <summary>
        /// Tests calculates sma.
        /// </summary>
        [Test]
        public void TestCalculateSMA()
        {
            // Arrange
            double[] prices = [10, 15, 20, 25, 30];

            // Act
            var result = TCPServer.CalculateSMA(prices);

            // Assert
            Assert.That(result, Is.EqualTo(25));
        }

        /// <summary>
        /// Tests calculates macd.
        /// </summary>
        [Test]
        public void TestCalculateMACD()
        {
            // Arrange
            double[] prices = [10, 15, 20, 25, 30, 35, 40, 45, 50, 55];

            // Act
            var result = TCPServer.CalculateMACD(prices);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests calculates sma no data.
        /// </summary>
        [Test]
        public void TestCalculateSMANoData()
        {
            // Arrange
            double[] prices = [];

            // Act
            var result = TCPServer.CalculateSMA(prices);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests calculates macd no data.
        /// </summary>
        [Test]
        public void TestCalculateMACDNoData()
        {
            // Arrange
            double[] prices = [];

            // Act
            var result = TCPServer.CalculateMACD(prices);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests calculates sma with negative prices.
        /// </summary>
        [Test]
        public void TestCalculateSMAWithNegativePrices()
        {
            // Arrange
            double[] prices = [-10, -15, -20, -25, -30];

            // Act
            var result = TCPServer.CalculateSMA(prices);

            // Assert
            Assert.That(result, Is.EqualTo(-20));
        }

        /// <summary>
        /// Tests calculates macd with negative prices.
        /// </summary>
        [Test]
        public void TestCalculateMACDWithNegativePrices()
        {
            // Arrange
            double[] prices = [-10, -15, -20, -25, -30, -35, -40, -45, -50, -55];

            // Act
            var result = TCPServer.CalculateMACD(prices);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
    }
}