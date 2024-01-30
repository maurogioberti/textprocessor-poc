using NUnit.Engine;
using System.Xml;

namespace Poc.TextProcessor.IntegrityAssurance.Runner
{
    class Program
    {
        private const string TestProjectAssemblyName = "Poc.TextProcessor.IntegrityAssurance.Tests.dll";
        private const string TestNameSpaces = "Poc.TextProcessor.IntegrityAssurance.Tests.Endpoints";
        private const string MainNameSpace = "Endpoints";

        static void Main(string[] args)
        {
            var testPackage = new TestPackage(TestProjectAssemblyName);

            using (var engine = TestEngineActivator.CreateInstance())
            {
                engine.Initialize();

                var runner = engine.GetRunner(testPackage);

                // Run all the tests
                var results = runner.Run(null, TestFilter.Empty);

                // Log the results to the console
                LogResultsToConsole(results);
            }
        }

        private static void LogResultsToConsole(XmlNode resultNode)
        {
            PrintHeader();

            var nodes = new Stack<XmlNode>();
            nodes.Push(resultNode);

            while (nodes.Count > 0)
            {
                XmlNode node = nodes.Pop();
                ProcessNode(node);

                foreach (XmlNode childNode in node.ChildNodes)
                    nodes.Push(childNode);
            }

            PrintFooter(resultNode);
        }

        private static void ProcessNode(XmlNode node)
        {
            if (node.Name == "test-suite" || node.Name == "test-run")
                PrintTestSuiteSummary(node);

            if (node.Name == "test-case")
                PrintTestCaseResult(node);
        }

        private static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("HTTP Status Code Verification for API Endpoints");
            Console.WriteLine("Note: These tests validate the HTTP response status codes and basic response structures.");
            Console.WriteLine("The primary goal is to ensure API endpoints are behaving as documented (e.g., in Swagger).");
            Console.WriteLine("Detailed logic testing should be performed separately in unit tests.");
            Console.WriteLine(new string('=', 80));
            Console.ResetColor();
        }

        private static void PrintFooter(XmlNode resultNode)
        {
            var total = resultNode.SelectNodes(".//test-case").Count;
            var passed = resultNode.SelectNodes(".//test-case[@result='Passed']").Count;
            var failed = resultNode.SelectNodes(".//test-case[@result='Failed']").Count;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("Test Run Summary");
            Console.WriteLine($"Total Tests: {total}, Passed: {passed}, Failed: {failed}");
            Console.WriteLine(new string('=', 80));
            Console.ResetColor();
        }

        private static void PrintTestSuiteSummary(XmlNode testSuiteNode)
        {
            var fullname = testSuiteNode.Attributes["fullname"]?.Value;

            // Check if the test suite is part of the 'Endpoints' namespace
            if (!fullname.StartsWith(TestNameSpaces))
                return;

            var name = testSuiteNode.Attributes["name"]?.Value;
            var result = testSuiteNode.Attributes["result"]?.Value;
            var passed = testSuiteNode.SelectNodes(".//test-case[@result='Passed']").Count;
            var failed = testSuiteNode.SelectNodes(".//test-case[@result='Failed']").Count;
            var total = testSuiteNode.SelectNodes(".//test-case").Count;

            Console.ForegroundColor = name == MainNameSpace ? ConsoleColor.DarkGreen : ConsoleColor.Cyan;
            Console.WriteLine($"Test Suite: {name}");
            Console.WriteLine($"Result: {result}, Total: {total}, Passed: {passed}, Failed: {failed}");
            Console.ResetColor();
        }

        private static void PrintTestCaseResult(XmlNode testCaseNode)
        {
            var testName = testCaseNode.Attributes["fullname"]?.Value;
            var result = testCaseNode.Attributes["result"]?.Value;
            var duration = testCaseNode.Attributes["duration"]?.Value;
            var asserts = testCaseNode.Attributes["asserts"]?.Value;

            Console.ForegroundColor = result == "Passed" ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Test Case: {testName}");
            Console.WriteLine($"Result: {result}, Duration: {duration}s, Asserts: {asserts}");
            Console.ResetColor();
        }
    }
}