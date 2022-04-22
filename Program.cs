bool continueLoop = true;
const int tableWidth = 73;
while (continueLoop)
{
    Console.Clear();
    PrintLine();
    PrintRow("Input", "Squared", "Cubed"); // Names of the columns
    PrintLine();
    // ask for user input
    int usersNumber = AskForNumber(); // Method for asking for user input specifically a int



    // loop to create the amount of rows based on the users input
    for (int i = 1; i <= usersNumber; i++)
    {
        PrintRow(i.ToString(), (i * i).ToString(), (i * i * i).ToString());
        // Had to use ToString() on i because the PrintRow method takes a string array as parameter and int would break the method



    }
    PrintLine();
    continueLoop = DoYouWantToContinueLoop(continueLoop); // ask user if they want to continue to input more numbers
}




static void PrintLine()
{
    Console.WriteLine(new string('-', tableWidth));
}



static void PrintRow(params string[] columns)
{
    int width = (tableWidth - columns.Length) / columns.Length;
    string row = "|";



    PrintLine();
    foreach (string column in columns)
    {
        row += AlignCentre(column, width) + "|";
    }



    Console.WriteLine(row);
}



static int AskForNumber() // Ask user for number method
{
    PrintQuestion("Please enter a number you want squared and cubed: ");
    string userInput = Console.ReadLine(); // store user input
    int numberForTable; // create out variable for try parse method used on next line
    bool parsedUserInput = int.TryParse(userInput, out numberForTable); // try parse method returns true if number is paresed successfully
    if (parsedUserInput) //Checking to see if user inputted valid number
    {
        return numberForTable; // returns users number
    }
    else
    {
        throw new Exception("Did not give a number"); // Throw error if parse failed
    }



}






static string AlignCentre(string text, int width)
{
    text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;



    if (string.IsNullOrEmpty(text))
    {
        return new string(' ', width);
    }
    else
    {
        return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
    }
}




static void PrintQuestion(string question)
{
    Console.WriteLine($"{question}");
}



static bool DoYouWantToContinueLoop(bool continueLoop)
{
    PrintQuestion("Would you like to try another number? Y/N");
    string userAnswer = Console.ReadLine();
    if (userAnswer.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || userAnswer.Contains("y"))
    {
        // continue loop
        // no need to change anything since continueLoop is already true
    }
    else
    {
        continueLoop = false;
        //break loop
    }



    return continueLoop;
}
