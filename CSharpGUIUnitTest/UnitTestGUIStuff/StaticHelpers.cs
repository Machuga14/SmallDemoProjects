using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestGUIStuff
{
  public static class StaticHelpers
  {
    /// <summary>
    /// Extension method to invoke a generic Delegate for a known Event Name, on any Control.
    /// This is because Fees read data out of Textboxes on the Textbox OnLeave() event, so
    /// we needed a way to simuluate the user "leaving" the Textbox.
    /// 
    /// Note: I kinda stole this from work... Meh, whatever. I am the person who researched and made this workaround anyways,
    /// and it's generic enough as to be a more universally applicable pattern for workarounds with GUI stuff.
    /// </summary>
    /// <param name="controlToInvoke"></param>
    /// <param name="eventName"></param>
    public static void InvokeGenericDelegateForControlEventName(this System.Windows.Forms.Control controlToInvoke, string eventName)
    {
      MethodInfo methodInfo = controlToInvoke.GetType().GetMethod(string.Format("On{0}", eventName), BindingFlags.NonPublic | BindingFlags.Instance);
      methodInfo?.Invoke(controlToInvoke, new object[] { EventArgs.Empty });
    }
  }
}
