using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AssemblyTests
    {
        AssemblyWeaver assemblyWeaver;
        Guid expected;

        public AssemblyTests()
        {
            expected = Guid.Parse("3B28DB47-0744-4387-8020-9F571EE3C776");
            var assemblyPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestAssembly.dll");
            assemblyWeaver = new AssemblyWeaver(assemblyPath);
        }

        [Test]
        public void TestRegularAssembly()
        {
            var id = assemblyWeaver.Assembly.ManifestModule.ModuleVersionId;
            Assert.AreEqual(expected, id);
        }

        [Test]
        public void TestSignedAssembly()
        {
            var assemblyPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "SignedAssembly.dll");
            var v = new AssemblyWeaver(assemblyPath);

            var id = v.Assembly.ManifestModule.ModuleVersionId;
            Assert.AreEqual(expected, id);
        }

        [Test]
        public void AssemblyShouldNotHaveReferenceToMvidAssembly()
        {
            var referencedAssemblies = assemblyWeaver.Assembly.GetReferencedAssemblies();
            Assert.IsFalse(referencedAssemblies.Any(assembly => assembly.Name == "Mvid"));
        }

        [Test]
        public void AssemblyShouldNotHaveTheMvidAttribute()
        {
            var customAttributes = assemblyWeaver.Assembly.GetCustomAttributes();
            Assert.IsFalse(customAttributes.Any(o => o.GetType().Name == "MvidAttribute"));
        }
    }
}
