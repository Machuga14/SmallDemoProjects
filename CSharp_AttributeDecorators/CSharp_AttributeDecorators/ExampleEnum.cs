namespace CSharp_AttributeDecorators
{
  /// <summary>
  /// Example enum to be decorated with <see cref="CustomizedAttribute"/> tags
  /// 
  /// If you look, even though my class was called <see cref="CustomizedAttribute"/>, we use it by the "Customized" keyword.
  /// (Attribute gets chopped off).
  /// 
  /// I intermix named inputs, and default inputs, as it is common to see both when using attributes,
  /// in my experience.
  /// </summary>
  [Customized("ENUM LEVEL ATTRIBUTE", 666)]
  public enum ExampleEnum : int
  {
    /// <summary>
    /// Unknown enum state.
    /// </summary>
    [Customized(description:"THIS IS AN UNKNOWN STATE", payload:15)]
    UNKNOWN = 0,

    /// <summary>
    /// Invalid enum state.
    /// </summary>
    [Customized("THIS IS AN INVALID STATE", 42)]
    INVALID = 9999,

    /// <summary>
    /// Cheese Wheel State. (Shhhhhhh! Don't tell Uncle Sheo)
    /// </summary>
    [Customized("Cheese Wheels. Eat 50 at once to survive a dragon attack.", 50)]
    CheeseWheel = 1,

    /// <summary>
    /// Soap enum state.
    /// </summary>
    [Customized(payload: 9001, description:"Soapy.")]
    Soap = 2,

    /// <summary>
    /// Argon enum state. Survives 1 day, and then has a half-life of 1 day afterwards.
    /// Don't expect to farm hundreds at once and then rely upon a stockpile in
    /// your WARFAME save; that will end poorly.
    /// </summary>
    [Customized("Argon. Farm only as needed, and not in advance.", 3)]
    ArgonCrystal = 3,

    /// <summary>
    /// Fiddlesnarf enum state.
    /// Note: I use a different constructor; we assume a default integer payload.
    /// </summary>
    [Customized("What's the Password? <i>Fiddlesnarf.</i>")]
    Fiddlesnarf = 4,

    /// <summary>
    /// Foo enum state. Because what's a programming example without Foo?
    /// </summary>
    [Customized("Foo enum state. Because what's a programming example without Foo?", 13)]
    Foo = 5,

    /// <summary>
    /// Bar enum state. Because every Foo must have a Bar.
    /// </summary>
    [Customized("Bar enum state. Because every Foo must have a Bar.", 14)]
    Bar = 6,
  }
}
