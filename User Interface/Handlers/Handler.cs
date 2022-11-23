using System.Windows.Forms;

namespace User_Interface.Handlers
{
    public abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(Control control);
    }
}
