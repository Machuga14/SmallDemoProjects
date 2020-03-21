using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGUIPractices
{
  public partial class StudentUserControl : UserControl
  {
    public StudentUserControl()
    {
      this.InitializeComponent();
    }

    private Student ReadStudentFromControls()
    {
      return new Student()
      {
        FirstName = this.tbxFirstName.Text,
        LastName = this.tbxLastName.Text,
        BirthDate = this.dtpBirthDate.Value
      };
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
      Student s = ReadStudentFromControls();
      MessageBox.Show(s.Age);
    }
  }
}