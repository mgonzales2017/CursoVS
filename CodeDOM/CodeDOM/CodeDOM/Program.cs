using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            var unit = new CodeCompileUnit();

            var dynamicNamespace = new CodeNamespace("FourthCoffee.Dynamic");
            unit.Namespaces.Add(dynamicNamespace);

            dynamicNamespace.Imports.Add(new CodeNamespaceImport("System"));

            var programType = new CodeTypeDeclaration("Program");
            dynamicNamespace.Types.Add(programType);

            var mainMethod = new CodeEntryPointMethod();
            programType.Members.Add(mainMethod);

            var expression = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"), "WriteLine", new CodePrimitiveExpression("Hello Clase")
                );

            var provider = new CSharpCodeProvider();
            var fileName = "program.cs";
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                using (var textWriter = new IndentedTextWriter(stream))
                {
                    var options = new CodeGeneratorOptions();
                    options.BlankLinesBetweenMembers = true;

                    var compileUnit = unit;
                    provider.GenerateCodeFromCompileUnit(compileUnit, textWriter, options);
                }
            }

            var compilerSettings = new CompilerParameters();
            compilerSettings.ReferencedAssemblies.Add("System.dll");
            compilerSettings.GenerateExecutable = true;
            compilerSettings.OutputAssembly = "FourthCoffee.exe";

            var sourceCodeFileName = "program.cs";
            var compilationResults = provider.CompileAssemblyFromFile(
                compilerSettings, sourceCodeFileName);
            var buildFailed = false;
            foreach (var error in compilationResults.Errors)
            {
                var errorMesage = error.ToString();
                buildFailed = true;
            }
        }
    }
}
