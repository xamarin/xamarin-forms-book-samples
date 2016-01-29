namespace Xamarin.FormsBook.Toolkit
{
    public interface IPersistantPage
    {
        void Save(string prefix);

        void Restore(string prefix);
    }
}
