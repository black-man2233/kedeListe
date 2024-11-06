namespace KedeListe.Models;

public class Element<T>
{
    public Object Data { get; set; }
    public Element<T>? Next { get; set; }
    
    public Element(T data)
    {
        this.Data = data;
        this.Next = null;
    }
}