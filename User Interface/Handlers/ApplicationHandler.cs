using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Interface.Handlers
{
    public class ApplicationHandler : Handler
    {
        private readonly ToolTip toolTip = new ToolTip();
        public override void HandleRequest(Control control)
        {
            if (control is Form)
                toolTip.SetToolTip(control, $"This is an Application!");
            else if (Successor != null)
                Successor.HandleRequest(control);
        }
    }
}
