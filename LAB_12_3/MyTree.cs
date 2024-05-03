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
    internal class MyTree<T> where T : IInit, IComparable, new()
    {
        public Point<T>? root = null;
        int count = 0;
        public int Count => count;
        public MyTree(int lenght)
        {
            count = lenght;
            root = MakeTree(lenght, root);
        }

        public void ShowTree()
        {
            Show(root);
        }

        Point<T> MakeTree(int lenght, Point<T>? point)
        {
            if (lenght < 0)
            {
                throw new Exception("Количество элементов в дереве не может быть меньше нуля");
            }
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data, "");
            if (lenght == 0)
            {
                return null;
            }
            int nl = lenght / 2;
            int nr = lenght - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }

        public int CountingLeaps(Point<T>? point, int count)
        {
            if (point.Right == null && point.Left == null)
            {
                Console.WriteLine(point.Data.ToString());
                return count + 1;
            }
            if (point.Left != null && point.Right != null)
            {
                count = CountingLeaps(point.Left, count);
                count = CountingLeaps(point.Right, count);
            }
            else if (point.Left != null)
            {
                count = CountingLeaps(point.Left, count);
            }
            else if (point.Right != null)
            {
                count = CountingLeaps(point.Right, count);
            }
            return count;
        }

        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(point.Data.ToString());
                Show(point.Right, spaces + 5);
            }
        }

        void AddPoint(T data)
        {
            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;
            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else
                {
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
            }
            if (isExist)
            {
                return;
            }
            Point<T> newPoint = new Point<T>(data, "");
            if (current.Data.CompareTo(data) < 0)
            {
                current.Left = newPoint;
            }
            else
            {
                current.Right = newPoint;
            }
            count++;
        }

        public void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);
            root = new Point<T>(array[0], "");
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }
    }
}
