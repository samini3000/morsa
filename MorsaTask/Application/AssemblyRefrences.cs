﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class AssemblyRefrences
    {
        public static readonly Assembly Assembly = typeof(AssemblyRefrences).Assembly;
    }
}
