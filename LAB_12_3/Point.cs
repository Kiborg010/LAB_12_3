using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12_3
{
    public class Point<T> where T: IComparable
    {
        public T? Data { get; set; }
        public Point<T>? Left { get; set; }
        public Point<T>? Right { get; set; }
        public Point<T>? Parent { get; set; }

        public string colour;
        public string? Colour 
        {
            get
            {
                return colour;
            }
            set
            {
                if (value == "red")
                {
                    colour = "red";
                }
                else if (value == "black")
                {
                    colour = "black";
                }
                else
                {
                    colour = null;
                }
            }
        }

        public Point()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
            this.Colour = "black";
            this.Parent = null;
        }

        public Point(T data, string colour)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
            this.Colour = colour;
            this.Parent = null;
        }

        public override string? ToString()
        {
            if (Data == null)
            {
                return "";
            }
            else
            {
                return Data.ToString();
            }
        }

        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}
