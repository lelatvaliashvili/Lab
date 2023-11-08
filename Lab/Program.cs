

#region RollingTheDice

/***
* 
*You roll two dice. Each die has six faces, which contain one, two, three, four, five andsix spots, respectively. 
*After the dice have come to rest, the sum of the spots on the two upward faces is calculated. 
*If the sum is 7 or 11 on the first throw, you win.
*If the sum is 2, 3 or 12 on the first throw (called “craps”), you lose.
*If the sum is 4, 5, 6, 8, 9 or 10 on the first throw, that sum becomes your “point.” 
*To win, you must continue rolling the dice until you “make your point” (i.e., roll that same point value).
*You lose by rolling a 7 before making your point.
*making your point" means achieving the same total value as the point set during the first throw
* 
*/

using Lab;

PlayGame();

static void PlayGame()
{
    var random = new Random();
    var state = GameState.Continue;
    var point = 0;

    while (state == GameState.Continue)
    {
        //start rolling the dice
        var sum = RollDice(random);

        switch (sum)
        {
            case 7:
            case 11:
                state = GameState.Win;
                break;
            case 2:
            case 3:
            case 12:
                state = GameState.Craps;
                break;
            default:
                state = GameState.Point;
                point = sum;
                break;
        }

        //map state to the results
        switch (state)
        {
            case GameState.Win:
                Console.WriteLine("You win!");
                break;
            case GameState.Craps:
                Console.WriteLine("You lost");
                break;
            case GameState.Point:
                Console.WriteLine($"Your point {point}");
                ContinueRolling(random, point);
                break;
        }
    }
}

static void ContinueRolling(Random random, int point)
{
    while (true)
    {
        int sum = RollDice(random);

        if (sum == point)
        {
            Console.WriteLine("The sum equals to the point, congrats!");
            break;
        }
        else if (sum == 7)
        {
            Console.WriteLine("You rolled 7, You lost!");
            break;
        }
    }
}

static int RollDice(Random random)
{
    var number1 = random.Next(1, 7);
    var number2 = random.Next(1, 7);
    var sum = number1 + number2;
    Console.WriteLine($"You rolled {number1} and {number2}. Total is: {sum}");
    return sum;
}
#endregion '

#region Do-While

int number;
do
{
    //input the number
    //determine if its positive, negative or 0
    Console.WriteLine("Enter an integer: ");
    if (int.TryParse(Console.ReadLine(), out number))
    {
        var type = FindIntType(number);
        if (type == 1)
        {
            Console.WriteLine("Positive");
        }
        else if (type == -1)
        {
            Console.WriteLine("Negative");
        }
        else
        {
            Console.WriteLine("Zero");
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid integer");
    }
} while (number != 0);

static int FindIntType(int number)
{
    //+ 1
    //- -1
    //0 0
    if (number > 0)
    {
        return 1;
    }
    else if (number < 0)
    {
        return -1;
    }
    else
    {
        return 0;
    }
}
#endregion

#region ref and out

int a = 5;
int b = 10;
Console.WriteLine($"Before swap: a= {a}, b = {b}");

SwapValuesWithOut(a, b, out a, out b);

Console.WriteLine($"After swap: a= {a}, b = {b}");


static void SwapValuesWithOut(int x, int y, out int a, out int b)
{
    a = y;
    b = x;
}
#endregion

#region const

const int arraySize = 10;

var arr2 = new int[arraySize];

arr2[0] = 1;

#endregion


#region Resize the Array
var arr = new int[] { 1, 3, 4, 5 };

PrintArray(arr);
Array.Resize(ref arr, 3);

Console.WriteLine("\nArray after resizing to a smaller size: ");
PrintArray(arr);

//ensure that reassignment of the array is reflected outside the method.
//Array.Resize(ref arr, 10);
//PrintArray(arr);

ModifyArrayAtIndex1(arr);
PrintArray(arr);


static void ModifyArrayAtIndex1(int[] arr)
{
    if (arr.Length > 1)
    {
        arr[1] = 100;
    }
}
static void PrintArray(int[] arr)
{
    //foreach (var item in arr)
    //{
    //    Console.WriteLine(item + " ");
    //}
    for (int i = 0; i < arr.Length; i++)
    {
        var updatedValueinArray = arr[100];
        Console.WriteLine(updatedValueinArray);
    }
}

#endregion

#region Try catch finally
Console.WriteLine("Enter the number: ");
int firstNumber = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the second number: ");
int secondNumber = int.Parse(Console.ReadLine());

try
{
    //code that may raise the exception
    int result = firstNumber / secondNumber; //0
    Console.WriteLine("The result of devision: " + result);
}
catch (Exception ex)
{
    Console.WriteLine("An exception has occured: " + ex.Message);
}
finally
{
    Console.WriteLine("Sum of the two numbers is: " + (firstNumber + secondNumber));
}
#endregion
