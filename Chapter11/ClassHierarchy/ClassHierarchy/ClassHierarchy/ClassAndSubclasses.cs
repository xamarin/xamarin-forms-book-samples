using System;
using System.Collections.Generic;

namespace ClassHierarchy
{
    class ClassAndSubclasses
    {
        public ClassAndSubclasses(Type parent, bool isXamarinForms)
        {
            Type = parent;
            IsXamarinForms = isXamarinForms;
            Subclasses = new List<ClassAndSubclasses>();
        }

        public Type Type { private set; get; }
        public bool IsXamarinForms { private set; get; }
        public List<ClassAndSubclasses> Subclasses { private set; get; }
    }
}
