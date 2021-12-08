using EstudoConsole.Lib;

namespace EstudoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var jogo = new Jogo(
                new Jogador1("Cleomilson"),
                new Jogador2());
            jogo.iniciarJogo();
        }
    } 
}
