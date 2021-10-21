using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Add("First");
            list.Add("Second");
            list.Add("Third");
            list.AddFirst("PreFirst");

            Console.WriteLine(list.GetFirst());

            list.DeleteElement(1);
            Console.WriteLine(list.GetLast());

            list.ChangeElement(0, "Realy First");
            Console.WriteLine(list.GetFirst());
        }          
    }
}
