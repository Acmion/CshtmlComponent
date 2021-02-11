using System;
using System.Collections.Generic;
using System.Text;

namespace Acmion.CshtmlComponent
{
    public class CshtmlComponentReference<ReferencableComponentType> where ReferencableComponentType : CshtmlComponentReferenceableBase<ReferencableComponentType>
    {
        public ReferencableComponentType Component { get; set; } = null!;
    }
}
