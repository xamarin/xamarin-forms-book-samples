using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class RadioButtonManager<T> : BindableObject where T : struct
    {
        StringBuilder stringBuilder = new StringBuilder();

        public static readonly BindableProperty SelectedValueProperty =
            BindableProperty.Create(
                "SelectedValue",
                typeof(T),
                typeof(RadioButtonManager<T>),
                default(T), 
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    foreach (RadioButtonItem<T> item in ((RadioButtonManager<T>)bindable).Items)
                    {
                        item.IsSelected = item.Value.Equals((T)newValue);
                    }
                });

        public RadioButtonManager()
        {
            /*
                        if (!typeof(T).GetTypeInfo().IsEnum)
                        {
                            throw new ArgumentException("T must be an enumerated type");
                        }

                        string[] names = Enum.GetNames(typeof(T));
                        T[] values = (T[])Enum.GetValues(typeof(T));
                        Items = new List<RadioButtonItem<T>>();
            */

            string[] names = null;
            T[] values = null;

            if (typeof(T).GetTypeInfo().IsEnum)
            {
                names = Enum.GetNames(typeof(T));
                values = (T[])Enum.GetValues(typeof(T));
            }
            else
            {
                List<string> namesList = new List<string>();
                List<T> valuesList = new List<T>();

                // Fields
                IEnumerable<FieldInfo> fields = typeof(T).GetTypeInfo().DeclaredFields;

                foreach (FieldInfo field in fields)
                {
                    if (field.IsPublic && field.IsStatic && field.FieldType == typeof(T))
                    {
                        namesList.Add(field.Name);
                        valuesList.Add((T)(field.GetValue(null)));
                    }
                }

                // Properties
                IEnumerable<PropertyInfo> properties = typeof(T).GetTypeInfo().DeclaredProperties;

                foreach (PropertyInfo property in properties)
                {
                    MethodInfo method = property.GetMethod;

                    if (method.IsPublic && method.IsStatic && method.ReturnType == typeof(T) && property.CanRead) // ????
                    {
                        namesList.Add(method.Name);
                        valuesList.Add((T)(property.GetValue(null)));
                    }
                }

                // Convert to arrays.
                names = namesList.ToArray();
                values = valuesList.ToArray();
            }



            Items = new List<RadioButtonItem<T>>();

            for (int i = 0; i < names.Length; i++)
            {
                RadioButtonItem<T> item =
                    new RadioButtonItem<T>(BreakUpCamelCase(names[i]),
                                           values[i],
                                           new Command<T>(TapCommand),
                                           values[i].Equals(SelectedValue));
                Items.Add(item);
            }
        }

        string BreakUpCamelCase(string name)
        {
            stringBuilder.Clear();
            int index = 0;

            foreach (char ch in name)
            {
                if (index != 0 && Char.IsUpper(ch))
                {
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append(ch);
                index++;
            }
            return stringBuilder.ToString();
        }

        public T SelectedValue
        {
            set { SetValue(SelectedValueProperty, value); }
            get { return (T)GetValue(SelectedValueProperty); }
        }

        public IList<RadioButtonItem<T>> Items
        {
            private set;
            get;
        }

        void TapCommand(T param)
        {
            SelectedValue = param;
        }
    }
}
