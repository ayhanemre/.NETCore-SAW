public class RspBaseResponse<T>
{
    public string Host { get; set; }
    public T Data { get; set; }
}