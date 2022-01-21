using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cFPTest;
using Verblijven;

namespace Vakanties
{
    public interface IActiviteit
    {
        public string Naam { get; set; }
        public decimal BerekenPrijs();
    }

    public class MTB : IActiviteit
    {


        public string Naam { get; set; }
        public decimal PrijsUitrusting { get; set; }
        public decimal HuurprijsFietsPerUur { get; set; }
        public int AantalUren { get; set; }

        public decimal BerekenPrijs()
        {
            return PrijsUitrusting + AantalUren * HuurprijsFietsPerUur;
        }

    }

    public class Cinema : IActiviteit
    {


        public string Naam { get; set; }
        public decimal Inkom { get; set; }
        public decimal Snoepgoed { get; set; }

        public decimal BerekenPrijs()
        {
            return Inkom + Snoepgoed;
        }

    }

    public class Stadsbezoek : IActiviteit
    {


        public string Naam { get; set; }
        public decimal PrijsGidsPer10Personen { get; set; }
        public int AantalPersonen { get; set; }

        public decimal BerekenPrijs()
        {
            decimal gids = AantalPersonen / 10m;
            gids = Math.Ceiling(gids);
            return gids * PrijsGidsPer10Personen;
        }

    }

    public class Vakantie
    {

        public int BoekingsNr { get; set; }
        public Bestemming Bestemming { get; set; }
        public DateTime Vertrekdatum { get; set; }
        private DateTime TerugkeerdatumValue;
        public DateTime Terugkeerdatum
        {
            get
            {
                return TerugkeerdatumValue;
            }
            set
            {
                if ((value - Vertrekdatum).Days > 0)
                {
                    TerugkeerdatumValue = value;
                }
                else
                {
                    Console.WriteLine($"reis met boekingsnr{BoekingsNr}: Terugkeerdatum {Terugkeerdatum} moet later zijn dan vertrekdatum {Vertrekdatum}");
                }
            }
        }
        public List<IActiviteit> Activiteiten { get; set; }
        public virtual decimal BerekenVakantieprijs()
        {
            throw new NotImplementedException();
        }
        public string ToonActiviteiten()
        {
            decimal Totaal = 0;
            string ReturnString = "";
            if (Activiteiten != null)
            {
                foreach (IActiviteit activiteit in Activiteiten)
                {
                    ReturnString += $"{activiteit.Naam}: {activiteit.BerekenPrijs()} euro#";
                    Totaal += activiteit.BerekenPrijs();
                }
            }
            ReturnString += $"Totaal Bedrag : {Totaal}#";

            return ReturnString;
        }
        public virtual string ToonGegevens()
        {
            return "";
        }

    }

    public class Route
    {
        public Route(string vertekpunt, string eindpunt, Verblijfstype gekozenVerblijfstype, Formule gekozenFormuleValue)
        {
            Vertekpunt = vertekpunt;
            Eindpunt = eindpunt;
            GekozenVerblijfstype = gekozenVerblijfstype;
            GekozenFormuleValue = gekozenFormuleValue;
        }

        public string Vertekpunt { get; set; }
        public string Eindpunt { get; set; }
        public Verblijfstype GekozenVerblijfstype { get; set; }
        private Formule GekozenFormuleValue;



        public Formule GekozenFormule
        {
            get
            {
                return GekozenFormuleValue;
            }
            set
            {
                bool error = true;
                foreach (Formule formule in GekozenVerblijfstype.BeschikbareVerblijfsFormules)
                {
                    if (value == formule)
                    {
                        GekozenFormuleValue = value;
                        error = false;
                    }
                }
                if (error == true)
                {
                    Console.WriteLine("kies een van de juiste formules");
                    foreach (Formule formule in GekozenVerblijfstype.BeschikbareVerblijfsFormules)
                    {
                        Console.WriteLine(formule);
                    }
                }

            }
        }
        public decimal BerekenVerblijfsprijsPerDag()
        {
            return GekozenVerblijfstype.BerekenPrijsPerDag() + (int)GekozenFormule;
        }
        public override string ToString()
        {
            return $"{Vertekpunt} {Eindpunt} {GekozenFormule} {GekozenVerblijfstype.NaamVerblijf} {BerekenVerblijfsprijsPerDag()}#";


        }

    }

