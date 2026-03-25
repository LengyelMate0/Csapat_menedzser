using System;

namespace Focicsapat_menedzser
{

    public abstract class CsapatTag
    {
        private string nev;

        public string Nev
        {
            get => nev;
            set => nev = value;
        }

        public abstract string GetInfo();
    }

    public class Jatekos : CsapatTag
    {
        public string Poszt { get; set; }
        public int Golok { get; set; }
        public int Passzok { get; set; }

        public Jatekos(string nev, string poszt, int golok, int passzok)
        {
            this.Nev = nev;
            this.Poszt = poszt;
            this.Golok = golok;
            this.Passzok = passzok;
        }

        public override string GetInfo() => $"{Nev} ({Poszt})";

        public string ToCsv() => $"{Nev};{Poszt};{Golok};{Passzok}";
    }
}