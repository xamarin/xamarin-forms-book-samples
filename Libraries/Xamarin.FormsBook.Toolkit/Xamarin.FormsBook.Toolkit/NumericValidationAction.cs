using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class NumericValidationAction : TriggerAction<Entry> 
    {
        protected override void Invoke(Entry entry)
        {
            double result;
            bool isValid = Double.TryParse(entry.Text, out result);
            entry.TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}

