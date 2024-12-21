using System;
using MathLibrary;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = MathProxy.Instance;

            while (true)
            {
                Console.WriteLine("\nКалькулятор");
                Console.WriteLine("Оберіть операцію:");
                Console.WriteLine("1. Додавання (+)");
                Console.WriteLine("2. Віднімання (-)");
                Console.WriteLine("3. Множення (*)");
                Console.WriteLine("4. Ділення (/)");
                Console.WriteLine("5. Табуляція функції exp(a)");
                Console.WriteLine("6. Вихід");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "6")
                {
                    Console.WriteLine("Завершення програми.");
                    break;
                }

                try
                {
                    if (choice == "5")
                    {
                        calculator.TabulateExp();
                        continue;
                    }

                    Console.Write("Введіть перше число: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Введіть друге число: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    double result = choice switch
                    {
                        "1" => calculator.Add(num1, num2),
                        "2" => calculator.Subtract(num1, num2),
                        "3" => calculator.Multiply(num1, num2),
                        "4" => calculator.Divide(num1, num2),
                        _ => throw new InvalidInputException("Невірний вибір операції.")
                    };

                    Console.WriteLine($"Результат: {result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: Невірний формат числа.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Невідома помилка: {ex.Message}");
                }
            }
        }
    }
}
