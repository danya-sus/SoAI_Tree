using System;

namespace SoAI_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>();
            Menu menu = new Menu(node);
            menu.StartMenu();
            Console.ReadKey();
        }
    }
}
