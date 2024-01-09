using System;
using Methods;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Method Arr1 = new Method();
            
            Arr1.Fill();
            Arr1.Show();

            float sum = Arr1.AToB(2, 5);

            float from = Arr1.FromAToB(2, 5);
            
            float sumMax = Arr1.SumAfterMax();
            Console.Write(sum+"  "+sumMax+"  "+from);

        }
    }
}
