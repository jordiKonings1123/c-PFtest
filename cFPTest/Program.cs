using System;
using static Methods.Methods;
using Verblijven;
using Vakanties;
using System.Collections.Generic;
using System.Linq;

namespace cFPTest
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {


                //**********************************************************
                // Hotels
                //**********************************************************
                Hotel albergoNero = new Hotel("Albergo Nero", 120m, true, true, 0m);
                Hotel capella = new Hotel("Capella", 150m, false, false, null);
                Hotel hotelletFrokost = new Hotel("Hotellet Frokost", 200m, true, true, 75m);
                Hotel meniBeach = new Hotel("MeniBeach", 100m, true, true, 50m);

                //**********************************************************
                // Appartementen
                //**********************************************************
                Appartement casaBlanca = new Appartement("Casa Blanca", 150m, false, 20m, true);
                Appartement parcoVista = new Appartement("Parco Vista", 100m, false, 15m, true);
                Appartement hviteHus = new Appartement("Hvite Hus", 125m, false, 15m, false);
                Appartement husetSvart = new Appartement("Huset Svart", 200m, true, 20m, false);

                //**********************************************************
                //Vakantiehuizen
                //**********************************************************
                Vakantiehuis fioriTorre = new Vakantiehuis("Fiori Torre", 150m, false, 15m, 5m);
                Vakantiehuis gronnpark = new Vakantiehuis("Gronnpark", 120m, false, 10m, 10m);
                Vakantiehuis blomsterTarnet = new Vakantiehuis("BlomsterTarnet", 100m, false, 10m, 10m);
                Vakantiehuis visning = new Vakantiehuis("Visning", 200m, false, 20m, 10m);



                //**********************************************************
                //Routes
                //**********************************************************

                Route routeLucca = new Route("Lucca", "Prato", casaBlanca, Formule.Ontbijt);
                Route routePrato = new Route("Prato", "Bologna", albergoNero, Formule.Ontbijt);
                Route routeBologna = new Route("Bologna", "Arezzo", parcoVista, Formule.HalfPension);
                Route routeArezzo = new Route("Arezzo", "Livorno", fioriTorre, Formule.Ontbijt);
                Route routeLivorno = new Route("Livorno", "Firenze", capella, Formule.Ontbijt);
                Route routeStavanger = new Route("Stavanger", "EgerSund", hviteHus, Formule.Ontbijt);
                Route routeEgerSund = new Route("EgerSund", "Kragera", husetSvart, Formule.Ontbijt);
                Route routeKragera = new Route("Kragera", "Porsgrunn", gronnpark, Formule.Ontbijt);
                Route routePorsgrunn = new Route("Porsgrunn", "Drammen", blomsterTarnet, Formule.Ontbijt);
                Route routeDrammen = new Route("Drammen", "Oslo", visning, Formule.Ontbijt);
                Route routeOslo = new Route("Oslo", "Moss", hotelletFrokost, Formule.Ontbijt);
                Route routeAthene = new Route("Athene", "Kos", meniBeach, Formule.VolPension);



                //**********************************************************
                //Activiteiten
                //**********************************************************
                MTB volwassenenFiets = new MTB
                {
                    Naam = "Volwassenenfiets",
                    PrijsUitrusting = 20m,
                    HuurprijsFietsPerUur = 10m,
                    AantalUren = 4
                };


                MTB kinderFiets = new MTB
                {
                    Naam = "Kinderfiets",
                    PrijsUitrusting = 15m,
                    HuurprijsFietsPerUur = 7.5m,
                    AantalUren = 3
                };

                Cinema volwassenenCinema = new Cinema
                {
                    Naam = "Volwassenencinema",
                    Inkom = 7.5m,
                    Snoepgoed = 5m
                };

                Cinema kinderCinema = new Cinema
                {
                    Naam = "Kindercinema",
                    Inkom = 5m,
                    Snoepgoed = 5.25m
                };

                Stadsbezoek stadsbezoekAthene = new Stadsbezoek
                {
                    Naam = "Athene",
                    PrijsGidsPer10Personen = 150m,
                    AantalPersonen = 15
                };

                Stadsbezoek stadsbezoekRome = new Stadsbezoek
                {
                    Naam = "Rome",
                    PrijsGidsPer10Personen = 125m,
                    AantalPersonen = 12
                };

                Stadsbezoek stadsbezoekOslo = new Stadsbezoek
                {
                    Naam = "Oslo",
                    PrijsGidsPer10Personen = 175m,
                    AantalPersonen = 7
                };

                // table 

                Cruise cruise1 = new Cruise
                {
                    BoekingsNr = 1,
                    Bestemming = Bestemming.Finland,
                    Vertrekdatum = new DateTime(2020, 08, 12),
                    Terugkeerdatum = new DateTime(2020, 08, 20),
                    Vertrekpunt = "Helsinki",
                    Eindpunt = "Helsinki",
                    Aanlegplaatsen = new List<string> { "Turku", "Rauma", "Vaasa", "Oulu" },
                    Allinprijs = 6800
                };


                Autovakantie autovakantie1 = new Autovakantie
                {
                    BoekingsNr = 2,
                    Bestemming = Bestemming.Italie,
                    Vertrekdatum = new DateTime(2020, 05, 14),
                    Terugkeerdatum = new DateTime(2020, 05, 19),
                    Wagentype = WagenType.Camper,
                    Huurprijs = 500,
                    Activiteiten = new List<IActiviteit> { stadsbezoekRome, volwassenenCinema, volwassenenCinema, kinderCinema },
                    Routes = new List<Route> { routeArezzo, routeBologna, routeKragera }

                };

                Autovakantie autovakantie2 = new Autovakantie
                {
                    BoekingsNr = 3,
                    Bestemming = Bestemming.Noorwegen,
                    Vertrekdatum = new DateTime(2020, 08, 8),
                    Terugkeerdatum = new DateTime(2020, 08, 14),
                    Wagentype = WagenType.Camper,
                    Huurprijs = 600,
                    Activiteiten = new List<IActiviteit> { stadsbezoekOslo, volwassenenFiets, kinderFiets, kinderFiets },
                    Routes = new List<Route> { routeArezzo, routeBologna, routeKragera }
                };

                Vliegvakantie vliegvakantie1 = new Vliegvakantie
                {
                    BoekingsNr = 4,
                    Bestemming = Bestemming.Griekenland,
                    Vertrekdatum = new DateTime(2020, 09, 1),
                    Terugkeerdatum = new DateTime(2020, 09, 15),
                    Vliegticketprijs = 800,
                    Activiteiten = new List<IActiviteit> { stadsbezoekAthene, volwassenenFiets, volwassenenFiets, kinderFiets, kinderFiets },
                    Route = routeArezzo

                };

                //programa



                List<Vakantie> vakanties = new List<Vakantie> { cruise1, autovakantie2, vliegvakantie1, autovakantie1 };
                var lijst = from vakantie in vakanties orderby vakantie.GetType().FullName select vakantie;

                string[] datas;

                string Soort = "";

                foreach (Vakantie vakantie1 in lijst)
                {
                    if (Soort != vakantie1.GetType().Name)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine($"{vakantie1.GetType().Name}s");
                        Console.WriteLine("-----------------------------------");
                        Soort = vakantie1.GetType().Name;
                    }

                    datas = vakantie1.ToonGegevens().Split('#');
                    foreach (string data in datas)
                    {
                        Console.WriteLine(data);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("er is iets fout gebeurt");
            }

        }
    }
}
