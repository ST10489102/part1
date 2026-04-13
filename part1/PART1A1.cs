using System;
using System.Threading;
using System.Speech.Synthesis;

namespace VioletVault
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "VIOLET VAULT";
            Console.Clear();

            // ===== COLOUR CHANGING LOADING SCREEN =====
            ConsoleColor[] colors =
            {
                ConsoleColor.Magenta,
                ConsoleColor.DarkMagenta,
                ConsoleColor.Cyan,
                ConsoleColor.White
            };

            Console.Write("Loading Violet Vault");

            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = colors[i % colors.Length];
                Console.Write(".");
                Thread.Sleep(333);
            }

            Console.ResetColor();
            Thread.Sleep(500);
            Console.Clear();

            UI.Header();
            VoiceGreeting.Play();

            string name = User.GetName();
            UI.Welcome(name);

            Chatbot.Start(name);
        }
    }

    // ================= VOICE =================
    class VoiceGreeting
    {
        public static void Play()
        {
            using (SpeechSynthesizer speech = new SpeechSynthesizer())
            {
                speech.Speak("Welcome to Violet Vault. Your cybersecurity assistant.");
            }
        }
    }

    // ================= UI =================
    class UI
    {
        public static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(@"
██╗   ██╗██╗ ██████╗ ██╗███████╗████████╗     ██╗   ██╗ █████╗ ██╗   ██╗██╗     
██║   ██║██║██╔════╝ ██║██╔════╝╚══██╔══╝     ██║   ██║██╔══██╗██║   ██║██║     
██║   ██║██║██║  ███╗██║█████╗     ██║        ██║   ██║███████║██║   ██║██║     
╚██╗ ██╔╝██║██║   ██║██║██╔══╝     ██║        ╚██╗ ██╔╝██╔══██║██║   ██║██║     
 ╚████╔╝ ██║╚██████╔╝██║███████╗   ██║         ╚████╔╝ ██║  ██║╚██████╔╝███████╗
  ╚═══╝  ╚═╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝          ╚═══╝  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
");

            Console.ResetColor();
        }

        public static void Welcome(string name)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" Welcome, {name}!");
            Console.WriteLine("=======================================");
            Console.ResetColor();
        }
    }

    // ================= USER =================
    class User
    {
        public static string GetName()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter your name: ");
            Console.ResetColor();

            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(" Please enter a valid name: ");
                Console.ResetColor();

                name = Console.ReadLine();
            }

            return name.Trim();
        }
    }

    // ================= CHATBOT =================
    class Chatbot
    {
        public static void Start(string name)
        {
            while (true)
            {
                // ===== MENU COLOUR SHIFT =====
                ConsoleColor menuColor = (DateTime.Now.Second % 2 == 0)
                    ? ConsoleColor.Magenta
                    : ConsoleColor.DarkMagenta;

                Console.ForegroundColor = menuColor;

                Console.WriteLine("\n ===== PINK MENU ===== ");
                Console.WriteLine("1  How are you?");
                Console.WriteLine("2  What is your purpose?");
                Console.WriteLine("3  Password safety");
                Console.WriteLine("4  Phishing attacks");
                Console.WriteLine("5  Safe browsing");
                Console.WriteLine("6  Exit");
                Console.WriteLine("===================== ");

                Console.Write(" Choose an option (1-6): ");
                Console.ResetColor();

                string choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Error("Please select an option.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        Speak($"I'm doing well, {name}! Staying safe and secure");
                        break;

                    case "2":
                        Speak("My purpose is to protect you from online threats");
                        break;

                    case "3":
                        Speak("Use strong passwords with letters, numbers, and symbols");
                        break;

                    case "4":
                        Speak("Phishing tricks you into giving personal information");
                        break;

                    case "5":
                        Speak("Always use HTTPS websites and avoid suspicious links");
                        break;

                    case "6":
                        Goodbye(name);
                        return;

                    default:
                        Error("Invalid option. Please choose 1-6.");
                        break;
                }
            }
        }

        private static void Speak(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Bot: ");
            Console.ResetColor();

            Effects.Type(message);
        }

        private static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void Goodbye(string name)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Goodbye {name}! Stay safe with Violet Vault");
            Console.ResetColor();
        }
    }

    // ================= EFFECTS =================
    class Effects
    {
        public static void Type(string message)
        {
            foreach (char c in message)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(c);
                Thread.Sleep(10);
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}