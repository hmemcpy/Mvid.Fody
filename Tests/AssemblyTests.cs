using System;
using System.IO;
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
        }

        [Test]
        public void TestRegularAssembly()
        {
            var assemblyPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestAssembly.dll");
            assemblyWeaver = new AssemblyWeaver(assemblyPath);

            var id = assemblyWeaver.Assembly.ManifestModule.ModuleVersionId;
            Assert.AreEqual(expected, id);
        }

        [Test]
        public void TestSignedAssembly()
        {
            var assemblyPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "SignedAssembly.dll");
            assemblyWeaver = new AssemblyWeaver(assemblyPath);

            var id = assemblyWeaver.Assembly.ManifestModule.ModuleVersionId;
            Assert.AreEqual(expected, id);
        }
    }
}
