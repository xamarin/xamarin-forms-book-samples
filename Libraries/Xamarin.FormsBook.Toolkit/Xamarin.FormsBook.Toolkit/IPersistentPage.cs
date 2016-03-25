namespace Xamarin.FormsBook.Toolkit
{
    public interface IPersistentPage
    {
        void Save(string prefix);

        void Restore(string prefix);
    }
}
