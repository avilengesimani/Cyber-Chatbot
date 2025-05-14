# CyberSecurity Chatbot

Welcome to the **CyberSecurity Chatbot** project! This chatbot is designed to help users stay safe online by providing valuable cybersecurity tips and advice. It responds to user inputs related to phishing, password security, privacy, and scams. It also remembers user interests and offers personalized suggestions. The chatbot even includes voice feedback, making the experience more interactive.

## Features

- **Interactive Conversations:** Engage in a natural conversation with the chatbot about cybersecurity topics.
- **Voice Feedback:** The chatbot speaks its responses using the `System.Speech.Synthesis` API, providing an auditory experience.
- **Sentiment Detection:** The chatbot recognizes and responds empathetically to emotions like "worried," "curious," and "frustrated."
- **Personalized Tips:** Based on your interests, the chatbot will offer tips on phishing, passwords, privacy, and scams.
- **Interest Tracking:** The bot remembers your interests and can provide additional relevant tips as the conversation progresses.

## Technologies Used

- **C# (.NET Framework)**: Main programming language for the chatbot.
- **System.Speech.Synthesis**: For speech synthesis (text-to-speech functionality).
- **Dictionary-based Keyword Handling**: The bot uses a dictionary of keywords to trigger relevant responses.

## Getting Started

To get started with the **CyberSecurity Chatbot**, follow these steps:

### Prerequisites

- .NET Framework installed (or .NET Core if you adapt the project)
- A C# compiler (Visual Studio or any other C# IDE)

### Usage

1. Run the chatbot application.
2. It will greet you and ask for your name.
3. You can interact with the bot by typing messages in the console, such as:
   - **"I’m interested in phishing"**
   - **"Tell me more about passwords"**
   - **"What should I do to stay safe from scams?"**
4. The bot will respond to your queries and offer useful tips.
5. If you mention you're feeling worried, curious, or frustrated, the bot will respond with empathy based on your mood.

### Example Interaction
Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.
Please enter your name: John

Hello, John! Welcome to the Cybersecurity Awareness Bot. Let's learn how to stay safe online.

You: I'm interested in phishing
Bot: Great! I'll remember that you're interested in phishing.

You: Tell me more about phishing
Bot: Phishing Tip: Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.

### Commands

- **"interested in [topic]"**: Track your interest in a specific cybersecurity topic (e.g., phishing, password, privacy, scam).
- **"Tell me more"**: Get additional tips based on your interests.
- **"exit"**: End the conversation.


