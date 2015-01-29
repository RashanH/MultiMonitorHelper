using System.Drawing;

namespace MultiMonitorHelper
{
    /// <summary>
    /// Each monitor is abstraced away with help of IDisplay.
    /// </summary>
    public sealed class Display
    {
        /// <summary>
        /// Display representation on system. Such as \\.\\DISPLAY1
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Returns the resolution of display. In pixels.
        /// </summary>
        public Size Resolution { get; internal set; }

        /// <summary>
        /// Indicates the cordinates of origin where monitor area starts from.
        /// That is left-top cordinates.
        /// </summary>
        public Point Origin { get; internal set; }

        /// <summary>
        /// Indicates degrees of rotation.
        /// </summary>
        public DisplayRotation Rotation { get; internal set; }

        /// <summary>
        /// Indicates refresh rate of monitor. This is vertical refresh rate.
        /// </summary>
        public int RefreshRate { get; internal set; }

        /// <summary>
        /// Indicates whenever monitor is primary, or not.
        /// </summary>
        public bool IsPrimary { get; internal set; }
    }
}