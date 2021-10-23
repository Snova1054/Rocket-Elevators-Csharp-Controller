using System;
namespace Commercial_Controller
{
    public class Program
    {
        static void Main(string[] args)
        {
            int scenarioNumber = Int32.Parse(args[0]);
            Scenarios scenarios = new Scenarios();
            scenarios.run(scenarioNumber);
        }
    }
}
