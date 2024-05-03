using ClassLibrary1;

namespace LAB_12_3
{
    public class Program
    {
        static int CorrectInputInt(int left, int right, string message) //Стандартная функция для ввода числа в нужном диапазоне
        {
            Console.WriteLine($"Введите {message}");
            Console.Write($"Введите целое число от {left} до {right}: ");
            string input = Console.ReadLine();
            int number;
            bool numberIsCorrect = int.TryParse(input, out number);
            while (!numberIsCorrect || !((left <= number) && (number <= right)))
            {
                Console.WriteLine($"Ошибка. Вам необходимо ввести целое число от {left} до {right}");
                Console.Write($"Введите целое число от {left} до {right}: ");
                input = Console.ReadLine();
                numberIsCorrect = int.TryParse(input, out number);
            }
            return number;
        }

        static void WriteCommandsBegin() //Вывод вариантов базового меню
        {
            Console.WriteLine("1. Создать хэш-таблицу заданной длины");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2. Распечатать хэш-таблицу");
            Console.ResetColor();
            Console.WriteLine("3. Удалить элемент из хэш-таблицы");
            Console.WriteLine("4. Выполнить поиск элемента в хэш-таблице");
            Console.WriteLine("5. Добавить элемент в хэш-таблицу");
            Console.WriteLine("6. Завершить работу");
        }

        static void TrashAnswer() //Ненужный вопрос, для того, чтобы просто подождать, пока пользователь будет готов вернуться в меню
        {
            Console.WriteLine();
            Console.Write("Введите что-нибудь, чтобы вернуться в меню: ");
            string trashAnswer = Console.ReadLine();
        }



        static void Main(string[] args)
        {
            WriteCommandsBegin();
            int numberAnswerOne = -1;
            MyTree<Car> tree = new MyTree<Car>(0);
            Point<Car> root = tree.root;
            while (numberAnswerOne != 6)
            {
                Console.Clear();
                WriteCommandsBegin();
                numberAnswerOne = CorrectInputInt(1, 6, "номер выбранной команды");
                switch (numberAnswerOne)
                {
                    case 1:
                        {
                            Console.Clear();
                            int lenght = CorrectInputInt(-100, 100, "количество элементов в ИСД");
                            try
                            {
                                tree = new MyTree<Car>(lenght);
                                root = tree.root;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            TrashAnswer();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            if (tree.Count == 0)
                            {
                                Console.WriteLine("Таблица пуста");
                            }
                            else
                            {
                                tree.ShowTree();
                            }
                            TrashAnswer();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            int count = tree.CountingLeaps(root, 0);
                            Console.WriteLine(count);
                            TrashAnswer();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Car[] array = new Car[5];
                            int current = 0;
                            tree.TransformToArray(root, array, ref current);
                            foreach (Car el in array)
                            {
                                Console.WriteLine(el.ToString());
                            }
                            TrashAnswer();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            int lenght = CorrectInputInt(-100, 100, "количество элементов в ИСД");
                            try
                            {
                                Car car1 = new Car();
                                car1.id.number = 1;
                                Car car2 = new Car();
                                car2.id.number = 2;
                                Car car3 = new Car();
                                car3.id.number = 3;
                                Car car4 = new Car();
                                car4.id.number = 4;
                                Car car5 = new Car();
                                car5.id.number = 5;
                                Car car6 = new Car();
                                car6.id.number = 6;
                                Car car7 = new Car();
                                car7.id.number = 7;
                                Car car8 = new Car();
                                car8.id.number = 8;
                                Car car9 = new Car();
                                car9.id.number = 9;
                                Car car10 = new Car();
                                car10.id.number = 10;
                                Car[] array = { car1, car2, car3, car4, car5, car6, car7, car8, car9, car10};
                                MyRedBlackTree<Car> tree1 = new MyRedBlackTree<Car>(array);
                                tree1.ShowTree();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            TrashAnswer();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            TrashAnswer();
                            break;
                        }
                }
            }
        }
    }
}