using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeyroN
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;

            public decimal LastError { get; private set; }

            public decimal Smoothing { get; set; } = 0.0000005m;

            public decimal ProcessInputData(decimal input)
            {
                return input * weight; 
            }

            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }
        }
        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();

            int i = 0;
            do
            {
                i++;

                neuron.Train(km, miles);
                if (i % 100000 == 0)
                {
                    Console.WriteLine($"iteracia: {i}\tshecdoma:\t{neuron.LastError}");
                }

            }while ( neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("swavla damtavrebulia");

            Console.WriteLine($"{neuron.ProcessInputData(100)} mili {100} kilometria");

            Console.WriteLine($"{neuron.ProcessInputData(541)} mili {541} kilometria");

            Console.WriteLine($"{neuron.ProcessInputData(10)} kilometri {10} milia");

            Console.ReadLine();
        }
    }
}
