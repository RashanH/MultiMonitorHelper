#region Usings

using System.Collections.Generic;

#endregion

namespace MultiMonitorHelper
{
    /// <summary>
    ///     Each display model implementation is abstraced away with help of IDisplayModel.
    /// </summary>
    public interface IDisplayModel
    {
        /// <summary>
        ///     Call this if you want to receive list of currently active displays.
        ///     What does "active" mean in our context? It means the monitors that are "enabled"
        ///     in Desktop properties screen.
        /// </summary>
        /// <returns>list of active monitors</returns>
        IEnumerable<Display> GetActiveDisplays();

        /// <summary>
        ///     Gets the primary display.
        /// </summary>
        /// <returns>current **active** primary display</returns>
        Display GetPrimaryDisplay();
    }
}