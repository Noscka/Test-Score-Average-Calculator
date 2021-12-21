#include <iostream>
#include <string>
#include <limits>

/// <summary>
/// Check if String is just numbers
/// </summary>
/// <param name="str">String to Check</param>
/// <returns>True if only numbers, False if not just numbers</returns>
bool isNumber(const std::string& str)
{
    for(char const& c : str)
    {
        if(std::isdigit(c) == 0) return false;
    }
    return true;
}

int main()
{
    //setting up all the variables
    std::string TestScoreNumber, StrInput;
    int input= 0, currentIteration = 1;
    float total = 0;
    bool CorrectValue = true, ContinueAsking = true;

    //Just ASCII art
    std::cout << "   _____ __            __           __     ______          __     ______      __           __      __" << std::endl;
    std::cout << "  / ___// /___  ______/ /__  ____  / /_   /_  __/__  _____/ /_   / ____/___ _/ /______  __/ /___ _/ /_____  _____" << std::endl;
    std::cout << "  \\__ \\/ __/ / / / __  / _ \\/ __ \\/ __/    / / / _ \\/ ___/ __/  / /   / __ `/ / ___/ / / / / __ `/ __/ __ \\/ ___/" << std::endl;
    std::cout << " ___/ / /_/ /_/ / /_/ /  __/ / / / /_     / / /  __(__  ) /_   / /___/ /_/ / / /__/ /_/ / / /_/ / /_/ /_/ / /" << std::endl;
    std::cout << "/____/\\__/\\__,_/\\__,_/\\___/_/ /_/\\__/    /_/  \\___/____/\\__/   \\____/\\__,_/_/\\___/\\__,_/_/\\__,_/\\__/\\____/_/" << std::endl;

    std::cout << std::endl;

    //Explaination
    std::cout << "You can input as many Student Score Entries to this \"calculator\"" << std::endl;
    std::cout << "The inputs have to between 0 and 10" << std::endl;
    std::cout << "The inputs have to be interger, so it can not be character or float(Decimal Number)" << std::endl;
    std::cout << std::endl;
    std::cout << "To stop asking for entries and calculate, Simply enter \"x\"" << std::endl;

    std::cout << std::endl;
    std::cout << "====================================================================================" << std::endl;
    std::cout << std::endl;

    //While loop, the boolean will be set to true untill x in inputed, then break loop
    while(ContinueAsking)
    {
        CorrectValue = true;
        //Logic for figuring out if inside the question it should say st,nd,rd or th according to the number
        if(currentIteration > 3)
        {
            TestScoreNumber = std::to_string(currentIteration) + "th";
        }
        else
        {
            switch(currentIteration)
            {
            case 1:
                TestScoreNumber = std::to_string(currentIteration) + "st";
                break;
            case 2:
                TestScoreNumber = std::to_string(currentIteration) + "nd";
                break;
            case 3:
                TestScoreNumber = std::to_string(currentIteration) + "rd";
                break;
            }
        }

        currentIteration++; //increment value
        total += input;
        input = -2; // so input from last time doesn't get carried over

        //While loop meant to see if the input is with in range (0 to 10)
        while(CorrectValue)
        {
            std::cout << TestScoreNumber << " Input Score: ";

            std::getline(std::cin, StrInput);

            if(!StrInput.empty())
            {
                if(isNumber(StrInput)) // check if input string is just numbers
                {
                    input = std::stoi(StrInput);

                    if(input >= 0 && input <= 10) //check if number is in range of 0 to 10
                    {
                        CorrectValue = false;
                    }
                    else
                    {
                        std::cout << "Please Input a Value that is inbetween 0 and 10" << std::endl;
                    }
                }
                else
                {
                    if(StrInput == "x") // if not just numbers, check if it just x and if yes, break and end loop to go onto calculations
                    {
                        if(total == 0)
                        {
                            std::cout << "Please enter some values first" << std::endl;
                        }
                        else
                        {
                            CorrectValue = false;
                            ContinueAsking = false;
                        }
                    }
                    else
                    {
                        std::cout << "Please Input an interger, Don't input any characters or decimal numbers" << std::endl;
                    }
                }
            }
            else
            {
                std::cout << "Please Input a value" << std::endl;
            }
            
        }
    }
    //divide total (all scores added up) by the currentIteration(basically amount of values that got added) but -2 as it starts at 1 plus the x input counts as an iterations
    std::cout << "Average Score is: " << total / (currentIteration-2) << std::endl;
    
    //Just so screen doesn't instantly disappear
    std::cout << "Press ENTER to continue... ";
    std::getchar();
    return 0;
}