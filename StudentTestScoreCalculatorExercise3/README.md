## StudentTestScoreCalculatorExercise3 

### Intro
This is a basic program that has the ability to have a list of students and their scores. You can add, remove, and rename (although renaming is a bit buggy) groups with their own lists of students and scores. I used a dictionary for the groups as it is just a key (group name) and the value (Group’s Student List) that are stored.

You can Export the groups in 2 formats, Text format which is meant for just displaying and show off the groups, results and etc. Or Json format which is meant for importing later on, saving or converting to other programs that accept json. The program also has Import function with imports the previously exported json file. 

As an extra, the program also has an info/error text at the bottom to show different errors or info.
### Explanation of features
### List
As the main feature of this program, you can add to a list which you can later calculate the average, min and max of all the students. There is a limit of the mark being between 10 and 0, and the mark field has to be a number
![show](/Images/image1.png)
![show](/Images/image2.png)
##### Errors
![errors](/Images/image3.png)
![errors](/Images/image4.png)

#### Calculate
This is just a button that calculates the average, min and max from the current List
![show](/Images/image5.png)
##### Errors
![errors](/Images/image6.png)

#### Groups
The groups are how List are sorted, each group has a name and the corresponding list to it. These groups can be added, removed, imported and renamed. 
![show](/Images/image7.png)

To rename a group or name a new group, you have to double click. The digit is the number of entries in the group’s list.
##### Errors
![errors](/Images/image8.png)

#### Import
Import just imports a json file that has to be selected.
![show](/Images/image9.png?raw=true)
##### Errors
![errors](/Images/image10.png)

### Export
Export has the ability to export as both text (which is for demonstrating the results in a nice way) and json (which is for importing)
![show](/Images/image11.png)
![show](/Images/image12.png)
![show](/Images/image13.png)

### Summary
This is just the submission for the gcse project and therefore doesn’t have as many features as it could do such as fullscreen, making different stuff smoother and anymore.
