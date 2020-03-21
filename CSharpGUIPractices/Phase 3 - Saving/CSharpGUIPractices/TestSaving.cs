using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGUIPractices
{
  public static class TestSaving
  {
    public static void RunTests()
    {
      Dictionary<int, Student> daStudents = new Dictionary<int, Student>();

      Student tmp = new Student()
      {
        BirthDate = new DateTime(1995, 09, 18),
        FirstName = "Matthew",
        LastName = "Crandall",
      };

      daStudents.Add(tmp.ID, tmp);

      tmp = new GraduateStudent()
      {
        BirthDate = new DateTime(1980, 01, 01),
        FirstName = "Iddi",
        LastName = "LastName",
        Emphasis = "Being a cool person",
      };

      daStudents.Add(tmp.ID, tmp);

      tmp = new Student()
      {
        BirthDate = new DateTime(1, 1, 1),
        FirstName = "Chair",
        LastName = "Seasoning",
      };

      daStudents.Add(tmp.ID, tmp);

      // XML Serialization testing
      XMLSaver.Save("TestStudents.xml", daStudents);
      Dictionary<int, Student> loaded = XMLSaver.Load("TestStudents.xml");

      // Binary Serialization testing
      BinarySaver.Save("TestStudents.bin", daStudents);
      loaded = BinarySaver.Load("TestStudents.bin");

      // JSON Serialization testing
      JSonSaver.Save("TestStudents.json", daStudents);
      loaded = JSonSaver.Load("TestStudents.json");
    }
  }
}