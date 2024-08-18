using Microsoft.EntityFrameworkCore;
using Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework;
using System.Diagnostics;

namespace Poc.TextProcessor.Presentation.RestApi.IntegrityAssurance
{
    public static class IntegrityAssuranceInitializer
    {
        private const string EnvironmentVariableExecutionMode = "ExecutionMode";
        private const string ExecutionModeIntegrityAssurance = "IntegrityAssurance";
        private const string DockerComposeCommand = "docker-compose";
        private const string DockerComposeUpArguments = "up -d";
        private const string IntegrityAssuranceBaseDirectory = "IntegrityAssurance";
        private const string ScriptsDirectory = "Scripts";
        private const string SystemScriptsDirectory = "System";
        private const string ScriptsExtensions = "*.sql";

        /// <summary>
        /// Initializes the application to run in Integrity Assurance mode.
        /// This method starts a Docker container, waits for SQL Server to be ready,
        /// executes a SQL script to drop the database, and applies any pending migrations.
        /// </summary>
        /// <param name="app">The WebApplication instance to configure.</param>
        public static void InitializeIntegrityAssurance(WebApplication app)
        {
            if (Environment.GetEnvironmentVariable(EnvironmentVariableExecutionMode) == ExecutionModeIntegrityAssurance)
            {
                Console.WriteLine("Running in Integrity Assurance mode...");

                var dockerUp = Process.Start(DockerComposeCommand, DockerComposeUpArguments);
                dockerUp.WaitForExit();

                // TODO: Temporary workaround to wait for SQL Server to be ready
                Thread.Sleep(30000);

                var systemScriptsDirectory = Path.Combine(Directory.GetCurrentDirectory(), IntegrityAssuranceBaseDirectory, ScriptsDirectory, SystemScriptsDirectory);
                ExecuteScriptsDirectory(systemScriptsDirectory);

                // TODO: Migrations will not apply in NHibernate replace this with the provider interface
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<PocContext>();
                    dbContext.Database.Migrate();
                }

                var testScriptsDirectory = Path.Combine(Directory.GetCurrentDirectory(), IntegrityAssuranceBaseDirectory, ScriptsDirectory);
                ExecuteScriptsDirectory(testScriptsDirectory);
            }
        }

        private static void ExecuteScriptsDirectory(string scriptsDirectory)
        {
            var scriptFiles = Directory
                                .GetFiles(scriptsDirectory, ScriptsExtensions, SearchOption.TopDirectoryOnly)
                                .OrderBy(f => f);

            foreach (var scriptFile in scriptFiles)
            {
                try
                {
                    ExecuteSqlScript(scriptFile);
                }
                catch (Exception ex)
                {
                    //TODO: Add a custom exception and stop the execution
                    Console.WriteLine($"Error while loading script: {scriptFile}. Exception: {ex.Message}");
                }
            }
        }

        private static void ExecuteSqlScript(string scriptPath)
        {
            var sqlCmdProcess = Process.Start(new ProcessStartInfo
            {
                FileName = "sqlcmd",
                Arguments = $"-S localhost -U sa -P YourStrong!Passw0rd -i \"{scriptPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            sqlCmdProcess.WaitForExit();
            Console.WriteLine($"SQL script {scriptPath} executed with exit code: {sqlCmdProcess.ExitCode}");
        }
    }
}