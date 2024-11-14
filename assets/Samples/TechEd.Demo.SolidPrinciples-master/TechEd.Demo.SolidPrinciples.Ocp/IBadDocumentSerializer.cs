using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEd.Demo.SolidPrinciples.Ocp
{
    interface IBadDocumentSerializer
    {

    }

    interface IAkaDocumentSerializer : IDocumentSerializer, IBadDocumentSerializer
    {
         
    }
}
