using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pocTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using static pocTemplates.LocalBDContext;

public class HelloWorld
{

    public class Request
    {
        public int IdTabelaDeDados { get; set; }
        public string NomeTabelaDeDados { get; set; }
    }
    public class Response
    {
        public string TemplatePreenchido { get; set; }
        public List<string> CamposVazios { get; set; }
    }

    public static void Main(string[] args)
    {
        LocalBD.ReiniciarBanco();
        Request request = new Request
        {
            IdTabelaDeDados = 1
        };

        string template = @"Nome: @TabelaDeDados.nome@    Idade: @TabelaDeDados.idade@   Altura: @TabelaDeDados.altura@      Telefone: @TabelaDeDados2.telefone@";
        var response = PreencherVariaveisTemplate(request, template);
        Console.WriteLine(response.TemplatePreenchido);

    }

    public static List<string> ObterVariaveisTemplate(string input)
    {
        List<string> valores = new List<string>();
        Regex regex = new Regex(@"@([^@]+)@");
        MatchCollection matches = regex.Matches(input);
        foreach (Match match in matches)
        {
            string valor = match.Groups[0].Value;
            valores.Add(valor);
        }
        return valores;
    }
    public static Response PreencherVariaveisTemplate(Request request, string template)
    {
        var context = new LocalBDContext();
        var teste = context.TabelaDeDados.ToList();

        request.NomeTabelaDeDados = context.TabelaDeDados.Find(request.IdTabelaDeDados)?.nome;

        List<VariaveisTemplates> lstVariaveisBD = context.VariaveisTemplate.ToList();
        List<String> lstVariaveisPresentes = ObterVariaveisTemplate(template);
        Response response = new Response();

        foreach (string variavel in lstVariaveisPresentes)
        {
            var variavelBD = lstVariaveisBD.Where(x => x.identificador == variavel).FirstOrDefault();
            if (variavelBD is not null)
            {
                string operacao = PreencherOperacao(request, variavelBD.operacao);
                Console.WriteLine("Executando.......: " + operacao);
                Console.WriteLine();

                var retornoOperacao = context.Database.SqlQueryRaw<string>(operacao).ToList().FirstOrDefault();

                if (retornoOperacao is not null)
                    template = template.Replace(variavel, retornoOperacao);
                else
                {
                    template = template.Replace(variavel, "");
                    response.CamposVazios.Add(variavelBD.nome);
                }
            }
        }
        response.TemplatePreenchido = template;
        return response;
    }
    static string PreencherOperacao(Request requestDTO, string queryString)
    {
        PropertyInfo[] properties = requestDTO.GetType().GetProperties();
        foreach (var property in properties)
        {
            string parameterName = "@" + property.Name + "@";
            string parameterValue = property.GetValue(requestDTO)?.ToString() ?? "NULL"; // Obter o valor da propriedade da DTO

            queryString = queryString.Replace(parameterName, parameterValue);
        }
        return queryString;
    }
}
