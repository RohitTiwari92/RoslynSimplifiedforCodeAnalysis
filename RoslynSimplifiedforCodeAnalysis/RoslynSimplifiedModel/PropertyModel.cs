using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSimplifiedModel
{
   public class PropertyModel
    {
        public PropertyDeclarationSyntax PropertyDeclaration { get; set; }
    }
}
