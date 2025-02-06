using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stellantis.Core.Contracts
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IgnoreOnUpdate: System.Attribute
    {
    }
}
