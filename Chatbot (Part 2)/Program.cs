using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

class CyberSecurityChatbot
{
    static string userName = "";
    static List<string> userInterests = new List<string>();
    static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

    delegate void ResponseHandler();
    static Dictionary<string, ResponseHandler> keywordActions = new Dictionary<string, ResponseHandler>();

    static List<string> phishingTips = new List<string>
    {
        "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
        "Always hover over links to check their destination before clicking.",
        "Do not open attachments from unknown sources.",
        "Enable two-factor authentication to add an extra layer of protection."
    };

    static List<string> passwordTips = new List<string>
    {
        "Use a combination of upper and lower case letters, numbers, and special characters in your passwords.",
        "Avoid using easily guessable passwords like '123456' or 'password'.",
        "Use a unique password for each of your accounts.",
        "Change your passwords regularly, especially after a data breach."
    };

    static List<string> privacyTips = new List<string>
    {
        "Review privacy settings on social media to control who can see your posts.",
        "Be cautious when sharing personal information online.",
        "Use a VPN when connecting to public Wi-Fi networks.",
        "Regularly clear your browser cookies and history to limit tracking."
    };

    static List<string> scamTips = new List<string>
    {
        "Watch out for deals that sound too good to be true—they often are.",
        "Don't share personal or financial information over the phone unless you're sure of the caller’s identity.",
        "Be suspicious of urgent messages asking for immediate action.",
        "Research unknown websites or businesses before making purchases or giving information."
    };

    static void Main()
    {
        Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
        DisplayGreetingMessage();
        DisplayAsciiArt();

        Console.Write("Please enter your name: ");
        userName = Console.ReadLine().Trim();

        string welcomeMessage = $"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot.\n";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(welcomeMessage);
        Console.ResetColor();

        Speak($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot. Let's learn how to stay safe online.");

        InitializeKeywordActions();
        StartConversation();
    }

    static void Speak(string message)
    {
        synthesizer.SetOutputToDefaultAudioDevice();
        synthesizer.Speak(message);
    }

    static void DisplayGreetingMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.\n");
        Console.ResetColor();
    }

    static void DisplayAsciiArt()
    {
        string asciiArt = @"
  CCCC   Y   Y  BBBBB   EEEEE  RRRRR    SSSS  EEEEE  CCCC  U   U  RRRRR   I   TTTTT  Y   Y
 C        Y Y   B    B  E      R    R  S       E     C      U   U  R    R  I     T     Y Y
 C         Y    BBBBB   EEEE   RRRRR   SSSS    EEEE   C      U   U  RRRRR   I     T      Y
 C        Y Y   B    B  E      R   R       S   E     C      U   U  R   R   I     T     Y Y
  CCCC   Y   Y  BBBBB   EEEEE  R    R  SSSS    EEEEE  CCCC   UUUU   R    R  I     T     Y   Y
";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(asciiArt);
        Console.ResetColor();
    }

    static void InitializeKeywordActions()
    {
        var random = new Random();

        keywordActions["password"] = () =>
        {
            string tip = passwordTips[random.Next(passwordTips.Count)];
            Respond($"Password Tip: {tip}");
        };

        keywordActions["phishing"] = () =>
        {
            string tip = phishingTips[random.Next(phishingTips.Count)];
            Respond($"Phishing Tip: {tip}");
        };

        keywordActions["privacy"] = () =>
        {
            string tip = privacyTips[random.Next(privacyTips.Count)];
            Respond($"Privacy Tip: {tip}");
        };

        keywordActions["scam"] = () =>
        {
            string tip = scamTips[random.Next(scamTips.Count)];
            Respond($"Scam Tip: {tip}");
        };
    }

    static void AddInterest(string interest)
    {
        if (!userInterests.Contains(interest))
        {
            userInterests.Add(interest);
            Respond($"Great! I'll remember that you're interested in {interest}.");
        }
        else
        {
            Respond($"You've already mentioned you're interested in {interest}.");
        }
    }

    static void StartConversation()
    {
        while (true)
        {
            Console.Write("\nYou: ");
            string input = Console.ReadLine().ToLower().Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Respond("I didn't quite understand that. Could you rephrase?");
                continue;
            }

            if (input == "exit")
            {
                Respond("Thank you for chatting! Stay safe online!");
                return;
            }

            if (DetectSentiment(input, out string mood))
            {
                HandleSentiment(mood);
                continue;
            }

            bool matched = false;

            // Capture interest
            if (input.Contains("interested in"))
            {
                foreach (var keyword in keywordActions.Keys)
                {
                    if (input.Contains($"interested in {keyword}"))
                    {
                        AddInterest(keyword);
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                {
                    Respond("I only track interests related to password, phishing, privacy, or scam.");
                    matched = true;
                }
            }

            // Respond based on keyword
            if (!matched)
            {
                foreach (var keyword in keywordActions.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        keywordActions[keyword].Invoke();
                        matched = true;
                        break;
                    }
                }
            }

            // Respond with more tips
            if (!matched && userInterests.Count > 0 && input.Contains("more"))
            {
                Respond("Sure! Here are more tips based on your interests:");
                var random = new Random();

                foreach (var interest in userInterests)
                {
                    switch (interest)
                    {
                        case "password":
                            Respond("• Password Tip: " + passwordTips[random.Next(passwordTips.Count)]);
                            break;
                        case "phishing":
                            Respond("• Phishing Tip: " + phishingTips[random.Next(phishingTips.Count)]);
                            break;
                        case "privacy":
                            Respond("• Privacy Tip: " + privacyTips[random.Next(privacyTips.Count)]);
                            break;
                        case "scam":
                            Respond("• Scam Tip: " + scamTips[random.Next(scamTips.Count)]);
                            break;
                    }
                }

                matched = true;
            }

            if (!matched)
            {
                Respond("I'm not sure I understand. Try saying something like 'I'm interested in phishing'.");
            }
        }
    }

    static void Respond(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nBot: {message}");
        Console.ResetColor();
        Speak(message);
    }

    static bool DetectSentiment(string input, out string sentiment)
    {
        if (input.Contains("worried"))
        {
            sentiment = "worried";
            return true;
        }
        if (input.Contains("curious"))
        {
            sentiment = "curious";
            return true;
        }
        if (input.Contains("frustrated"))
        {
            sentiment = "frustrated";
            return true;
        }
        sentiment = "";
        return false;
    }

    static void HandleSentiment(string mood)
    {
        switch (mood)
        {
            case "worried":
                Respond("It's completely understandable to feel that way. Cyber threats can be scary, but you're taking the right step by learning.");
                break;
            case "curious":
                Respond("I love your curiosity! Cybersecurity is full of fascinating concepts—ask me anything!");
                break;
            case "frustrated":
                Respond("I'm here to help. Let’s break it down and go step by step.");
                break;
        }
    }
}
