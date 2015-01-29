#region Usings

using System;

#endregion

namespace MultiMonitorHelper.DisplayModels.XP.Enum
{
    [Flags]
    internal enum CdsFlags
    {
        Reset = 0x40000000,
        Noreset = 0x10000000,
        UpdateRegistry = 0x00000001,
        SetPrimary = 0x00000010
    };
}