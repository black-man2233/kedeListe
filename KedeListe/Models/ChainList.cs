namespace KedeListe.Models;

public class ChainList<T>
{
    public Element<T>? First { get; set; }

    public void Add_First(T data)
    {
        Element<T> newElement = new Element<T>(data);
        
        if (First == null)
        {
            First = newElement;
        }
        else
        {
            Element<T> current = First;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newElement;
        }
    }

    public bool Remove_First()
    {
        if (First == null)
        {
            return false;
        }

        First = First.Next;

        return true;
    }
    public int? Count()
    {
        var count = 0;
        Element<T>? current = First;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public string? To_String()
    {
        Element<T>? current = First;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
        return null;
    }
}