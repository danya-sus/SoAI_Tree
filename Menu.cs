using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAI_Tree
{
    public class Menu
    {
        private Node<string> Root;
        public Menu(Node<string> root)
        {
            this.Root = root;
        }
        public void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("\\\\Главное меню\\\\");
            Console.Write("\n\t\t* * *\n");
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1) Начать проход по дереву.");
            Console.WriteLine("2) Настроить дерево.");
            Console.WriteLine("3) выход из программы.");
            int answer = Int32.Parse(Console.ReadLine());
            Console.Clear();
            switch (answer)
            {
                case 1:
                    Work(Root);
                    break;
                case 2:
                    CreateMenu(Root);
                    break;
                case 3:
                    Console.WriteLine("Выход из программы...");
                    Console.ReadKey();
                    break;
                default:
                    StartMenu();
                    break;
            }
        }

        private void CreateMenu(Node<string> node)
        {
            Console.Clear();
            Console.WriteLine("\\\\Меню создания дерева\\\\");
            Console.WriteLine($"Вопрос: {node.Value}");
            if (node.Answers != null)
            {
                Console.WriteLine("Дочернии ветви:");
                for (int i = 0; i < node.Answers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) Ответ для перехода на эту ветвь: {node.Answers[i]}");
                }
            }
            else Console.WriteLine("Дочерних ветвей нет...");
            Console.WriteLine("\n\t\t* * *\n");
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1) Изменить вопрос.");
            Console.WriteLine("2) Добавить ветви.");
            Console.WriteLine("3) Перейти к следующему пункту.");
            Console.WriteLine("4) Перейти к предыдущему пункту.");
            Console.WriteLine("5) Выйти из режима создания дерева.");
            Console.Write("\nВыбор: ");
            int answer = Int32.Parse(Console.ReadLine());
            Console.Clear();
            switch (answer)
            {
                case 1:
                    node.ChangeName();
                    CreateMenu(node);
                    break;
                case 2:
                    node.AddChilds();
                    CreateMenu(node);
                    break;
                case 3:
                    CreateMenu(node.MoveToChild());
                    break;
                case 4:
                    CreateMenu(node.MoveToParent());
                    break;
                case 5:
                    Console.Clear();
                    StartMenu();
                    break;
                default:
                    CreateMenu(node);
                    break;
            }
        }

        private void Work(Node<string> node)
        {
            Console.Clear();
            if (node.Childs == null)
            {
                Result(node);
            }
            Console.WriteLine("\\\\Какой компьютер выбрать?\\\\");
            Console.WriteLine("\n\t\t* * *\n");
            Console.WriteLine($"{node.Value}");
            Console.WriteLine("Варианты ответов:");
            for (int i = 0; i < node.Answers.Length; i++)
            {
                Console.WriteLine($"{1 + 1}) {node.Answers[i]}");
            }
            Console.Write("Выбор: ");
            int answer = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < node.Childs.Length; i++)
            {
                if (i == answer - 1)
                {
                    Work(node.Childs[i]);
                }
            }
            Work(node);
        }

        private void Result(Node<string> node)
        {
            Console.WriteLine("\\\\Результат\\\\");
            Console.WriteLine("\n\t\t* * *\n");
            Console.WriteLine($"Вам подходит {node.Value}");
            Console.WriteLine("\n\nВозврат в меню, нажимте любую клавишу...");
            Console.ReadKey();
            StartMenu();
        }
    }
}
