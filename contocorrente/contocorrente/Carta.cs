using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contocorrente
{
    internal class Carta
    {
        private string num_seriale;
        private string pin;
        private Conto conto;
        public Carta(string num_seriale, string pin, Conto conto)
        {
            this.num_seriale = num_seriale;
            this.pin = pin;
            this.conto = conto;
        }
        public string Num_seriale
        {
            get { return num_seriale; }
        }
        public string Pin
        {
            get { return pin; }
        }
        public Conto Conto
        {
            get { return conto; }
            set { conto = value; }
        }
        public double Deposita(double value, string pinInserito)
        {
            if (pin == pinInserito)
                return conto.DepositaDenaro(value);
            else
                return -1;
        }
        public double Preleva(double value, string pinInserito)
        {
            if (pin == pinInserito)
                return conto.PrelevaDenaro(value);
            else
                return -1;
        }
        public double Conosci(string pinInserito)
        {
            if (pin == pinInserito)
                return conto.ConosciSaldo();
            else
                return -1;
        }
    }
}
