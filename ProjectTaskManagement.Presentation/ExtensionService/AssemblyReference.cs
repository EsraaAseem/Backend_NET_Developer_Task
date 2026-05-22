using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace ProjectTaskManagement.Presentation.ExtensionService
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
