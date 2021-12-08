using EstudoConsole.Interface;

namespace EstudoConsole
{
    public class Jogo
    {
        private readonly Jogador _jogador1;
        private readonly Jogador _jogador2;

        //CTRL + . para ver opções de algo
        public Jogo(Jogador jogador1, Jogador jogador2)
        {
            _jogador1 = jogador1;
            _jogador2 = jogador2;
        }
        public void iniciarJogo()
        {
            //System.Console.WriteLine($"{ _jogador._nome } deu 1 passo");
            System.Console.WriteLine(_jogador1.Corre());
            System.Console.WriteLine(_jogador1.Chuta());
            System.Console.WriteLine(_jogador1.Passa());

            System.Console.WriteLine("\nPROXIMO JOGADOR \n");

            System.Console.WriteLine(_jogador2.Corre());
            System.Console.WriteLine(_jogador2.Chuta());
            System.Console.WriteLine(_jogador2.Passa());
        }
    }
}