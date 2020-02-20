using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace regexapp
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoveMultipleBlankLines();

            //RemoveAnnotationLine();
            //RemoveMultipleBlankLinesToNoBlank();

            //RemoveHeaderComments();
            //RemoveMultipleBlankLinesWithProperHeaderComment();
            Console.WriteLine("Hello World!");
        }

        public static void RemoveMultipleBlankLines()
        {
            string[] files = Directory.GetFiles(@"C:\CodeHub\other-corefx\corefx\src\System.Data.OleDb\", "*.cs", SearchOption.AllDirectories);
            foreach (var item in files)
            {
                var text = File.ReadAllText(item);
                var rgex = new Regex(@"(\r?\n\s*){3,}");
                var rgex2 = new Regex(@"(\r?\n\s*){3,}");
                var res = rgex.Replace(text, Environment.NewLine + Environment.NewLine);
                if (rgex2.IsMatch(text)) File.WriteAllText(item, res);
            }
        }

        public static void RemoveAnnotationLine()
        {
            string[] files = Directory.GetFiles(@"C:\CodeHub\other-corefx\corefx\src\System.Data.OleDb\", "*.cs", SearchOption.AllDirectories);
            foreach (var item in files)
            {
                var text = File.ReadAllText(item);
                var rgex = new Regex(@"[ ]*\[ContractArgumentValidator\]");
                var rgex2 = new Regex(@"[ ]*\[ContractArgumentValidator\]");
                var res = rgex.Replace(text, Environment.NewLine + Environment.NewLine + Environment.NewLine);
                if (rgex2.IsMatch(text)) File.WriteAllText(item, res);
            }
        }

        public static void RemoveMultipleBlankLinesToNoBlank()
        {
            string[] files = Directory.GetFiles(@"C:\CodeHub\other-corefx\corefx\src\System.Data.OleDb\", "*.cs", SearchOption.AllDirectories);
            foreach (var item in files)
            {
                var text = File.ReadAllText(item);
                var rgex = new Regex(@"(\r?\n\s*){3,}");
                var rgex2 = new Regex(@"(\r?\n\s*){3,}");
                var res = rgex.Replace(text, Environment.NewLine);
                if (rgex2.IsMatch(text)) File.WriteAllText(item, res);
            }
        }

        public static void RemoveMultipleBlankLinesWithProperHeaderComment()
        {
            string[] files = Directory.GetFiles(@"C:\CodeHub\other-corefx\corefx\src\System.Data.OleDb\", "*.cs", SearchOption.AllDirectories);
            foreach (var item in files)
            {
                var text = File.ReadAllText(item);
                var rgex = new Regex(@"(\r?\n\s*){3,}");
                var rgex2 = new Regex(@"(\r?\n\s*){3,}");
		var sb = new StringBuilder();
		sb.Append("// Licensed to the .NET Foundation under one or more agreements.").Append(Environment.NewLine)
		        .Append("// The .NET Foundation licenses this file to you under the MIT license.").Append(Environment.NewLine)
        		.Append("// See the LICENSE file in the project root for more information.").Append(Environment.NewLine);
                var res = rgex.Replace(text, sb.ToString());
                if (rgex2.IsMatch(text)) File.WriteAllText(item, res);
            }
        }

        // TODO:
        // Licensed to the .NET Foundation under one or more agreements.
        // The .NET Foundation licenses this file to you under the MIT license.
        // See the LICENSE file in the project root for more information.

        public static void RemoveHeaderComments()
        {
            string[] files = Directory.GetFiles(@"C:\CodeHub\other-corefx\corefx\src\System.Data.OleDb\", "*.cs", SearchOption.AllDirectories);
            foreach (var item in files)
            {
                var text = File.ReadAllText(item);
                var rgex = new Regex(@"[\/]{2,}[ ][-]+(\r?\n\s*)[\/]{2,}[ ](Copyright \(c\) Microsoft Corporation.  All rights reserved).*(\r?\n\s*)[\/]{2,}[ ][-]+");
                var rgex2 = new Regex(@"[\/]{2,}[ ][-]+(\r?\n\s*)[\/]{2,}[ ](Copyright \(c\) Microsoft Corporation.  All rights reserved).*(\r?\n\s*)[\/]{2,}[ ][-]+");
                var res = rgex.Replace(text, Environment.NewLine + Environment.NewLine + Environment.NewLine);
                if (rgex2.IsMatch(text)) File.WriteAllText(item, res);
            }
        }

    }
}
