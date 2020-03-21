using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpGUIPractices
{
  /// <summary>
  /// This is why I *HATE* C#'s default XMLSerializer.
  /// It does not jive with dictionaries, and requires *garbage*
  /// custom mapping functionality intermingled with data to be able to
  /// serialize them...
  /// 
  /// It's too goddamned literal about the inner mappings and structures of collections
  /// and algorithms and doesn't enumerate them intelligently like *other* serializers.
  /// 
  /// Microsoft's garbage about "Equality Comparer" is null and void as far as I'm concerned; it belongs
  /// to the higher-level application to be concerned about that, and provide a predicate
  /// at runtime in code to handle the equality and hashing, just like dictionaries
  /// themselves already natively support (and hash sets / other hashed collections) natively...
  /// 
  /// SOAPBOX done.
  /// </summary>
  public static class XMLSaver
  {
    public static void Save(string fileName, Dictionary<int, Student> studentsToSave)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

      using (StreamWriter writer = new StreamWriter(fileName))
      {
        // translate to list
        serializer.Serialize(writer, studentsToSave.Values.ToList());
      }
    }

    public static Dictionary<int, Student> Load(string fileName)
    {
      List<Student> tmp = null;
      Dictionary<int, Student> retDict = new Dictionary<int, Student>();
      XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

      using (StreamReader rdr = new StreamReader(fileName))
      {
        tmp = serializer.Deserialize(rdr) as List<Student>; // runtime type-safe type-casting. MUST be given objects, not structs. (ints are structs)
      }

      // translate back to dictionary
      foreach (Student s in tmp)
      {
        retDict.Add(s.ID, s);
      }

      return retDict;
    }
  }
}