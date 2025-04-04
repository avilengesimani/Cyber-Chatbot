using System;
using System.Speech.Synthesis;

class CyberSecurityChatbot
{
    // The entry point for the program, this is where the execution begins
    static void Main()
    {
        // Play the greeting message using speech synthesis
        Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");

        // Display a greeting message to the user
        DisplayGreetingMessage();

        // Display ASCII art for a fun introduction
        DisplayAsciiArt();

        // Prompt the user to enter their name
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine().Trim();

        // Greet the user by name
        Console.ForegroundColor = ConsoleColor.Green;  // Set text color to green
        Console.WriteLine($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot.\n");
        Console.ResetColor();  // Reset color to default

        // Start the conversation loop
        StartConversation();
    }

    // Method to speak a message using SpeechSynthesizer
    static void Speak(string message)
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        synthesizer.SetOutputToDefaultAudioDevice();  // Set the audio output device to default
        synthesizer.Speak(message);  // Speak the message
    }

    // Displays a greeting message to the user
    static void DisplayGreetingMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;  // Set text color to cyan
        Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.\n");
        Console.ResetColor();  // Reset color to default
    }

    // Displays a piece of ASCII art to enhance user experience
    static void DisplayAsciiArt()
    {
        string asciiArt = @"
  CCCC   Y   Y  BBBBB   EEEEE  RRRRR    SSSS  EEEEE  CCCC  U   U  RRRRR   I   TTTTT  Y   Y
 C        Y Y   B    B  E      R    R  S       E     C      U   U  R    R  I     T     Y Y
 C         Y    BBBBB   EEEE   RRRRR   SSSS    EEEE   C      U   U  RRRRR   I     T      Y
 C        Y Y   B    B  E      R   R       S   E     C      U   U  R   R   I     T     Y Y
  CCCC   Y   Y  BBBBB   EEEEE  R    R  SSSS    EEEEE  CCCC   UUUU   R    R  I     T     Y   Y
";
        // Print the ASCII art to the console
        Console.ForegroundColor = ConsoleColor.Cyan;  // Set text color to cyan
        Console.WriteLine(asciiArt);
        Console.ResetColor();  // Reset color to default
    }

    // Starts a conversation loop where the bot interacts with the user
    static void StartConversation()
    {
        // Infinite loop to continue the conversation until the user exits
        while (true)
        {
            // Prompt user for input
            Console.Write("\nYou: ");
            string userInput = Console.ReadLine().ToLower();  // Convert input to lowercase for easier comparison

            // Handle case where user doesn't provide any input
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;  // Set text color to red for error
                Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
                Console.ResetColor();  // Reset color to default
                continue; // Continue the loop without doing anything else
            }

            // Switch statement to handle different user inputs
            switch (userInput)
            {
                case "how are you":
                    Console.ForegroundColor = ConsoleColor.Yellow;  // Set text color to yellow
                    Console.WriteLine("Bot: I'm just a program, but I'm here to help you stay safe online!");
                    Console.ResetColor();  // Reset color to default
                    break;

                case "what questions can i ask you about":
                    Console.ForegroundColor = ConsoleColor.Yellow;  // Set text color to yellow
                    Console.WriteLine("Bot: You can ask me about password safety, phishing, and safe browsing.");
                    Console.ResetColor();  // Reset color to default
                    break;

                case "password safety":
                    Console.ForegroundColor = ConsoleColor.Yellow;  // Set text color to yellow
                    Console.WriteLine("Bot: Password safety is crucial, in order to accomplish that, use at least 12 characters, including a mix of uppercase and lowercase letters, numbers, and special symbols. Avoid using easily guessable information like birthdays or common words.");
                    Console.ResetColor();  // Reset color to default
                    break;

                case "phishing":
                    Console.ForegroundColor = ConsoleColor.Yellow;  // Set text color to yellow
                    Console.WriteLine("Bot: Phishing is a cyber attack where attackers impersonate legitimate companies to trick you into providing sensitive information. Be cautious of unsolicited emails, verify senders, and never click suspicious links.");
                    Console.ResetColor();  // Reset color to default
                    break;

                case "safe browsing":
                    Console.ForegroundColor = ConsoleColor.Yellow;  // Set text color to yellow
                    Console.WriteLine("Bot: Safe browsing helps protect your information online. Use 'https://' websites, avoid untrusted sites, and install reputable security software.");
                    Console.ResetColor();  // Reset color to default
                    break;

                case "exit":
                    // Exit the conversation when user types 'exit'
                    Console.ForegroundColor = ConsoleColor.Green;  // Set text color to green for exit message
                    Console.WriteLine("Bot: Thank you for chatting! Stay safe online!");
                    Console.ResetColor();  // Reset color to default
                    return; // Exit the method and thus the program

                default:
                    // If the user input doesn't match any known topics, ask them to rephrase
                    Console.ForegroundColor = ConsoleColor.Red;  // Set text color to red for error
                    Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();  // Reset color to default
                    break;
            }
        }
    }
}

