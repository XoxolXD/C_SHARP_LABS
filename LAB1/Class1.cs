using System;
using System.Linq;

namespace Methods
{
    public class Method
    {
        Random rnd = new Random();
        int N = 12;
        float sum;
        float[] Array;
        
        public Method()
        {
            Array = new float[N];
        }
        
        public void Fill()
        {
            for (int i = 0; i < N; i++)
            {
                Array[i] = rnd.Next(0, 10);
                
            }
            
        }

        public void Show()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine();
            
        }

        public float FromAToB(int A, int B)
        {
            return B - A;

        }
        public float AToB(int A,int B)
        {
            for (int i = 0; i < N; i++)
            {
                if (B >= Array[i] && A <= Array[i])
                {
                    sum++;
                }
            }
            return sum;
        }

        public float SumAfterMax()
        {
            float maxVal = Array.Max();
            int indexMax = Array.ToList().IndexOf(maxVal);
            float sumAfterMax = 0;
            
            for (int i = indexMax + 1; i < N; i++)
            {
                sumAfterMax += Array[i];
            }
            
            return sumAfterMax;
        }
    }
}