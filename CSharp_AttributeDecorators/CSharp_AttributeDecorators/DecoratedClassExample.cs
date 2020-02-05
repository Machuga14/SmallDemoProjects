using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_AttributeDecorators
{
  [Customized("Decorated class")]
  class DecoratedClassExample
  {
    [Customized("DecoratedInt1")]
    public int DecoratedInt1 { get; set; }
    [Customized("DecoratedInt2")]
    public int DecoratedInt2 { get; set; }

    public int UndecoratedInt1 { get; set; }

    public int UndecoratedInt2 { get; set; }
    
    [Customized("decorated method.")]
    public int DecoratedMethod1(int a)
    {
      return a;
    }

    public int UndecoratedMethod1(int a)
    {
      return a;
    }
  }
}
