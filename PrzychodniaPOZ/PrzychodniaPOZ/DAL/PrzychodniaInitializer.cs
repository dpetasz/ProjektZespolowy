using PrzychodniaPOZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.DAL
{
    public class PrzychodniaInitializer : DropCreateDatabaseIfModelChanges<PrzychodniaContext>
    {
        protected override void Seed(PrzychodniaContext context)
        {
            SeedPrzychodniaData(context);

            base.Seed(context);
        }

        private void SeedPrzychodniaData(PrzychodniaContext context)
        {
           var pacjenci = new List<Pacjent>
            {
                new Pacjent() { Nazwisko = "Nowak", Imie = "Jan", Haslo = "1234", Email = "nowak@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "kowalski", Imie = "Jan", Haslo = "1234", Email = "kowalski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "janowski", Imie = "Jan", Haslo = "1234", Email = "janowski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "filipiak", Imie = "Jan", Haslo = "1234", Email = "filipiak@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "piotrowski", Imie = "Jan", Haslo = "1234", Email = "piotrowski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "grzegorzewski", Imie = "Jan", Haslo = "1234", Email = "grzegorzewski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "pawlikowski", Imie = "Jan", Haslo = "1234", Email = "pawlikowski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "wojciechowski", Imie = "Jan", Haslo = "1234", Email = "wojciechowski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "darkowski", Imie = "Jan", Haslo = "1234", Email = "darkowski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "markowski", Imie = "Jan", Haslo = "1234", Email = "markowski@a.pl" ,ConfirmHaslo = "1234"},
                new Pacjent() { Nazwisko = "krzysztowski", Imie = "Jan", Haslo = "1234", Email = "krzysztowski@a.pl" ,ConfirmHaslo = "1234"}
            };
            pacjenci.ForEach(p => context.Pacjent.Add(p));
            context.SaveChanges();

            var pracownicy = new List<Pracownik>
            {
                new Pracownik() { PracownikId = 1, Nazwisko = "Nowak", Imie = "Jan", Haslo = "1234", Login = "nowakjan" },
                new Pracownik() { PracownikId = 2, Nazwisko = "kwiatkowski", Imie = "Jan", Haslo = "1234", Login = "kwiatkowskijan" },
                new Pracownik() { PracownikId = 3, Nazwisko = "kowalczyk", Imie = "Jan", Haslo = "1234", Login = "kowalczykjan" },
                new Pracownik() { PracownikId = 4, Nazwisko = "pijanowski", Imie = "Jan", Haslo = "1234", Login = "pijanowskijan" }
            };
            pracownicy.ForEach(p => context.Pracownik.Add(p));
            context.SaveChanges();

            var lekarze = new List<Lekarz>
            {
                new Lekarz() { LekarzId = 1 ,Nazwisko = "Nowak", Imie = "Jan", Adres = "BRAK", Email = "BRAK", Telefon = "BRAK" },
                new Lekarz() { LekarzId = 2 ,Nazwisko = "Kowal", Imie = "Jan", Adres = "BRAK", Email = "BRAK", Telefon = "BRAK"},
                new Lekarz() { LekarzId = 3 ,Nazwisko = "Sowa", Imie = "Jan", Adres = "BRAK", Email = "BRAK", Telefon = "BRAK"},
                new Lekarz() { LekarzId = 4 ,Nazwisko = "Kwiecien", Imie = "Jan", Adres = "BRAK", Email = "BRAK", Telefon = "BRAK"},
                new Lekarz() { LekarzId = 5 ,Nazwisko = "Maj", Imie = "Jan", Adres = "BRAK", Email = "BRAK", Telefon = "BRAK"},
                new Lekarz() { LekarzId = 6 ,Nazwisko = "Czerwiec", Imie = "Jan", Adres = "BRAK", Email = "BRAK", Telefon = "BRAK"},
                new Lekarz() { LekarzId = 7 ,Nazwisko = "Lipiec", Imie = "Jan", Adres = "BRAK", Email = "BRAK", Telefon = "BRAK"}
            };
            lekarze.ForEach(l => context.Lekarz.Add(l));
            context.SaveChanges();
        }
    }
}