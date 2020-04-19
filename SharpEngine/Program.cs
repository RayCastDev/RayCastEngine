namespace SharpEngine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var game = new Game(1280, 720, "SharpEngine"))
            {
                game.VSync = OpenTK.VSyncMode.On;
                game.Run(60);
            }
        }
    }
}
