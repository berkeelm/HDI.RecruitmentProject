namespace WebUI.Interfaces
{
    public interface IRequestHelper
    {
        public T SendRequest<T>(string _endpoint, object _data);
    }
}
