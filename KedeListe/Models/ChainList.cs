namespace KedeListe.Models;

public class ChainList<T>
{
    public Element<T>? First { get; set; }
    private int _count = 0;

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

        _count++;
    }

    public bool Remove_First()
    {
        if (First == null)
        {
            return false;
        }

        First = First.Next;

        _count--;
        return true;
    }

    public int Count() => _count;

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
    
    public void Sort()
    {
        if (First == null || First.Next == null) return;

        bool swapped;
        do
        {
            swapped = false;
            Element<T>? current = First;
            while (current?.Next != null)
            {
                if (Compare((T)current.Data, (T)current.Next.Data) > 0)
                {
                    T temp = (T)current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }
    
    private int Compare(T x, T y)
    {
        if (x is string strX && y is string strY)
        {
            return strX.Length.CompareTo(strY.Length);
        }
        else if (x is int intX && y is int intY)
        {
            return intX.CompareTo(intY);
        }
        throw new InvalidOperationException("Can only sort String and Ints !");
    }
}