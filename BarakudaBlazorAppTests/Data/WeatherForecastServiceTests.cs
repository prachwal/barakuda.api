using System;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace Barakuda.App.Data.Tests
{
    [TestFixture()]
    public class WeatherForecastServiceTests
    {
        [Test()]
        public void GetForecastAsyncTest()
        {
            string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            var w = new WeatherForecastService();
            var result = w.GetForecastAsync( DateTime.Today ).Result;
            result.Should().NotBeEmpty();
            result.Should().HaveCount( 5 );
            result.Should().BeAssignableTo<WeatherForecast[]>();
            foreach ( var item in result )
            {
                item.Should().NotBeNull();
                item.Should().BeAssignableTo<WeatherForecast>();
                item.TemperatureF.Should().Be( 32 + ( int ) (item.TemperatureC / 0.5556) );
                Summaries.ToList().Contains( item.Summary ).Should().BeTrue();
            }
        }
    }
}