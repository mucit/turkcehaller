using System;
using System.Collections.Generic;
using System.Text;

namespace EvcilNet
{
    /// <summary>
    /// Türkçe isimlere hâl eklerini uygulayan yardımcı sınıf.
    /// </summary>
    /// <remarks>
    /// Muhammed Cuma Tahiroğlu, http://www.tahiroglu.com 
    /// </remarks>
    public class TurkceHaller
    {
        static Dictionary<IsminHali, List<IHarf>> _haller = new Dictionary<IsminHali, List<IHarf>>();

        /// <summary>
        /// Türkçe'de isme uygulanabilecek hâller (Yalın hâl dışında)
        /// </summary>
        public enum IsminHali
        {
            /// <summary>
            /// (e): dative(eve)
            /// </summary>
            Yonelme,
            /// <summary>
            /// (i): accusative(evi)
            /// </summary>
            Gosterme,
            /// <summary>
            /// (de):locative(evde)
            /// </summary>
            Bulunma,
            /// <summary>
            /// (den): ablative(evden)
            /// </summary>
            Cikma,
            /// <summary>
            /// (in): genitive ya da posessive(evin)
            /// </summary>
            Tamlama
        }

        static TurkceHaller()
        {
            _haller.Add(IsminHali.Yonelme, new List<IHarf>( new IHarf[] { new KaynastirmaHarfi(Kaynastirma.Y), new DuzGenisSesliHarf() } ));
            _haller.Add(IsminHali.Gosterme, new List<IHarf>(new IHarf[] { new KaynastirmaHarfi(Kaynastirma.Y), new DarSesliHarf() }));
            _haller.Add(IsminHali.Bulunma, new List<IHarf>(new IHarf[] { new AkilliDHarfi(), new DuzGenisSesliHarf() }));
            _haller.Add(IsminHali.Cikma, new List<IHarf>(new IHarf[] { new AkilliDHarfi(), new DuzGenisSesliHarf(), new SabitHarf(Alfabe.N) }));
            _haller.Add(IsminHali.Tamlama, new List<IHarf>(new IHarf[] { new KaynastirmaHarfi(Kaynastirma.N), new DarSesliHarf(), new SabitHarf(Alfabe.N) }));
        }

        /// <summary>
        /// Verilen Türkçe ifade sonuna, verilen ismin hâlini uyumlu biçime sokar, tek tırnak"la birlikte ilave eder ve döner.
        /// </summary>
        /// <param name="govde">Türkçe ifade</param>
        /// <param name="hal">İsmin hâli</param>
        /// <returns>Tek tırnak sonrası hâl eki eklenmiş ifade.</returns>
        public static string Uygula(string govde, IsminHali hal)
        {
            GovdeBilgisi govdeBilgisi = new GovdeBilgisi(govde);
            var harfler = _haller[hal];
            StringBuilder sb = new StringBuilder(govde);
            sb.Append("'");
            foreach (var harf in harfler)
            {
                var c = harf.Bas(govdeBilgisi);
                if (c != char.MinValue) sb.Append(c);
            }
            return sb.ToString();
        }

        static class Alfabe
        {
            public static HashSet<char> Sesliler = new HashSet<char>(new[] { A, E, I, İ, O, Ö, U, Ü });
            public static HashSet<char> DuzSesliler = new HashSet<char>(new[] { A, E, I, İ });
            public static HashSet<char> YuvarlakSesliler = new HashSet<char>(new[] { O, Ö, U, Ü });
            public static HashSet<char> DarSesliler = new HashSet<char>(new[] { I, İ, U, Ü });
            public static HashSet<char> GenisSesliler = new HashSet<char>(new[] { A, E, O, Ö });
            public static HashSet<char> KalinSesliler = new HashSet<char>(new[] { A, I, O, U });
            public static HashSet<char> InceSesliler = new HashSet<char>(new[] { E, İ, Ö, Ü });

            public static HashSet<char> SertSessizler = new HashSet<char>(new[] { P, Ç, T, K });

            public const char A = 'a';
            public const char B = 'b';
            public const char C = 'c';
            public const char Ç = 'ç';
            public const char D = 'd';
            public const char E = 'e';
            public const char F = 'f';
            public const char G = 'g';
            public const char Ğ = 'ğ';
            public const char H = 'h';
            public const char I = 'ı';
            public const char İ = 'i';
            public const char J = 'j';
            public const char K = 'k';
            public const char L = 'l';
            public const char M = 'm';
            public const char N = 'n';
            public const char O = 'o';
            public const char Ö = 'ö';
            public const char P = 'p';
            public const char R = 'r';
            public const char S = 's';
            public const char Ş = 'ş';
            public const char T = 't';
            public const char U = 'u';
            public const char Ü = 'ü';
            public const char V = 'v';
            public const char Y = 'y';
            public const char Z = 'z';
        }

        #region Harf

        static class Kaynastirma
        {
            public const char Y = Alfabe.Y;
            public const char N = Alfabe.N;
        }

        interface IHarf
        {
            char Bas(GovdeBilgisi govde);
        }

        class KaynastirmaHarfi : IHarf
        {
            char _k;

            public KaynastirmaHarfi(char k)
            {
                _k = k;
            }

            public char Bas(GovdeBilgisi govde)
            {
                if (govde.SessizIleBitiyor)
                {
                    return char.MinValue;
                }
                else
                {
                    return _k;
                }
            }
        }

        class DuzGenisSesliHarf : IHarf
        {
            public char Bas(GovdeBilgisi govde)
            {
                if (Alfabe.KalinSesliler.Contains(govde.SonSesli))
                    return Alfabe.A;
                else
                    return Alfabe.E;
            }
        }

        class DarSesliHarf : IHarf
        {
            public char Bas(GovdeBilgisi govde)
            {
                switch (govde.SonSesli)
                {
                    case Alfabe.E:
                        return Alfabe.İ;
                    case Alfabe.A:
                        return Alfabe.I;
                    case Alfabe.O:
                        return Alfabe.O;
                    case Alfabe.Ö:
                        return Alfabe.Ü;
                    default:
                        return govde.SonSesli;
                }
            }
        }

        class SabitHarf : IHarf
        {
            public char EsasHarf { get; set; }

            public SabitHarf(char c)
            {
                EsasHarf = c;
            }

            public char Bas(GovdeBilgisi govde)
            {
                return EsasHarf;
            }
        }

        class AkilliDHarfi : IHarf
        {
            public char Bas(GovdeBilgisi govde)
            {
                if (govde.SessizIleBitiyor && Alfabe.SertSessizler.Contains(govde.SonHarf))
                {
                    return Alfabe.T;
                }
                else
                {
                    return Alfabe.D;
                }
            }
        } 

        #endregion

        class GovdeBilgisi
        {
            public char SonSesli { get; set; }
            public char SonHarf { get; set; }
            public bool SessizIleBitiyor { get; set; }

            public GovdeBilgisi(string kaynak)
            {
                SonSesli = SonSesliyiVer(kaynak);
                SonHarf = kaynak[kaynak.Length - 1];
                SessizIleBitiyor = !Alfabe.Sesliler.Contains(SonHarf);
            }

            public char SonSesliyiVer(string t)
            {
                // son sesliyi, son dört harfte ara!
                for (int i = t.Length - 1; i > t.Length - 5 && i >= 0; i--)
                {
                    char c = t[i];
                    if (Alfabe.Sesliler.Contains(c))
                    {
                        return c;
                    }
                }
                return char.MinValue;
            }
        }
    }
}
