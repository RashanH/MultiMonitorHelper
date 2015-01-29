#region Usings

using System.Collections.Generic;
using System.Drawing;

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

        /// <summary>
        ///     Tries to set to rotation of display.
        /// </summary>
        /// <param name="display">the display to set rotation of</param>
        /// <param name="rotation">the value of rotation</param>
        /// <returns>true if successful, false otherwise.</returns>
        bool SetRotation(Display display, DisplayRotation rotation);

        /// <summary>
        /// Tries to set resolution of a display.
        /// </summary>
        /// <param name="display">the display to set resolution of</param>
        /// <param name="newResolution">new resolution</param>
        /// <returns>true if successful, false otherwise.</returns>
        bool SetResolution(Display display, Size newResolution);
    }
}