using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGUIUnitTest
{
  public partial class MyFormThatIWantToTest : Form
  {
    public MyFormThatIWantToTest()
    {
      InitializeComponent();
    }

    public bool DidValidate { get; private set; }

    private void tbxValidatesOnFocusLeave_Leave(object sender, EventArgs e)
    {
      Console.WriteLine("Focus Leaving");
      this.DidValidate = int.TryParse(this.tbxValidatesOnFocusLeave.Text, out int n);
    }

    private void tbxValidatesOnFocusLeave_Enter(object sender, EventArgs e)
    {
      Console.WriteLine("Focus Gained");
    }
  }
}