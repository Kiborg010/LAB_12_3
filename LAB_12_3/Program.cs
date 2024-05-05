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
            Console.WriteLine("1. Создать ИСД заданной длины");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2. Распечатать ИСД");
            Console.ResetColor();
            Console.WriteLine("3. Найти количество листьев в ИСД");
            Console.WriteLine("4. Создать КЧД на основе ИСД");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5. Распечатать КЧД");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Распечатать ИСД и КЧД");
            Console.ResetColor();
            Console.WriteLine("7. Удалить ИСД из памяти");
            Console.WriteLine("8. Удалить КЧД из памяти");
            Console.WriteLine("9. Завершить работу");
        }

        static void TrashAnswer() //Ненужный вопрос, для того, чтобы просто подождать, пока пользователь будет готов вернуться в меню
        {
            Console.WriteLine();
            Console.Write("Введите что-нибудь, чтобы вернуться в меню: ");
            string trashAnswer = Console.ReadLine();
        }

        static Car[] CreateListWithRandomCars(int lenght)
        {
            List<Car> cars = new List<Car>();
            for (int i = 0; i < lenght; i++)
            {
                Random random = new Random();
                int type = random.Next(0, 4); //Случайное число от 0 до 3
                Car car = new Car();
                if (type == 0) //В зависимости от числа выибраем тип
                {
                    car = new Car(); //Создаём машину нужного типа
                }
                else if (type == 1) //В зависимости от типа создаём определённую машину
                {
                    car = new LorryCar();
                }
                else if (type == 2)
                {
                    car = new PassengerCar();
                }
                else if (type == 3)
                {
                    car = new OffRoadCar();
                }
                car.RandomInit(); //Заполняем случайными значениями
                cars.Add(car);
            }
            return cars.ToArray();
        }

        static void PrintTreePB(MyTree<Car> treePB)
        {
            Console.WriteLine("Идеально-сбалансированное дерево:");
            if (treePB.Count != 0)
            {
                try
                {
                    treePB.ShowTree();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Дерево пустое");
            }
            Console.WriteLine("\n\n");
        }

        static void PrintTreeRB(MyRedBlackTree<Car> treeRB)
        {
            Console.WriteLine("Красно-чёрное дерево:");
            if (treeRB.Count != 0)
            {
                try
                {
                    treeRB.ShowTree();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Дерево пустое");
            }
            Console.WriteLine("\n\n");
        }

        static void Main(string[] args)
        {
            WriteCommandsBegin();
            int numberAnswerOne = -1;
            Car[] array = new Car[0];
            MyTree<Car> treePB = new MyTree<Car>(array);
            MyRedBlackTree<Car> treeRB = new MyRedBlackTree<Car>(array);
            Point<Car> rootPB = treePB.root;
            Point<Car> rootRB = treeRB.root;
            while (numberAnswerOne != 9)
            {
                Console.Clear();
                WriteCommandsBegin();
                numberAnswerOne = CorrectInputInt(1, 9, "номер выбранной команды");
                switch (numberAnswerOne)
                {
                    case 1:
                        {
                            Console.Clear();
                            int lenght = CorrectInputInt(-100, 100, "количество элементов в ИСД");
                            try
                            {
                                array = CreateListWithRandomCars(lenght);
                                treePB = new MyTree<Car>(array);
                                rootPB = treePB.root;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            PrintTreePB(treePB);
                            TrashAnswer();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            PrintTreePB(treePB);
                            TrashAnswer();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            PrintTreePB(treePB);
                            if (treePB.Count == 0)
                            {
                                Console.WriteLine("Листьев нет");
                            }
                            else
                            {
                                Console.WriteLine("Листья: ");
                                int count = treePB.CountingLeaps(rootPB, 0);
                                Console.WriteLine($"\n\nКоличество листьев в дереве: {count}");
                            }
                            TrashAnswer();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            PrintTreePB(treePB);
                            if (treePB.count != 0)
                            {
                                try
                                {
                                    Car[] cars = new Car[treePB.Count];
                                    int index = 0;
                                    treePB.TransformToArray(rootPB, ref cars, ref index);
                                    treeRB = new MyRedBlackTree<Car>(cars);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Console.WriteLine("\n\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Преобразование невозможно");
                                Console.WriteLine("\n\n");
                            }
                            PrintTreeRB(treeRB);
                            TrashAnswer();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            PrintTreeRB(treeRB);
                            TrashAnswer();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            PrintTreePB(treePB);
                            PrintTreeRB(treeRB);
                            TrashAnswer();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            if (treePB.Count != 0)
                            {
                                treePB.Clear();
                                Console.WriteLine("ИСД удалено");
                            }
                            else
                            {
                                Console.WriteLine("ИСД и так пустое");
                            }
                            TrashAnswer();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            if (treeRB.Count != 0)
                            {
                                treeRB.Clear();
                                Console.WriteLine("КЧД удалено");
                            }
                            else
                            {
                                Console.WriteLine("КЧД и так пустое");
                            }
                            TrashAnswer();
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine("Завершение работы");
                            break;
                        }
                }
            }
        }
    }
}