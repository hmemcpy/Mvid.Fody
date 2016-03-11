using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Mono.Cecil;

public class AssemblyWeaver
{
    public Assembly Assembly;
    public AssemblyWeaver(string assemblyPath)
    {
        assemblyPath = FixAssemblyPath(assemblyPath);

        var newAssembly = assemblyPath.Replace(".dll", "2.dll");
        File.Copy(assemblyPath, newAssembly, true);
        var oldPdb = Path.ChangeExtension(assemblyPath, "pdb");
        var newPdb = Path.ChangeExtension(newAssembly, "pdb");
        File.Copy(oldPdb, newPdb, true);

        var assemblyResolver = new MockAssemblyResolver();
        var readerParameters = new ReaderParameters
        {
            AssemblyResolver = assemblyResolver,
            ReadSymbols = true,
        };
        var moduleDefinition = ModuleDefinition.ReadModule(newAssembly, readerParameters);
        var weavingTask = new ModuleWeaver
        {
            ModuleDefinition = moduleDefinition,
            AssemblyResolver = assemblyResolver,
            LogError = LogError,
        };

        weavingTask.Execute();
        moduleDefinition.Write(newAssembly);

        Assembly = Assembly.LoadFrom(newAssembly);
    }

    public static string FixAssemblyPath(string assemblyPath)
    {
#if (!DEBUG)
        assemblyPath = assemblyPath.Replace("Debug", "Release");
#endif
        return assemblyPath;
    }

    void LogError(string error)
    {
        Errors.Add(error);
    }

    public List<string> Errors = new List<string>();
}