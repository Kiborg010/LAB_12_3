using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAB_12_3
{
    public class MyTree<T> where T : IInit, IComparable, new() //Класс для создания ИСД
    {
        public Point<T>? root = null; //Точка корень
        public int count = 0; //Для записи количества элементов
        public int Count => count;
        public MyTree(T[] array) //Конструктор для создания дерева. Дерево создаётся на основе массива
        { 
            if (array is null || array.Length == 0) //Если массив пустой, то и корень пустой
            {
                root = null;
            }
            else
            {
                root = MakeTree(array); //Иначе запускаем метод создания дерева
            }
        }

        public void ShowTree() //Метод для запуска печати дерева
        {
            if (root == null) //Если корень пустой, то исключение
            {
                throw new Exception("Дерево пустое");
            }
            Show(root); //Иначе метод печати
        }

        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null) //Если точка дерева равна ноль, то ничего не делаем, иначе печатаем
            {
                Show(point.Right, spaces + 5); //Запускаем печать правой ветки
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" "); //Выводим нужное количество пробелов, чтобы дерево вывелось в нужном порядке
                }
                Console.WriteLine(point.Data.ToString()); //Вывод саму информацию в точке
                Show(point.Left, spaces + 5); //Запускаем печать левой ветки
            }
        }

        public void Clear() //Метод для удаления дерева
        {
            root = null; //Обнуляем корень
            count = 0; //Количество элементов в дереве тоже ноль
        }

        Point<T> MakeTree(T[] array) //Метод для создания дерева на основе массива. Метод рекурсивный
        {
            if (array.Length == 0) //Если в массиве элементов нет, то возвращаем ноль
            {
                return null;
            }
            count++; //Увеличиваем количество на один
            T data = array[0]; //Создаём узел верхнего уровня
            array = array.Skip(1).ToArray(); //Массив с остальными элементами будет распределён ниже
            int lenght = array.Length; //Количество элементов в массиве
            Point<T> newItem = new Point<T>(data, ""); //data записываем в Point
            int nl = lenght / 2; //Количество элементов слева от верхнего узла
            int nr = lenght - nl; //Количество элементов справа от верхнего узла
            T[] segmentNL = new ArraySegment<T>(array, 0, nl).ToArray(); //Срез с элементами, которые идут влево от верхнего узла
            T[] segmentNR = new ArraySegment<T>(array, nl, nr).ToArray(); // Срез с элементами, которые идут справо от верхнего узла
            newItem.Left = MakeTree(segmentNL); //Устанавливаем левую и правую связи для верхнего узла и заоодно рекурсивно создаём поддеревья
            newItem.Right = MakeTree(segmentNR);
            return newItem;
        }

        public int CountingLeafs(Point<T>? point, int count) //Метод для подсчёта листьев в дереве. Метод рекурсивный
        {
            if (point.Right == null && point.Left == null) //Если у узла нет связи ни справа, ни слева, то это лист
            {
                Console.WriteLine(point.Data.ToString()); //Печатаем лист
                return count + 1; //Возвращаем количество увеличенное на один
            }
            if (point.Left != null && point.Right != null) //У точки есть левая и правая ветви
            {
                count = CountingLeafs(point.Left, count); //Запускаем подсчёт листьев в левой ветви
                count = CountingLeafs(point.Right, count); //Запускаем подсчёт листьев в правой ветви
            }
            else if (point.Left != null) //У точки есть левая ветвь, а правой нет.
            {
                count = CountingLeafs(point.Left, count); //Запускаем подсчёт листьев в левой ветви
            }
            else if (point.Right != null) //У точки есть правая ветвь, а левой нет
            {
                count = CountingLeafs(point.Right, count); //Запускаем подсчёт листьев в правой ветви
            }
            return count; //Возвращаем количество
        }

        public void TransformToArray(Point<T>? point, ref T[] array, ref int current) //Рекурсивный метод трансформации дерева в массив. Передаём point - элемент для начала считывания, array по ссылке - сюда записываем элементы, current по ссылке - мндекс для записи элемента в массив
        {
            if (point != null) //Если текущая точка не пустая
            {
                TransformToArray(point.Left, ref array, ref current); //Тогда запускаем этот же метод для левого поддереве
                array[current] = point.Data; //Записываем в массив элемент
                current++; //Индекс увеличиваем
                TransformToArray(point.Right, ref array, ref current); //Запуск этого же метода для правого поддерева
            }
        }
    }
}
