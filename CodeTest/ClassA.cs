using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    public class ClassA
    {
        private readonly IClassB _classB;

        public ClassA(IClassB classB)
        {
            _classB = classB;
        }

        public double Square(double value)
        {
            return value * value;
        }

        public void DoSomething()
        {
            _classB.DoSomething(5);
        }

        public int ReturnSomething()
        {
            return _classB.ReturnSomething();
        }
    }
}
