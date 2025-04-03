using System.Threading.Channels;

namespace jogoDosDados.ConsoleApp1
{
    /*
     *   int sorte = Random NumeroDaSorte = new Random();
     */
    internal class Program
    {
        const int limiteLinhaChegada = 30;
        static void Main(string[] args)
        {
            while (true)
            {
                int posicaoUsuario = 0;
                int posicaoConputador = 0;

                bool jogoEstaEmAndamento = true;
               
                 Random numroDaSorte = new Random();
                int Sorter = numroDaSorte.Next(1, 29);

                while (jogoEstaEmAndamento)
                {
                    PosicaoDoJogador();
                    PosicaoDoComputador();
                }
               
                string opcaoContinuar = ExibirMenuContinuar();

                if (opcaoContinuar != "s")
                    break;
            }

        }
        static void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("---------------------------------------");

            Console.Write("pressione ENTER para lançar o dado . . .");
            Console.ReadLine();
        }

        static int  LancaDado()
        {
            Random geradorDeNumeros = new Random();

            int resultado = geradorDeNumeros.Next(1, 7);

            return resultado;
        }

        static void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado} ");
            Console.WriteLine("---------------------------------------");
        }
        static string  ExibirMenuContinuar()
        {
            Console.Write("Deseja continuar? s/n");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }
        static bool PosicaoDoJogador(int posicaoUsuario)
        {
            bool jogoEstaEmAndamento = true;

            //Usuaio
            ExibirCabecalho();

            int resultado = LancaDado();

            ExibirResultadoSorteio(resultado);

            posicaoUsuario += resultado;

            Console.WriteLine("---------------------------------------");

            if (posicaoUsuario >= limiteLinhaChegada)
            {
                Console.Clear();
                Console.WriteLine("parabéns, você alacançou a linha de chegada");

                jogoEstaEmAndamento = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"O jogador está na posiçao : {posicaoUsuario} de {limiteLinhaChegada}");
            }
            Console.Write("pressione ENTER para continuar . . .");
            Console.ReadLine();
            return jogoEstaEmAndamento;
        }
        static void PosicaoDoComputador(int posicaoConputador)
        {
            bool jogoEstaEmAndamento = true;
            
            // computador
            ExibirCabecalho();

            int resultadoComputador = LancaDado();

            ExibirResultadoSorteio(resultadoComputador);

            posicaoConputador += resultadoComputador;

            Console.WriteLine("---------------------------------------");

            if (posicaoConputador >= limiteLinhaChegada)
            {
                Console.WriteLine("o computador ganhou :(");

                jogoEstaEmAndamento = false;
            }
            else
            {
                Console.WriteLine($"O computador está na posiçao : {posicaoConputador} de {limiteLinhaChegada}");
                Console.WriteLine("---------------------------------------");
            }
            Console.Write("pressione ENTER para continuar . . .");
            Console.ReadLine();
        }
    }
}
