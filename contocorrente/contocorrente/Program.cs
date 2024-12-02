using contocorrente;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Conto conto1 = new Conto("123456", "Orlandi", "Mediolanum", 0);
        Conto conto2 = new Conto("789101", "Andreoli", "Mediolanum", 0);

        Carta carta1 = new Carta("012", "1234", conto1);
        Carta carta2 = new Carta("345", "5678", conto2);

        List<Carta> carte = new List<Carta>();
        carte.Add(new Carta("012", "1234", conto1));
        carte.Add(new Carta("345", "5678", conto1));
        //...// Per aggiungere altre eventuali carte
        

        //Parte A
        
        //CONTO 1

        Console.WriteLine("Inserire la somma che si desidera depositare:");
        double depositadenaro = Convert.ToDouble(Console.ReadLine());
        if (depositadenaro <= 0)
        {
            Console.WriteLine("QTA DENARO NON VALIDA!\n");
        }
        else
        {
            conto1.DepositaDenaro(depositadenaro);
        }

        Console.WriteLine("Inserire la somma che si desidera prelevare:");
        double prelevadenaro = Convert.ToDouble(Console.ReadLine());

        if (prelevadenaro <= 0 || prelevadenaro > conto1.Saldo)
        {
            Console.WriteLine("NON E' POSSIBILE PRELEVARE QUESTA SOMMA DI DENARO!\n");
        }
        else
        {
            conto1.PrelevaDenaro(prelevadenaro);
        }

        Console.WriteLine($"il saldo del primo conto equivale a { conto1.ConosciSaldo() }$");


        //CONTO 2

        Console.WriteLine("Inserire la somma che si desidera depositare:");
        depositadenaro = Convert.ToDouble(Console.ReadLine());
        if (depositadenaro <= 0)
        {
            Console.WriteLine("QTA DENARO NON VALIDA!\n");
        }
        else
        {
            conto2.DepositaDenaro(depositadenaro);
        }

        Console.WriteLine("Inserire la somma che si desidera prelevare:");
        prelevadenaro = Convert.ToDouble(Console.ReadLine());
        if (prelevadenaro <= 0 || prelevadenaro > conto2.Saldo)
        {
            Console.WriteLine("NON E' POSSIBILE PRELEVARE QUESTA SOMMA DI DENARO!\n");
        }
        else
        {
            conto2.PrelevaDenaro(prelevadenaro);
        }

        Console.WriteLine($"il saldo del secondo conto equivale a { conto2.ConosciSaldo() }$");


        //BONIFICO

        Console.WriteLine("Inserire la somma con cui si desidera effettuare il bonifico:");
        prelevadenaro = Convert.ToDouble(Console.ReadLine());
        if (prelevadenaro <= 0 || prelevadenaro > conto1.Saldo)
        {
            Console.WriteLine("NON E' POSSIBILE EFFETTUARE UN BONIFICO CON QUESTA SOMMA DI DENARO!\n");
        }
        else
        {
            conto1.Bonifico(prelevadenaro, conto2);
        }
        Console.WriteLine($"il saldo del primo conto a seguito del bonifico equivale a {conto1.ConosciSaldo()}$");
        Console.WriteLine($"il saldo del secondo conto a seguito del bonificao equivale a {conto2.ConosciSaldo()}$");

//Parte B
        /*
        //CARTA 1
        double depositadenaro = Convert.ToDouble(Console.ReadLine());
        string pinInserito = Convert.ToString(Console.ReadLine());
        if (depositadenaro <= 0)
        {
            Console.WriteLine("QTA DENARO NON VALIDA!\n");
        }
        else
        {
            carta1.Deposita(depositadenaro, pinInserito);
        }

        double prelevadenaro = Convert.ToDouble(Console.ReadLine());
        pinInserito = Convert.ToString(Console.ReadLine());
        if (prelevadenaro <= 0 || prelevadenaro > Convert.ToDouble(carta1.Conosci))
        {
            Console.WriteLine("NON E' POSSIBILE PRELEVARE QUESTA SOMMA DI DENARO!\n");
        }
        Console.WriteLine($"il saldo associato alla carta1 equivale a {carta1.Conosci}$");


        //CARTA 2

        depositadenaro = Convert.ToDouble(Console.ReadLine());
        pinInserito = Convert.ToString(Console.ReadLine());
        if (depositadenaro <= 0)
        {
            Console.WriteLine("QTA DENARO NON VALIDA!\n");
        }
        else
        {
            carta1.Deposita(depositadenaro, pinInserito);
        }

        prelevadenaro = Convert.ToDouble(Console.ReadLine());
        pinInserito = Convert.ToString(Console.ReadLine());
        if (prelevadenaro <= 0 || prelevadenaro > Convert.ToDouble(carta2.Conosci))
        {
            Console.WriteLine("NON E' POSSIBILE PRELEVARE QUESTA SOMMA DI DENARO!\n");
        }
        Console.WriteLine($"il saldo associato alla carta2 equivale a {carta2.Conosci}$");
        */
        carta1.Deposita(40, "1234");
        carta2.Preleva(50, "5678");

        double saldo1 = carta1.Conosci("1234");
        if (saldo1 == -1)
            Console.WriteLine("PIN errato per la carta1");
        else
            Console.WriteLine($"Il saldo associato alla carta1 equivale a {saldo1}$");

        double saldo2 = carta2.Conosci("5678");
        if (saldo2 == -1)
            Console.WriteLine("PIN errato per la carta2");
        else
            Console.WriteLine($"Il saldo associato alla carta2 equivale a {saldo2}$");


//IMPLEMENTAZIONE CON LISTE
    //implementa le liste con l'esercizio in modo che si possa prelevare e depositare una somma di denaro, divisa in una lista di carte.
        Console.WriteLine("Inserire la somma che si desidera depositare:");

        double deposita;
        deposita = Convert.ToDouble(Console.ReadLine());
        if (deposita < 0)
        {
            Console.WriteLine("QTA DENARO NON VALIDA!\n");
        }
        else
        {
            double qta = deposita / carte.Count;
            foreach (Carta carta in carte)
            {
                carta.Deposita(qta, carta.Pin);
            }
            Console.WriteLine($"il deposito è avvenuto con successo, su ogni carta in suo possesso sono stati depositati ${qta}, il conto aggiornato ora dispone di: ${conto1.ConosciSaldo()}");
        }

        Console.WriteLine("Inserire la somma che si desidera prelevare:");
        double preleva;
        preleva = Convert.ToDouble(Console.ReadLine());
        if (preleva <= 0 || preleva > Convert.ToDouble(conto1.ConosciSaldo()))
        {
            Console.WriteLine("NON E' POSSIBILE PRELEVARE QUESTA SOMMA DI DENARO!\n");
        }
        else
        {
            double qta = preleva / carte.Count;
            foreach(Carta carta in carte)
            {
                carta.Preleva(qta, carta.Pin);
            }
            Console.WriteLine($"il prelevamento è avvenuto con successo, da ogni carta in suo possesso sono stati prelevati ${qta}, il conto aggiornato ora disponde di: ${conto1.ConosciSaldo()}");
        }
    }
}