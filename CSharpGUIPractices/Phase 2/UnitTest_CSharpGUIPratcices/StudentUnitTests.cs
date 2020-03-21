using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpGUIPractices;
using System.Collections.Generic;

namespace UnitTest_CSharpGUIPratcices
{
  [TestClass]
  public class StudentUnitTests
  {
    [TestMethod]
    public void Student_Age_Works_1()
    {
      string expected = "3 Years";
      Student s = new Student()
      {
        BirthDate = DateTime.Now.AddYears(-3),
      };

      Assert.AreEqual(true, s.Age.Contains(expected));
    }

    [TestMethod]
    public void Student_ConstructorList_Works_1()
    {
      Student s = new Student()
      {
        FirstName = "Matt",
        LastName = "C",
      };

      Assert.AreEqual("Matt", s.FirstName, "The first name was not the expected value");
      Assert.AreEqual("C", s.LastName, "The last name was not the expected value");

      // theoretical demonstration of AreEqual with a margin of error:
      float calculated = 10.457f; // Imagine a complex calcuation that works with floating point arithmetic.
      float expected = 10.46f;

      Assert.AreEqual(expected, calculated, .01f);

      // Checking that a thing throws an exception
      Assert.ThrowsException<Exception>(() =>
      {
        throw new Exception("Blah");
      });

      Dictionary<int, object> myDict = new Dictionary<int, object>();
      myDict.Add(0, "fish");

      Assert.ThrowsException<ArgumentException>(() =>
      {
        myDict.Add(0, 42.519f);
      });
    }
  }
}
