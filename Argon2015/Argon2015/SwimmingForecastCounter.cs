using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Argon2015.UnitTest")]
namespace Argon2015
{
    internal class SwimmingForecastCounter : ForecastCounter
    {
        public SwimmingForecastCounter()
            : base(0)
        {
        }
    }
}