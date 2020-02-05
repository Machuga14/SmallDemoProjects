namespace CSharp_AttributeDecorators
{
  using System;

  /// <summary>
  /// This is a customized attribute, following the reccomended pattern from Microsoft, which can be found at:
  ///     http://go.microsoft.com/fwlink/?LinkId=85236
  /// </summary>
  [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
  public sealed class CustomizedAttribute : Attribute
  {
    /// <summary>
    /// String description for a more in-depth description.
    /// </summary>
    private readonly string stringDescription;

    /// <summary>
    /// Additional payload associated with this <see cref="CustomizedAttribute"/>.
    /// </summary>
    private readonly int additionalPayload;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomizedAttribute"/> class.
    /// <para>Parameterized Constructor.</para>
    /// </summary>
    /// <param name="description">The string description.</param>
    /// <param name="payload">The additional integer payload.</param>
    public CustomizedAttribute(string description, int payload)
    {
      this.stringDescription = description;
      this.additionalPayload = payload;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomizedAttribute"/> class.
    /// <para>Parameterized Constructor.</para>
    /// </summary>
    /// <param name="description">The string description.</param>
    public CustomizedAttribute(string description)
    {
      this.stringDescription = description;
      this.additionalPayload = -9999;
    }

    /// <summary>
    /// Gets the Description for this <see cref="CustomizedAttribute"/>.
    /// </summary>
    public string Description
    {
      get
      {
        return this.stringDescription;
      }
    }

    /// <summary>
    /// Gets the payload for this <see cref="CustomizedAttribute"/>.
    /// </summary>
    public int Payload
    {
      get
      {
        return this.additionalPayload;
      }
    }
  }
}