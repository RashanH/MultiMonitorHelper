#region Usings

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

#endregion

namespace MultiMonitorHelper
{
    internal abstract class AbstractDisplayModel : IDisplayModel
    {
        #region Implementation of IDisplayModel

        public abstract IEnumerable<Display> GetActiveDisplays();

        public Display GetPrimaryDisplay()
        {
            return GetActiveDisplays().First(x => x.IsPrimary);
        }

        public abstract bool SetRotation(Display display, DisplayRotation rotation);
        public abstract bool SetResolution(Display display, Size newResolution);

        #endregion
    }
}