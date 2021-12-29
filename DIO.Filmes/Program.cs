using System;

namespace DIO.Filmes
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
                                  
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;

                    case "2":
                        InserirFilme();
                        break;
                    
                    case "3":
                        AtualizarFilme();
                        break;

                    case "4":
                        ExcluirFilme();
                        break;

                    case "5":
                        VisualizarFilme();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();


                    
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossa plataforma.");
            Console.ReadLine();
        }

        private static void ExcluirFilme()
        {
            System.Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceFilme);
        }

        private static void VisualizarFilme()
        {
            System.Console.WriteLine("Digite o id do filme: ");
              int indiceFilme = int.Parse(Console.ReadLine()); 
              var filme = repositorio.RetornaPorId(indiceFilme);

              System.Console.WriteLine(filme);
        }

        private static void AtualizarFilme()
        {
            System.Console.WriteLine("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero), i ));
            }

            System.Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano do filme : ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição do filme : ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizarFilme = new Filme(id : indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

        repositorio.Atualiza(indiceFilme, atualizarFilme);
        
        }

        private static void ListarFilmes()
        {
            System.Console.WriteLine("Listar filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum filme cadastrado. ");
                return;
            }
            foreach(var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                if(!excluido)
                {
                System.Console.WriteLine("#ID {0}:   -   {1}", filme.retornaId(), filme.retornaTitulo());
                }
            }
        }

        private static void InserirFilme()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero), i ) );
            }
            System.Console.WriteLine("Digite o gênero entre as opçãos acima : ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título do filme : ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano do filme : ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Descrição do filme : ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id : repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoFilme);

        }



        private  static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Max Filmes a seu dispor !");
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1- Listar filmes ");
            System.Console.WriteLine("2- Inserir novo filme");
            System.Console.WriteLine("3- Atualizar filme ");
            System.Console.WriteLine("4- Excluir filme ");
            System.Console.WriteLine("5- Visualizar filmes ");
            System.Console.WriteLine("C- Limpar Tela ");
            System.Console.WriteLine("X- Sair ");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }

    }
}