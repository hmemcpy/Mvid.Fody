using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Cil;

public class ModuleWeaver
{
    public Action<string> LogDebug { get; set; }
    public Action<string> LogInfo { get; set; }
    public Action<string> LogWarning { get; set; }
    public Action<string, SequencePoint> LogWarningPoint { get; set; }
    public Action<string> LogError { get; set; }
    public Action<string, SequencePoint> LogErrorPoint { get; set; }

    public ModuleDefinition ModuleDefinition { get; set; }

    public ModuleWeaver()
    {
        LogDebug = s => { Debug.WriteLine(s); };
        LogInfo = s => { Debug.WriteLine(s); };
        LogWarning = s => { Debug.WriteLine(s); };
        LogWarningPoint = (s, p) => { Debug.WriteLine(s); };
        LogError = s => { Debug.WriteLine(s); };
        LogErrorPoint = (s, p) => { Debug.WriteLine(s); };
    }

    public void Execute()
    {
        
    }
}
