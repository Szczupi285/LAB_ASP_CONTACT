using System.Reflection.Metadata.Ecma335;

namespace labolatorium_3___App.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvidercs
    {
        public DateTime CurrentDate() => DateTime.Now;

    }
}
