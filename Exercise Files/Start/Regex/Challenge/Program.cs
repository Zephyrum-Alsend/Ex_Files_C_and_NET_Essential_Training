// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// After peeking the solution, I know nowhere near enough REGEX to implement this at the moment.
// Rather than have nothing, here's an outline of what was my plan:
/*
Take input
if (DateTime.TryParse(userinput)) {
    Know it's MM/DD/YYYY format
    Scan for the last 4 digits, move them to the front
}
else {
    cw("Not a valid date!");
}
*/
// This could be implemented without REGEX using string parsing or DateTime local cultures.