using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LanguageApp
{
    static class Program
    {

        public static webScraper webText;

        //Curent languages:
        //English, French, Spanish, German, Polish, Finnish,
        //Czech, Latin,  Afrikaans, Italian, Portugese, Catalan,
        //Frisian, Irish, Norwegian, Dutch, Romanian, Swedish, Danish, 

        //To add data, enter the an element to the following array in format
        // {"Language", "URL"}
        //ex: { "Czech", "https://www.gutenberg.org/cache/epub/34225/pg34225.html"},

        //Old URLs at bottom of page

        public static string[,] resources = new string[,]
        {
            { "Czech", "https://www.gutenberg.org/cache/epub/34225/pg34225.html"}
        };

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //Call this to upload all data in resources array to a TSV file
        static void addDataToDocument()
        {
            System.Diagnostics.Debug.WriteLine("Starting to add resources");

            string basePath = @"H:\Documents\VisualStudioProjects\LanguageTextFiles\";
            string path = basePath + "Haha";

            TextFile textFile = new TextFile(path, true);

            for (int i = 0; i < resources.Length / 2; i++)
            {
                webText = new webScraper(resources[i, 1], resources[i, 0]);

                webText.scrapeURL();
                webText.convertForMLLanguage();

                bool complete = webText.saveIntoTextFile(textFile);

                if (complete)
                    Console.WriteLine("Finished writing resource " + i + " to " + path);
            }

            System.Diagnostics.Debug.WriteLine("Finished adding resources");
        }
    }


    /*
            { "Czech", "https://www.gutenberg.org/cache/epub/34225/pg34225.html"},

            { "Portugese", "https://www.gutenberg.org/files/57895/57895-h/57895-h.htm"},
            { "Portugese", "https://www.gutenberg.org/cache/epub/24401/pg24401.html"},

            { "Catalan", "https://www.gutenberg.org/cache/epub/27142/pg27142.html"},
            { "Catalan", "https://www.gutenberg.org/cache/epub/17583/pg17583.html"},
            { "Catalan", "https://www.gutenberg.org/cache/epub/20253/pg20253.html"},
            { "Catalan", "https://www.gutenberg.org/cache/epub/15346/pg15346.html"}

            { "Finnish", "https://www.gutenberg.org/cache/epub/57633/pg57633.html"},
            { "Finnish", "https://www.gutenberg.org/cache/epub/65281/pg65281.html"},

            { "Romanian", "https://www.bursa.ro/bursa-de-valori-bursa-ideilor-si-bursa-politica-69133343"},
            { "Romanian", "https://www.gutenberg.org/files/64597/64597-h/64597-h.htm"},
            { "Romanian", "https://www.gutenberg.org/cache/epub/11756/pg11756.html"}

            { "Italian", "https://www.lanotiziagiornale.it/biden-intelligence-covid19/"},
            { "Italian", "https://www.lanotiziagiornale.it/contro-codice-degli-appalti/"},
            { "Italian", "https://www.gutenberg.org/files/23297/23297-h/23297-h.htm"},

            { "German", "https://www.sueddeutsche.de/politik/schwexit-schweiz-laesst-vertrag-mit-eu-platzen-1.5305067"},
            { "German", "https://www.gutenberg.org/files/24571/24571-h/24571-h.htm"},
            { "German", "https://www.gutenberg.org/files/7205/7205-h/7205-h.htm"},

            { "English", "https://www.gutenberg.org/files/64317/64317-h/64317-h.htm" },
            { "English", "https://www.gutenberg.org/files/64002/64002-h/64002-h.htm"},
            { "English", "https://www.cbc.ca/news/canada/edmonton/lumber-mills-wood-covid-19-pandemic-supply-demand-fence-posts-decks-edmonton-1.6024190" },
            { "English", "https://www.gutenberg.org/files/65446/65446-h/65446-h.htm"},

            { "French", "https://www.gutenberg.org/files/54873/54873-h/54873-h.htm"},
            { "French", "https://ici.radio-canada.ca/nouvelle/1796167/jason-kenney-assouplissement-covid-19-alberta-reouverture"},
            { "French", "https://ici.radio-canada.ca/nouvelle/1796177/fusillade-san-jose-gare-triage-californie"},
            { "French", "https://www.gutenberg.org/files/18812/18812-h/18812-h.htm" },
            { "French", "https://www.gutenberg.org/cache/epub/17808/pg17808.html"},
            { "French", "https://www.gutenberg.org/files/56393/56393-h/56393-h.htm"},
            { "French", "https://www.gutenberg.org/files/25335/25335-h/25335-h.htm"},
            { "French", "https://www.gutenberg.org/files/63979/63979-h/63979-h.htm"}

            { "Spanish", "https://www.gutenberg.org/files/2000/2000-h/2000-h.htm"},
            { "Spanish", "https://es.wikipedia.org/wiki/Protestas_en_Colombia_de_2021"},
            {"Spanish", "https://www.gutenberg.org/files/14307/14307-h/14307-h.htm"},
            {"Spanish", "https://www.gutenberg.org/files/19543/19543-h/19543-h.htm"},
            {"Spanish", "https://www.gutenberg.org/files/43861/43861-h/43861-h.htm"},
            {"Spanish", "https://www.gutenberg.org/files/55157/55157-h/55157-h.htm"},
            {"Spanish", "https://www.gutenberg.org/files/56219/56219-h/56219-h.htm"}

            { "Danish", "https://www.dr.dk/nyheder/penge/nu-kan-du-downloade-det-nye-coronapas-se-fordele-og-ulemper-ved-skifte-til-den-nye-app"},
            { "Danish", "https://www.dr.dk/nyheder/indland/test-dig-selv-har-nedlukningen-oedelagt-din-evne-til-genkende-alverdens-flag"},
            { "Danish", "https://www.dr.dk/nyheder/indland/vennerne-maa-igen-fejre-dig-natten-lang-saadan-undgaar-du-smitten-loeber-loebsk-til"},
            { "Danish", "https://www.dr.dk/nyheder/viden/kroppen/kan-det-passe-vi-kun-bruger-10-procent-af-hjernen"},
            { "Danish", "https://www.dr.dk/nyheder/penge/oekonomiske-vismaend-med-opsigtsvaekkende-melding-ingen-grund-til-indgreb-paa-glohedt"},
            { "Danish", "https://www.dr.dk/nyheder/indland/folkeskolen-faar-flere-penge-og-mere-frihed-naeste-skoleaar-men-det-er-sent-skemaet"},
            { "Danish", "https://www.dr.dk/nyheder/udland/putin-goer-hovedrent-alle-der-udviser-utilfredshed-med-styret-bliver-ryddet-af-vejen"},
            { "Danish", "https://www.dr.dk/nyheder/viden/kroppen/kun-en-maaned-tilbage-14-15-aarige-drenge-derfor-boer-du-overveje-en-gratis"},
            { "Danish", "https://www.dr.dk/nyheder/regionale/sjaelland/forsoemt-cirkustiger-fra-spanien-faar-luksusliv-paa-lolland"},
            { "Danish", "https://www.dr.dk/nyheder/viden/teknologi/danmark-lod-usa-spionere-gennem-internetkabler-saadan-foregaar"},
            { "Danish", "https://www.dr.dk/nyheder/udland/hassan-blev-bragt-til-danskstoettet-lejr-efter-seks-forsoeg-paa-krydse-middelhavet"},
            { "Danish", "https://www.dr.dk/nyheder/viden/klima/juraprofessor-om-klimadom-mod-shell-det-er-dybt-problematisk"},
            { "Danish", "https://www.dr.dk/nyheder/politik/regeringen-vil-give-kommuner-lov-til-forbyde-dieselbiler"},
            { "Danish", "https://www.dr.dk/nyheder/viden/klima/otte-unge-klimaaktivister-sultestrejker-klimaet"},
            { "Danish", "https://www.dr.dk/nyheder/viden/klima/afrikanske-regnskove-optog-masser-af-co2-trods-toerkerekord"},
            { "Danish", "https://www.dr.dk/nyheder/viden/klima/ny-energirapport-vi-kan-godt-naa-maalene-fra-paris-aftalen"},
            { "Danish", "https://www.dr.dk/nyheder/viden/klima/torben-har-holdt-oeje-med-klimaet-i-arktis-i-mere-30-aar-pludselig-var-det-her"}

            { "Irish", "https://www.gutenberg.org/files/16122/16122-h/16122-h.htm"},
            { "Irish", "https://www.gutenberg.org/files/50913/50913-h/50913-h.htm"},

            { "Norwegian", "https://www.gutenberg.org/files/43725/43725-h/43725-h.htm"},
            { "Norwegian", "https://www.gutenberg.org/files/34062/34062-h/34062-h.htm"},
            { "Norwegian", "https://www.gutenberg.org/files/53978/53978-h/53978-h.htm"}

            { "Frisian", "https://www.gutenberg.org/files/60480/60480-h/60480-h.htm"},
            { "Frisian", "https://www.gutenberg.org/files/63023/63023-h/63023-h.htm"},
            { "Frisian", "https://www.gutenberg.org/files/60480/60480-h/60480-h.htm"}

            { "Esperanto", "https://www.gutenberg.org/files/27915/27915-h/27915-h.htm"},
            { "Esperanto", "https://www.gutenberg.org/files/31348/31348-h/31348-h.htm"},
            { "Esperanto", "https://www.gutenberg.org/files/20802/20802-h/20802-h.htm"}

            { "Swedish", "https://www.gutenberg.org/cache/epub/52671/pg52671.html"},
            { "Swedish", "https://www.gutenberg.org/cache/epub/52752/pg52752.html"},
            { "Swedish", "https://www.gutenberg.org/files/48638/48638-h/48638-h.htm"},
            { "Swedish", "https://www.gutenberg.org/cache/epub/54714/pg54714.html" }
    */
}
