#region Usings

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CCD.Enum;
using CCD.Struct;

#endregion

namespace MultiMonitorHelper.DisplayModels.Win7
{
    internal partial class Win7DisplayModel : AbstractDisplayModel
    {
        public override IEnumerable<Display> GetActiveDisplays()
        {
            DisplayConfigTopologyId topologyId;
            var pathWraps = CCDHelpers.GetPathWraps(QueryDisplayFlags.OnlyActivePaths, out topologyId);

            // convert pathWrap elements to IDisplay elements(actually Win7Display elements)
            return pathWraps.Select(CreateDisplay);
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
        /// Creates new instance of Win7Display
        /// </summary>
        /// <returns></returns>
        private Display CreateDisplay(DisplayConfigPathWrap pathWrap)
        {
            var path = pathWrap.Path;
            var sourceModeInfo = pathWrap.Modes.First(x => x.infoType == DisplayConfigModeInfoType.Source);
            var origin = new Point
            {
                X = sourceModeInfo.sourceMode.position.x,
                Y = sourceModeInfo.sourceMode.position.y
            };

            var resolution = new Size
            {
                Width = sourceModeInfo.sourceMode.width,
                Height = sourceModeInfo.sourceMode.height
            };

            // TODO; MAKE SURE THAT IT IS POSSIBLE TO DIVIDE THIS
            // WHAT IF DENOMINATOR IS ZERO?!
            var refreshRate =
                (int) Math.Round((double) path.targetInfo.refreshRate.numerator/path.targetInfo.refreshRate.denominator);
            var rotationOriginal = path.targetInfo.rotation;


            // query for display name.
            DisplayConfigSourceDeviceName displayConfigSourceDeviceName;

            var displayName = "<unidentified>"; // TODO refactor it out
            var nameStatus = CCDHelpers.GetDisplayConfigSourceDeviceName(sourceModeInfo,
                out displayConfigSourceDeviceName);

            if (nameStatus == StatusCode.Success)
                displayName = displayConfigSourceDeviceName.viewGdiDeviceName;

            return new Display
            {
                Resolution = resolution,
                Origin = origin,
                Rotation = rotationOriginal.ToScreenRotation(),
                RefreshRate = refreshRate,
                Name = displayName,
                IsActive = true
            };
        }
    }
}