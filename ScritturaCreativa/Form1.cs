using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScritturaCreativa;
/*
Lettera ai futuri studenti della professoressa Macrì

Poiché 15 scritture creative sono state più che a sufficienza per me, 
ho deciso di lasciare in eredità uno strumento (modestamente) eccezionale:
ecco a voi Creativ-IO , in grado di produrre scritture creative a una velocità di 20 scritture/minuto.
Non saranno grammaticamente corrette, ma possono essere utili per i futuri studenti: 
basterà trovare qualche (sfortunato) studente che sappia cos'è il C# e capirà tutto.

###########################

Nota per il futuro studente:

    Innanzitutto, congratulazioni per aver scelto di imparare il miglior linguaggio di sempre.
    Creativ-IO ha una sola namespace, ScritturaCreativa. Esecutore è 
    semplicemente la classe parziale del Form.
    Se vuoi usare la versione completa, avrai bisogno della libreria JSON.Net
    per il parsing delle pagine di Wikipedia.
    Puoi trovare la versione digitalizzata del codice qui: http://pastebin.com/RusucZ0u 


    Se vuoi usare Wikipedia come fonte:
    
    ProfessoressaMacrì.AssegnaScritturaCreativa(string argomento, int lunghezza, int nFonti); --vedi documentazione

    Se vuoi fornire tu il testo di partenza:

    Studente s = new Studente(string nome);
    s.ScriviScritturaCreativa(string testo, int lunghezza) --idem


    L'algoritmo usa le catene di Markov, ma se preferisci Karpathy lo ha rifatto con le reti neurali


    Samuele Marro(/u/smarro)
    1462558620 (se non lo sai leggere, torna a studiare le Timestamp)

###########################
*/
namespace Esecutore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Esegui_Click(object sender, EventArgs e)
        {
            //risultato.Text = ProfessoressaMacrì.AssegnaScritturaCreativa(argomento.Text, (int)lunghezza.Value, (int)fonti.Value);
            risultato.Text = ScritturaCreativa.Continuità.GeneraScritturaCreativa(ScritturaCreativa.Continuità.AnalizzaFonte(risultato.Text),200);
        }

        private void risultato_MouseClick(object sender, MouseEventArgs e)
        {
            //risultato.SelectAll();
        }
    }
}

