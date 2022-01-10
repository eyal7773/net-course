using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prototype Example.");
            // the "regular" way - clone by constructor
            Point p1 = new Point(4.0f, 5.1f);

            // creating a copy (clone)
            Point p1_clone = new Point(p1.X, p1.Y);

            // ------------------- step 2 
            // ------------------- we want to do it more easy, more generics.
            // 1. Create inteface
            // 2. implement clone method
            Point_1 p2 = new Point_1(4.0f, 5.1f);

            Point_1 p2clone = p2.Clone();

            // -------------------- step 3
            // generate problem when tring to clone reference object.
            Point_1 p4 = new Point_1(4.0f, 5.1f);
            Point_1 p5 = new Point_1(9.18f, 3.04f);

            Line l1 = new Line(p4, p5);
            Line l2 = l1.Clone();

            l1.P1.X = 4.5f;

            Console.WriteLine(l2.P1.X); // will print 4.5  ... 

            // Problem - ref type 
            // Problem - deep copy VS shallow copy
            // Explain - Ref type VS value type.
            // How to solve ? 
            // When cloning - clone all the hirarchy!
            // ---------------------------- step 4

            NewLine l3 = new NewLine(p4, p5);
            NewLine l4 = l3.Clone();

            l3.P1.X = 6.0f;
            l4.P1.X = 5.0f;

            Console.WriteLine(l3.P1.X); 
            Console.WriteLine(l4.P1.X);

            // Practices
            // Don't use IClonable : because it returns object, that you must cast, and it's not generics.
            // Same for MemberwiseClone


            // Serialize solution.
            // Explain what is serialize & deserialize.
            NewLine afterSerialized = DeepCopy<NewLine>(l3);
            l3.P1.X = 77.0f;
            afterSerialized.P1.X = 88.0f;
            Console.WriteLine(l3.P1.X);
            Console.WriteLine(afterSerialized.P1.X);

        }

        public static T DeepCopy<T>(T self)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(self);
            T obj = System.Text.Json.JsonSerializer.Deserialize<T>(json);
            return obj;
        }
    }

    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
    // ------------------- step 2 
    // ------------------- step 2 
    // ------------------- step 2 
    // ------------------- step 2 
    public interface Proto<T>
    {
        T Clone();
    }

    class Point_1 : Proto<Point_1>
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point_1(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point_1 Clone()
        {
            // create a copy of this object 
            Point_1 clone = new Point_1(this.X, this.Y);

            // return the clone
            return clone;
        }
    }

    // ---------------step 3
    class Line : Proto<Line>
    {
        public Point_1 P1 { get; set; }
        public Point_1 P2 { get; set; }

        public Line Clone()
        {
            // create a copy of this object 
            Line clone = new Line(this.P1, this.P2);

            // return the clone
            return clone;
        }

        public Line(Point_1 p1, Point_1 p2)
        {
            P1 = p1;
            P2 = p2;
        }
    }

    // ---------------------------- step 4
    // ---------------------------- step 4
    // ---------------------------- step 4
    // ---------------------------- step 4
    [Serializable]
    class NewLine : Proto<NewLine>
    {
        public Point_1 P1 { get; set; }
        public Point_1 P2 { get; set; }

        public NewLine Clone()
        {
            // create a copy of this object 
            NewLine clone = new NewLine(this.P1.Clone(), this.P2.Clone());
                              // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                              // We clone each point.
                              // NOT reffer to it.
            // return the clone
            return clone;
        }

        public NewLine(Point_1 p1, Point_1 p2)
        {
            P1 = p1;
            P2 = p2;
        }
    }


}
