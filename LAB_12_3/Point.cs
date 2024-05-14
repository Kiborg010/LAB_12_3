using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12_3
{
    public class Point<T> where T: IComparable //Класс для точки-узла для использования в ИСД и КЧД
    {
        public T? Data { get; set; } //Данные в точке
        public Point<T>? Left { get; set; } //Левая связь. Ссылка на точку слева на уровень ниже
        public Point<T>? Right { get; set; } //Правая связь. Ссылка на точку справа на уровень ниже
        public Point<T>? Parent { get; set; } //Родительская связь. Ссылка на точку выше. Справа или слева в данном случае неважно

        public string colour; 
        public string? Colour //Свойство для определения цвета
        {
            get
            {
                return colour;
            }
            set
            {
                if (value == "red") //Цвет может быть либо красный, либо чёрный, либо никакой
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

        public Point() //Конструктор без параметров
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
            this.Colour = "black";
            this.Parent = null;
        }

        public Point(T data, string colour) //Конструктор с параметрами
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
            this.Colour = colour;
            this.Parent = null;
        }

        public override string? ToString() //Метод для печати точки
        {
            if (Data == null)
            {
                return "";
            }
            else
            {
                return Data.ToString(); //Печатаем информацию внутри точки
            }
        }

        public int CompareTo(Point<T> other) //Метод для сравнения точек
        {
            return Data.CompareTo(other.Data); //Сравниваются информации внутри точек
        }
    }
}
