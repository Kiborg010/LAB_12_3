using ClassLibrary1;
using LAB_12_3;
using System.Drawing;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
            Car[] array = { car1, car2, car3, car4, car5, car6, car7, car8 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;
            
            Assert.IsTrue(tree.root.Data == car4);
            Assert.IsTrue(root.Left.Data == car2);
            Assert.IsTrue(root.Right.Data == car6);
            Assert.IsTrue(root.Left.Left.Data == car1);
            Assert.IsTrue(root.Left.Right.Data == car3);
            Assert.IsTrue(root.Right.Left.Data == car5);
            Assert.IsTrue(root.Right.Right.Data == car7);
            Assert.IsTrue(root.Right.Right.Right.Data == car8);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Car car1 = new Car();
            car1.id.number = 6;
            Car car2 = new Car();
            car2.id.number = 1;
            Car car3 = new Car();
            car3.id.number = 11;
            Car car4 = new Car();
            car4.id.number = 8;
            Car car5 = new Car();
            car5.id.number = 13;
            Car car6 = new Car();
            car6.id.number = 22;
            Car car7 = new Car();
            car7.id.number = 27;
            Car car8 = new Car();
            car8.id.number = 28;
            Car[] array = { car1, car2, car3, car4, car5, car6, car7, car8 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car3);
            Assert.IsTrue(root.Left.Data == car1);
            Assert.IsTrue(root.Right.Data == car6);
            Assert.IsTrue(root.Left.Left.Data == car2);
            Assert.IsTrue(root.Left.Right.Data == car4);
            Assert.IsTrue(root.Right.Left.Data == car5);
            Assert.IsTrue(root.Right.Right.Data == car7);
            Assert.IsTrue(root.Right.Right.Right.Data == car8);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Car car1 = new Car();
            car1.id.number = 28;
            Car car2 = new Car();
            car2.id.number = 27;
            Car car3 = new Car();
            car3.id.number = 22;
            Car car4 = new Car();
            car4.id.number = 13;
            Car car5 = new Car();
            car5.id.number = 8;
            Car car6 = new Car();
            car6.id.number = 11;
            Car car7 = new Car();
            car7.id.number = 1;
            Car car8 = new Car();
            car8.id.number = 6;
            Car[] array = { car1, car2, car3, car4, car5, car6, car7, car8 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car4);
            Assert.IsTrue(root.Left.Data == car5);
            Assert.IsTrue(root.Right.Data == car2);
            Assert.IsTrue(root.Left.Left.Data == car7);
            Assert.IsTrue(root.Left.Right.Data == car6);
            Assert.IsTrue(root.Right.Left.Data == car3);
            Assert.IsTrue(root.Right.Right.Data == car1);
            Assert.IsTrue(root.Left.Left.Right.Data == car8);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Car car1 = new Car();
            car1.id.number = 8;
            Car car2 = new Car();
            car2.id.number = 11;
            Car car3 = new Car();
            car3.id.number = 13;
            Car car4 = new Car();
            car4.id.number = 1;
            Car car5 = new Car();
            car5.id.number = 22;
            Car car6 = new Car();
            car6.id.number = 6;
            Car car7 = new Car();
            car7.id.number = 27;
            Car car8 = new Car();
            car8.id.number = 28;
            Car[] array = { car1, car2, car3, car4, car5, car6, car7, car8 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car2);
            Assert.IsTrue(root.Left.Data == car6);
            Assert.IsTrue(root.Right.Data == car5);
            Assert.IsTrue(root.Left.Left.Data == car4);
            Assert.IsTrue(root.Left.Right.Data == car1);
            Assert.IsTrue(root.Right.Left.Data == car3);
            Assert.IsTrue(root.Right.Right.Data == car7);
            Assert.IsTrue(root.Right.Right.Right.Data == car8);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Car car1 = new Car();
            car1.id.number = 6;
            Car car2 = new Car();
            car2.id.number = 1;
            Car car3 = new Car();
            car3.id.number = 11;
            Car car4 = new Car();
            car4.id.number = 8;
            Car car5 = new Car();
            car5.id.number = 13;
            Car car6 = new Car();
            car6.id.number = 22;
            Car car7 = new Car();
            car7.id.number = 21;
            Car[] array = { car1, car2, car3, car4, car5, car6, car7};
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car1);
            Assert.IsTrue(root.Left.Data == car2);
            Assert.IsTrue(root.Right.Data == car3);
            Assert.IsTrue(root.Right.Right.Data == car7);
            Assert.IsTrue(root.Right.Left.Data == car4);
            Assert.IsTrue(root.Right.Right.Right.Data == car6);
            Assert.IsTrue(root.Right.Right.Left.Data == car5);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Car car1 = new Car();
            car1.id.number = 22;
            Car car2 = new Car();
            car2.id.number = 13;
            Car car3 = new Car();
            car3.id.number = 8;
            Car car4 = new Car();
            car4.id.number = 11;
            Car car5 = new Car();
            car5.id.number = 1;
            Car car6 = new Car();
            car6.id.number = 6;
            Car[] array = { car1, car2, car3, car4, car5, car6};
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car2);
            Assert.IsTrue(root.Left.Data == car3);
            Assert.IsTrue(root.Right.Data == car1);
            Assert.IsTrue(root.Left.Right.Data == car4);
            Assert.IsTrue(root.Left.Left.Data == car5);
            Assert.IsTrue(root.Left.Left.Right.Data == car6);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Car car1 = new Car();
            car1.id.number = 3;
            Car car2 = new Car();
            car2.id.number = 1;
            Car car3 = new Car();
            car3.id.number = 2;
            Car[] array = { car1, car2, car3};
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car3);
            Assert.IsTrue(root.Left.Data == car2);
            Assert.IsTrue(root.Right.Data == car1);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Car car1 = new Car();
            car1.id.number = 3;
            Car car2 = new Car();
            car2.id.number = 5;
            Car car3 = new Car();
            car3.id.number = 4;
            Car[] array = { car1, car2, car3 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);

            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car3);
            Assert.IsTrue(root.Left.Data == car1);
            Assert.IsTrue(root.Right.Data == car2);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Car car1 = new Car();
            car1.id.number = 6;
            Car car2 = new Car();
            car2.id.number = 22;
            Car car3 = new Car();
            car3.id.number = 27;
            Car car4 = new Car();
            car4.id.number = 1;
            Car car5 = new Car();
            car5.id.number = 11;
            Car car6 = new Car();
            car6.id.number = 15;
            Car car7 = new Car();
            car7.id.number = 25;
            Car car8 = new Car();
            car8.id.number = 8;
            Car car9 = new Car();
            car9.id.number = 17;
            Car car10 = new Car();
            car10.id.number = 13;
            Car[] array = { car1, car2, car3, car4, car5, car6, car7, car8, car9, car10 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);
            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car5);
            Assert.IsTrue(root.Left.Data == car1);
            Assert.IsTrue(root.Right.Data == car2);
            Assert.IsTrue(root.Left.Left.Data == car4);
            Assert.IsTrue(root.Left.Right.Data == car8);
            Assert.IsTrue(root.Right.Left.Data == car6);
            Assert.IsTrue(root.Right.Right.Data == car3);
            Assert.IsTrue(root.Right.Left.Left.Data == car10);
            Assert.IsTrue(root.Right.Left.Right.Data == car9);
            Assert.IsTrue(root.Right.Right.Left.Data == car7);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Car car1 = new Car();
            car1.id.number = 20;
            Car car2 = new Car();
            car2.id.number = 25;
            Car[] array = { car1, car2, car1, car2};
            string message = "";
            try
            {
                MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual(message, "В переданном массиве есть повторяющиеся элементы. В дереве все элементы должны быть уникальны");
        }

        [TestMethod]
        public void TestMethod11()
        {
            Car car1 = new Car();
            car1.id.number = 25;
            Car car2 = new Car();
            car2.id.number = 25;
            Car car3 = new Car();
            car3.id.number = 30;
            Car car4 = new Car();
            car4.id.number = 20;
            Car[] array = { car1, car2, car3, car4};
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);
            Point<Car> root = tree.root;

            Assert.IsTrue(tree.root.Data == car1);
            Assert.IsTrue(root.Left.Data == car4);
            Assert.IsTrue(root.Right.Data == car3);
        }

        [TestMethod]
        public void TestMethod12()
        {
            Car car1 = new Car();
            car1.id.number = 25;
            Car car2 = new Car();
            car2.id.number = 30;
            Car car3 = new Car();
            car3.id.number = 20;
            Car car4 = new Car();
            car4.id.number = 40;
            Car[] array = { car1, car2, car3 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);
            Point<Car> root = tree.root;
            string message = tree.Find(car4);
            Assert.AreEqual(message, "Элемент не найден");
        }

        [TestMethod]
        public void TestMethod13()
        {
            Car car1 = new Car();
            car1.id.number = 25;
            Car car2 = new Car();
            car2.id.number = 30;
            Car car3 = new Car();
            car3.id.number = 20;
            Car car4 = new Car();
            car4.id.number = 40;
            Car[] array = { car1, car2, car3, car4 };
            MyRedBlackTree<Car> tree = new MyRedBlackTree<Car>(array);
            Point<Car> root = tree.root;
            string message = tree.Find(car4);
            Assert.AreEqual(message, "Элемент найден");
        }

        [TestMethod]
        public void TestMethod14()
        {
            string message = "";
            try
            {
                MyTree<Car> tree = new MyTree<Car>(-1);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Console.WriteLine(message);
            Assert.AreEqual(message, "Количество элементов в дереве не может быть меньше нуля");
        }

        [TestMethod]
        public void TestMethod15()
        {
            string message = "";
            MyTree<Car> tree = new MyTree<Car>(0);
            Assert.AreEqual(tree.root, null);
        }
    }
}