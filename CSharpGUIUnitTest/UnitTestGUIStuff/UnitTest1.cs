using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpGUIUnitTest;
using System.Windows.Forms;

namespace UnitTestGUIStuff
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      MyFormThatIWantToTest asdf = new MyFormThatIWantToTest();
      Assert.AreEqual(false, asdf.DidValidate);

      asdf.tbxValidatesOnFocusLeave.Focus();
      asdf.tbxValidatesOnFocusLeave.Text = "5";

      // Force GUI to invoke leave()
      asdf.tbxValidatesOnFocusLeave.InvokeGenericDelegateForControlEventName("Leave");
      Assert.AreEqual(true, asdf.DidValidate);
    }
  }
}
