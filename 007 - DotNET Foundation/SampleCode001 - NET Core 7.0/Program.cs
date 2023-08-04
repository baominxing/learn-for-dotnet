using Python.Runtime;

namespace SampleCode001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var execute_obj = new SampleCode20230804();

                execute_obj.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("按任意键结束");

            Console.ReadKey();
        }
    }
}