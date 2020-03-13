using System;

namespace practice0306
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            Random rand = new Random();

            double area_ = 0;
            int x = 0;
            for (int i = 0; i < 10; i++)
            {
                var num = rand.Next(0, 4);

                switch (num)
                {
                    case 0:
                        Circle a = new Circle(rand.Next(1, 10));
                        if (a.Judge()) area_ += a.Area();
                        else
                        {
                            x = 1;
                            Console.WriteLine("随机生成的圆形半径错误");
                        }
                        break;//0是圆形
                    case 1:
                        Triangle b = new Triangle(rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10));
                        if (b.Judge()) area_ += b.Area();
                        else
                        {
                            x = 1;
                            Console.WriteLine("随机生成的三角形三边长错误");
                        }
                        break;//1是三角形
                    case 2:
                        Rectangle c = new Rectangle();
                        c.length = rand.Next(1, 10); c.width = rand.Next(1, 10);
                        if (c.Judge()) area_ += c.Area();
                        else
                        {
                            x = 1;
                            Console.WriteLine("随机生成的长方形长宽错误");
                        }
                        break;//2是长方形
                    case 3:
                        Square d = new Square(rand.Next(1, 10));
                        if (d.Judge()) area_ += d.Area();
                        else
                        {
                            x = 1;
                            Console.WriteLine("随机生成的正方形边长错误");
                        }
                        break;//3是正方形
                    default:
                        Console.WriteLine("随机数错误");
                        x = 1;
                        break;
                }

                if (x == 1)
                {
                    Console.WriteLine("随机生成图形时错误");
                    break;
                }

            }
            if (x == 0)
            {
                Console.WriteLine("随机生成的十个图形的总面积是" + area_);
            }
        }
    }

    interface Type
    {
        double Area();
        bool Judge();
    }
    class Triangle : Type
    {
        private double side_1, side_2, side_3;

        public Triangle(double side_1, double side_2, double side_3)
        {
            this.side_1 = side_1;
            this.side_2 = side_2;
            this.side_3 = side_3;
        }
        public double Area()
        {
            double p = (side_1 + side_2 + side_3) / 2;
            return System.Math.Sqrt(p * (p - side_1) * (p - side_2) * (p - side_3));
        }
        public bool Judge()
        {
            if (side_1 + side_2 > side_3 && side_3 + side_2 > side_1 && side_1 + side_3 > side_2) return true;
            else return false;
        }
    }

    class Rectangle : Type
    {
        public double length { set; get; }
        public double width { set; get; }


        public double Area()
        {
            return this.length * this.width;
        }
        public bool Judge()
        {
            if (length > 0 && width > 0 && length >= width) return true;
            else return false;
        }
    }
    class Circle : Type
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double Area()
        {
            return this.radius * this.radius * 3.14;
        }
        public bool Judge()
        {
            if (radius > 0) return true;
            else return false;
        }
    }
    class Square : Rectangle
    {
        public Square(double SideLength)
        {
            base.length = SideLength;
            base.width = SideLength;
        }
        new public bool Judge()
        {
            if (length > 0) return true;
            else return false;
        }
    }

}
