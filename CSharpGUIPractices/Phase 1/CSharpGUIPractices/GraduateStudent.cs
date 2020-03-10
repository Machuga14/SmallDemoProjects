using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGUIPractices
{
  public class GraduateStudent : Student
  {
    public GraduateStudent()
      : base()
    {
    }

    public string Emphasis { get; set; }

    public override StudentType TypeOfStudent
    {
      get
      {
        return StudentType.GraduateStudent;
      }
    }
  }
}