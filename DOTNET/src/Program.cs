using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TheTurtleChallange
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the turtle challange");

                string gitRepoLink = "https://github.com/panilo/TheTurtleChallange";
                Console.WriteLine($"Please provide two files in JSON format see {gitRepoLink} for further info");

                if (args.Length == 0)
                {
                    throw new ArgumentNullException("please use -gameSettings and -moves to provide required files");
                }

                GameSettings gs = null;
                List<string> moves = null;
                for (var i = 0; i < args.Length; i++)
                {
                    string arg = args[i];
                    switch (arg)
                    {
                        case "-gameSettings":
                            gs = GetGameSettingsFromFile(args[i + 1]);
                            break;
                        case "-moves":
                            moves = GetMovesFromFile(args[i + 1]);
                            break;
                    }
                }

                try
                {
                    Logic gameLogic = new Logic(gs, moves);
                    gameLogic.Play();
                }
                catch (StillInDangerException)
                {
                    Console.WriteLine("Your turtle is still in danger");
                }
                catch (MineHitException)
                {
                    Console.WriteLine("Ops your turtle hit a mine... poor turtle!");
                }
                catch (IsOutOfBoundsException)
                {
                    Console.WriteLine("Your turtle wants to go around the world, perhaps is out of bounds...");
                }
                catch (IsExitException)
                {
                    Console.WriteLine("GREAT! SUCCESS your turtle is safe!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ops... Something goes wrong: '{e.Message}'");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static GameSettings GetGameSettingsFromFile(string filePath)
        {
            string fileContent = ReadFileContent(filePath);
            return JsonConvert.DeserializeObject<GameSettings>(fileContent);
        }

        private static List<string> GetMovesFromFile(string filePath)
        {
            string fileContent = ReadFileContent(filePath);
            return fileContent.Split(",").ToList();
        }

        private static string ReadFileContent(string filePath)
        {
            using(Stream s = new FileStream(filePath, FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
