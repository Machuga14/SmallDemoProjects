using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CSharpGUIPractices
{
  public static class BinarySaver
  {
    public static void Save(string fileName, Dictionary<int, Student> studentsToSave)
    {
      BinaryFormatter binFormatter = new BinaryFormatter();

      using (StreamWriter writer = new StreamWriter(fileName))
      {
        binFormatter.Serialize(writer.BaseStream, studentsToSave);
      }
    }

    public static Dictionary<int, Student> Load(string fileName)
    {
      Dictionary<int, Student> retDict = null;
      BinaryFormatter binFormatter = new BinaryFormatter();

      using (StreamReader rdr = new StreamReader(fileName))
      {
        retDict = binFormatter.Deserialize(rdr.BaseStream) as Dictionary<int, Student>;
      }

      return retDict;
    }
  }
}
