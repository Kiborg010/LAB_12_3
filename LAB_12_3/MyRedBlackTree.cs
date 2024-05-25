using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAB_12_3
{
    public class MyRedBlackTree<T> where T : IInit, ICloneable, IComparable, new() //Метод для создания КЧД
    {
        public Point<T>? root = null; //Корень

        public int count = 0; //Количество элементов в дереве
        public int Count => count;

        public MyRedBlackTree(T[] array1) //Метод для старта создания дерева
        {
            if (array1 is null || array1.Length == 0) //Если массив ноль или пустой, то корень делаем ноль
            {
                root = null;
            }
            else 
            {
                int length = array1.Length; //В ином случае создаём дерево на основе массива
                T[] array = new T[length]; //Сначала надо сделать глубокое копирование массива
                for (int i = 0; i < length; i++)
                {
                    array[i] = (T)array1[i].Clone();
                }
                root = MakeTree(array); 
            }
        }

        public void ShowTree() //Метод для запуска дерева
        {
            if (root == null) //Если корень ноль, то и дерева нет
            {
                throw new Exception("Дерево пустое");
            }
            Show(root); //Иначе выводим дерево
        }

        void Show(Point<T>? point, int spaces = 5) //Рекурсивный метод печати дерева аналогичен выводу в MyTree
        {
            if (point.ToString() != "")
            {
                Show(point.Right, spaces + 5);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine($"{point.Data.ToString()}  Цвет: {point.Colour}");
                Show(point.Left, spaces + 5);
            }
        }

        public void Clear() //Метод для удаления дереве
        {
            if (root != null) //Если корень не пустой
            {
                Point<T> leftSon = root.Left;
                Point<T> rightSon = root.Right;
                root = null; //Корень обнуляется
                leftSon.Parent = null; //Удаляем ссылку на отца у правого и левого сыновей
                rightSon.Parent = null;
                count = 0; //Количество обнуляется
            }
        }

        public string Find(T el) //Метод для определения наличия элемента в дереве
        {
            Point<T> el1 = new Point<T>(el, ""); //Создаём точку на основе искомого элемента
            Point<T> el2 = FindElement(root, el1); //Попытка поиска элемента
            if (el2 == null) //Если элемент пустой
            {
                return "Элемент не найден";
            }
            else //Иначе
            {
                return "Элемент найден";
            }
        }

        Point<T> FindElement(Point<T> current, Point<T> element) //Непосредственно метод поиска. Метод рекурсивный
        {
            if (current.Data == null) //Если информации в текущей точке нет, то возвращаем ноль. Это ситуация возникает в том случае, когда поиск элемента в дереве нет.
            {
                return null;
            }
            int comparing = current.CompareTo(element); //Записываем результат сравнения текущего элемента дерева и элемента поиска
            if (comparing == -1) //Если текущий меньше искомого
            {
                Point<T> el = FindElement(current.Right, element); //То ищем в правой ветке
                return el;
            }
            else if (comparing == 0) //Если же элементы равны, то возвращаем сам элемент
            {
                return current;
            }
            else
            {
                Point<T> el1 = FindElement(current.Left, element); //Иначе 1. То есть текущий больше искомого. Запускаем поиск в левой ветке
                return el1;
            }
        }
        //В КЧД применяется следующая терминология: сын, отец, дед, дядя, прадед. Сын - добавляемый элемент. Отец - тот, кто на уровень выше сына. Дед - тот, кто выше отца. Дядя - наследуется от деда, находится на уровне отца, но с другой стороны. Прадед - отец деда.
        Point<T> FindUncle(Point<T> son) //Метод для поиска дяди. В КЧД дядя имеет большое значение. Как минимум нужно определять цвет дяди, чтобы понять какие именно изменения делать
        {
            Point<T> dad = son.Parent; //
            if (dad == null) //Если отец null, то возвращаем ноль
            {
                return null;
            }
            Point<T> grandDad = dad.Parent; //Определяем деда
            Point<T> uncle; 
            if (grandDad == null) //Если деда нет, то и дяди нет. Возвращаем ноль
            {
                return null;
            }
            if (grandDad.Left == dad) //Если отец находится по левую сторону от деда, то дядя справа
            {
                uncle = grandDad.Right; //Дядя - правый предок деда
            }
            else
            {
                uncle = grandDad.Left; //В ином случае дядя - леваый предок деда
            }
            return uncle; //Возвращаем дядю
        }
        //Основная суть КЧД - сохранения чёрной высоты, количество чёрных точек в подветке, в каждой.
        //Причём считать высоту самому необязательно ( по крайней мере я не считал, и вроде работает), а достаточно рассмотреть цвет и расположение точек сына, отца, деда, дяди и применить нужные для ситуации изменения
        //Именно это делает метод ниже
        //Кроме того в КЧД есть ещё основные правила:
        //У узла только два цвета: красный и чёрный
        //Корень всегда чёрный
        //Есть обычные листья - это нижние узлы, которые имеют значения. А есть листья-null. Эти листья находятся на уровень ниже обычных листьев и имеют чёрный цвет, но не имеют значения. 
        //Красный узел должен иметь два чёрных сына (при этом получаем очень важный для нас вывод - две красных точки подряд быть не может). Чёрный узел может иметь любых сыновей.
        void CorrectColour(Point<T> current, Point<T> uncle) 
        {
            if (current.Colour == "red" && current.Parent.Colour == "black") //Если добавляемый элемент красный, а его родитель чёрный, то ничего делать не надо
            {

            }
            else if (current.Colour == "red" && current.Parent.Colour == "red") //Иной случай, когда добавляемый элемент красный и его родитель тоже красный. Теперь надо что-то делать. Разбор ситуаци будет представлен на картинках, так как проще показать, чем написать
            {
                Point<T> son = current; //сын 
                Point<T> dad = current.Parent; //батя
                Point<T> grandDad = current.Parent.Parent; //дед
                Point<T> grandGrandDad = current.Parent.Parent.Parent; //прадед
                if (uncle.Colour == "red") //Если дядя красный. Здесь все четыре случая, когда дядя красный
                {//То надо всё перекрасить (кроме сына)
                    dad.Colour = "black"; //Отца в чёрный
                    uncle.Colour = "black"; //Дядю в чёрный
                    if (grandGrandDad != null) //Нам надо перекрасить деда в красный. Но так как он может быть корнем, то надо проверить, есть ли прадед
                    {
                        grandDad.Colour = "red"; //Если прадед есть, то красим деда в красный
                    }
                }
                else if (uncle.Colour == "black") //Намного больше делать надо, если дядя чёрный
                {//Теперь для нас принциапиальная разница добавление сына происходит в правую или левую ветку, если смотреть относительно деда и относительно отца
                    if (grandDad.Left == dad)  //Чёрный дядя справа
                    {
                        if (dad.Right == son) //Чёрный дядя справа. Добавление справа от отца
                        {
                            Point<T> grandSon = son.Left;
                            dad.Right = grandSon;
                            grandSon.Parent = dad;

                            son.Parent = grandDad;
                            grandDad.Left = son;
                            son.Left = dad;
                            dad.Parent = son;

                            Point<T> brother = son.Right;
                            son.Right = grandDad;
                            grandDad.Parent = son;
                            grandDad.Left = brother;
                            brother.Parent = grandDad;
                            son.Parent = grandGrandDad;

                            son.Colour = "black";
                            grandDad.Colour = "red";

                            if (grandGrandDad != null)
                            {
                                if (grandGrandDad.Right == grandDad)
                                {
                                    grandGrandDad.Right = son;
                                }
                                else if (grandGrandDad.Left == grandDad)
                                {
                                    grandGrandDad.Left = son;
                                }
                            }
                            else if (grandGrandDad == null)
                            {
                                root = son;
                            }
                        }
                        else if (dad.Left == son) //Черный дядя справа. Добавление слева от отца
                        {
                            Point<T> brother = dad.Right;
                            dad.Right = grandDad;
                            grandDad.Parent = dad;
                            grandDad.Left = brother;
                            brother.Parent = grandDad;
                            dad.Parent = grandGrandDad;

                            dad.Colour = "black";
                            grandDad.Colour = "red";

                            if (grandGrandDad != null)
                            {
                                if (grandGrandDad.Right == grandDad)
                                {
                                    grandGrandDad.Right = dad;
                                }
                                else if (grandGrandDad.Left == grandDad)
                                {
                                    grandGrandDad.Left = dad;
                                }
                            }
                            else if (grandGrandDad == null)
                            {
                                root = dad;
                            }
                        }
                    }
                    else if (grandDad.Right == dad) //Чёрный дяд слева
                    {
                        if (dad.Left == son) //Чёрный дядя слева. Добавление слева от отца
                        {
                            Point<T> preson = son.Right;
                            dad.Left = preson;
                            preson.Parent = dad;

                            son.Parent = grandDad;
                            grandDad.Right = son;
                            son.Right = dad;
                            dad.Parent = son;

                            Point<T> brother = son.Left;
                            son.Left = grandDad;
                            grandDad.Parent = son;
                            grandDad.Right = brother;
                            brother.Parent = grandDad;
                            son.Parent = grandGrandDad;

                            son.Colour = "black";
                            grandDad.Colour = "red";

                            if (grandGrandDad != null)
                            {
                                if (grandGrandDad.Right == grandDad)
                                {
                                    grandGrandDad.Right = son;
                                }
                                else if (grandGrandDad.Left == grandDad)
                                {
                                    grandGrandDad.Left = son;
                                }
                            }
                            else if (grandGrandDad == null)
                            {
                                root = son;
                            }
                        }
                        else if (dad.Right == son) //Чёрный дядя слева. Добавление справа от отца
                        {
                            Point<T> brother = dad.Left;
                            dad.Left = grandDad;
                            grandDad.Parent = dad;
                            grandDad.Right = brother;
                            brother.Parent = grandDad;
                            dad.Parent = grandGrandDad;

                            dad.Colour = "black";
                            grandDad.Colour = "red";

                            if (grandGrandDad != null)
                            {
                                if (grandGrandDad.Right == grandDad)
                                {
                                    grandGrandDad.Right = dad;
                                }
                                else if (grandGrandDad.Left == grandDad)
                                {
                                    grandGrandDad.Left = dad;
                                }
                            }
                            else if (grandGrandDad == null)
                            {
                                root = dad;
                            }
                        }
                    }
                }
                if (current.Parent != null && current.Parent.Parent != null) //При изменении цвета, может быть такое, что выше по дереву две точки подряд красные.
                                                                             //Причём ситуация дед и отец красные не может возникнуть, а вот дед и прадед красные может.
                                                                             //Поэтому проверяем и при наличии таковых запускаем метод для корректировки цвета
                {
                    CorrectColour(current.Parent.Parent, FindUncle(current.Parent.Parent)); //Запускаем корректировку цвета относительно деда и его дяди
                }
            }
        }

        Point<T> MakeTree(T[] array) //Метод для создания дерева
        { //Дерево создаётся на основе массива
            if (array.Distinct().Count() != array.Length) //Проверка на то, есть ли повторяющиеся элементы в массиве
            {
                throw new Exception("В переданном массиве есть повторяющиеся элементы. В дереве все элементы должны быть уникальны");
            }
            Point<T> begin = new Point<T>(array[0], "black"); //Создаём начало
            root = begin; //Задаём корень
            begin.Left = new Point<T>(); //Создаём слева и справа листья-null
            begin.Right = new Point<T>(); //
            array = array.Skip(1).ToArray(); //Первый элемент из массива убираем, так как уже записали
            count = 1;
            foreach (T el in array)
            {
                Point<T> newItem = new Point<T>(el, "red"); //Создаём элемент-точку для добавления

                Point<T> check = FindElement(root, newItem); //Проверка на то, есть ли элемент в дереве
                if (check != null)
                {
                    Console.WriteLine($"Элемент {newItem.Data.ToString()} не может быть добавлен, так как он уже есть в дереве");
                }
                else
                {
                    Point<T> current = root; //Создаём две основных переменных - текущий элемент и предыдущий элемент. Сначала обе этих переменных - это корень
                    Point<T> previous = root;
                    bool isAdded = false; //Флаг для показателя добавления элемента
                    int comparison = 0; //Переменная для показателя сравнения. -1 - добавляемый элемент меньше текущего. 1 - добавляемый элемент больше текущего.
                    while (!isAdded) //Пока элемент не добавлен
                    {
                        if (current.ToString() == "") //Проверка на то, что текущий элемент - это лист-null. Так проверить проще всего
                        {
                            current = newItem; //Текущему элементу присваеваем значение добавляемого значения
                            current.Parent = previous; //Устанавливаем родителя у текущего 
                            current.Left = new Point<T>(); //Теперь current - это лист, а на уровень ниже лист-null
                            current.Right = new Point<T>();//И слева и справа

                            if (comparison < 0) //Надо установить у родителя нужную связь: левую или правую в зависимости от показателя сравнения. (То есть надо показать у родителя по какую сторону находится текущий сын)
                            {
                                previous.Left = newItem;
                            }
                            else if (comparison > 0)
                            {
                                previous.Right = newItem;
                            }

                            Point<T> uncle = FindUncle(current); //Определяем дядю
                            CorrectColour(current, uncle); //Выполняем корректировку цвета
                            isAdded = true; //Показатель добавления
                            count++; //Количество элементов увеличиваем
                        }
                        else if (newItem.CompareTo(current) < 0) //Добавляемый элемент меньше текущего
                        {
                            previous = current; //Сдвигаем предыдущий элемент на текущий
                            current = current.Left; //Сдвигаем текущий элемент на уровень ниже влево
                            comparison = -1; //Результат сравнения -1
                        }
                        else if (newItem.CompareTo(current) > 0)
                        {
                            previous = current; //Сдвишаем предыдущий на текущий
                            current = current.Right; //Сдвигаем текущий элемент на уровень ниже вправо
                            comparison = 1; //Результат сравнения 1
                        }
                    }
                }
            }
            return root;
        }
    }
}

