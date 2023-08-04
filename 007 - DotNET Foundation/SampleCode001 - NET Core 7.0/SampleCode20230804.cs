using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace SampleCode001
{
    internal class SampleCode20230804 : SampleCodeBase
    {
        public override void Description()
        {
            Console.WriteLine("演示在NET中调用Python库");
        }

        public override void Execute()
        {
            this.Description();

            Runtime.PythonDLL = @"E:\Python\Python311\python311.dll";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                Console.WriteLine(np.cos(np.pi * 2));

                dynamic sin = np.sin;
                Console.WriteLine(sin(5));

                double c = (double)(np.cos(5) + sin(5));
                Console.WriteLine(c);

                dynamic a = np.array(new List<float> { 1, 2, 3 });
                Console.WriteLine(a.dtype);

                dynamic b = np.array(new List<float> { 6, 5, 4 }, dtype: np.int32);
                Console.WriteLine(b.dtype);

                Console.WriteLine(a * b);
                Console.ReadKey();
            }
        }
    }
}
