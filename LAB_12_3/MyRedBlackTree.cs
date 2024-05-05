using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAB_12_3
{
    public class MyRedBlackTree<T> where T : IInit, IComparable, new()
    {
        public Point<T>? root = null;

        public int count = 0;
        public int Count => count;

        public MyRedBlackTree(T[] array)
        {
            root = MakeTree(array);
        }

        public void ShowTree()
        {
            if (root == null)
            {
                throw new Exception("Дерево пустое");
            }
            Show(root);
        }

        void Show(Point<T>? point, int spaces = 5)
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

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public string Find(T el)
        {
            Point<T> el1 = new Point<T>(el, ""); 
            Point<T> el2 = FindElement(root, el1);
            if (el2 == null)
            {
                return "Элемент не найден";
            }
            else
            {
                return "Элемент найден";
            }
        }

        Point<T> FindElement(Point<T> current, Point<T> element)
        {
            if (current.Data == null)
            {
                return null;
            }
            int comparing = current.Data.CompareTo(element.Data);
            if (comparing == -1)
            {
                Point<T> el = FindElement(current.Right, element);
                return el;
            }
            else if (comparing == 0)
            {
                return current;
            }
            Point<T> el1 = FindElement(current.Left, element);
            return el1;
        }

        Point<T> FindUncle(Point<T> son)
        {
            Point<T> dad = son.Parent;
            if (dad == null)
            {
                return null;
            }
            Point<T> granddad = dad.Parent;
            Point<T> uncle;
            if (granddad == null)
            {
                return null;
            }
            if (granddad.Left == dad)
            {
                uncle = granddad.Right;
            }
            else
            {
                uncle = granddad.Left;
            }
            return uncle;
        }

        void Change(Point<T> current, Point<T> uncle)
        {
            if (current.Colour == "red" && current.Parent.Colour == "black")
            {

            }
            else if (current.Colour == "red" && current.Parent.Colour == "red")
            {
                if (uncle.Colour == "red")
                {
                    current.Parent.Colour = "black";
                    uncle.Colour = "black";
                    if (current.Parent.Parent.Parent != null)
                    {
                        current.Parent.Parent.Colour = "red";
                    }
                }
                else if (uncle.Colour == "black")
                {
                    Point<T> son = current;
                    Point<T> dad = current.Parent;
                    Point<T> granddad = current.Parent.Parent;
                    Point<T> grandgranddad = current.Parent.Parent.Parent;
                    if (granddad.Left == dad)
                    {
                        if (dad.Right == son)
                        {
                            Point<T> preson = son.Left;
                            dad.Right = preson;
                            preson.Parent = dad;

                            son.Parent = granddad;
                            granddad.Left = son;
                            son.Left = dad;
                            dad.Parent = son;

                            Point<T> brother = son.Right;
                            son.Right = granddad;
                            granddad.Parent = son;
                            granddad.Left = brother;
                            brother.Parent = granddad;
                            son.Parent = grandgranddad;

                            son.Colour = "black";
                            granddad.Colour = "red";

                            if (grandgranddad != null)
                            {
                                if (grandgranddad.Right == granddad)
                                {
                                    grandgranddad.Right = son;
                                }
                                else if (grandgranddad.Left == granddad)
                                {
                                    grandgranddad.Left = son;
                                }
                            }
                            else if (grandgranddad == null)
                            {
                                root = son;
                            }
                        }
                        else if (dad.Left == son)
                        {
                            Point<T> brother = dad.Right;
                            dad.Right = granddad;
                            granddad.Parent = dad;
                            granddad.Left = brother;
                            brother.Parent = granddad;
                            dad.Parent = grandgranddad;

                            dad.Colour = "black";
                            granddad.Colour = "red";

                            if (grandgranddad != null)
                            {
                                if (grandgranddad.Right == granddad)
                                {
                                    grandgranddad.Right = dad;
                                }
                                else if (grandgranddad.Left == granddad)
                                {
                                    grandgranddad.Left = dad;
                                }
                            }
                            else if (grandgranddad == null)
                            {
                                root = dad;
                            }
                        }
                    }
                    else if (granddad.Right == dad)
                    {
                        if (dad.Left == son)
                        {
                            Point<T> preson = son.Right;
                            dad.Left = preson;
                            preson.Parent = dad;

                            son.Parent = granddad;
                            granddad.Right = son;
                            son.Right = dad;
                            dad.Parent = son;

                            Point<T> brother = son.Left;
                            son.Left = granddad;
                            granddad.Parent = son;
                            granddad.Right = brother;
                            brother.Parent = granddad;
                            son.Parent = grandgranddad;

                            son.Colour = "black";
                            granddad.Colour = "red";

                            if (grandgranddad != null)
                            {
                                if (grandgranddad.Right == granddad)
                                {
                                    grandgranddad.Right = son;
                                }
                                else if (grandgranddad.Left == granddad)
                                {
                                    grandgranddad.Left = son;
                                }
                            }
                            else if (grandgranddad == null)
                            {
                                root = son;
                            }
                        }
                        else if (dad.Right == son)
                        {
                            Point<T> brother = dad.Left;
                            dad.Left = granddad;
                            granddad.Parent = dad;
                            granddad.Right = brother;
                            brother.Parent = granddad;
                            dad.Parent = grandgranddad;

                            dad.Colour = "black";
                            granddad.Colour = "red";

                            if (grandgranddad != null)
                            {
                                if (grandgranddad.Right == granddad)
                                {
                                    grandgranddad.Right = dad;
                                }
                                else if (grandgranddad.Left == granddad)
                                {
                                    grandgranddad.Left = dad;
                                }
                            }
                            else if (grandgranddad == null)
                            {
                                root = dad;
                            }
                        }
                    }
                }
                if (current.Parent != null && current.Parent.Parent != null) 
                {
                    Change(current.Parent.Parent, FindUncle(current.Parent.Parent));
                }
            }
        }

        Point<T> MakeTree(T[] array)
        {
            if (array.Length == 0)
            {
                return null;
            }
            if (array.Distinct().Count() != array.Length)
            {
                throw new Exception("В переданном массиве есть повторяющиеся элементы. В дереве все элементы должны быть уникальны");
            }
            Point<T> begin = new Point<T>(array[0], "black");
            root = begin;
            begin.Left = new Point<T>();
            begin.Right = new Point<T>();
            array = array.Skip(1).ToArray();
            foreach (T el in array)
            {
                Point<T> newItem = new Point<T>(el, "red");

                Point<T> check = FindElement(root, newItem);
                if (check != null)
                {
                    Console.WriteLine($"Элемент {newItem.Data.ToString()} не может быть добавлен, так как он уже есть в дереве");
                }
                else
                {
                    Point<T> current = root;
                    Point<T> previous = root;
                    bool flag = false;
                    int n = 0;
                    while (!flag)
                    {
                        if (current.ToString() == "")
                        {
                            current = newItem;
                            current.Parent = previous;
                            current.Left = new Point<T>();
                            current.Right = new Point<T>();

                            Point<T> uncle = FindUncle(current);

                            if (n < 0)
                            {
                                previous.Left = newItem;
                            }
                            else if (n > 0)
                            {
                                previous.Right = newItem;
                            }

                            Change(current, uncle);
                            flag = true;
                            count++;
                        }
                        else if (newItem.Data.CompareTo(current.Data) < 0)
                        {
                            previous = current;
                            current = current.Left;
                            n = -1;
                        }
                        else if (newItem.Data.CompareTo(current.Data) > 0)
                        {
                            previous = current;
                            current = current.Right;
                            n = 1;
                        }
                    }
                }
            }
            return root;
        }
    }
}

