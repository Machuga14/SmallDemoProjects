using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGUIPractices
{
  [Flags]
  public enum StudentType : ulong
  {
    NormalStudent = 1,

    GraduateStudent = 1024
  }
}
