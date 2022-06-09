namespace MGDesktopApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
}

// ** Alterar o tipo do projeto de ConsoleApplication para WindowsApplication para abrir apenas a tela do jogo sem a console