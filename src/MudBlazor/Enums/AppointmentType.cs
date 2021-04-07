using System.ComponentModel;

namespace MudBlazor
{
    public enum AppointmentType
    {
        [Description("one-time")]
        OneTime,
        [Description("all-day")]
        AllDay,
        [Description("recurrent")]
        Recurrent
    }
}
