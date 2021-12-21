#include <iostream>
#include <string>
#include <limits>

int main()
{
	//setting up all the variables
	std::string TestScoreNumber;
	char ch;
	int input;
	float total = 0;
	bool CorrectValue = true;

	//Just ASCII art
	std::cout << "   _____ __            __           __     ______          __     ______      __           __      __" << std::endl;
	std::cout << "  / ___// /___  ______/ /__  ____  / /_   /_  __/__  _____/ /_   / ____/___ _/ /______  __/ /___ _/ /_____  _____" << std::endl;
	std::cout << "  \\__ \\/ __/ / / / __  / _ \\/ __ \\/ __/    / / / _ \\/ ___/ __/  / /   / __ `/ / ___/ / / / / __ `/ __/ __ \\/ ___/" << std::endl;
	std::cout << " ___/ / /_/ /_/ / /_/ /  __/ / / / /_     / / /  __(__  ) /_   / /___/ /_/ / / /__/ /_/ / / /_/ / /_/ /_/ / /" << std::endl;
	std::cout << "/____/\\__/\\__,_/\\__,_/\\___/_/ /_/\\__/    /_/  \\___/____/\\__/   \\____/\\__,_/_/\\___/\\__,_/_/\\__,_/\\__/\\____/_/" << std::endl;

	std::cout << std::endl;

	//Explaination
	std::cout << "This \"Calculator\" asks for 10 Student Test scores and then averages at the end" << std::endl;
	std::cout << "The inputs have to between 0 and 10" << std::endl;
	std::cout << "The inputs have to be interger, so it can not be character or float(Decimal Number)" << std::endl;

	std::cout << std::endl;
	std::cout << "====================================================================================" << std::endl;
	std::cout << std::endl;


	//For loop, loops 10 times asking for TestScoreInput
	//Start at 1 as to make everything not start at 0
	for(int i = 1; i < 11; i++)
	{
		CorrectValue = true;
		//Logic for figuring out if inside the question it should say st,nd,rd or th according to the number
		if(i > 3)
		{
			TestScoreNumber = std::to_string(i) + "th";
		}
		else
		{
			switch(i)
			{
			case 1:
				TestScoreNumber = std::to_string(i) + "st";
				break;
			case 2:
				TestScoreNumber = std::to_string(i) + "nd";
				break;
			case 3:
				TestScoreNumber = std::to_string(i) + "rd";
				break;
			}
		}
		//While loop meant to see if the input is with in range (0 to 10)
		while(CorrectValue)
		{
			std::cout << TestScoreNumber << " Input Score: ";
			/*
			Get User inputand convert to int.Then get the first character from the input line
			If characeter doesn't equal character 10 (New line I am assuming), it means the line wans't straight numbers so there for float or characters
			*/
			std::cin >> input;
			std::cin.get(ch);

			if(!(ch == 10))
			{
				std::cout << "Please Input an interger, Don't input any characters or decimal numbers" << std::endl;
				std::cin.clear();
				std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); // This makes input ignore till new line so it doesn't take the output as input (inf loop)
			}
			else if(input >= 0 && input <= 10) //check if number is in range of 0 tp 10
			{
				CorrectValue = false;
			}
			else
			{
				std::cout << "Please Input a Value that is inbetween 0 and 10" << std::endl;
			}
		}
		total += input;
	}
	std::cout << "Average Score is: " << total / 10 << std::endl;

	//Just so screen doesn't instantly disappear
	std::cout << "Press ENTER to continue... ";
	std::getchar();
	return 0;
}