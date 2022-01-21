using System;
using cFPTest;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Verblijven
{
    public abstract class Verblijfstype
    {
        public Verblijfstype(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle, List<Formule> beschikbareVerblijfsFormules)
        {
            NaamVerblijf = naamVerblijf;
            BasisPrijsPerDag = basisPrijsPerDag;
            ToeslagSingle = toeslagSingle;
            BeschikbareVerblijfsFormules = beschikbareVerblijfsFormules;
        }

        public string NaamVerblijf { get; set; }
        public decimal BasisPrijsPerDag { get; set; }
        public bool ToeslagSingle { get; set; }
        public List<Formule> BeschikbareVerblijfsFormules { get; set; }

        public virtual decimal BerekenPrijsPerDag()
        {
            if (ToeslagSingle == true)
            {
                return BasisPrijsPerDag + 5;
            }
            else
            {
                return BasisPrijsPerDag;
            }

        }
    }

    public class Appartement : Verblijfstype
    {
        List<Formule> Default = new List<Formule> { Formule.Ontbijt, Formule.HalfPension };

        public Appartement(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle, decimal schoonmaakprijserDag, bool lift, List<Formule> beschikbareVerblijfsFormules = default) : base(naamVerblijf, basisPrijsPerDag, toeslagSingle, beschikbareVerblijfsFormules)
        {
            SchoonmaakprijserDag = schoonmaakprijserDag;
            Lift = lift;
            BeschikbareVerblijfsFormules = Default;
        }

        public decimal SchoonmaakprijserDag { get; set; }
        public bool Lift { get; set; }
        public override decimal BerekenPrijsPerDag()
        {
            return base.BerekenPrijsPerDag() + SchoonmaakprijserDag;
        }
    }

    public class Hotel : Verblijfstype
    {
        List<Formule> Default = new List<Formule> { Formule.Ontbijt, Formule.HalfPension, Formule.VolPension };
        public Hotel(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle, bool internet, decimal? wellnessprijsPerDag, List<Formule> beschikbareVerblijfsFormules = default) : base(naamVerblijf, basisPrijsPerDag, toeslagSingle, beschikbareVerblijfsFormules)
        {
            Internet = internet;
            WellnessprijsPerDag = wellnessprijsPerDag;
            BeschikbareVerblijfsFormules = Default;
        }

        public bool Internet { get; set; }

        public decimal? WellnessprijsPerDag
        {
            get; set;
        }
        public override decimal BerekenPrijsPerDag()
        {
            return base.BerekenPrijsPerDag() + (decimal)WellnessprijsPerDag;
        }
    }

    public class Vakantiehuis : Verblijfstype
    {
        List<Formule> Default = new List<Formule> { Formule.Ontbijt };
        public Vakantiehuis(string naamVerblijf, decimal basisPrijsPerDag, bool toeslagSingle, decimal schoonmaakprijsPerDag, decimal linnengoedprijsPerDag, List<Formule> beschikbareVerblijfsFormules = default) : base(naamVerblijf, basisPrijsPerDag, toeslagSingle, beschikbareVerblijfsFormules)
        {
            SchoonmaakprijsPerDag = schoonmaakprijsPerDag;
            LinnengoedprijsPerDag = linnengoedprijsPerDag;
            BeschikbareVerblijfsFormules = Default;
        }

        public decimal SchoonmaakprijsPerDag { get; set; }
        public decimal LinnengoedprijsPerDag { get; set; }
        public override decimal BerekenPrijsPerDag()
        {
            return base.BerekenPrijsPerDag() + SchoonmaakprijsPerDag + LinnengoedprijsPerDag;
        }
    }
}