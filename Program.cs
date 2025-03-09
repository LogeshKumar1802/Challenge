namespace Challenge;
internal class Program {
    static void Main (string[] args) {
        Console.Write ("Enter the number: ");
        var ip = Console.ReadLine ();
        if (int.TryParse (ip, out int num)) {
            Console.WriteLine ("1");
            if (num == 1) return;
            int prevFirstNum = 1;
            for (int i = 2, tempNum = num, temp = 0, counter = 0, add = 0; i <= num; i++) {
                prevFirstNum += tempNum--;
                counter = i - 1; add = tempNum;
                Console.Write (prevFirstNum + " ");
                temp = prevFirstNum;
                while (counter-- != 0) Console.Write ((temp -= add++) + " ");
                Console.WriteLine ();
            }
        } else Console.WriteLine ("Invaild number");
    }
}
