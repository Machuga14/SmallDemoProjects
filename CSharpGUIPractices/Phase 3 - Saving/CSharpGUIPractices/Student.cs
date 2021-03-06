﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpGUIPractices
{
  [XmlInclude(typeof(GraduateStudent))] // used by XMLSerializer; include Graduate Students as potential derived classes.
  [Serializable] // Used by BinarySerializer
  public class Student
  {
    // This is a bad way to automatically generate auto incrementing ID's
    // It won't persist across opening and closing the program,
    // It is not threadsafe,
    // the ID's are easily predictable (if you need security for pseudo-random unique id's)
    // (passwords? time-sensitive things? data that can be abused or exploited by serial ID's
    // This is here to ensure, in a single run of the program, that we automatically increment ID's.
    private static int _GENERATED_ID = 0;

    public Student()
    {
      this.FirstName = string.Empty;
      this.LastName = string.Empty;
      this.BirthDate = new DateTime(2000, 1, 1);
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public int ID { get; set; } = _GENERATED_ID++;

    [JsonIgnore] // Ignore the age; it's readonly, and we don't care about exposing it to the datafile.
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
