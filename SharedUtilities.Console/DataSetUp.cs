using System.ComponentModel;

namespace SharedUtilities.Console
{
    public enum StatusEnum
    {
        Default,
        [Description("not-started")]
        NotStarted,
        [Description("in-progress")]
        InProgress,
        [Description("completed")]
        Completed,
    }

}
