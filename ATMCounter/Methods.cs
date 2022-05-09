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

            try
            {
                if (inputDouble < 0)
                {
                    throw new NegativeNumberException("Input Value shouldn't be Negative!!");
                }
            }
            catch (NegativeNumberException nx)
            {
                WriteLine(nx.Message);
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
            try
            {
                if (inputInt < 0)
                {
                    throw new NegativeNumberException("Input Value shouldn't be Negative!!");
                }
            }
            catch (NegativeNumberException nx)
            {
                WriteLine(nx.Message);
            }
            return inputInt;
        }

        //Validate Float number input
        public static float ValidFloat(float inputFloat, string message)
        {
            try
            {
                WriteLine(message);
                inputFloat = float.Parse(ReadLine());
            }
            catch (Exception)
            {
                WriteLine($"Please entre a valid Int number!!!");
                return ValidFloat(inputFloat, message);
            }
            try
            {
                if (inputFloat < 0 )
                {
                    inputFloat = 0.0f;
                    throw new NegativeNumberException("Input Value shouldn't be Negative!!");
                }
                else if (inputFloat > 0.09f || inputFloat < 0.0001f)
                {
                    inputFloat = 0.0f;
                    throw new NegativeNumberException("Input Value should between 0.0001 - 0.09");
                }
            }
            catch (NegativeNumberException nx)
            {
                WriteLine(nx.Message);
            }
            return inputFloat;
        }

        //Input double Amount Limit
        public static double MaxValue (double inputDouble, string message, double maxvalue)
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

            try
            {
                if (inputDouble < 0)
                {
                    throw new NegativeNumberException("Input Value shouldn't be Negative!!");
                }
                else if (inputDouble > maxvalue)
                {
                    throw new NegativeNumberException($"The Max input value is {maxvalue}");
                }
            }
            catch (NegativeNumberException nx)
            {
                WriteLine(nx.Message);
            }

            return inputDouble;

        }
    }
}
