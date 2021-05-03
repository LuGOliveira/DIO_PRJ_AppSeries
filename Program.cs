using System;

namespace DIO_PRJ_AppSeries
{
    class Program
    {
        static SerieRepositorio  repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();                        
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigada!");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if(lista.Count ==0)
            {
                Console.WriteLine("Nenhuma seria cadastrada.");
                return;
            }
            foreach( var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1}{2}", serie.retornaID(), serie.retornaTitulo(), (excluido? " *Excluido*" : ""));
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir série"); 

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.WriteLine("Escolha um genêro: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe um Titulo: ");
            string entradaTitulo = Console.ReadLine().ToUpper();

            Console.WriteLine("Informe o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Inclua uma descrição: ");
            string entradaDescricao = Console.ReadLine().ToUpper();

            Serie novaSerie = new Serie(id: repositorio.ProximoID(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo, 
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

         private static void AtualizarSerie(){
            Console.WriteLine("Qual série deseja atualizar?"); 
            int idSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.WriteLine("Escolha um genêro: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe um Titulo: ");
            string entradaTitulo = Console.ReadLine().ToUpper();

            Console.WriteLine("Informe o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Inclua uma descrição: ");
            string entradaDescricao = Console.ReadLine().ToUpper();

            Serie atualizaSerie = new Serie(id: idSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo, 
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(idSerie, atualizaSerie);

        }

        private static void ExcluirSerie(){
            Console.WriteLine("Qual série deseja excluir?"); 
            int idSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(idSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Qual série deseja consultar?"); 
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serie); 

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO - Séries");
            Console.WriteLine("Informe uma opção:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
