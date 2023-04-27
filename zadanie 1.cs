/*Проблемы исходного кода:
Он не обрабатывает некорректный ввод пользователя и не проверяет, что введенное число положительное. 
Проблема в методе One класса ZadanieOne - он не обрабатывает некорректный ввод пользователя. 
Если пользователь вводит что-то, что не может быть преобразовано в целое число, то программа выдаст исключение. 
В классе ZadanieTwo не указано, что введенное число должно быть больше 3. Если пользователь вводит значение меньше 3, программа работает некорректно.
Метод Two имеет еще одну проблему: если пользователь вводит четное число, то метод не выдает никакой ошибки, а просто выходит из функции.
Это неоптимальное поведение, потому что может ввести в заблуждение пользователя.*/

using System;
using System.Linq;
using System.Text;

namespace Library
{
    public class Program
    {
        static void Main(string[] args)
        {
            ZadanieOne.One();
            ZadanieTwo.Two();
        }
    }

    public class ZadanieOne
    {
        public static void One()
        {
            int n;
            while (true)
            {
                Console.Write("Введите число N: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Выход из программы.");
                    return;
                }

                if (int.TryParse(input, out n) && n > 0)
                {
                    string result = string.Join(", ", Enumerable.Range(1, n));
                    Console.WriteLine(result);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите положительное целое число или 'exit' для выхода из программы.");
                }
            }
        }
    }

    public class ZadanieTwo
    {
        public static void Two()
        {
            int n;
            while (true)
            {
                Console.Write("Введите нечетное число N (больше 3): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Выход из программы.");
                    return;
                }

                if (int.TryParse(input, out n) && n % 2 == 1 && n > 3)
                {
                    int capacity = n * (n + Environment.NewLine.Length);
                    StringBuilder sb = new StringBuilder(capacity);
                    for (int row = 1; row <= n; row++)
                    {
                        for (int col = 1; col <= n; col++)
                        {
                            if (row == n / 2 + 1 && col == n / 2 + 1)
                                sb.Append(" ");
                            else
                                sb.Append("#");
                        }
                        sb.Append(Environment.NewLine);
                    }
                    Console.WriteLine(sb.ToString());
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите нечетное число больше 3 или 'exit' для выхода из программы.");
                }
            }
        }
    }
}
