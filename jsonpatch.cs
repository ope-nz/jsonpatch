using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using JsonDiffPatchDotNet;

// A few assembly level attributes.
[assembly:AssemblyVersion("2.0.0.0")]
[assembly:AssemblyProductAttribute("jsonpatch")]
[assembly:AssemblyCopyrightAttribute("ope ltd")]
[assembly:AssemblyTitle("JSON Patch")]

// NOTE: console output only shows if you run with | more option at cmd. eg runner.exe | more
namespace JsonDiff
{
    class Program
    {
        static void Main(string[] args)
        {
			string ExeName = System.AppDomain.CurrentDomain.FriendlyName;	
			string ThisLocation = Directory.GetCurrentDirectory();
			
			string action = "";
			string left_file = "";
			string right_file = "";

            // join into one string
            string argString = string.Join(" ", args);

            int c = args.GetUpperBound(0);

            // Loop through arguments
            for (int n = 0; n < c; n++)
            {
                string thisKey = args[n].ToLower();
                string thisVal = args[n + 1].TrimEnd().TrimStart();

                // eval the key or slash-switch option ("/key")
                switch (thisKey)
                {
                    case "-action":
                        action = thisVal;                        
                        break;
                    case "-left":
                        left_file = thisVal;
                        break;
					case "-right":
						right_file = thisVal;
						break;
                }
            }        
			
			var jdp = new JsonDiffPatch();			
				
			string left = File.ReadAllText(left_file);
            string right = File.ReadAllText(right_file);
			
			if (action == "diff")
			{
				var result = jdp.Diff(left, right);
				
				StreamWriter sw = new StreamWriter(ThisLocation+"\\output.json",false);
				sw.Write(result.ToString());
				sw.Close();
			}
			if (action == "patch")
			{
				var patch = jdp.Diff(left, right);
				var result = jdp.Patch(left, patch);
				
				StreamWriter sw = new StreamWriter(ThisLocation+"\\output.json",false);
				sw.Write(result.ToString());
				sw.Close();
			}            

			//Console.WriteLine(result);

			Environment.Exit(0);			
        }
    }
}