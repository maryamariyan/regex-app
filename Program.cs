﻿using System;
 using System.IO;
 using System.Text.RegularExpressions;

namespace regexapp
{
    class Program
    {
        static void Main(string[] args)
        {
		RemoveMultipleBlankLines();

		RemoveAnnotationLine();
		RemoveMultipleBlankLinesToNoBlank();

		Console.WriteLine("Hello World!");
        }

	public static void RemoveMultipleBlankLines()
	{
		string[] files = Directory.GetFiles(@"/Users/mariyan/CodeHub/corefx/src/System.ComponentModel.Composition/", "*.cs", SearchOption.AllDirectories);
		foreach(var item in files)
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
                string[] files = Directory.GetFiles(@"/Users/mariyan/CodeHub/corefx/src/System.ComponentModel.Composition/", "*.cs", SearchOption.AllDirectories);
                foreach(var item in files)
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
                string[] files = Directory.GetFiles(@"/Users/mariyan/CodeHub/corefx/src/System.ComponentModel.Composition/", "*.cs", SearchOption.AllDirectories);
                foreach(var item in files)
                {
                        var text = File.ReadAllText(item);
                        var rgex = new Regex(@"(\r?\n\s*){3,}");
                        var rgex2 = new Regex(@"(\r?\n\s*){3,}");
                        var res = rgex.Replace(text, Environment.NewLine);
                        if (rgex2.IsMatch(text)) File.WriteAllText(item, res);
                }
        }

// TODO:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

    }
}
