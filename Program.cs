using System.Text;
namespace Challenge;
internal class Program {
    static void Main (string[] args) {
        Console.Write ("Enter the input: ");
        var ip = Console.ReadLine ()?.ToLower ();
        if (string.IsNullOrWhiteSpace (ip)) return;
        StringBuilder sb = new ();
        char c = ' ';
        for (int i = 0; i < ip!.Length; i++) {
            if (ip![i] >= 'a' && ip![i] <= 'z') {
                Print (c);
                c = ip[i];
            } else if (ip![i] >= '0' && ip![i] <= '9') sb.Append (ip[i]);
            else Print (c);
        }
        if (sb != null) Print (c);

        void Print (char ch) {
            if (int.TryParse (sb.ToString (), out int count)) {
                Console.Write (new string (ch, count));
                sb.Clear ();
            }
        }
    }
}