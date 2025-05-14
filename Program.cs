using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace CreedCyberWorriasBot
{
    class Program
    {
        static Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>()
        {
            ["phishing"] = new List<string>()
            {
                "Be cautious of emails asking for personal info — scammers mimic trusted companies.",
                "Check the sender's address before clicking links.",
                "Watch for poor grammar and urgent language — classic phishing red flags."
            },
            ["password"] = new List<string>()
            {
                "Use a mix of uppercase, lowercase, numbers, and special characters.",
                "Don't reuse passwords — each account should be unique.",
                "A password manager can help generate and store secure passwords."
            },
            ["scam"] = new List<string>()
            {
                "If it sounds too good to be true, it probably is.",
                "Don't send money or info to strangers online.",
                "Scammers often create urgency — pause and verify."
            },
            ["privacy"] = new List<string>()
            {
                "Limit what you share on social media.",
                "Check your app and browser privacy settings regularly.",
                "Use a VPN on public Wi-Fi to keep your data safe."
            }
        };
        static Random rand = new Random();

        static void Main(string[] args)
        {
            DisplayLogo();
            PlayGreetingSound();
            string userName = GetUserName();
            StartChat(userName);
        }

        static void DisplayLogo()
        {
            Console.WriteLine(@"
   ______                   __                                           
  / ____/_______  ___  ____/ /                                            
 / /   / ___/ _ \/ _ \/ __  /                                             
/ /___/ /  /  __/  __/ /_/ /                                              
\____/_/_  \___/\___/\__,_/   _       __                _                
  / ____/_  __/ /_  ___  ____| |     / /___ ___________(_)___  __________
 / /   / / / / __ \/ _ \/ ___/ | /| / / __ `/ ___/ ___/ / __ \/ ___/ ___/
\____/\__, /_.___/\___/_/    |__/|__/\__,_/_/  /_/  /_/\____/_/  /____/  
    _/____/     __                                                       
   / __ )____  / /_                                                      
  / __  / __ \/ __/                                                      
 / /_/ / /_/ / /_                                                         
/_____\/____/\__/");
        }

        static void PlayGreetingSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("welcom.wav");
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Unable to play sound: " + ex.Message);
            }
        }

        static string GetUserName()
        {
            Console.WriteLine("\nWhat's your name? ");
            string name = Console.ReadLine();
            TypingDelay($"\nHello, {name}! Welcome to Creed CyberWorrias  your online safety guide.");
            return name;
        }

        static void StartChat(string userName)
        {
            Console.WriteLine($"\nType 'help' for topics or 'exit' to leave.");

            while (true)
            {
                Console.Write($"\nYou: ");
                string input = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input)) continue;

                if (input == "exit")
                {
                    TypingDelay("Thanks for chatting. Stay safe out there!");
                    break;
                }

                if (input.Contains("interested in"))
                {
                    string topic = ExtractTopic(input);
                    TypingDelay($"Got it! You're interested in {topic} — I'll keep that in mind.");
                    continue;
                }

                if (DetectEmotion(input)) continue;
                if (HandleKeywordTopic(input)) continue;

                {
                    if (input.Contains("how are you"))
                    {
                        TypingDelay("I'm just code, but I'm here to help you stay safe!");
                        continue;
                    }
                    else if (input.Contains("what is your purpose"))
                    {
                        TypingDelay("To guide and educate you about cybersecurity.");
                        continue;
                    }
                    else if (input.Contains("what can i ask"))
                    {
                        TypingDelay("You can ask about phishing, passwords, scams, privacy, and more.");
                        continue;
                    }
                    else if (input.Contains("help"))
                    {
                        TypingDelay("Here are some things you can ask me:");
                        Console.WriteLine("- Password\n- Phishing\n- Scam\n- Privacy\n- What is Two-Factor Authentication?\n- How can I protect against malware?\n- What is social engineering?\n- General cybersecurity tips");
                        continue;
                    }
                    else if (input.Contains("what is two-factor authentication"))
                    {
                        TypingDelay("2FA adds a second layer to your login — like a code sent to your phone.");
                        continue;
                    }
                    else if (input.Contains("how can i protect against malware"))
                    {
                        TypingDelay("Use antivirus software, update it often, and don't download unknown files.");
                        continue;
                    }
                    else if (input.Contains("what is social engineering"))
                    {
                        TypingDelay("It's when attackers manipulate people to give up private info — always verify!");
                        continue;
                    }
                    else if (input.Contains("general cybersecurity tips"))
                    {
                        TypingDelay("Update software, use strong passwords, enable 2FA, and avoid suspicious links.");
                        continue;
                    }
                }
            }
        }
        


        static bool HandleKeywordTopic(string input)
        {
            foreach (var key in topicResponses.Keys)
            {
                if (input.Contains(key))
                {
                    ShowRandomResponse(key);
                    return true;
                }
            }
            return false;
        }

        static bool DetectEmotion(string input)
        {
            if (input.Contains("worried"))
            {
                TypingDelay("It's okay to feel worried — you're not alone. Let's work through your concerns.");
                return true;
            }
            if (input.Contains("curious"))
            {
                TypingDelay("Curiosity is the first step to awareness. Ask me anything!");
                return true;
            }
            if (input.Contains("frustrated"))
            {
                TypingDelay("Cybersecurity can be tricky — but you're in good hands here.");
                return true;
            }
            return false;
        }

        static void ShowRandomResponse(string category)
        {
            var responses = topicResponses[category];
            TypingDelay(responses[rand.Next(responses.Count)]);
        }


        static string ExtractTopic(string input)
        {
            int i = input.IndexOf("interested in");
            if (i < 0) return "that topic";
            string topic = input.Substring(i + "interested in".Length).Trim();

            return string.IsNullOrWhiteSpace(topic) ? "that topic" : topic;
        }

        static void TypingDelay(string message)
        {
            Console.Write("Bot: ");
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }
            Console.WriteLine();
        }
    }
}