namespace ScritturaCreativa
{
    public static class ProfessoressaMacrì
    {
        public static Random random = new Random();
        /// <summary>
        /// Assegna una scrittura creativa alla classe
        /// </summary>
        /// <param name="argomento">Uno o più argomenti della scrittura creativa</param>
        /// <param name="lunghezza">La lunghezza in parole della scrittura creativa</param>
        /// <param name="nFonti">Quante pagine di Wikipedia deve usare come fonti? (non usarne troppe, idealmente 5-6)</param>
        /// <returns>La scrittura creativa</returns>
        public static string AssegnaScritturaCreativa(string argomento, int lunghezza, int nFonti)
        {
            string fonte = Continuità.OttieniFonte(argomento, nFonti);
            Studente studente = new Studente("Samuele Marro", new ScritturaCreativa());
            studente.ScriviScritturaCreativa(fonte, lunghezza);
            studente.scritturaCreativa.valutazione = 10;
            return studente.scritturaCreativa.testo;
        }
    }
    public struct ScritturaCreativa
    {
        public string testo;
        public int valutazione;
    }
    public class Studente
    {
        public string nome = "";
        public ScritturaCreativa scritturaCreativa;
        public Studente(string _nome, ScritturaCreativa _scritturaCreativa)
        {
            nome = _nome;
            scritturaCreativa = _scritturaCreativa;
        }
        public void ScriviScritturaCreativa(string testo, int lunghezza)
        {
            List<Parola> parole = Continuità.AnalizzaFonte(testo);
            scritturaCreativa.testo = Continuità.GeneraScritturaCreativa(parole, lunghezza);
        }
    }
    public static class Continuità
    {
        public static string OttieniFonte(string argomento, int nFonti)
        {
            string fonte = "";
            argomento = argomento.Replace(" ", "+");
            string urlRicerca = "https://it.wikipedia.org/w/api.php?action=query&format=json&list=search&utf8=1&srsearch=" + argomento;
            string ricercaJSON = OttieniJSON(urlRicerca);
            JObject risultatoJSON = (JObject)JsonConvert.DeserializeObject(ricercaJSON);
            for (int i = 0; i < nFonti; i++)
            {
                string titolo = risultatoJSON.SelectToken("query.search[0].title").ToString();
                string urlPagina = "https://it.wikipedia.org/w/api.php?action=query&format=json&prop=extracts&titles=" + titolo + "&utf8=1&exchars=5000&explaintext=1&exsectionformat=plain";
                string paginaJSON = OttieniJSON(urlPagina);
                JObject risultato = (JObject)JsonConvert.DeserializeObject(paginaJSON);
                JToken token = risultato.SelectToken("query.pages").First.First.SelectToken("extract");
                fonte += token.ToString() + " ";
            }
            return fonte;
        }
        static string OttieniJSON(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }
        }
        public static List<Parola> AnalizzaFonte(string fonte)
        {
            List<string> listaParoleString = fonte.Split(new char[] { ' ' }).ToList();
            List<Parola> listaParole = new List<Parola>();
            //Crea la lista di parole, ma senza assegnare le occorrenze
            for (int i = 0; i < listaParoleString.Count; i++)
            {
                string testo = listaParoleString[i];
                if (listaParole.Find(x => x.valore == testo) == null)
                {
                    listaParole.Add(new Parola(testo));
                }
            }
            for (int i = 0; i < listaParoleString.Count - 1; i++)
            {
                string testo = listaParoleString[i];
                Parola parolaCorrispondente = listaParole.Find(x => x.valore == testo);
                parolaCorrispondente.AggiungiOccorrenza(listaParoleString[i + 1], listaParole);
            }
            return listaParole;
        }
        public static string GeneraScritturaCreativa(List<Parola> parole, int lunghezza)
        {
            Parola parolaAttuale = parole[ProfessoressaMacrì.random.Next(parole.Count)];
            string risultato = parolaAttuale.valore + " ";
            for (int i = 0; i < lunghezza; i++)
            {
                if (parolaAttuale.occorrenzeSuccessive.Keys.Count == 0)
                    break;
                parolaAttuale = parolaAttuale.ProssimaParola();
                risultato += parolaAttuale.valore + " ";
            }
            return risultato;
        }
    }
    public class Parola
    {
        public string valore = "";
        public Dictionary<Parola, int> occorrenzeSuccessive = new Dictionary<Parola, int>();
        public Parola(string _valore)
        {
            valore = _valore;
        }
        public void AggiungiOccorrenza(string nome, List<Parola> listaParole)
        {
            if (occorrenzeSuccessive.ContieneParolaConNome(nome))
            {
                Parola p = occorrenzeSuccessive.TrovaParolaConNome(nome);
                occorrenzeSuccessive[p]++;
            }
            else
            {
                occorrenzeSuccessive.Add(listaParole.Find(x => x.valore == nome), 1);
            }
        }
        public Parola ProssimaParola()
        {
            int totaleOccorrenze = occorrenzeSuccessive.Values.Sum();
            int indice = ProfessoressaMacrì.random.Next(1, totaleOccorrenze + 1);
            int contatore = 0;
            foreach (KeyValuePair<Parola, int> kvp in occorrenzeSuccessive)
            {
                contatore += kvp.Value;
                if (indice <= contatore)
                    return kvp.Key;
            }
            return null;
        }
    }
    public static class Estensioni
    {
        public static bool ContieneParolaConNome(this Dictionary<Parola, int> dizionario, string nome)
        {
            foreach (Parola p in dizionario.Keys)
            {
                if (p.valore == nome)
                    return true;
            }
            return false;
        }
        public static Parola TrovaParolaConNome(this Dictionary<Parola, int> dizionario, string nome)
        {
            foreach (Parola p in dizionario.Keys)
            {
                if (p.valore == nome)
                    return p;
            }
            return null;
        }
    }
}

