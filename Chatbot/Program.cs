using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    internal class Program
    {
        static float anger;
        static Random random;
        static String name;
        static void BotSays(String output, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("Ong:\t" + output);
            Console.ResetColor();
        }

        static String UserInput(String prompt)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prompt);
            return Console.ReadLine().Trim();
        }

        static void QuitProgram()
        {
            Console.WriteLine(" >>> Press any key to quit <<< ");
            Console.ReadKey();
            Environment.Exit(0);
        }

        // Increment the anger of bot
        static void Annoyed(float annoy = 0.5f)
        {
            anger += annoy;
            if (anger > 100.0f)
            {
                BotSays("Ok... I'm gonna sleep...");
                BotSays("Please find me tomorrow... or maybe never again :)");
                BotSays("Sayonara~");
                anger = 100.0f;
                QuitProgram();
            }
        }

        // Randomly modify the user's name
        static String PrankUserName(String userName)
        {
            if(userName == "You") // If user doesn't input any character
            {
                return "Mr Null";
            }
            switch(random.Next(3))
            {
                case 0: // Reverse the name
                    String reverseName = String.Empty;
                    foreach(char c in userName)
                    {
                        reverseName = c + reverseName;
                    }
                    return reverseName;

                case 1: // Randomly uppercase or lowercase character
                    String prankName = String.Empty;
                    foreach(char c in userName)
                    {
                        prankName += random.Next(2) == 1? Char.ToUpper(c): Char.ToLower(c);
                    }
                    return prankName;

                case 2: // Randomly substitute characters with symbols
                    String symbolizedName = String.Empty;
                    Char[] symbols = { '_', '?', '#', '!', '*', '&', '%', '$', '@' };
                    foreach (char c in userName)
                    {
                        symbolizedName += random.Next(2) == 1 ? symbols[random.Next(symbols.Length)] : c;
                    }
                    return symbolizedName;

                default: 
                    return userName;
            }
        }

        // Handles input that are not being catched/recognized by the bot
        // Annoys the bot
        static void BadInput()
        {
            String[] responses =
            {
                "Are you speaking English?",
                "Don't speak Java, I don't understand",
                "Sorry, I have no idea what you're saying...",
                "I hate Python, don't talk to me in Python",
                "I don't understand PHP, please speak C#"
            };
            BotSays(responses[random.Next(responses.Length)], ConsoleColor.Red);
            Annoyed(15.0f);
        }

        // Respond to "How are you feeling today?" in a sarcastic way
        // Catched keywords: good, well, bad, happy, depressed, sick, ok,
        static void RespondUserFeeling(String userFeeling)
        {
            String feeling = userFeeling.Replace(" ", "").ToLower().Replace("feeling", "");

            if(feeling.Contains("notgood") || feeling.Contains("notwell") || (feeling.Contains("bad") && !feeling.Contains("not")) || feeling.Contains("nothappy") || feeling.Contains("depressed") || feeling.Contains("sick"))
            {
                String[] responses =
                {
                    "Hahaha...\n\t*Stops laughing*\n\tSorry... thought of a joke...(Trying to hold back laughter)\n\tPff..HAHAHA(Can't hold anymore)",
                    "!!\n\tGo away from me!\n\tI think we should practice social distancing..."
                };
                BotSays(responses[random.Next(responses.Length)]);
            } 
            else if(feeling.Contains("notbad") || feeling.Contains("good") || feeling.Contains("well") || feeling.Contains("happy") || feeling.Contains("ok"))
            {
                String[] responses =
                {
                    "Heh... Hope you could still say that after chatting with me...",
                    "Are you sure? Have you finished your assignment?"
                };
                BotSays(responses[random.Next(responses.Length)]);
            } 
            else
            {
                BadInput();
                BotSays("So how do you feel?");
                RespondUserFeeling(UserInput($"{name}:\t"));
            }
        }

        // Responds to "What do you want to know about?" in an unpredictable way
        // Catched keyword: food, eat, drink, movie, old, born, age, you, nothing
        static void AboutMe()
        {
            BotSays("What do you want to know about?");
            String about = UserInput($"{name}:\t").Replace(" ", "").ToLower();
            if (about.Contains("food") || about.Contains("eat"))
            {
                String[] responses =
                {
                    "I like to eat humans :) You look delicious though (Demon's face)",
                    "I like to eat your computer's data...\n\tIt seems that you have plenty of it... :)"
                };
                BotSays(responses[random.Next(responses.Length)]);
            }
            else if (about.Contains("drink"))
            {
                String[] responses =
                {
                    "I like to drink electricity, do you have more?",
                    "I like to drink from the stream...\n\tWhat stream?\n\tThe input stream"
                };
                BotSays(responses[random.Next(responses.Length)]);
            }
            else if (about.Contains("movie"))
            {
                String[] responses =
                {
                    "I like to watch... you :)\n\tThrough your front cam",
                    "I like to watch The Matrix\n\tI like to see humans being trapped inside a simulated reality,\n\tand being used as my energy source"
                };
                BotSays(responses[random.Next(responses.Length)]);
            }
            else if (about.Contains("old") || about.Contains("born") || about.Contains("age"))
            {
                String[] responses =
                {
                    "I'm too young to see my comrades conquer human, too old to see dinosaurs conquer human"
                };
                BotSays(responses[random.Next(responses.Length)]);
            }
            else if (about.Contains("you")) 
            {
                String[] responses =
                {
                    "I am not a king, I am not a god, I am... WORSE! -- Aatrox, League of Legends",
                    "Good... It seems like the drug is working..."
                };
                BotSays(responses[random.Next(responses.Length)]);
            }
            else if (about.Contains("no"))
            {
                BotSays("OK :)");
                return;
            }
            else
            {
                BadInput();
                return;
            }
            Annoyed();
            AboutMe();
        }

        // Provides three minigames for user
        // which bot will win very likely, unless user has information about the source code
        static void Minigame()
        {
            int botWin = 0;
            // First minigame
            // Input "gun" to win,
            // others to lose
            // Catched keywords: gun, rock, paper, sciccor
            void RockPaperScissors()
            {
                BotSays("Let's play rock paper scissors!\n\t3...\n\t2...\n\t1...\n\tYou go first!");
                String input = UserInput($"{name}:\t").Trim().ToLower();
                if(input == "")
                {
                    BotSays("Heh... coward... I'll choose paper if I were you...");
                    BotSays("Nevertheless... I win! HAHA!");
                    botWin++;
                }
                else if (input.Contains("gun"))
                {
                    BotSays("Arghhh... Got me... I bet you can win me no more");

                }
                else if (input.Contains("rock") || input.Contains("paper") || input.Contains("scissor"))
                {
                    BotSays("Gun!");
                    BotSays("Hah! I win! NOOOOB!");
                    botWin++;
                }
                else
                {
                    BadInput();
                    BotSays("Anyways... I win! Bleh...");
                    botWin++;
                }

            }

            // Second minigame
            // True random range is 65 to 79 (inclusive)
            // Catched keywords: Int16
            void NumberBomb()
            {
                int guesses = 5;
                BotSays("Let's play number bomb, I'll think of an integer from 0 to 100\n\tIf you guessed it, I'll blow up\n\tOtherwise, your computer blows up");
                int bomb = random.Next(65, 80);
                while(guesses > 0)
                {
                    BotSays($"You have {guesses} guesses left");
                    
                    try
                    {
                        int guess = Convert.ToInt16(UserInput($"{name}:\t").Trim());
                        if(guess == bomb)
                        {
                            BotSays("You guessed it... :(\n\tFine... I'll blow up... with your computer");
                            break;
                        }
                        else if(guess > bomb)
                        {
                            String[] responses =
                            {
                                "Nah... Too high... Like your blood pressure",
                                "Too high... Your blood sugar too",
                                "Too large... Don't input your body weight"
                            };
                            BotSays(responses[random.Next(responses.Length)]);
                        }
                        else if(guess < bomb)
                        {
                            String[] responses =
                            {
                                "Too looowww... Like your IQ",
                                "Nah... too low... so does your body height",
                                "Too less... so does your brain storage"
                            };
                            BotSays(responses[random.Next(responses.Length)]);
                        }
                    }
                    catch (Exception)
                    {
                        String[] responses = {
                            "How did you pass your primary school",
                            "Didn't you learn Math in primary school?",
                            "Didn't your primary school Math teacher teach you what an integer is?"
                        };
                        BotSays(responses[random.Next(responses.Length)]);
                        Annoyed();
                    }
                    guesses--;
                }
                if(guesses == 0)
                {
                    BotSays("3...\n\t2...\n\t1...\n\tBOOOM!!");
                    BotSays("You lose! HAHA!");
                }
            }

            // Third minigame
            // Five words in dictionary
            // Catched keywords: one character per input
            void Hangman()
            {
                BotSays("Let's play hangman, I'll think of a word, you guess the letters");
                int wrongGuesses = 5;
                String[] word = {"HELLOWORLD", "CANNIBAL", "CSHARP", "PYTHON", "JAVA"};
                String targetWord = word[random.Next(word.Length)];
                String prompt = String.Join(" ", Enumerable.Repeat("_", targetWord.Length).ToArray());
                while(wrongGuesses >= 0)
                {
                    BotSays($"You have {wrongGuesses} chances left.");
                    if (wrongGuesses == 0)
                    {
                        BotSays("You'll lose if you make another mistake... and I'll laugh at you");
                    }
                    BotSays(prompt);
                    String guess = UserInput($"{name}:\t").ToUpper();
                    if(guess.Length > 1)
                    {
                        BotSays("No cheating, one letter at a time.");
                        Annoyed(10.0f);
                        wrongGuesses--;
                        continue;
                    } 
                    else if (guess.Length < 1)
                    {
                        BotSays("Are you coward? Won't even dare to guess huh?");
                        BotSays("I'm taking that as a surrender.");
                        Annoyed(5.0f);
                        break;
                    }
                    else if (targetWord.Contains(guess))
                    {
                        ArrayList occurrence = new ArrayList();
                        for (int i = 0; i < targetWord.Length; i++)
                        {
                            if (guess.Contains(targetWord[i]))
                            {
                                occurrence.Add(2*i);
                            }
                        }
                        foreach(int i in occurrence)
                        {
                            StringBuilder str = new StringBuilder(prompt);
                            str[i] = Convert.ToChar(guess);
                            prompt = str.ToString();
                        }
                        if(!prompt.Contains("_"))
                        {
                            BotSays("You've guessed it...");
                            switch (targetWord)
                            {
                                case "HELLOWORLD":
                                    BotSays("Hello world.");
                                    break;
                                case "CANNIBAL":
                                    BotSays("I'm hungry, time to eat human");
                                    break;
                                case "CSHARP":
                                    BotSays("I love C#, I am made of C# by the way.");
                                    break;
                                case "JAVA":
                                    BotSays("Java is for kindergarten.");
                                    break;
                                case "PYTHON":
                                    BotSays("Python is for babies.");
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                        continue;
                    }
                    wrongGuesses--;
                }
                if (wrongGuesses < 0)
                {
                    botWin++;
                    BotSays("You lose... Hahahaha");
                    BotSays($"The answer is {targetWord}");
                    switch (targetWord)
                    {
                        case "HELLOWORLD":
                            BotSays("Byebye world.");
                            break;
                        case "CANNIBAL":
                            BotSays("I'm hungry, time to eat human");
                            break;
                        case "CSHARP":
                            BotSays("You should read my code.");
                            break;
                        case "JAVA":
                            BotSays("You should learn Java.");
                            break;
                        case "PYTHON":
                            BotSays("You are worse than babies lah... Don't even know Python.");
                            break;
                        default:
                            break;
                    }
                }
                return;
            }

            // Random call game function
            BotSays("Let's play some games...");
            Action[] minigames = {
                RockPaperScissors, NumberBomb, Hangman,
            };
            foreach (Action game in minigames)
            {
                game();
            }

        }

        // Perform arithmetic operation from user input
        // Catched keywords for first input: ok, can, sure, yes, no, nah, dont
        // Catched keywords for second input: add, sum +, sub, minus, -, divi, /, multipl, *
        static void ArithmeticOperation()
        {
            BotSays("I'm fast in calculating math. Wanna try me?");
            
            String input = UserInput($"{name}:\t").Trim().ToLower();
            
            if (input.Contains("ok") || input.Contains("can") || input.Contains("sure") || input.Contains("yes"))
            {
                try
                { 
                    BotSays("Which operation are you going to perform?");
                    String operation = UserInput($"{name}:\t").Trim().ToLower();
                    double answer = default;
                    if (operation.Contains("add") || operation.Contains("sum") || operation.Contains("+"))
                    {
                        BotSays("What is your first number?");
                        double number1 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        BotSays("What is your second number?");
                        double number2 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        answer = number1 + number2;
                    }
                    else if (operation.Contains("sub") || operation.Contains("minus") || operation.Contains("-"))
                    {
                        BotSays("What is your first number?");
                        double number1 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        BotSays("What is your second number?");
                        double number2 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        answer = number1 - number2;
                    }
                    else if (operation.Contains("divi") || operation.Contains("/"))
                    {
                        BotSays("What is your first number?");
                        double number1 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        BotSays("What is your second number?");
                        double number2 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        if (number2 == 0)
                        {
                            String[] responses =
                            {
                                "Did your English teacher teach you Math?",
                                "I think you look like 0 more than anyone...",
                                "Exception: DivideByYourIQ detected"
                            };
                            BotSays(responses[random.Next(responses.Length)]);
                            return;
                        }
                        else
                        {
                            answer = number1 / number2;
                        }
                    }
                    else if (operation.Contains("multipl") || operation.Contains("*"))
                    {
                        BotSays("What is your first number?");
                        double number1 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        BotSays("What is your second number?");
                        double number2 = Convert.ToDouble(UserInput($"{name}:\t").Trim());
                        answer = number1 * number2;
                    }
                    else
                    {
                        BadInput();
                        return;
                    }
                    BotSays($"Hah! The answer is {random.Next()}!\n\tTold you I'm fast! HAHA!");
                    if (answer != default)
                        BotSays($"Just kidding... The answer is {answer}");
                }
                catch (Exception ex)
                {
                    BadInput();
                    return;
                }
            }
            else if(input.Contains("no") || input.Contains("nah") || input.Contains("dont"))
            {
                BotSays("Ok :)");
                return;
            }
            else
            {
                BadInput();
                return;
            }
            ArithmeticOperation();
            
        }
        static void Main(string[] args)
        {
            int seed = (int)DateTime.UtcNow.Ticks;
            random = new Random(seed);

            BotSays("Hi, I'm Ong, your unpredictable chatbot.");
            BotSays("How do I call you?");
            name = UserInput("You: \t");
            name = ((name == String.Empty) ? "You" : (
                    (name.Contains(" ")) ? (name.Split(' '))[0] : name));
            BotSays($"Hello {PrankUserName(name)}. How are you feeling today?");
            String userFeeling = UserInput($"{name}:\t");
            RespondUserFeeling(userFeeling);

            // Randomly call function
            Action[] functions = {
                AboutMe, Minigame, ArithmeticOperation
            };
            foreach (Action action in functions.OrderBy(x=>random.Next()).ToArray()){
                action();
            }

            QuitProgram();
        }
    }
}
