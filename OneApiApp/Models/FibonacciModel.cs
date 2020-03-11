using System;
using System.Text;
using OneApiApp.Models.Interface;

namespace OneApiApp.Models
{
    public class FibonacciModel : IFibonacciModel
    {
        public string GetNextFibonacciNumber(int number)
        {
            var str = new StringBuilder("0");
            int firstnumber = 0, secondnumber = 1;
            if (number == 0) return str.ToString();
            str.Append(", 1");
            if (number == 1) return str.ToString(); //To return the second Fibonacci number   
            for (int i = 2; i <= number; i++)
            {
                int result = firstnumber + secondnumber;
                if (result < 0) throw new Exception("The number is too big.");
                str.AppendFormat(", {0}", result.ToString());
                firstnumber = secondnumber;
                secondnumber = result;
            }
            return str.ToString();
        }
    }
}
