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
      asdf.tbxValidatesOnFocusLeave.InvokeGenericDelegateForControlEventName("Leave");
      asdf.ActiveControl = asdf.tbxTheSecond;
      Assert.AreEqual(true, asdf.DidValidate);
    }
  }
}
