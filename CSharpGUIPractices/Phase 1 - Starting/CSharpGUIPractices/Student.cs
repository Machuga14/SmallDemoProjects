using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGUIPractices
{
  public class Student
  {
    public Student()
    {
      this.FirstName = string.Empty;
      this.LastName = string.Empty;
      this.BirthDate = new DateTime(2000, 1, 1);
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public string Age
    {
      get
      {
        string age = string.Empty;
        TimeSpan ts = DateTime.Now - BirthDate;

        // math may be wrong; this is for demonstration purposes.
        age = string.Format(
          "{0:N0} Years, {1:N0} Months, {2:N0} Days, {3:N0} hours",
          ts.TotalDays / 365,
          (ts.TotalDays % 365) / 30,
          ts.TotalDays - ((ts.TotalDays % 365) / 30),
          ts.TotalHours - ((int)ts.TotalDays) * 24);

        return age;
      }
    }

    public virtual StudentType TypeOfStudent
    {
      get
      {
        return StudentType.NormalStudent;
      }
    }
  }
}
