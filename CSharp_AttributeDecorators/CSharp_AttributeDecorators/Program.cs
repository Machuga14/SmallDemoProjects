namespace CSharp_AttributeDecorators
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;

  /// <summary>
  /// Main <see cref="Program"/> class.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// Main entrypoint for the program.
    /// </summary>
    /// <param name="args">Args for the program.</param>
    [Customized("Main method thingy", 888)]
    static void Main(string[] args)
    {
      // Reflect in-place. We could build a lookup dictionary, but I leave that as an exercise to
      // the user of this example. Note that reflection tends to be quite slow,
      // and you are usually better off if you reflect once, cache somehow, and then
      // use a lookup of some form. (I personally really like storing this information in a 
      // static class, and then if necessary, use threadsafe programming techniques to allow readonly
      // access.

      // Every single type in this assembly.
      // Doesn't include types from referenced assemblies, nor builtin types;
      // just types associated with our own assembly.
      Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
      Console.WriteLine("Report # 1 - all types.");
      ConsoleColor archivedColor = Console.ForegroundColor;
      ConsoleColor attributeColor = ConsoleColor.Green;

      foreach (Type t in allTypes)
      {
        Console.WriteLine();
        Console.WriteLine(t.Name.ToString());

        // 1: Check if this type has the attribute.
        CustomizedAttribute ca = t.GetCustomAttributes<CustomizedAttribute>().FirstOrDefault();

        if (ca != null)
        {
          Console.ForegroundColor = attributeColor;
          Console.WriteLine(string.Format("\t{1}: {0}", ca.Description, ca.Payload));
          Console.ForegroundColor = archivedColor;
        }

        // 2: If Enum, check enum states.
        if (t.IsEnum)
        {
          // Iterate enum states.
          foreach (Enum enumState in Enum.GetValues(t))
          {
            Console.WriteLine("\t\t{0}: {1}", Convert.ToInt32(enumState), enumState.ToString());

            ca = enumState
              .GetType()
              .GetFields()
              ?.Where(t => t.Name == enumState.ToString())
              .FirstOrDefault()
              ?.GetCustomAttribute<CustomizedAttribute>();


            if (ca != null)
            {
              Console.ForegroundColor = attributeColor;
              Console.WriteLine(string.Format("\t\t\t{1}: {0}", ca.Description, ca.Payload));
              Console.ForegroundColor = archivedColor;
            }
          }
        }
        else if (t.IsClass)
        {
          foreach (MemberInfo mi in t.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.NonPublic))
          {
            Console.WriteLine("\t{0}", mi.ToString());
            ca = mi.GetCustomAttribute<CustomizedAttribute>();

            if (ca != null)
            {
              Console.ForegroundColor = attributeColor;
              Console.WriteLine(string.Format("\t\t{1}: {0}", ca.Description, ca.Payload));
              Console.ForegroundColor = archivedColor;
            }
          }
        }
      }

      Console.WriteLine("Press any key to terminate.");
      Console.ReadKey();
    }

    public static IEnumerable<T> DeepCopyIEnumerable<T>(this IEnumerable<T> thingToCopy) where T : class, ICloneable
    {
      List<T> copied = new List<T>(thingToCopy.Count());
      foreach (T itm in thingToCopy)
      {
        copied.Add(itm.Clone() as T);
      }

      return copied;
    }
  }
}