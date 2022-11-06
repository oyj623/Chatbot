# SWE310 Programming Elective II (2) Assignment 1 Question 1

## Question: Chatbot using C#

## Title: Unpredictable chatbot 

## Author: Ong Yi Jun SWE2002109

This is the user manual. The user's input is trimmed, converted to lower case before being catched. When being prompted, the catched keywords will be recognized, and the corresponding type of response will be given. Keywords grouped in parenthesis returns same type of response. Each type of response consists of one or more responses. When a type of response is prompted, only one response is randomly chosen and output to the user. 

#### Q1: How are you feeling today?

Catched keywords:  
- (good, well, happy, ok)  
- (bad, depressed, sick)

### Rest of the questions are asked in a random order

#### Q2~6: What do you want to know about?

**Note: This question will be looped until the user inputs a 'no' or an uncatched input**

Catched keywords:  
- (food, eat)  
- drink  
- movie  
- (old, born, age)  
- you  
- no  

#### Q7~9: Let's play some games...

**Note: There are three minigames in this section, they are called in random sequence**

**Minigame 1: Rock, Paper, Scissors**

Catched keywords:
- gun  
- (rock, paper, scissor)  

**Minigame 2: Number Bomb**

Catched keywords:
- Any integer

**Minigame 3: Hangman**

Catched keywords:
- One character every input

#### Q10: I'm fast in calculating math. Wanna try me?

**Note: This question will be looped until the user inputs a 'no' or an uncatched input**

Catched keywords:
- (ok, can, sure, yes)
- (no, nah, dont)

Q10.1: Which operation are you going to perform?

Catched keywords:
- (add, sum, +)
- (sub, minus, -)
- (divi, /)
- (multipl, *)

Q10.2~10.3: What is your first/second number?

Catched keywords:
- Any numbers