    public class Autovakantie : Vakantie
    {
        public List<Route> Routes { get; set; }
        public WagenType Wagentype { get; set; }
        public decimal Huurprijs { get; set; }

        public override decimal BerekenVakantieprijs()
        {
            decimal Totaal = 0;
            if (Routes != null)
            {
                foreach (Route route in Routes)
                {
                    Totaal += route.BerekenVerblijfsprijsPerDag();
                }
            }
            Totaal += Huurprijs;
            if (Activiteiten != null)
            {
                foreach (IActiviteit activiteit in Activiteiten)
                {
                    Totaal += activiteit.BerekenPrijs();
                }
            }
            return Totaal;
        }
        public override string ToonGegevens()
        {
            string ReturnString = "";

            ReturnString += "=======================================#";
            ReturnString += $"boekingsnr {BoekingsNr}    Bestemming: {Bestemming}#";
            ReturnString += $"vertrekdatum {Vertrekdatum}     terugkeerdatum: {Terugkeerdatum}#";
            ReturnString += "Routes:#";
            decimal Totaal = 0;
            if (Routes != null)
            {
                foreach (Route route in Routes)
                {
                    ReturnString += $"{route.ToString()}";
                    Totaal += route.BerekenVerblijfsprijsPerDag();
                }
            }
            ReturnString += $"Totaal verblijfprijs: {Totaal}#";
            ReturnString += $"Huurprijs: {Huurprijs}#";
            ReturnString += $"activiteiten:#";

            ReturnString += ToonActiviteiten();

            ReturnString += $"Totale vakantieprijs: {BerekenVakantieprijs()}#";

            return ReturnString;




        }
    }

    public class Vliegvakantie : Vakantie
    {
        public Route Route { get; set; }
        public decimal Vliegticketprijs { get; set; }
        public override decimal BerekenVakantieprijs()
        {
            decimal Totaal = 0;

            Totaal += Route.BerekenVerblijfsprijsPerDag() * (Terugkeerdatum - Vertrekdatum).Days;
            Totaal += Vliegticketprijs;
            foreach (IActiviteit activiteit in Activiteiten)
            {
                Totaal += activiteit.BerekenPrijs();
            }
            return Totaal;


        }
        public override string ToonGegevens()
        {
            string ReturnString = "";


            ReturnString += "=======================================#";
            ReturnString += $"boekingsnr {BoekingsNr}    Bestemming: {Bestemming}#";
            ReturnString += $"vertrekdatum {Vertrekdatum}     terugkeerdatum: {Terugkeerdatum}#";
            ReturnString += "Routes:#";
            decimal Totaal = 0;
            if (Route != null)
            {

                ReturnString += $"{Route.ToString()}";
                Totaal += Route.BerekenVerblijfsprijsPerDag() * (Terugkeerdatum - Vertrekdatum).Days;

            }
            ReturnString += $"Totaal verblijfprijs: {Totaal}#";
            ReturnString += $"vliegticketrijs: {Vliegticketprijs}#";
            ReturnString += $"activiteiten:#";

            ReturnString += ToonActiviteiten();

            ReturnString += $"Totale vakantieprijs: {BerekenVakantieprijs()}#";

            return ReturnString;

        }

    }

    public class Cruise : Vakantie
    {
        public string Vertrekpunt { get; set; }
        public string Eindpunt { get; set; }
        public List<string> Aanlegplaatsen { get; set; }
        public decimal Allinprijs { get; set; }

        public override decimal BerekenVakantieprijs()
        {
            return Allinprijs;


        }
        public override string ToonGegevens()
        {
            string ReturnString = "";


            ReturnString += "=======================================#";
            ReturnString += $"boekingsnr {BoekingsNr}    Bestemming: {Bestemming}#";
            ReturnString += $"vertrekdatum {Vertrekdatum}     terugkeerdatum: {Terugkeerdatum}#";
            ReturnString += $"Aanlegplaatsen:";
            foreach (string aanlegplaats in Aanlegplaatsen)
            {
                ReturnString += $" {aanlegplaats} ";
            }
            ReturnString += $"#Totale vakantieprijs:{BerekenVakantieprijs()}#";

            return ReturnString;
        }

    }
}