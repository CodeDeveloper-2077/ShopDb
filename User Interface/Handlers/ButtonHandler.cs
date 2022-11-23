using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Interface.Handlers
{
    public class ButtonHandler : Handler
    {
        private readonly ToolTip toolTip = new ToolTip();
        public override void HandleRequest(Control control)
        {
            if (control is Button)
                toolTip.SetToolTip(control, $"This is the button!");
            else if (Successor != null)
                Successor.HandleRequest(control);
        }
    }
}
