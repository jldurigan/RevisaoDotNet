using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario;
            Aluno[] alunos = new Aluno[5];
            var indiceAluno=0;
            do{
                opcaoUsuario=obterOpcao();
                switch(opcaoUsuario){
                    case "1":
                    //adicionar aluno
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal!");
                        }
                        else
                        {
                            aluno.Nota = nota;
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    
                    case "2":
                    //listar alunos
                        foreach(var a in alunos){
                            if(a.Nome!=null){
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                    //calcular média geral
                        decimal notaTotal=0;
                        var nAlunos=0;
                        foreach(var a in alunos){
                            if(a.Nome!=null){
                                nAlunos++;
                                notaTotal+= a.Nota;
                            }
                        }
                        var mediaGeral=notaTotal/nAlunos;

                        Conceito conceitoGeral;
                        if(mediaGeral < 2){
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral <4){
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral <6){
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral <8){
                            conceitoGeral = Conceito.B;
                        }
                        else{
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média geral: {mediaGeral}, Conceito: {conceitoGeral}");

                        break;

                    case "x":
                        break;

                    default: 
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine();
            }while(opcaoUsuario.ToUpper()!="X");
            Console.WriteLine("Saindo...");
        }

        private static string obterOpcao(){
            string opcaoUsuario;
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular Média Geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
