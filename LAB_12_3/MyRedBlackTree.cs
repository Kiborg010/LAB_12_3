using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAB_12_3
{
    internal class MyRedBlackTree<T> where T : IInit, IComparable, new()
    {
        public Point<T>? root = null;

        public MyRedBlackTree(T[] array)
        {
            root = MakeTree(array);
        }

        public void ShowTree()
        {
            Show2(root);
        }

        void Show1(Point<T>? point, int spaces = 5)
        {
            string m = "<Нет>";
            if (point.ToString() != "")
            {
                if (spaces > 50)
                {
                    throw new Exception("AAAAAAAAAAAAaa");
                }
                Console.WriteLine($"Элемент: {point.Data.ToString()}");
                m = point.Data.ToString();
            }
            if (point.ToString() != "")//point != null )
            {
                
                Console.WriteLine($"Справа от {m}");
                Show1(point.Right, spaces + 5);
                Console.WriteLine($"Слева от {m}");
                Show1(point.Left, spaces + 5);
            }
        }

        void Show2(Point<T>? point, int spaces = 5)
        {
            if (point.ToString() != "")//point != null )
            {
                Show2(point.Right, spaces + 5);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine($"{point.Data.ToString()}  Цвет: {point.Colour}");
                Show2(point.Left, spaces + 5);
            }
        }

        public void Remove(T el)
        {
            Point<T> el1 = new Point<T>(el, "");
            Point<T> el2 = FindElement(root, el1);
            if (el2 == null)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine("Элемент найден");
                if (el2.Left.Data == null && el2.Right.Data == null)
                {
                    Point<T> dad = el2.Parent;
                    if (dad.Left == el2)
                    {
                        dad.Left = new Point<T>();
                    }
                    else if (dad.Right == el2)
                    {
                        dad.Right = new Point<T>();
                    }
                    el2.Parent = null;
                }
            }
        }

        public void Find(T el)
        {
            Point<T> el1 = new Point<T>(el, ""); 
            Point<T> el2 = FindElement(root, el1);
            if (el2 == null)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine("Элемент найден");
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
            else if (comparing == 1)
            {
                Point<T> el = FindElement(current.Left, element);
                return el;
            }
            else
            {
                return null;
            }
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
                if (uncle == null)
                {

                }
                else if (uncle.Colour == "red")
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
                            son.Parent = granddad;
                            granddad.Left = son;
                            son.Left = dad;
                            dad.Parent = son;
                            dad.Right = new Point<T>();

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
                            son.Parent = granddad;
                            granddad.Right = son;
                            son.Right = dad;
                            dad.Parent = son;
                            dad.Left = new Point<T>();

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
                            //Show(root);
                            //Console.WriteLine("\n\n");
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

