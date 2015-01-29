#region Usings

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CCD.Enum;

#endregion

namespace MultiMonitorHelper.DisplayModels.Win7
{
    internal partial class Win7DisplayModel : AbstractDisplayModel
    {
        public override IEnumerable<Display> GetActiveDisplays()
        {
            DisplayConfigTopologyId topologyId;
            var pathWraps = GetPathWrap(QueryDisplayFlags.OnlyActivePaths, out topologyId);

            // convert pathWrap elements to IDisplay elements(actually Win7Display elements)
            return pathWraps.Select(CreateDisplay);
        }

        public override bool SetRotation(Display display, DisplayRotation rotation)
        {
            throw new System.NotImplementedException();
        }

        public override bool SetResolution(Display display, Size newResolution)
        {
            throw new System.NotImplementedException();
        }
    }
}