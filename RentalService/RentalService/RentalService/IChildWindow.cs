namespace RentalService
{
    public delegate void ClosingDelegate();
    public delegate void MessageDelegate(string title, string msg);
    public interface IChildWindow
    {
        event ClosingDelegate Closing;
        event MessageDelegate OpenMsg;
    }
}
