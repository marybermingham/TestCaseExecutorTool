using System;
using System.Collections.Generic;
using System.IO;

class TestCase
{
    public string ID { get; set; }
    public string Description { get; set; }
    public string ExpectedResult { get; set; }
    public string ActualResult { get; set; }
    public string Result { get; set; }
    public string Tester { get; set; }
    public DateTime DateTested { get; set; }

    public override string ToString()
    {
        return $"Test Case ID: {ID}\n" +
               $"Description: {Description}\n" +
               $"Expected Result: {ExpectedResult}\n" +
               $"Actual Result: {ActualResult}\n" +
               $"Result: {Result}\n" +
               $"Tested By: {Tester}\n" +
               $"Date: {DateTested}\n" +
               $"--------------------------------------";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("🧪 Test Case Executor Tool\n");

        var testCases = LoadSampleTestCases();
        var executedCases = new List<TestCase>();

        foreach (var testCase in testCases)
        {
            Console.WriteLine($"Test Case ID: {testCase.ID}");
            Console.WriteLine($"Description: {testCase.Description}");
            Console.WriteLine($"Expected Result: {testCase.ExpectedResult}");

            Console.Write("Enter Actual Result: ");
            testCase.ActualResult = Console.ReadLine();

            Console.Write("Enter Result (PASS/FAIL): ");
            testCase.Result = Console.ReadLine()?.ToUpper();

            Console.Write("Enter your name: ");
            testCase.Tester = Console.ReadLine();

            testCase.DateTested = DateTime.Now;

            executedCases.Add(testCase);

            Console.WriteLine("✅ Test case recorded.\n");
        }

        SaveResultsToFile(executedCases);
        Console.WriteLine("\n📄 Test summary saved to test_summary.txt");
    }

    static List<TestCase> LoadSampleTestCases()
    {
        return new List<TestCase>
        {
            new TestCase
            {
                ID = "TC001",
                Description = "Ensure device powers on within 5 seconds",
                ExpectedResult = "Device powers on in <5s"
            },
            new TestCase
            {
                ID = "TC002",
                Description = "Verify temperature alarm activates at 38°C",
                ExpectedResult = "Alarm activates at 38°C"
            },
            new TestCase
            {
                ID = "TC003",
                Description = "Confirm data logging starts when button is pressed",
                ExpectedResult = "Data logging begins"
            }
        };
    }

    static void SaveResultsToFile(List<TestCase> executedCases)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "test_summary.txt");
        using StreamWriter writer = new StreamWriter(filePath);

        foreach (var testCase in executedCases)
        {
            writer.WriteLine(testCase.ToString());
        }
    }
}
