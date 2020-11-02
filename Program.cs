using System;
using System.Data.SqlClient;
using Dapper;

namespace TodoApp
{
    class Program
    {
        static void Main()
        {
            TodoManager todoManager = new TodoManager("Server=40.85.84.155;Database=Student34;User=Student34;Password=zombie-virus@2020;");
            string title;
            int index;
            bool endLoop;
            ConsoleKeyInfo choice;

            while (true)
            {
                Console.Clear();
                PrintMainMenu();

                try
                {
                    choice = Console.ReadKey();
                    switch (choice.Key)
                    {

                        case ConsoleKey.V: //Visa listan
                            Console.Clear();
                            DisplayTodoList(todoManager);
                            PrintIfListEmpty(todoManager);
                            Console.Write("\nTryck på valfri tangent för att fortsätta");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.L: //Lägga till
                            Console.Clear();
                            Console.WriteLine("Vad vill du lägga till?");
                            title = Console.ReadLine();
                            todoManager.AddTodoItem(title);
                            //GÖR EN FUNKTION DÄR DET ÄR MÖJLIGT ATT ADDERA BESKRIVANDE TEXT!!!!
                            break;

                        case ConsoleKey.K: //Klarmarkera uppgift
                            Console.Clear();
                            DisplayTodoList(todoManager);
                            Console.WriteLine("Vilken uppgift vill du markera som färdig?");
                            index = int.Parse(Console.ReadLine());
                            todoManager.UpdateStatus(index);
                            break;

                        case ConsoleKey.T: //Ta bort uppgift
                            DisplayTodoList(todoManager);
                            Console.WriteLine("Välj vilket index som du vill ta bort");
                            index = int.Parse(Console.ReadLine());
                            todoManager.RemoveTodoItem(index);
                            break;

                        case ConsoleKey.E:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("\nFelaktigt val! Tryck på valfri tangent för att fortsätta");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"Felaktig inmatning. Gör om igen och följ instruktionerna! {e}");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                }
            }

            void PrintMainMenu()
            {
                Console.WriteLine("------Todo listan!------");
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("[V]isa Todo-listan");
                Console.WriteLine("[L]ägg till uppgift");
                Console.WriteLine("[K]larmarkera uppgift");
                Console.WriteLine("[T]a bort uppgift");
                Console.WriteLine("[A]vsluta");
                Console.Write("Val: ");
            }
        }
        static void PrintIfListEmpty(TodoManager todoManager) // Modifiera eller ta bort
        {
            if (todoManager.GetTodos() == null)
            {
                Console.WriteLine("Grattis! Listan är tom oga Todos");
            }
        }

        private static void DisplayTodoList(TodoManager todoManager)
        {
            foreach (var todo in todoManager.GetTodos())
            {
                if (todo.Id == 0)
                {
                    Console.WriteLine("Grattis! Listan är tom och du har inga Todos");
                }
                else
                {
                    Console.WriteLine($"{todo.Id} {todo.Title} {todo.IsDoneDisplay()}");
                }
            }
        }
    }
}
