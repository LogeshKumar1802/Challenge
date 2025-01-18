namespace Challenge;
internal class Program {
    static void Main (string[] args) {
        int dice1 = 1, dice2 = 1, dice3 = 1, allAreEqual = 1, anyTwoequal = 1, allAreUnique = 1;
        while (dice1 <= 6) {
            bool a = dice1 == dice2, b = dice2 == dice3, c = dice1 == dice3;
            if (!a && !b && !c) Console.WriteLine ($"{dice1},{dice2},{dice3}  =>  {allAreUnique++}");
            else if (a && b && c) Console.WriteLine ($"{dice1},{dice2},{dice3}  =>  {allAreEqual++}");
            else Console.WriteLine ($"{dice1},{dice2},{dice3}  =>  {anyTwoequal++}");
            // The below if condition is working on a basis of analog speedometer.
            // Like once dice 3 reached value 6, then dice 3 is reset to 1. Whenever dice 2
            // reached value 6, then only dice 1 get increment by 1 and dice 2 is reset to 1.
            if (++dice3 > 6) {
                dice3 = 1;
                if (++dice2 > 6) { dice2 = 1; dice1++; }
            }
        }
    }
}