// Advent of Code 2023

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

partial class Program
{
    static void Main()
    {
        // Day01PartOne();
        // Day01PartTwo();
        Day02PartOne();
    }

    // Day 01 - Part One
    static void Day01PartOne()
    {
        string input =
        @"1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet";

        string[] inputArray = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        List<string> outputArray = new List<string>();

        foreach (string line in inputArray)
        {
            List<char> numbers = new List<char>();

            foreach (char character in line)
            {
                if (char.IsDigit(character))
                {
                    numbers.Add(character);
                }
            }

            string combinedNumber = new string(numbers[0].ToString() + numbers[numbers.Count - 1].ToString());
            outputArray.Add(combinedNumber);
        }

        int sum = 0;

        foreach (string output in outputArray)
        {
            sum += int.Parse(output);
        }

        Console.WriteLine(sum);
    }

    // Day 01 - Part Two
    static void Day01PartTwo()
    {
        string input =
        @"two1nine
        eightwothree
        abcone2threexyz
        xtwone3four
        4nineeightseven2
        zoneight234
        7pqrstsixteen";

        Dictionary<string, string> digits = new Dictionary<string, string>
        {
            {"one", "o1e"},
            {"two", "t2o"},
            {"three", "t3e"},
            {"four", "f4r"},
            {"five", "f5e"},
            {"six", "s6x"},
            {"seven", "s7n"},
            {"eight", "e8t"},
            {"nine", "n9e"}
        };

        string[] inputArray = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        List<string> outputArray = new List<string>();

        foreach (string line in inputArray)
        {
            List<char> numbers = new List<char>();

            string modifiedLine = line;

            foreach (KeyValuePair<string, string> digit in digits)
            {
                modifiedLine = modifiedLine.Replace(digit.Key, digit.Value.ToString());
            }

            foreach (char character in modifiedLine)
            {
                if (char.IsDigit(character))
                {
                    numbers.Add(character);
                }
            }

            string combinedNumber = new string(numbers[0].ToString() + numbers[numbers.Count - 1].ToString());
            outputArray.Add(combinedNumber);
        }

        int sum = 0;

        foreach (string output in outputArray)
        {
            sum += int.Parse(output);
        }

        Console.WriteLine(sum);
    }

    // Day 02 - Part One
    static void Day02PartOne()
    {
        string input =
        @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

        string[] games = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        int gamesCompleted = 0;

        int cubesRed = 12;
        int cubesGreen = 13;
        int cubesBlue = 14;

        int id = 0;

        for (int i = 0; i < games.Length; i++)
        {
            id++;

            games[i] = Regex.Replace(games[i], @"^Game \d+: ", string.Empty);

            string[] gamesSplit = games[i].Split(";", StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            int countAll = 0;

            foreach (string game in gamesSplit)
            {
                string[] cubes = game.Split(",", StringSplitOptions.RemoveEmptyEntries);

                int check_red = 0;
                int check_green = 0;
                int check_blue = 0;

                int check = 0;

                foreach (string cubeColor in cubes)
                {
                    int number = ExtractNumber(cubeColor);
                    string color = ExtractColor(cubeColor);
                    
                    if (color == "red")
                    {
                        check++;
                        if (number <= cubesRed)
                            check_red = 1;
                    }
                    if (color == "green")
                    {
                        check++;
                        if (number <= cubesGreen)
                            check_green = 1;
                    }
                    if (color == "blue")
                    {
                        check++;
                        if (number <= cubesBlue)
                            check_blue = 1;
                    }
                }

                int colorSum = check_red + check_green + check_blue;

                if ((check == 3 && colorSum == 3) || (check == 2 && colorSum == 2) || (check == 1 && colorSum == 1))
                {
                    count++;
                }

                countAll++;
            }

            if (count == countAll)
            {
                gamesCompleted += id;
            }
        }

        Console.WriteLine(gamesCompleted);
    }
    public static int ExtractNumber(string input)
    {
        Match match = Regex.Match(input, @"(\d+)");
        return match.Success ? int.Parse(match.Groups[1].Value) : 0;
    }
    public static string ExtractColor(string input)
    {
        Match match = Regex.Match(input, @"\d+\s+(\w+)");
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
}