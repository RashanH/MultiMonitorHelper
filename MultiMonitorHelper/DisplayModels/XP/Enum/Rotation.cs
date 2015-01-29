#region Usings

using System;

#endregion

namespace MultiMonitorHelper.DisplayModels.XP.Enum
{
    [Flags]
    internal enum Rotation
    {
        Default = 0,
        Rotate90 = 1,
        Rotate180 = 2,
        Rotate270 = 3
    }
}