using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Exercicio_01_e_02
{
    class Program
    {
        static void Main(string[] args )
        {
            Console.Clear();
            List<string> lista = new List<string>();
            string final_digito = "FIM";
            string desc_disciplina = "Cadastre as disciplinas ou (fim para finalizar): ";
            string desc_aluno = "Cadastre os alunos da Disciplina: {0} ";
            string desc_nome_aluno = "Nome do Aluno ou (fim para finalizar): ";
            string desc_nota_aluno = "Nota {0}: ";
            string desc_err_nota_aluno = "Nota Inválida ";
            string nome_disciplina = "";
            string nomes_alunos = "";
            string notas_alunos = "";
            string status_alunos = "";
            string[] guarda_disciplina = new string[10];
            string[] guarda_aluno = new string[32];
            double[] guarda_notas = new double[3];
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
                        notas_alunos = Console.ReadLine().Replace(".",",");
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
                            Console.Write("Média: {0}" , media_aluno);

                           // if (media_aluno >= 7)
                           // {
                           //     status_alunos = " Aprovado";
                           // }
                           // else
                           // {
                           //     status_alunos = " Reprovado";
                           // }
                            status_alunos = media_aluno >= 7 ? "Aprovado" : "Reprovado";

                          //  Console.WriteLine(" - Aprov/Reprov: {0}", status_alunos);
                            soma_notas_aluno = 0;
                            contador_nota = 0;

                            lista.Add(disci + "\t" + nomes_alunos + "\t" + guarda_notas[0] + "\t" + guarda_notas[1] + "\t" + guarda_notas[2] + "\t" + string.Format(formatoNumeroDecimal, "{0:N}", media_aluno) + "\t" + status_alunos);
                        }
                        
                    }
                  
                }
            }
            // Exibição da Lista
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
