using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json; // include json serializer

namespace CSharpGUIPractices
{
  public static class JSonSaver
  {
    public static void Save(string fileName, Dictionary<int, Student> studentsToSave)
    {
      // Do not use this approach to actually save the file itself, *if* the file is ***large*** (gigabytes, or even hundreds of mg at least)
      JsonSerializerSettings settings = new JsonSerializerSettings()
      {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.Auto, // AUTO only provides hints if different.
      };

      File.WriteAllText(fileName, JsonConvert.SerializeObject(studentsToSave, settings));
    }

    public static Dictionary<int, Student> Load(string fileName)
    {
      // same as save; use streams if the file is large (gigabytes, or hundreds of mg)
      JsonSerializerSettings settings = new JsonSerializerSettings()
      {
        TypeNameHandling = TypeNameHandling.Auto
      };

      return JsonConvert.DeserializeObject<Dictionary<int, Student>>(File.ReadAllText(fileName), settings);
    }
  }
}
