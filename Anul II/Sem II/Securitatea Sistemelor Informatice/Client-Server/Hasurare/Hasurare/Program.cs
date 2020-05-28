namespace Hasurare
{
    class Program
    {
        static void Main(string[] args)
        {
            //string password = Console.ReadLine();
            A.Init("password");
            for (int i = 0; i < A.t; i++)
                A.LogIn();
        }
    }
}
