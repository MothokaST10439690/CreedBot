# CreedBotCreed CyberWorrias Bot

Creed CyberWorrias Bot is a simple, interactive chatbot built in C# designed to help users learn and stay informed about cybersecurity. The bot educates users on topics such as phishing, password security, privacy, scams, and more.

✨ Features

Keyword recognition for cybersecurity topics (e.g., phishing, password, scam)

Randomized informative responses to avoid repetition

Emotional response detection (e.g., "worried", "frustrated")

Memory personalization using user's name

Simple natural language understanding (e.g., "how are you" with or without punctuation)

Error handling for media playback

Lightweight and console-based

⚙️ How It Works

Startup

Displays an ASCII logo

Attempts to play a greeting sound (welcome.wav)

Asks for the user's name and greets them personally

Chat Loop

Users type questions or statements into the console

The bot checks for recognized keywords or questions

Responses are provided accordingly, with a simulated typing delay

Recognized Inputs

Cybersecurity topics like "phishing", "password", "privacy", etc.

Natural questions like "how are you", "what is your purpose"

Emotional expressions like "worried", "curious"

Fallback

If input is not recognized, the bot suggests asking about online safety topics

📄 Setup Instructions

Prerequisites

.NET SDK (version 6.0 or higher)

Installation

Clone or download the repository.

   git clone https://github.com/yourusername/CreedCyberWorriasBot.git
   cd CreedCyberWorriasBot

Place a welcome.wav file in the same directory (optional, for greeting sound).

Build and run the application:

   dotnet run

🎮 Example Interactions

What's your name? Jane
Hello, Jane! Welcome to Creed CyberWorrias — your online safety guide.

You: how are you
Bot: I'm just code, but I'm here to help you stay safe!

You: tell me about phishing
Bot: Be cautious of emails asking for personal info — scammers mimic trusted companies.

You: exit
Bot: Thanks for chatting. Stay safe out there!

✉️ Contribution

Feel free to fork the project and submit pull requests. Ideas for extending it with more AI or NLP features are welcome!

⚠️ Disclaimer

This bot is a prototype for educational use. It provides general guidance and should not replace professional cybersecurity advice.

© License

MIT License

