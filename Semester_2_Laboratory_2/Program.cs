using System;
using System.IO;
using System.Text.Json;

namespace Semester_2_Laboratory_2
{
    class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }
        public Vector(double X = 0, double Y = 0, double Z = 0)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Vector(Vector vector)
        {
            this.X = vector.X;
            this.Y = vector.Y;
            this.Z = vector.Z;
        }

        public static Vector SumOfVectors(Vector firstVector, Vector secondVector)
        {
            return firstVector + secondVector;
        }

        public static Vector SubtractionOfVectors(Vector firstVector, Vector secondVector)
        {
            return firstVector - secondVector;
        }

        public static double ScalarProductOfVectors(Vector firstVector, Vector secondVector)
        {
            return firstVector * secondVector;
        }

        public static double cosOfTheAngleBetweenTheVectors(Vector firstVector, Vector secondVector)
        {
            return (firstVector * secondVector) / (firstVector.GetLength() * secondVector.GetLength());
        }

        public double GetLength()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            return new Vector(firstVector.X + secondVector.X, firstVector.Y + secondVector.Y, firstVector.Z + secondVector.Z);
        }

        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            return new Vector(firstVector.X - secondVector.X, firstVector.Y - secondVector.Y, firstVector.Z - secondVector.Z);
        }

        public static double operator *(Vector firstVector, Vector secondVector)
        {
            return (firstVector.X * secondVector.X + firstVector.Y * secondVector.Y + firstVector.Z * secondVector.Z);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector firstVector = new Vector(2.5, -1.9, 4);
            Vector secondVector = new Vector(0.5, 7, -9.1);

            Vector SumOfVectors = firstVector + secondVector;
            Vector SumOfVectors2 = Vector.SumOfVectors(firstVector, secondVector);

            Vector SubtractionOfVectors = firstVector - secondVector;
            Vector SubtractionOfVectors2 = Vector.SubtractionOfVectors(firstVector, secondVector);

            double ScalarProductOfVectors = secondVector * firstVector;
            double ScalarProductOfVectors2 = Vector.ScalarProductOfVectors(firstVector, secondVector);

            double cos = Vector.cosOfTheAngleBetweenTheVectors(firstVector, secondVector);

            Console.WriteLine("\tFirst vector:");
            Console.WriteLine($"X = {firstVector.X}, Y = {firstVector.Y}, Z = {firstVector.Z}");
            Console.WriteLine($"Length = {firstVector.GetLength()}\n");

            Console.WriteLine("\tSecond vector:");
            Console.WriteLine($"X = {secondVector.X}, Y = {secondVector.Y}, Z = {secondVector.Z}");
            Console.WriteLine($"Length = {secondVector.GetLength()}\n");

            Console.WriteLine("\tSum of vectors:");
            Console.WriteLine($"X = {SumOfVectors.X}, Y = {SumOfVectors.Y}, Z = {SumOfVectors.Z}");
            Console.WriteLine($"Length of the resulting vector = {SumOfVectors.GetLength()}\n");

            Console.WriteLine("\tSubtraction of vectors:");
            Console.WriteLine($"X = {SubtractionOfVectors.X}, Y = {SubtractionOfVectors.Y}, Z = {SubtractionOfVectors.Z}");
            Console.WriteLine($"Length of the resulting vector = {SubtractionOfVectors.GetLength()}\n");

            Console.WriteLine("\tScalar product of vectors:");
            Console.WriteLine($"X = {ScalarProductOfVectors}\n");

            Console.WriteLine("\tCos of the angle between the vectors:");
            Console.WriteLine($"X = {cos}\n");

            string writeToJsonFirstVector = JsonSerializer.Serialize(firstVector);
            File.WriteAllText("firstVector.json", writeToJsonFirstVector);

            string readFromJsonFirstVector = File.ReadAllText("firstVector.json");
            Vector? firstVectorFromJson = JsonSerializer.Deserialize<Vector>(readFromJsonFirstVector);

            string writeToJsonSecondVector = JsonSerializer.Serialize(secondVector);
            File.WriteAllText("secondVector.json", writeToJsonSecondVector);

            string readFromJsonSecondVector = File.ReadAllText("secondVector.json");
            Vector secondVectorFromJson = JsonSerializer.Deserialize<Vector>(readFromJsonSecondVector);

            Console.WriteLine("\tFirst vector from JSON:");
            Console.WriteLine($"X = {firstVectorFromJson.X}, Y = {firstVectorFromJson.Y}, Z = {firstVectorFromJson.Z}");
            Console.WriteLine($"Length = {firstVectorFromJson.GetLength()}\n");

            Console.WriteLine("\tSecond vector from JSON:");
            Console.WriteLine($"X = {secondVectorFromJson.X}, Y = {secondVectorFromJson.Y}, Z = {secondVectorFromJson.Z}");
            Console.WriteLine($"Length = {secondVectorFromJson.GetLength()}\n");
        }
    }
}