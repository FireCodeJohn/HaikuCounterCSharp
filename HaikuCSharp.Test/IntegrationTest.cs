using NUnit.Framework;

namespace HaikuCSharp.Test
{
    [TestFixture]
    public class IntegrationTest
    {
        [Test]
        public void HaikuDetector_IntegrationTest()
        {
            var workingDir = Directory.GetCurrentDirectory();
            
            // should pass
            if (!File.Exists($"{workingDir}\\test1.txt"))
            {
                var test = new List<string>()
                {
                    "An old silent pond",
                    "A frog jumps into the pond",
                    "Splash! Silence again"
                };
                File.WriteAllLines($"{workingDir}\\test1.txt", test);
            }

            // should fail
            if (!File.Exists($"{workingDir}\\test2.txt"))
            {
                var test = new List<string>()
                {
                    "An old silent pond",
                    "A frog jumps into the pond",
                    "Splash! Silence again",
                    "Not a haiku"
                };
                File.WriteAllLines($"{workingDir}\\test2.txt", test);
            }

            // should fail
            if (!File.Exists($"{workingDir}\\test3.txt"))
            {
                var test = new List<string>()
                {
                    "An old silent pond",
                    "A frog jumps into the pond"
                };
                File.WriteAllLines($"{workingDir}\\test3.txt", test);
            }

            // should pass
            if (!File.Exists($"{workingDir}\\test4.txt"))
            {
                var test = new List<string>()
                {
                    "one two three four five",
                    "aye the count is here seven",
                    "the key is many"
                };
                File.WriteAllLines($"{workingDir}\\test4.txt", test);
            }

            // should fail
            if (!File.Exists($"{workingDir}\\test5.txt"))
            {
                var test = new List<string>()
                {
                    "one two three four",
                    "aye the count is here seven",
                    "the key is many"
                };
                File.WriteAllLines($"{workingDir}\\test5.txt", test);
            }

            // should fail
            if (!File.Exists($"{workingDir}\\test6.txt"))
            {
                var test = new List<string>()
                {
                    "one two three four five",
                    "aye the count is here seven Eight!",
                    "the key is many"
                };
                File.WriteAllLines($"{workingDir}\\test6.txt", test);
            }

            // should fail
            if (!File.Exists($"{workingDir}\\test7.txt"))
            {
                var test = new List<string>()
                {
                    "one two three four five",
                    "aye the count is here seven",
                    "the key is too many"
                };
                File.WriteAllLines($"{workingDir}\\test7.txt", test);
            }

            // should pass
            if (!File.Exists($"{workingDir}\\test8.txt"))
            {
                var test = new List<string>()
                {
                    "ouchie Im hurt now",
                    "owie aye I like a ale",
                    "The foam very nice"
                };
                File.WriteAllLines($"{workingDir}\\test8.txt", test);
            }

            var result = HaikuCounter.CountHaikus();
            Assert.AreEqual(result, 3);
        }
    }
}