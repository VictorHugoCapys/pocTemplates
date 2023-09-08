using System.Linq;
using static pocTemplates.LocalBDContext;

namespace pocTemplates
{
    public class LocalBD
    {
        public static void ReiniciarBanco()
        {
            LimparBanco();
            popularVariaveisTemplate();
            popularDados();
        }
        public static void LimparBanco()
        {
            using (var context = new LocalBDContext())
            {
                var VariaveisTemplates = context.VariaveisTemplate.ToList();
                context.VariaveisTemplate.RemoveRange(VariaveisTemplates);

                var lstTabelaDeDados = context.TabelaDeDados.ToList();
                context.TabelaDeDados.RemoveRange(lstTabelaDeDados);

                var lstTabelaDeDados2 = context.TabelaDeDados2.ToList();
                context.TabelaDeDados2.RemoveRange(lstTabelaDeDados2);
                context.SaveChanges();
            }
        }

        public static void popularVariaveisTemplate()
        {
            using (var context = new LocalBDContext())
            {
                context.VariaveisTemplate.Add(
                    new VariaveisTemplates
                    {
                        ID = 1,
                        identificador = "@TabelaDeDados.nome@",
                        operacao = "SELECT nome FROM TabelaDeDados WHERE ID=@IdTabelaDeDados@",
                        modulo = "teste",
                        nome = "variavel 1"
                    });
                context.VariaveisTemplate.Add(
                    new VariaveisTemplates
                    {
                        ID = 2,
                        identificador = "@TabelaDeDados.idade@",
                        operacao = "SELECT idade FROM TabelaDeDados WHERE nome='@NomeTabelaDeDados@'",
                        modulo = "teste",
                        nome = "variavel 2"
                    });
                context.VariaveisTemplate.Add(
                    new VariaveisTemplates
                    {
                        ID = 3,
                        identificador = "@TabelaDeDados.altura@",
                        operacao = "SELECT altura FROM TabelaDeDados WHERE nome='@NomeTabelaDeDados@' AND ID=@IdTabelaDeDados@",
                        modulo = "teste",
                        nome = "variavel 3"
                    });
                context.VariaveisTemplate.Add(
                    new VariaveisTemplates
                    {
                        ID = 4,
                        identificador = "@TabelaDeDados2.telefone@",
                        operacao = "SELECT telefone FROM TabelaDeDados2 td2 join TabelaDeDados td on td.ID = td2.idDados  WHERE nome='@NomeTabelaDeDados@'",
                        modulo = "teste",
                        nome = "variavel 4"
                    });


                context.SaveChanges();

            }
        }

        public static void popularDados()
        {
            using (var context = new LocalBDContext())
            {
                context.TabelaDeDados.Add(new TabelaDeDado
                {
                    ID = 1,
                    nome = "teste1",
                    idade = 18,
                    altura = 1.70M
                });

                context.TabelaDeDados.Add(new TabelaDeDado
                {
                    ID = 2,
                    nome = "teste2",
                    idade = 25,
                    altura = 1.80M
                });

                context.TabelaDeDados.Add(new TabelaDeDado
                {
                    ID = 3,
                    nome = "teste3",
                    idade = 47,
                    altura = 1.50M
                });
                context.TabelaDeDados2.Add(new TabelaDeDado2
                {
                    ID = 3,
                    telefone = "(31) 91234-5678",
                    idDados = 1
                });

                context.SaveChanges();
            }
        }


    }
}
