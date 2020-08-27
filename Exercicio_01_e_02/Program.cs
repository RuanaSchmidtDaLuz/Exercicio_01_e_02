using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
// evitar deixar usings nao utilizados na classe

namespace Exercicio_01_e_02
{
    class Program
    {
        static void Main(string[] args )
        {
            Console.Clear();

            // você pode usar var, quando o tipo ja ta explicito na instancia da variavel, ex:
            var lista = new List<string>();

            //usar const para strings fixas, ex:
            const string final_digito = "FIM";

            const string desc_disciplina = "Cadastre as disciplinas ou (fim para finalizar): ";
            const string desc_aluno = "Cadastre os alunos da Disciplina: {0} ";
            const string desc_nome_aluno = "Nome do Aluno ou (fim para finalizar): ";
            const string desc_nota_aluno = "Nota {0}: ";
            const string desc_err_nota_aluno = "Nota Inválida ";

            // evitar deixar variaveis nao utilizadas, remove-las
            // string nome_disciplina = string.Empty; usar string.empty ao invés de ""

            string nome_disciplina;
            string nomes_alunos;
            string notas_alunos;
            string status_alunos;

            var guarda_disciplina = new string[10];
            var guarda_aluno = new string[32];
            var guarda_notas = new double[3];
            
            double soma_notas_aluno = 0;
            double media_aluno;

            int contador = 0;
            int contador_aluno = 0;
            int contador_nota = 0;

            var formatoNumeroDecimal = new CultureInfo("pt-BR");

            formatoNumeroDecimal.NumberFormat.NumberDecimalDigits = 2;
            Calendar calendario = CultureInfo.InvariantCulture.Calendar;

            DateTime data = DateTime.Now;

            //Alguns métodos caso queira alterar informações atuais:
            //			data = calendario.AddYears(data, 5);
            //			data = calendario.AddMonths(data, 5);
            //			data = calendario.AddWeeks(data, 5);
            //			data = calendario.AddDays(data, 5);
            //			data = calendario.AddHours(data, 5);
            //			data = calendario.AddMinutes(data, 5);
            //			data = calendario.AddSeconds(data, 5);
            //			data = calendario.AddMilliseconds(data, 5);

            Console.WriteLine("\nData atual {0:d} at {0:T}.", data);
            Console.WriteLine("Periodo Letivo: {0}", calendario.GetYear(data));

            do
            {
                Console.Write(desc_disciplina.ToString());
                nome_disciplina = Console.ReadLine();

                if (nome_disciplina.ToUpper() == final_digito)
                {
                    break;
                }
                guarda_disciplina[contador] = nome_disciplina;
                contador++;

            }
            while (contador < guarda_disciplina.Length);

            // var texto = new StringBuilder();
            // melhor para trabalhar com concatenação de strings dentro de loops for / foreach / while

            foreach (string disci in guarda_disciplina)
            {
                if (disci == null)
                {
                    break;
                }

                Console.WriteLine(desc_aluno, disci);

                while (contador_aluno < guarda_aluno.Length)
                {
                    Console.Write(desc_nome_aluno.ToString(), disci);
                    nomes_alunos = Console.ReadLine();
                    if (nomes_alunos.ToUpper() == final_digito)
                    {
                        break;
                    }

                    guarda_aluno[contador_aluno] = nomes_alunos;
                    contador_aluno++;

                    for (int index = 0; index < guarda_notas.Length; index++)
                    {
                        contador_nota++;

                        Console.Write(desc_nota_aluno, contador_nota);
                        notas_alunos = Console.ReadLine().Replace(".", ",");
                        if (Convert.ToDouble(notas_alunos) > 10)
                        {
                            Console.WriteLine(desc_err_nota_aluno);

                            while (Double.Parse(notas_alunos) > 10)
                            {
                                Console.Write(desc_nota_aluno, contador_nota);
                                notas_alunos = Console.ReadLine().Replace(".", ",");
                                Console.WriteLine(desc_err_nota_aluno);
                            }
                        }
                        guarda_notas[index] = Convert.ToDouble(notas_alunos);
                        soma_notas_aluno = soma_notas_aluno + guarda_notas[index];
                        if (contador_nota == 3)
                        {
                            media_aluno = soma_notas_aluno / 3;
                            Console.Write("Média: {0}", media_aluno);

                            status_alunos = media_aluno >= 7 ? "Aprovado" : "Reprovado";

                            soma_notas_aluno = 0;
                            contador_nota = 0;

                            lista.Add(disci + "\t" + nomes_alunos + "\t" + guarda_notas[0] + "\t" + guarda_notas[1] + "\t" + guarda_notas[2] + "\t" + string.Format(formatoNumeroDecimal, "{0:N}", media_aluno) + "\t" + status_alunos);
                        }
                    }
                }
            }
            // evitar comentarios que explicam o que o código deve explicar por si mesmo
            // seria melhor extrair pra uma função, ex: ExibirListaDeAprovacaoDosAlunos();

            ExibirListaDeAprovacaoDosAlunos(lista);
        }

        private static void ExibirListaDeAprovacaoDosAlunos(List<string> lista)
        {
            Console.WriteLine("==============================================================================");
            Console.WriteLine("Disciplinas	 Alunos	   1º Nota	 2º Nota	3º Nota   	Médias	  Aprov/Reeprov");
            lista.Sort();

            foreach (string relatorio in lista)
                Console.WriteLine(relatorio);

            Console.ReadKey();
            Console.WriteLine("==============================================================================");
        }
    }
}
