# Budget (ITSE 1430)
## Version 1.0

In this lab you will create a console application to manage a simple budget.

[Skills Needed](#skills-needed)\
[General Guidelines](#general-guidelines) \
[Story 1](#story-1)\
[Story 2](#story-2)\
[Story 3](#story-3)\
[Story 4](#story-4)\
[Story 5](#story-5)\
[Story 6](#story-6)\
[Console Help](#Console Help)\
[Requirements](#requirements)

## Skills Needed

- C#
  - Control flow statements
  - Functions and parameters
  - Types
  - Variables
- Console read/write

## General Guidelines

### General 

- It is strongly recommended that you complete the stories in order. Some stories rely on the work done in previous stories.
- Commit your changes to Github frequently to ensure you don't lose any work. You do not need to wait for a story to be completed.
- After you implement a story ensure it meets all the acceptance criteria. In some cases a later story may change the behavior of an earlier story.
- After you complete a story you should commit the changes you've made to Github. If something comes up and you are not able to complete the remaining stories you can at least get credit for the work you've done.
- Unless otherwise stated all inputs must be validated to ensure they are of the current type and range as given in the assignment.

### Naming Conventions

- USE descriptive nouns for variable and parameter identifiers (e.g. `payRate`, `name`, `index`).
- USE descriptive verbs for function identifiers (e.g. `getName`, `showProgress`).
- DO NOT use single letters or abbreviations in identifiers (e.g. `x`, `descriptValue`).
- DO ensure spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

### Coding Style

- DO put a file header at the top of each file you create. The file header should contain the class, date and your name.
  ```csharp
  /*
   * Your Name
   * ITSE 1430 
   * Lab 1
   */
  ```
- DO use consistent indentation. In general each block indents one time (3 or 4 spaces). Curly braces should be aligned.
  ```csharp
  //NO
  while (someCondition) 
     { 
    Foo();
	     };
		 
  //YES
  while (someCondition)
  {
     Foo();
  };
  ```
- DO use a single blank line between blocks of code (e.g. functions, control flow statements, etc).
  ```csharp
  //NO
  void DoWork ()
  {
  }
  void DoMoreWork()
  {
  }
  
  //YES
  void DoWork ()
  {
  }
  
  void DoWork ()
  {
  }
  ```
- DO consider declaring variables just before or as part of their first usage instead of up front.
  ```csharp
  //NO
  int hours;
  double payRate, totalPay;
  ...
  totalPay = payRate * hours;
  
  //YES
  double totalPay = payRate * hours;
  ```
- DO put comments above code that is not clear.
- DO NOT put comments in code that repeats what the code does.
  ```csharp
  //NO
  //Loop through stuff
  for (...)
  //YES
  for (...)
  ```
  
## Story 1 - Create the Project

Create a new console project to hold your code.

### Description 

For this first lab here are the directions.

1. Start Visual Studio.
1. Create a new project by using the `Create a new project` option in the `Start Window`.
   1. Under the languages filter select `C#`. Then search for the template `Console App`.
   1. Select `Console App (.NET Core)`. Ensure that the language is shown as `C#`. Click `Next`.
   1. For the project name use `Budget`.
   1. Ensure the project location is set to the `Labs` folder of your Github repo that you have previously cloned.
   1. Click `Create` to create the project.
1. Display basic program information including your name and the program name of `Budget`.

### Acceptance Criteria

1. The application compiles cleanly without warnings or errors.
1. The application runs.
1. Can see the program information on startup.

## Story 2 - Get Starting Account 

Prompt the user for the starting account information.

### Description

Prompt the user for the account information. The foilowing information is needed.

Name +
: An account nickname. This field is required and cannot be empty.
Account Number +
: An account number. This field is required and must be a series of unique numbers.
Starting Balance +
: The starting balance. This field is a monetary amount and is required. It must be greater than zero.

In all cases perform input validation. If the input is invalid then keep prompting until the user enters the correct information. Show proper error messages.

*Note 1: Use `string` for the account number.*
*Note 2: Use `decimal` for the balance.*
*Note 3: Account information is needed for the entire application so the information needs to be stored outside the function.*

### Acceptance Criteria

1. User is prompted for the starting information.
1. Input is validated and errors shown. User is prompted to enter information again.
1. Required fields are required.
1. Account number only allows numbers.
1. Balance is greater than zero.

## Story 3 - Display the Main Menu

Display a menu of options to the user.

### Description

The user will need to choose from a list of options in a menu. Set up a simple menu function that displays the available menu options, validates the user input and calls the appropriate function to handle the request.

If the user enters an invalid option then display an error and prompt them again. For now put in a menu option to quit the program.

For user input you should use either letters or numbers to get input (you don't need both). For example a quit command may be mapped to the letter `Q` or the number `0`. You may use whichever is easiest for you but be consistent. 

*Note: When using letters case should not matter.*

Unless otherwise stated after a command is executed the user should return to the main menu so they may choose another option.

The account information should be shown at the top of the menu in all cases. The balance should be formatted as currency.

*Note: Create a helper function to display the menu.*
*Note: Consider using an enumeration to identify the options.*
*Note: To show prices use the currency format specifier `balance.ToString("C")`.*

### Acceptance Criteria

1. User is shown a menu of options.
1. If a user selects a valid menu option then that acction is performed.
1. If a user selects an incorrect option then they receive an error message and can try again.
1. If letters are used for menu options then case does not matter.
1. The account information is shown at the top of the menu each time.

## Story 4 - Quit

Allows the user to exit the program.

### Description

Implement the function to handle the quit menu item added previously. It should be the last option in the menu. 
If the user selects the quit option then prompt them for confirmation and then quit.

*Note: Consider creating a function to prompt for Yes/No questions and returns a boolean result. A simple Y/N is sufficient.*

### Acceptance Criteria

1. Command appears as last option in menu.
1. Selecting command prompts user to confirm.
1. User is limited to the defined yes/no options.
1. Case does not matter on user input.
1. Confirming quit terminates program.
1. Declining quit returns to menu.

## Story 5 - Add Income

Allows the user to add money to the account.

### Description

Add an option to the menu to add money to the account. To add money the user must provide some information first.

Amount +
: The amount to add. This value is required and must be greater than zero.
Description +
: The description. This value is required and cannot be empty.
Category +
: The optional category.
Date +
: The entry date. Defaults to the current date. The date must be in the format `MM/dd/yyyy'. 

*Note 1: Refer to `String Parsing` in the book for information on string parsing.*

After the information has been entered and validated update the balance for the account.

Display a confirmation that the information was added.

*Note 2: Consider adding helper functions to collect standard information such as required strings.*

*Note 3: None of the information is needed after the data entry.*

### Acceptance Criteria

1. Users is prompted for each piece of information.
1. Input validation is performed based upon requirements.
1. Account balance is updated and success message displayed.
1. User returns to the main menu.

## Story 6 - Add Expense

Allows the user to remove money from the account.

### Description

Add an option to the menu to add expense to the account. To add an expense the user must provide some information first.

Amount +
: The expense amount. The value is required and must be greater than 0.
Description +
: The description. This value is required and cannot be empty.
Category +
: The optional category.
Date +
: The entry date. Defaults to current date. Must be formatted as `MM/dd/yyyy`.

Handle input validation errors. Prompt the user until they enter the correct information.

The expense cannot decrease the balance below zero. If the balance will be below zero then report insufficient funds to the user.

*Note 1: Refer to `String Parsing` in the book for information on string parsing.*

After the information has been entered and validated update the balance for the account.

Display a confirmation that the information was added.

*Note 2: Consider adding helper functions to collect standard information such as required strings.*

*Note 3: None of the information is needed after the data entry.*

### Acceptance Criteria

1. Users is prompted for each piece of information.
1. Input validation is performed based upon requirements.
1. If the expense is more than the balance then report insufficient funds.
1. Account balance is updated and success message displayed.
1. User returns to the main menu.

## Console Help 

Refer to the `Console` section of the book for information on using the console.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.