using System.Diagnostics;

namespace MetricaEngenhariaSoftware.Core.CalcularMetricas
{
    public class MetricasBase
    {
        public double CalcularBase(int totalFPB)
        {
            Debug.WriteLine("######## BASE ########");

            var calcularBase = totalFPB /** Constant.FA*/;
            Debug.WriteLine("######## FIM BASE ########");
            return calcularBase;

        }

        

    }
}
