using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base;

namespace MetricaEngenhariaSoftware.Core.Utilidades
{
    public static class Debugar
    {
        public static void Caguetar(this List<TabelaDominio> itens)
        {
            Debug.WriteLine("======================= INICIO ===============================");
            Debug.WriteLine($"Quantidade de tipos de atributos {itens.Select(x => x.QuantidadeAtributos).Count()}");
            Debug.WriteLine("----------------------");

            foreach (var item in itens)
            {
                Debug.WriteLine($"Tabela [{item.NomeTabela}] - Atributos [{item.QuantidadeAtributos}]");
            }

            if (itens.Any())
            {
                Debug.WriteLine("----------------------");
                Debug.Write($"MIN >= {itens.Min(x => x.QuantidadeAtributos)}  | Max <= {itens.Max(x => x.QuantidadeAtributos)}");
            }
            Debug.WriteLine("");
            Debug.WriteLine("======================= FIM ===============================");
            Debug.WriteLine("");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contador"></param>
        /// <param name="count"></param>
        /// <param name="min">Valor Minimo</param>
        /// <param name="max">Valor Máximo</param>
        public static void Simples(this Contador contador, int count, int min, int max)
        {
            if (count >= min && count <= max)
            {
                Debug.WriteLine("Simples +1");
                contador.simples += count;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contador"></param>
        /// <param name="count"></param>
        /// <param name="min">Valor Minimo</param>
        /// <param name="max">Valor Máximo</param>
        public static void Medio(this Contador contador, int count, int min, int max)
        {
            if (count >= min && count <= max)
            {
                Debug.WriteLine("Medio +1");
                contador.medio += count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contador"></param>
        /// <param name="count"></param>
        /// <param name="min">Valor Minimo</param>
        /// <param name="max">Valor Máximo</param>
        public static void Complexo(this Contador contador, int count, int min, int max)
        {
            if (count >= min && count <= max)
            {
                Debug.WriteLine("Complexo +1");
                contador.complexo += count;
            }
        }
    }
}

