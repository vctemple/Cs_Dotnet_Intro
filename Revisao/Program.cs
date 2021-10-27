using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = obtermenu();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Informe a nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                           aluno.Nota = nota; 
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos [indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome}; NOTA: {a.Nota}");

                            }
                            
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var NAluno = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                NAluno++;
                            }
                        }

                        var MediaGeral = notaTotal/NAluno;
                        conceito conceitoG;

                        if (MediaGeral <= 3)
                        {
                            conceitoG = conceito.E;
                        }
                        else if (MediaGeral > 3 && MediaGeral <= 5)
                        {
                            conceitoG = conceito.D;
                        }
                        else if (MediaGeral > 5 && MediaGeral <= 7)
                        {
                            conceitoG = conceito.C;
                        }
                        else if (MediaGeral > 7 && MediaGeral <= 9)
                        {
                            conceitoG = conceito.B;
                        }
                        else
                        {
                            conceitoG = conceito.A;
                        }

                        Console.Write("MÉDIA GERAL: ");
                        Console.Write(MediaGeral.ToString("#.##")); 
                        Console.WriteLine($"; CONCEITO: {conceitoG}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = obtermenu();

            }
        }

        private static string obtermenu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("[1] Inserir novo aluno");
            Console.WriteLine("[2] Listar alunos");
            Console.WriteLine("[3] Calcular média geral");
            Console.WriteLine("[X] Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
