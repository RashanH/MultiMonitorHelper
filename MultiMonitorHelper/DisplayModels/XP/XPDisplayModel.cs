#region Usings

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using MultiMonitorHelper.DisplayModels.XP.Enum;
using MultiMonitorHelper.DisplayModels.XP.Struct;

#endregion

namespace MultiMonitorHelper.DisplayModels.XP
{
    internal sealed class XPDisplayModel : AbstractDisplayModel
    {
        public override IEnumerable<Display> GetActiveDisplays()
        {
            var displayDevices = GetDisplayDevices();

            // find out resolution parameters for each display device.
            foreach (var displayDevice in displayDevices.Where(
                x => x.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop)))
            {
                var mode = new DevMode {size = (short) Marshal.SizeOf(typeof (DevMode))};

                // -1 means current RESOLUTION for specific display.
                // you can enumerate through 0..N to find supported resolutions.
                var success = XPWrapper.EnumDisplaySettings(displayDevice.DeviceName, -1, ref mode);
                if (!success)
                    continue;

                var origin = mode.position;
                var resolution = mode.resolution;
                var refreshRate = mode.displayFrequency;
                var rotation = mode.displayOrientation;

                yield return new Display
                {
                    Resolution = resolution,
                    Origin = origin,
                    Rotation = rotation.ToScreenRotation(),
                    RefreshRate = refreshRate,
                    Name = displayDevice.DeviceName
                };
            }
        }

        public override bool SetRotation(Display display, DisplayRotation rotation)
        {
            throw new NotImplementedException();
        }

        public override bool SetResolution(Display display, Size newResolution)
        {
            throw new NotImplementedException();
        }

        public override bool TurnOn(Display display)
        {
            throw new NotImplementedException();
        }

        public override bool TurnOff(Display display)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets all possible display devices.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<DisplayDevice> GetDisplayDevices()
        {
            var i = 0;
            var valid = true;

            while (valid)
            {
                var displayDevice = new DisplayDevice {cb = Marshal.SizeOf(typeof (DisplayDevice))};

                valid = XPWrapper.EnumDisplayDevices(null, i, ref displayDevice, 0);
                if (valid)
                    yield return displayDevice;

                ++i;
            }
        }
    }
}