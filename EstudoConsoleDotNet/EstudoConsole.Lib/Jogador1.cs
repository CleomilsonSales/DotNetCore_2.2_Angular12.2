using EstudoConsole.Interface;

namespace EstudoConsole.Lib
{
    public class Jogador1 : Jogador
    {
        public readonly string _nome;

        public Jogador1(string nome = "JogadorDefault") //ao instanciar aqui a variavel recebida, isso me permite não informar a variavel na criação do objeto
        {
           _nome =  nome; 
        }

        public string Chuta()
        {
            return $"{ _nome } esta chutando!";
        }
        public string Corre()
        {
            return $"{ _nome } esta correndo!";
        }
        public string Passa()
        {
            return $"{ _nome } esta passando!";
        }
    }
}