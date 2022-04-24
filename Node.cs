using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAI_Tree
{
    public class Node<T>
    {
        public Node<T> Parent { get; set; }
        public String Value { get; set; }
        public String[] Answers { get; set; }
        public Node<T>[] Childs { get; set; }
        public Node()
        {
            this.Parent = this;
        }
        public Node(String value)
        {
            this.Value = value;
        }

        public void ChangeName()
        {
            Console.Write($"Введите новый вопрос: ");
            this.Value = Console.ReadLine();
            Console.WriteLine("Вопрос изменён...");
            Console.ReadKey();
        }

        public void AddChilds()
        {
            Console.Write("Сколько вы хотите ввести вопросов? Выбор: ");
            int count = Int32.Parse(Console.ReadLine());
            Childs = new Node<T>[count];
            Answers = new String[count];
            for (int i = 0; i < Childs.Length; i++)
            {
                Console.WriteLine($"\nВетвь {i + 1}.");
                Console.Write("Введите ответ для перехода на эту ветвь: ");
                Answers[i] = Console.ReadLine();
                Console.Write("Это конечный пункт? Выбор [1 - Да/2 - Нет]: ");
                int answer = Int32.Parse(Console.ReadLine());
                if (answer == 2)
                {
                    Console.Write($"Введите {i + 1}-ый вопрос: ");
                    var value = Console.ReadLine();
                    Childs[i] = new Node<T>(value);
                }
                else
                {
                    Console.WriteLine("Какой результат должен быть?");
                    count = 0;
                    foreach(Results result in Enum.GetValues(typeof(Results)))
                    {
                        count++;
                        Console.WriteLine($"{count}) {result}");
                    }
                    Console.Write("Выбор: ");
                    answer = Int32.Parse(Console.ReadLine());
                    Childs[i] = new Node<T>(Enum.GetValues(typeof(Results)).GetValue(answer - 1).ToString());
                }
                Childs[i].Parent = this;
            }
        }

        public Node<T> MoveToChild()
        {
            Console.WriteLine("К какому вопросу вы хотите перейти?");
            for (int i = 0; i < this.Childs.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Childs[i].Value}");
            }
            Console.Write("Выбор: ");
            int index = Int32.Parse(Console.ReadLine()) - 1;
            try
            {
                return Childs[index];
            }
            catch
            {
                return this;
            }
        }

        public Node<T> MoveToParent()
        {
            return this.Parent;
        }
    }
}