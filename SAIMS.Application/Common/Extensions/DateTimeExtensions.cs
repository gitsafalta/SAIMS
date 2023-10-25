using System.Globalization;

namespace SAIMS.Application.Extensions;

public static class DatetTimeExtensions
{
    public static string ToCultureDateTimeString(this DateTime utcDateTime, string cultureCode)
    {
        CultureInfo cultureInfo = new CultureInfo(cultureCode);
        DateTime cultureSpecificDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.Utc);
        return cultureSpecificDateTime.ToString("F", cultureInfo);
    }
}