using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace ATMCounter
{

    public static class Methods
    {
        //Validate double number inpunt
        public static double ValidDouble(double inputDouble, string message)
        {
            try
            {
                WriteLine(message);
                inputDouble = ToDouble(ReadLine());
            }
            catch (Exception)
            {
                WriteLine($"Please entre a valid Double number!!!");
                return ValidDouble(inputDouble, message);
            }
            return inputDouble;
        }

        //Validate int number input
        public static int ValidInt(int inputInt, string message)
        {
            try
            {
                WriteLine(message);
                inputInt = ToInt32(ReadLine());
            }
            catch (Exception)
            {
                WriteLine($"Please entre a valid Int number!!!");
                return ValidInt(inputInt, message);
            }
            return inputInt;
        }
    }
}
