using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAPISiumulacao.Data.Contracts
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IsVirtual : System.Attribute
    {
        // Determine property has virtual content for dont try persist
    }
}
