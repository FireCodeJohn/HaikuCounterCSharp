using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HaikuCSharp.Test")]

namespace HaikuCSharp
{
    internal static class HaikuCounter
    {
        internal static int CountHaikus()
        {
            // gets working directory and instruct user to place input haikus there
            var workingDir = Directory.GetCurrentDirectory();
            Console.WriteLine($"Working directory {workingDir}");
            Console.WriteLine("Place your .txt input files in the working directory.  Press any key when ready to continue...");
            Console.ReadKey();
            Console.WriteLine();

            // gets the files and loops through them
            var haikuFiles = Directory.GetFiles(workingDir, "*.txt");
            var haikuCount = 0;
            foreach (var haikuFile in haikuFiles)
            {
                // read the lines and remove/ignore any blank lines
                var lines = File.ReadAllLines(haikuFile).ToList();
                lines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

                // Verify line count
                if (lines.Count != 3)
                {
                    Console.WriteLine($"Text in file {haikuFile} is not a Haiku because it has {lines.Count} lines.");
                    Console.WriteLine();
                    continue;
                }

                // Verify syllables for line 1
                var syllables = SyllableCounter.GetSyllablesPerLine(lines[0]);
                if (syllables != 5)
                {
                    Console.WriteLine($"Text in file {haikuFile} is not a Haiku because line 1 has {syllables} syllables.");
                    Console.WriteLine($"Line: {lines[0]}");
                    Console.WriteLine();
                    continue;
                }

                // Verify syllables for line 2
                syllables = SyllableCounter.GetSyllablesPerLine(lines[1]);
                if (syllables != 7)
                {
                    Console.WriteLine($"Text in file {haikuFile} is not a Haiku because line 2 has {syllables} syllables.");
                    Console.WriteLine($"Line: {lines[1]}");
                    Console.WriteLine();
                    continue;
                }

                // Verify syllables for line 3
                syllables = SyllableCounter.GetSyllablesPerLine(lines[2]);
                if (syllables != 5)
                {
                    Console.WriteLine($"Text in file {haikuFile} is not a Haiku because line 3 has {syllables} syllables.");
                    Console.WriteLine($"Line: {lines[2]}");
                    Console.WriteLine();
                    continue;
                }

                // log that file is haiku and increase count
                Console.WriteLine($"Text in file {haikuFile} is a Haiku!  Haiku:");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
                haikuCount++;
            }

            Console.WriteLine($"The working directory had {haikuCount} haikus in it out of {haikuFiles.Length} files");
            Console.WriteLine("Press any key to close the program...");
            Console.WriteLine();
            Console.ReadKey();
            return haikuCount;
        }
    }
}
