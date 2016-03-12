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
    public IAssemblyResolver AssemblyResolver { get; set; }

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
        CustomAttribute attribute;
        if (ModuleDefinition.Assembly.TryGetAttribute("MvidAttribute", out attribute) ||
            ModuleDefinition.TryGetAttribute("MvidAttribute", out attribute))
        {
            var attrValue = attribute.ConstructorArguments[0].Value.ToString();
            if (!string.IsNullOrWhiteSpace(attrValue))
            {
                Guid guid;
                if (Guid.TryParse(attrValue, out guid))
                {
                    ModuleDefinition.Mvid = guid;
                }
            }

            RemoveReference(attribute);
        }
    }

    private void RemoveReference(CustomAttribute attribute)
    {
        ModuleDefinition.CustomAttributes.Remove(attribute);
        ModuleDefinition.Assembly.CustomAttributes.Remove(attribute);

        var referenceToRemove = ModuleDefinition.AssemblyReferences.FirstOrDefault(reference => reference.Name == "Mvid");
        if (referenceToRemove != null)
            ModuleDefinition.AssemblyReferences.Remove(referenceToRemove);
    }
}
