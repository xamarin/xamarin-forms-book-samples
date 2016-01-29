using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassHierarchy
{
    public partial class ClassHierarchyPage : ContentPage
    {
        public ClassHierarchyPage()
        {
            InitializeComponent();

            List<TypeInformation> classList = new List<TypeInformation>();

            // Get types in Xamarin.Forms.Core assembly.
            GetPublicTypes(typeof(View).GetTypeInfo().Assembly, classList);

            // Get types in Xamarin.Forms.Xaml assembly.
            GetPublicTypes(typeof(Extensions).GetTypeInfo().Assembly, classList);

            // Ensure that all classes have a base type in the list.
            //  (i.e., add Attribute, ValueType, Enum, EventArgs, etc.)
            int index = 0;

            // Watch out! Loops through expanding classList!
            do
            {
                // Get a child type from the list.
                TypeInformation childType = classList[index];

                if (childType.Type != typeof(Object))
                {
                    bool hasBaseType = false;

                    // Loop through the list looking for a base type.
                    foreach (TypeInformation parentType in classList)
                    {
                        if (childType.IsDerivedDirectlyFrom(parentType.Type))
                        {
                            hasBaseType = true;
                        }
                    }

                    // If there's no base type, add it.
                    if (!hasBaseType && childType.BaseType != typeof(Object))
                    {
                        classList.Add(new TypeInformation(childType.BaseType, false));
                    }
                }
                index++;
            }
            while (index < classList.Count);

            // Now sort the list.
            classList.Sort((t1, t2) =>
            {
                return String.Compare(t1.Type.Name, t2.Type.Name);
            });

            // Start the display with System.Object.
            ClassAndSubclasses rootClass = new ClassAndSubclasses(typeof(Object), false);

            // Recursive method to build the hierarchy tree.
            AddChildrenToParent(rootClass, classList);

            // Recursive method for adding items to StackLayout.
            AddItemToStackLayout(rootClass, 0);
        }

        void GetPublicTypes(Assembly assembly,
                            List<TypeInformation> classList)
        {
            // Loop through all the types.
            foreach (Type type in assembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                // Public types only but exclude interfaces.
                if (typeInfo.IsPublic && !typeInfo.IsInterface)
                {
                    // Add type to list.
                    classList.Add(new TypeInformation(type, true));
                }
            }
        }

        void AddChildrenToParent(ClassAndSubclasses parentClass,
                                 List<TypeInformation> classList)
        {
            foreach (TypeInformation typeInformation in classList)
            {
                if (typeInformation.IsDerivedDirectlyFrom(parentClass.Type))
                {
                    ClassAndSubclasses subClass = 
                        new ClassAndSubclasses(typeInformation.Type, typeInformation.IsXamarinForms);
                    parentClass.Subclasses.Add(subClass);
                    AddChildrenToParent(subClass, classList);
                }
            }
        }

        void AddItemToStackLayout(ClassAndSubclasses parentClass, int level)
        {
            // If assembly is not Xamarin.Forms, display full name.
            string name = parentClass.IsXamarinForms ? parentClass.Type.Name :
                                                       parentClass.Type.FullName;

            TypeInfo typeInfo = parentClass.Type.GetTypeInfo();

            // If generic, display angle brackets and parameters.
            if (typeInfo.IsGenericType)
            {
                Type[] parameters = typeInfo.GenericTypeParameters;
                name = name.Substring(0, name.Length - 2);
                name += "<";

                for (int i = 0; i < parameters.Length; i++)
                {
                    name += parameters[i].Name;
                    if (i < parameters.Length - 1)
                    {
                        name += ", ";
                    }
                }
                name += ">";
            }

            // Create Label and add to StackLayout.
            Label label = new Label
            {
                Text = String.Format("{0}{1}", new string(' ', 4 * level), name),
                TextColor = parentClass.Type.GetTypeInfo().IsAbstract ?
                                Color.Accent : Color.Default
            };

            stackLayout.Children.Add(label);

            // Now display nested types. 
            foreach (ClassAndSubclasses subclass in parentClass.Subclasses)
            {
                AddItemToStackLayout(subclass, level + 1);
            }
        }
    }
}

