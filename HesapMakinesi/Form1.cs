using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        private bool YeniGirisMi = true;
        private bool RadyanModuAktif = true;
        private string SonIslem = "";
        private string IslemMetni = "";
        private List<string> IslemGecmisi = new List<string>();
        private List<double> Sayilar = new List<double>();
        private int ParantezSayisi = 0;

        public Form1()
        {
            InitializeComponent();
            ButonlariAyarla();
            
            // TextBox özellikleri
            TxtSonuc.ReadOnly = true;
            TxtSonuc.TextAlign = HorizontalAlignment.Right;
            TxtSonuc.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            TxtSonuc.BackColor = Color.White;
            TxtSonuc.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ButonlariAyarla()
        {
            // Sayı butonları
            Btn1.Click += SayiGirisiYap;
            Btn2.Click += SayiGirisiYap;
            Btn3.Click += SayiGirisiYap;
            Btn4.Click += SayiGirisiYap;
            Btn5.Click += SayiGirisiYap;
            Btn6.Click += SayiGirisiYap;
            Btn7.Click += SayiGirisiYap;
            Btn8.Click += SayiGirisiYap;
            Btn9.Click += SayiGirisiYap;
            Btn0.Click += SayiGirisiYap;

            // İşlem butonları
            BtnTopla.Click += IslemYap;
            BtnCikar.Click += IslemYap;
            BtnCarp.Click += IslemYap;
            BtnBol.Click += IslemYap;
            BtnMod.Click += IslemYap;
            BtnSolParantez.Click += ParantezEkle;
            BtnSagParantez.Click += ParantezEkle;
            BtnVirgul.Click += SayiGirisiYap;
            BtnEsittir.Click += SonucuGoster;
            BtnFaktoriyel.Click += FaktoriyelHesapla;
            BtnLn.Click += DogalLogaritmaHesapla;
            BtnLog.Click += LogaritmaHesapla;
            BtnKok.Click += KarekokHesapla;
            BtnUs.Click += UsAlmaIslemi;
            BtnPi.Click += PiSayisiniGir;
            BtnE.Click += ESayisiniGir;
            BtnSin.Click += SinusHesapla;
            BtnCos.Click += KosinusHesapla;
            BtnTan.Click += TanjantHesapla;
            BtnAc.Click += EkraniTemizle;
            BtnC.Click += SonKarakteriSil;
            BtnRadyanDerece.Click += RadyanDereceDegistir;
        }

        private double SayiGirisiYap(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (YeniGirisMi)
            {
                TxtSonuc.Text = btn.Text;
                YeniGirisMi = false;
            }
            else
            {
                TxtSonuc.Text += btn.Text;
            }
            return double.Parse(TxtSonuc.Text);
        }

        private void ParantezEkle(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "(")
            {
                if (!YeniGirisMi)
                {
                    double sayi = double.Parse(TxtSonuc.Text);
                    Sayilar.Add(sayi);
                    IslemGecmisi.Add(sayi.ToString());
                }
                IslemGecmisi.Add("(");
                ParantezSayisi++;
            }
            else if (btn.Text == ")")
            {
                if (ParantezSayisi > 0)
                {
                    if (!YeniGirisMi)
                    {
                        double sayi = double.Parse(TxtSonuc.Text);
                        Sayilar.Add(sayi);
                        IslemGecmisi.Add(sayi.ToString());
                    }
                    IslemGecmisi.Add(")");
                    ParantezSayisi--;
                }
            }
            TxtSonuc.Text += btn.Text;
            YeniGirisMi = false;
        }

        private double IslemYap(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            try
            {
                if (!YeniGirisMi)
                {
                    double sayi = double.Parse(TxtSonuc.Text);
                    Sayilar.Add(sayi);
                    IslemGecmisi.Add(sayi.ToString());
                }
                
                SonIslem = btn.Text;
                IslemGecmisi.Add(btn.Text);
                IslemMetni = string.Join(" ", IslemGecmisi);
                TxtSonuc.Text = "";
                YeniGirisMi = true;
                return Sayilar.Count > 0 ? Sayilar[Sayilar.Count - 1] : 0;
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
                return 0;
            }
        }

        private void UsAlmaIslemi(object sender, EventArgs e)
        {
            try
            {
                if (!YeniGirisMi)
                {
                    double sayi = double.Parse(TxtSonuc.Text);
                    Sayilar.Add(sayi);
                    IslemGecmisi.Add(sayi.ToString());
                }
                
                SonIslem = "^";
                IslemGecmisi.Add("^");
                IslemMetni = string.Join(" ", IslemGecmisi);
                TxtSonuc.Text = "";
                YeniGirisMi = true;
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void SonucuGoster(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SonIslem))
                {
                    return;
                }

                if (!YeniGirisMi)
                {
                    double sayi = double.Parse(TxtSonuc.Text);
                    Sayilar.Add(sayi);
                    IslemGecmisi.Add(sayi.ToString());
                }

                // Parantezleri kontrol et
                if (ParantezSayisi > 0)
                {
                    MessageBox.Show("Lütfen tüm parantezleri kapatın!");
                    return;
                }

                double sonuc = Hesapla();
                TxtSonuc.Text = sonuc.ToString("G", CultureInfo.InvariantCulture);
                YeniGirisMi = true;
                SonIslem = "";
                IslemMetni = "";
                IslemGecmisi.Clear();
                Sayilar.Clear();
                ParantezSayisi = 0;
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private double Hesapla()
        {
            Stack<double> sayiYigini = new Stack<double>();
            Stack<string> islemYigini = new Stack<string>();

            for (int i = 0; i < IslemGecmisi.Count; i++)
            {
                string token = IslemGecmisi[i];
                if (double.TryParse(token, out double sayi))
                {
                    sayiYigini.Push(sayi);
                }
                else if (token == "(")
                {
                    islemYigini.Push(token);
                }
                else if (token == ")")
                {
                    while (islemYigini.Count > 0 && islemYigini.Peek() != "(")
                    {
                        double sayi2 = sayiYigini.Pop();
                        double sayi1 = sayiYigini.Pop();
                        string islem = islemYigini.Pop();
                        sayiYigini.Push(IslemUygula(sayi1, sayi2, islem));
                    }
                    if (islemYigini.Count > 0 && islemYigini.Peek() == "(")
                    {
                        islemYigini.Pop();
                    }
                }
                else if (IsOperator(token))
                {
                    while (islemYigini.Count > 0 && islemYigini.Peek() != "(" && 
                           OncelikDerecesi(islemYigini.Peek()) >= OncelikDerecesi(token))
                    {
                        double sayi2 = sayiYigini.Pop();
                        double sayi1 = sayiYigini.Pop();
                        string islem = islemYigini.Pop();
                        sayiYigini.Push(IslemUygula(sayi1, sayi2, islem));
                    }
                    islemYigini.Push(token);
                }
            }

            while (islemYigini.Count > 0)
            {
                double sayi2 = sayiYigini.Pop();
                double sayi1 = sayiYigini.Pop();
                string islem = islemYigini.Pop();
                sayiYigini.Push(IslemUygula(sayi1, sayi2, islem));
            }

            return sayiYigini.Pop();
        }

        private bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "×" || token == "÷" || 
                   token == "%" || token == "^";
        }

        private int OncelikDerecesi(string islem)
        {
            switch (islem)
            {
                case "+":
                case "-":
                    return 1;
                case "×":
                case "÷":
                case "%":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }

        private double IslemUygula(double sayi1, double sayi2, string islem)
        {
            switch (islem)
            {
                case "+":
                    return sayi1 + sayi2;
                case "-":
                    return sayi1 - sayi2;
                case "×":
                    return sayi1 * sayi2;
                case "÷":
                    if (sayi2 == 0)
                    {
                        throw new DivideByZeroException("Sıfıra bölme hatası!");
                    }
                    return sayi1 / sayi2;
                case "%":
                    return sayi1 % sayi2;
                case "^":
                    return Math.Pow(sayi1, sayi2);
                default:
                    throw new ArgumentException("Geçersiz işlem!");
            }
        }

        private void EkraniTemizle(object sender, EventArgs e)
        {
            TxtSonuc.Text = "";
            YeniGirisMi = true;
            SonIslem = "";
            IslemMetni = "";
            IslemGecmisi.Clear();
            Sayilar.Clear();
            ParantezSayisi = 0;
        }

        private void SonKarakteriSil(object sender, EventArgs e)
        {
            if (TxtSonuc.Text.Length > 0)
            {
                char sonKarakter = TxtSonuc.Text[TxtSonuc.Text.Length - 1];
                if (sonKarakter == '(')
                {
                    ParantezSayisi--;
                }
                else if (sonKarakter == ')')
                {
                    ParantezSayisi++;
                }
                TxtSonuc.Text = TxtSonuc.Text.Substring(0, TxtSonuc.Text.Length - 1);
                YeniGirisMi = false;
            }
        }

        private void FaktoriyelHesapla(object sender, EventArgs e)
        {
            try
            {
                int sayi = int.Parse(TxtSonuc.Text);
                if (sayi < 0)
                {
                    TxtSonuc.Text = "Hata";
                    YeniGirisMi = true;
                }
                else
                {
                    long sonuc = 1;
                    for (int i = 2; i <= sayi; i++)
                    {
                        sonuc *= i;
                    }
                    TxtSonuc.Text = sonuc.ToString();
                    YeniGirisMi = true;
                }
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void LogaritmaHesapla(object sender, EventArgs e)
        {
            try
            {
                double sayi = double.Parse(TxtSonuc.Text);
                if (sayi <= 0)
                {
                    TxtSonuc.Text = "Hata";
                    YeniGirisMi = true;
                }
                else
                {
                    double sonuc = Math.Log10(sayi);
                    TxtSonuc.Text = sonuc.ToString();
                    YeniGirisMi = true;
                }
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void DogalLogaritmaHesapla(object sender, EventArgs e)
        {
            try
            {
                double sayi = double.Parse(TxtSonuc.Text);
                if (sayi <= 0)
                {
                    TxtSonuc.Text = "Hata";
                    YeniGirisMi = true;
                }
                else
                {
                    double sonuc = Math.Log(sayi);
                    TxtSonuc.Text = sonuc.ToString();
                    YeniGirisMi = true;
                }
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void KarekokHesapla(object sender, EventArgs e)
        {
            try
            {
                double sayi = double.Parse(TxtSonuc.Text);
                if (sayi < 0)
                {
                    TxtSonuc.Text = "Hata";
                    YeniGirisMi = true;
                }
                else
                {
                    double sonuc = Math.Sqrt(sayi);
                    TxtSonuc.Text = sonuc.ToString();
                    YeniGirisMi = true;
                }
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void PiSayisiniGir(object sender, EventArgs e)
        {
            TxtSonuc.Text = Math.PI.ToString();
            YeniGirisMi = true;
        }

        private void ESayisiniGir(object sender, EventArgs e)
        {
            TxtSonuc.Text = Math.E.ToString();
            YeniGirisMi = true;
        }

        private void SinusHesapla(object sender, EventArgs e)
        {
            try
            {
                double sayi = double.Parse(TxtSonuc.Text);
                if (!RadyanModuAktif)
                {
                    sayi = sayi * Math.PI / 180;
                }
                double sonuc = Math.Sin(sayi);
                TxtSonuc.Text = sonuc.ToString();
                YeniGirisMi = true;
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void KosinusHesapla(object sender, EventArgs e)
        {
            try
            {
                double sayi = double.Parse(TxtSonuc.Text);
                if (!RadyanModuAktif)
                {
                    sayi = sayi * Math.PI / 180;
                }
                double sonuc = Math.Cos(sayi);
                TxtSonuc.Text = sonuc.ToString();
                YeniGirisMi = true;
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void TanjantHesapla(object sender, EventArgs e)
        {
            try
            {
                double sayi = double.Parse(TxtSonuc.Text);
                if (!RadyanModuAktif)
                {
                    sayi = sayi * Math.PI / 180;
                }
                double sonuc = Math.Tan(sayi);
                TxtSonuc.Text = sonuc.ToString();
                YeniGirisMi = true;
            }
            catch
            {
                TxtSonuc.Text = "Hata";
                YeniGirisMi = true;
            }
        }

        private void RadyanDereceDegistir(object sender, EventArgs e)
        {
            RadyanModuAktif = !RadyanModuAktif;
            BtnRadyanDerece.Text = RadyanModuAktif ? "RAD" : "DEG";
        }
    }
}
