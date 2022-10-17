// See https://aka.ms/new-console-template for more information
string exitPhrase = "exit";
string prompt = "Enter a date ('exit' to end).";
string userInput = String.Empty;
DateTime today = DateTime.Today;
DateTime date;
TimeSpan days;

while ( true ) {
    System.Console.WriteLine(prompt);
    userInput = Console.ReadLine();

    if ( userInput == exitPhrase ) break;

    if (DateTime.TryParse(userInput, out date)) {
        days = date - today;
        if ( days.Days == 0 ) {
            System.Console.WriteLine("That date is today!");
        }
        else if ( days.Days < 0 ) {
            System.Console.WriteLine($"That date is {Math.Abs(days.Days)} days ago!");
        }
        else {
            System.Console.WriteLine($"That date is {days.Days} days from now!");
        }
    }
    else {
        System.Console.WriteLine("That doesn't seem like a date...");
    }
}