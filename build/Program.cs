using System;
using System.Collections.Generic;
using System.IO;
using GlobExpressions;
using static Bullseye.Targets;
using static SimpleExec.Command;

const string Clean = "clean";
const string Restore = "restore";
const string Build = "build";
const string Test = "test";
const string Format = "format";
const string Publish = "publish";

Target(
    Clean,
    ForEach("**/bin", "**/obj"),
    dir =>
    {
        IEnumerable<string> GetDirectories(string d)
        {
            return Glob.Directories(".", d);
        }

        void RemoveDirectory(string d)
        {
            if (Directory.Exists(d))
            {
                Console.WriteLine(d);
                Directory.Delete(d, true);
            }
        }

        foreach (var d in GetDirectories(dir))
        {
            RemoveDirectory(d);
        }
    }
);

Target(
    Format,
    () =>
    {
        Run("dotnet", "tool restore");
        Run("dotnet", "csharpier --check .");
    }
);
Target(Restore, DependsOn(Format), () => Run("dotnet", "restore"));

Target(
    Build,
    DependsOn(Restore),
    () =>
    {
        Run("dotnet", "build src/Narochno.EnvFile/Narochno.EnvFile.csproj -c Release --no-restore");
    }
);

Target(
    Test,
    DependsOn(Build),
    () =>
    {
        IEnumerable<string> GetFiles(string d)
        {
            return Glob.Files(".", d);
        }

        foreach (var file in GetFiles("**/*.Test.csproj"))
        {
            Run("dotnet", $"test {file} -c Release -f net8.0 --no-restore --verbosity=normal");
        }
    }
);

Target(
    Publish,
    DependsOn(Test),
    () =>
    {
        Run("dotnet", "pack src/Narochno.EnvFile/Narochno.EnvFile.csproj -c Release -o artifacts/");
    }
);

Target("default", DependsOn(Publish), () => Console.WriteLine("Done!"));

await RunTargetsAndExitAsync(args);
