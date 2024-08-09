using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Diagnostics;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;


namespace Mikro
{
    public partial class Form1 : Form
    {
        string _i;
        string _j;
        string _k;
        string _l;
        string _m;

        private string[] hexF = { "a", "b", "c", "d", "e", "f" };
        List<string> dataSegment = new List<string>();


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            #region Data Segment oluştur

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int k = 0; k < 16; k++)
                    {
                        for (int l = 0; l < 16; l++)
                        {
                            //for (int m = 0; m < 16; m++)
                            //{
                            _i = i.ToString();
                            _j = j.ToString();
                            _k = k.ToString();
                            _l = l.ToString();
                            //  _m = m.ToString();

                            #region i

                            if (i == 10)
                            {
                                _i = "a";
                            }

                            if (i == 11)
                            {
                                _i = "b";
                            }

                            if (i == 12)
                            {
                                _i = "c";
                            }

                            if (i == 13)
                            {
                                _i = "d";
                            }

                            if (i == 14)
                            {
                                _i = "e";
                            }

                            if (i == 15)
                            {
                                _i = "f";
                            }

                            #endregion

                            #region j

                            if (j == 10)
                            {
                                _j = "a";
                            }

                            if (j == 11)
                            {
                                _j = "b";
                            }

                            if (j == 12)
                            {
                                _j = "c";
                            }

                            if (j == 13)
                            {
                                _j = "d";
                            }

                            if (j == 14)
                            {
                                _j = "e";
                            }

                            if (j == 15)
                            {
                                _j = "f";
                            }

                            #endregion

                            #region k

                            if (k == 10)
                            {
                                _k = "a";
                            }

                            if (k == 11)
                            {
                                _k = "b";
                            }

                            if (k == 12)
                            {
                                _k = "c";
                            }

                            if (k == 13)
                            {
                                _k = "d";
                            }

                            if (k == 14)
                            {
                                _k = "e";
                            }

                            if (k == 15)
                            {
                                _k = "f";
                            }

                            #endregion

                            #region l

                            if (l == 10)
                            {
                                _l = "a";
                            }

                            if (l == 11)
                            {
                                _l = "b";
                            }

                            if (l == 12)
                            {
                                _l = "c";
                            }

                            if (l == 13)
                            {
                                _l = "d";
                            }

                            if (l == 14)
                            {
                                _l = "e";
                            }

                            if (l == 15)
                            {
                                _l = "f";
                            }

                            #endregion

                            /*#region m

                            if (m == 10)
                            {
                                _m = "a";
                            }
                            if (m == 11)
                            {
                                _m = "b";
                            }
                            if (m == 12)
                            {
                                _m = "c";
                            }
                            if (m == 13)
                            {
                                _m = "d";
                            }
                            if (m == 14)
                            {
                                _m = "e";
                            }
                            if (m == 15)
                            {
                                _m = "f";
                            }
                            
                            #endregion
*/


                            dataSegment.Add(_i + _j + _k + _l + "h");

                            //}
                        }
                    }
                }
            }

            for (int i = 0; i < 4096; i++)
            {
                segmentData.Items.Add(dataSegment[i]);
                segmentCode.Items.Add(dataSegment[i]);
                segmentStack.Items.Add(dataSegment[i]);
            }

            #endregion


            #region Yamaçları listeye ekle

            yazmacListesi.Add(ax);
            yazmacListesi.Add(ah);
            yazmacListesi.Add(al);
            yazmacListesi.Add(bx);
            yazmacListesi.Add(bh);
            yazmacListesi.Add(bl);
            yazmacListesi.Add(cx);
            yazmacListesi.Add(ch);
            yazmacListesi.Add(cl);
            yazmacListesi.Add(dx);
            yazmacListesi.Add(dh);
            yazmacListesi.Add(dl);
            yazmacListesi.Add(sj);
            yazmacListesi.Add(bp);
            yazmacListesi.Add(dj);
            yazmacListesi.Add(sp);

            #endregion
        }

        void timer_Tick(object sender, EventArgs e, Label _a)
        {
            //Call method
        }


        bool _kontrol1;
        bool _kontrol2;
        private string adres1;
        private string adres2;
        int _durum1;
        int _durum2;
        int _bit1;
        int _bit2;
        private string _deger1;
        private string _deger2;
        bool hataYok = false;
        private string gecici;
        private string adresDurumu;
        private int durum = 0;
        private int bit = 0;
        bool kilit = false;
        List<Label> yazmacListesi = new List<Label>();
        List<degisken> degiskenListesi = new List<degisken>();
        private string[] ozelYazmaclar = { "ax", "cx", "dx" };
        private bool ozelYazmacKontrol = false;

        private string ozelYazmac = "";


        #region kod çalıştır

        private bool _bosDegerMi;
        private bool flagCalistirMa;

        private void komutCalistir_Click(object sender, EventArgs e)
        {
            if (deger1Text.Text.ToUpper().Equals("Sİ") || deger1Text.Text.ToUpper().Equals("SI"))
            {
                deger1Text.Text = "sj";
            }

            if (deger1Text.Text.ToUpper().Equals("DI") || deger1Text.Text.ToUpper().Equals("Dİ"))
            {
                deger1Text.Text = "dj";
            }

            if (deger2Text.Text.ToUpper().Equals("SI") || deger2Text.Text.ToUpper().Equals("Sİ"))
            {
                deger2Text.Text = "sj";
            }

            if (deger2Text.Text.ToUpper().Equals("Dİ") || deger2Text.Text.ToUpper().Equals("DI"))
            {
                deger2Text.Text = "dj";
            }

            _bosDegerMi = bosMu(deger1Text);
            if (_bosDegerMi == true)
            {
                _kontrol1 = kontrol(deger1Text);
                _bit1 = bit;
                _deger1 = deger;
                _durum1 = durum;
                deger1Lab.Text = _deger1;
                if (bit == 0)
                {
                    bit1.Text = "8-";
                }
                else
                {
                    bit1.Text = "16-";
                }

                if (_durum1 == 0)
                {
                    durumLab1.Text = "Yazmaç";
                }

                if (_durum1 == 1)
                {
                    durumLab1.Text = "Değişken";
                }

                if (_durum1 == 2)
                {
                    durumLab1.Text = "Değer";
                }

                if (_durum1 == 3)
                {
                    durumLab1.Text = "Adres";
                }

                if (!_kontrol1)
                {
                    durumLab1.Text = "Geçersiz";
                    bit2.Text = "";
                    deger2Lab.Text = "";
                }


                if (_durum1 == 3)
                {
                    adres1 = adres;
                }
            }

            _bosDegerMi = bosMu(deger2Text);
            if (_bosDegerMi == true)
            {
                _kontrol2 = kontrol(deger2Text);
                _bit2 = bit;
                _deger2 = deger;
                _durum2 = durum;
                deger2Lab.Text = _deger2;
                if (bit == 0)
                {
                    bit2.Text = "8-";
                }
                else
                {
                    bit2.Text = "16-";
                }

                if (_durum2 == 0)
                {
                    durumLab2.Text = "Yazmaç";
                }

                if (_durum2 == 1)
                {
                    durumLab2.Text = "Değişken";
                }

                if (_durum2 == 2)
                {
                    durumLab2.Text = "Değer";
                }

                if (_durum2 == 3)
                {
                    durumLab2.Text = "Adres";
                }

                if (!_kontrol2)
                {
                    durumLab2.Text = "Geçersiz";
                    bit2.Text = "";
                    deger2Lab.Text = "";
                }


                if (_durum2 == 3)
                {
                    adres2 = adres;
                }
            }

            hatasiz = false;

            if (komutText.Text.ToUpper().Equals("MOV"))
            {
                mov();
            }

            if (komutText.Text.ToUpper().Equals("ADD"))
            {
                add();
            }

            if (komutText.Text.ToUpper().Equals("INC") || komutText.Text.ToUpper().Equals("İNC"))
            {
                inc();
                flagCalistirMa = true;
            }

            if (komutText.Text.ToUpper().Equals("SUB"))
            {
                sub();
            }

            if (komutText.Text.ToUpper().Equals("DEC"))
            {
                dec();
                flagCalistirMa = true;
            }

            if (komutText.Text.ToUpper().Equals("ADC"))
            {
                adc();
            }

            if (komutText.Text.ToUpper().Equals("SBB"))
            {
                sbb();
            }

            if (komutText.Text.ToUpper().Equals("DIV")
                || komutText.Text.ToUpper().Equals("DİV"))
            {
                div();
            }

            if (komutText.Text.ToUpper().Equals("IDIV")
                || komutText.Text.ToUpper().Equals("İDİV")
                || komutText.Text.ToUpper().Equals("IDİV")
                || komutText.Text.ToUpper().Equals("İDIV"))
            {
                idiv();
            }

            if (komutText.Text.ToUpper().Equals("MUL"))
            {
                mul();
            }

            if (komutText.Text.ToUpper().Equals("IMUL") ||
                komutText.Text.ToUpper().Equals("İMUL"))
            {
                imul();
            }


            if (komutText.Text.ToUpper().Equals("CMP"))
            {
                cmp();
            }

            if (komutText.Text.ToUpper().Equals("OR"))
            {
                or();
            }

            if (komutText.Text.ToUpper().Equals("AND"))
            {
                and();
            }

            if (komutText.Text.ToUpper().Equals("XOR"))
            {
                xor();
            }

            if (komutText.Text.ToUpper().Equals("TEST"))
            {
                test();
            }

            if (komutText.Text.ToUpper().Equals("XCHG"))
            {
                mov();
            }

            if (komutText.Text.ToUpper().Equals("PUSH"))
            {
                push();
            }

            if (komutText.Text.ToUpper().Equals("POP"))
            {
                pop();
            }

            if (komutText.Text.ToUpper().Equals("NOT"))
            {
                not();
            }

            if (komutText.Text.ToUpper().Equals("NEG"))
            {
                neg();
            }

            if (komutText.Text.ToUpper().Equals("SHL"))
            {
                shl();
            }

            if (komutText.Text.ToUpper().Equals("SHR"))
            {
                shr();
            }

            if (komutText.Text.ToUpper().Equals("SAL"))
            {
                sal();
            }

            if (komutText.Text.ToUpper().Equals("SAR"))
            {
                sar();
            }

            if (komutText.Text.ToUpper().Equals("RCL"))
            {
                rcl();
            }

            if (komutText.Text.ToUpper().Equals("RCR"))
            {
                rcr();
            }

            if (komutText.Text.ToUpper().Equals("ROR"))
            {
                ror();
            }

            if (komutText.Text.ToUpper().Equals("ROL"))
            {
                rol();
            }


            if (hatasiz == true)
            {
                if (_durum1 == 10)
                {
                    bilgiLabel.Text = "Korumalı nesnedir";
                    Thread.Sleep(2000);
                    labelSifirla();
                }
            }

            if (komutText.Text.ToUpper().Equals("NOP"))
            {
                bilgiLabel.Text = "İşlem yapmaz bu komut";
                labelSifirla();
            }


            if (komutText.Text.ToUpper().Equals("CLC"))
            {
                bC.Text = "0";
                bilgiLabel.Text = $"{fC.Text} biti temizlendi";
                labelSifirla();
            }

            if (komutText.Text.ToUpper().Equals("CLI")
                || komutText.Text.ToUpper().Equals("CLİ"))
            {
                fI.Text = "0";
                bilgiLabel.Text = $"{fI.Text} biti temizlendi";
                labelSifirla();
            }

            if (komutText.Text.ToUpper().Equals("CMC"))
            {
                if (bC.Text.Equals("0"))
                {
                    bC.Text = "1";
                }
                else
                {
                    bC.Text = "0";
                }

                bilgiLabel.Text = $"{fC.Text} biti terslendi";
                labelSifirla();
            }

            if (hatasiz == true)
            {
                kodlar k = new kodlar();
                k.adres = dataSegment[kodSayisi];
                k.kod = komutText.Text + " " + " " +
                        deger1Text.Text + " " + " " +
                        deger2Text.Text;
                kodListesi.Add(k);
                kodSayisi++;
            }


            tasmaOldu = false;
            flagCalistirMa = false;
            deger = "";
            durum = 0;
            bit = 0;
            _bit1 = 0;
            _bit2 = 0;
            _deger1 = "0";
            _deger2 = "0";
            _durum1 = 0;
            _durum2 = 0;
            _kontrol1 = false;
            _kontrol2 = false;
            hatasiz = false;
            _bosDegerMi = false;
            if (deger1Text.Text.ToUpper().Equals("SJ"))
            {
                deger1Text.Text = "si";
            }

            if (deger1Text.Text.ToUpper().Equals("DJ"))
            {
                deger1Text.Text = "di";
            }

            if (deger2Text.Text.ToUpper().Equals("Sİ"))
            {
                deger2Text.Text = "si";
            }

            if (deger2Text.Text.ToUpper().Equals("DJ"))
            {
                deger2Text.Text = "di";
            }

            labelSifirla();
        }

        #endregion

        // ---- Değerlerin boş olup olmadığını kontrol et -----//
        private bool dolu;

        bool bosMu(TextBox text)
        {
            dolu = false;
            if (!string.IsNullOrEmpty(text.Text))
            {
                dolu = true;
            }

            return dolu;
        }


        private bool hatasiz;

        void mov()
        {
            // --- hata 1: geçersiz değerler ----//
            hatasiz = false;
            if (_kontrol1 == true && _kontrol2 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }

            if (hatasiz == true && _bit1 == 0 && _bit2 == 1)
            {
                hatasiz = false;
                bilgiLabel.Text = "Mixed Size hatası";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }

            if (hatasiz == true && _durum1 == 3 && _durum2 == 3)
            {
                hatasiz = false;
                bilgiLabel.Text = "Adresten adrese aktarım olmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }

            if (hatasiz == true && _durum1 == 3)
            {
                foreach (var i in degiskenListesi)
                {
                    if (deger1Text.Text.Substring(1, deger1Text.Text.Length - 2).Equals(i.degiskenAdi))
                    {
                        bilgiLabel.Text = "İzin verilmeyen bir işlem";
                        labelSifirla();
                        hatasiz = false;
                        break;
                    }
                }

                foreach (var i in yazmacListesi)
                {
                    if (deger1Text.Text.Substring(1, deger1Text.Text.Length - 2).ToUpper().Equals(i.Name.ToUpper()))
                    {
                        bilgiLabel.Text = "İzin verilmeyen bir işlem";
                        labelSifirla();
                        hatasiz = false;
                        break;
                    }
                }
            }

            if (hatasiz == true && _durum2 == 3)
            {
                foreach (var i in degiskenListesi)
                {
                    if (deger2Text.Text.Substring(1, deger2Text.Text.Length - 2).Equals(i.degiskenAdi))
                    {
                        bilgiLabel.Text = "İzin verilmeyen bir işlem";
                        labelSifirla();
                        hatasiz = false;
                        break;
                    }
                }

                foreach (var i in yazmacListesi)
                {
                    if (deger2Text.Text.Substring(1, deger2Text.Text.Length - 2).ToUpper().Equals(i.Name.ToUpper()))
                    {
                        bilgiLabel.Text = "İzin verilmeyen bir işlem";
                        labelSifirla();
                        hatasiz = false;
                        break;
                    }
                }
            }


            if (hatasiz == true && _durum1 == 2)
            {
                hatasiz = false;
                bilgiLabel.Text = "Değere bir şey atanmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            // ----- MOV işlemi ---- //
            if (hatasiz == true)
            {
                // ----- durum1 = 0 Yazmaç ise -------- //
                if (!komutText.Text.ToUpper().Equals("XCHG"))
                {
                    if (Convert.ToInt64(donusturDec(_deger2)) < 0)
                    {
                        _deger2 = binCon(_deger2) + "b";
                        _deger2 = donusturDec(_deger2);
                    }
                    else
                    {
                        _deger2 = Convert.ToInt64(donusturDec(_deger2)).ToString();
                    }

                    sonuc(_deger2);
                }
                else
                {
                    if (Convert.ToInt64(donusturDec(_deger2)) < 0)
                    {
                        _deger2 = binCon(_deger2) + "b";
                        _deger2 = donusturDec(_deger2);
                        _deger1 = binCon(_deger1) + "b";
                        _deger1 = donusturDec(_deger1);
                    }
                    else
                    {
                        bPP.Text = "";
                        _deger2 = Convert.ToInt64(donusturDec(_deger2)).ToString();
                        _deger1 = Convert.ToInt64(donusturDec(_deger1)).ToString();
                    }

                    if (_bit1 == _bit2)
                    {
                        sonuc2(_deger2);
                        sonuc3(_deger1);
                    }
                    else
                    {
                        bilgiLabel.Text = "Kapasiteleri birbirinden farklı sayılar olduğu için verilmez";
                        labelSifirla();
                    }
                }


                /*
                if (_durum1 == 0)
                {
                    yazmacaDegerAta(deger1Text.Text, _deger2, _bit1);
                }


                if (_durum1 == 1)
                {
                    foreach (var i in degiskenListesi)
                    {
                        if (i.degiskenAdi.Equals(deger1Text.Text))
                        {
                            if (i.degiskenBiti.Equals("8") && _bit2 == 1)
                            {
                                bilgiLabel.Text = "Değişkenin adres boyutunu aştığı için işleme izin verilmez";
                            }
                            else
                            {
                                i.degiskenDegeri = _deger2;
                            }
                        }
                    }
                }
            
                if (_durum1 == 3)
                {
                    /* degiskenVarMi = false;
                     _16Bit = false;
                     for (int i = 0; i < dataSegment.Count; i++)
                     {
                         if (dataSegment[i].Equals(adres1))
                         {
                             degiskenVarMi = degiskenBul(dataSegment[i]);
                             if (degiskenVarMi == true)
                             {
                                 bilgiLabel.Text = "Bu adreste değişken tanımlıdır";
                                 break;
                             }
                             else
                             {
                                 if (i != 0)
                                 {
                                     degiskenVarMi = degiskenBul(dataSegment[i - 1]);
                                     if (degiskenVarMi == true)
                                     {
                                         if (_16Bit == true)
                                         {
                                             bilgiLabel.Text = "Bu adreste değişken tanımlıdır";
                                             break;
                                         }
                                     }
                                 }
 
                                 degisken d = new degisken();
                                 if (_bit2 == 1)
                                 {
                                     degiskenVarMi = degiskenBul(dataSegment[i + 1]);
                                     if (degiskenVarMi == true)
                                     {
                                         bilgiLabel.Text = "Bu adrese 16 bitlik değer eklenemez";
                                         break;
                                     }
                                     else
                                     {
                                         d.degiskenBiti = "16";
                                     }
                                 }
                                 else
                                 {
                                     d.degiskenBiti = "8";
                                 }
 
                                 d.degiskenDegeri = _deger2;
                                 d.degiskenAdresi = adres1;
                                 d.degiskenAdi = "(tanimsiz)";
                                 degiskenListesi.Add(d);
                             }
                         }
                     }
                    if (_bit2 == 1)
                    {
                        bilgiLabel.Text = "Adres boyutunu aştığı için işleme izin verilmiyor";
                    }
                    else
                    {
                        adresDegeriAta(adres1, _deger2, _bit2);
                    }
                }*/
            }
        }


        void add()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true && _kontrol2 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }

            if (hatasiz == true && _durum1 == 3 && _durum2 == 3)
            {
                hatasiz = false;
                bilgiLabel.Text = "Adresten adrese toplama olmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            if (hatasiz == true)
            {
                _deger1 = donusturDec(_deger1);
                _deger2 = donusturDec(_deger2);
                deger = (Convert.ToInt64(_deger1) + Convert.ToInt64(_deger2)).ToString();
                if (_bit1 > _bit2)
                {
                    _bit1 = 1;
                }
                else
                {
                    if (_bit1 == _bit2)
                    {
                    }
                    else
                    {
                        _bit1 = 0;
                    }
                }


                sonuc(deger);
            }
        }


        void inc()
        {
            hatasiz = false;

            if (!deger2Text.Text.Equals(""))
            {
                bilgiLabel.Text = "İkinci değer boş olmalıdır";
                labelSifirla();
            }
            else
            {
                hatasiz = true;
            }

            if (_kontrol1 == false)
            {
                bilgiLabel.Text = "Geçersiz değer";
                labelSifirla();
                hatasiz = false;
            }


            if (hatasiz == true)
            {
                _deger1 = donusturDec(_deger1);
                _deger1 = (Convert.ToInt64(_deger1) + 1).ToString();

                sonuc(deger);
            }
        }


        void sub()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true && _kontrol2 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }

            if (hatasiz == true && _durum1 == 3 && _durum2 == 3)
            {
                hatasiz = false;
                bilgiLabel.Text = "Adresten adrese toplama olmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            if (hatasiz == true)
            {
                _deger1 = donusturDec(_deger1);
                _deger2 = donusturDec(_deger2);
                deger = (Convert.ToInt64(_deger1) - Convert.ToInt64(_deger2)).ToString();
                if (_bit1 > _bit2)
                {
                    _bit1 = 1;
                }
                else
                {
                    if (_bit1 == _bit2)
                    {
                    }
                    else
                    {
                        _bit1 = 0;
                    }
                }


                sonuc(deger);
            }
        }


        void dec()
        {
            hatasiz = false;

            if (!deger2Text.Text.Equals(""))
            {
                bilgiLabel.Text = "İkinci değer boş olmalıdır";
                labelSifirla();
            }
            else
            {
                hatasiz = true;
            }

            if (_kontrol1 == false)
            {
                bilgiLabel.Text = "Geçersiz değer";
                labelSifirla();
                hatasiz = false;
            }


            if (hatasiz == true)
            {
                _deger1 = donusturDec(_deger1);
                _deger1 = (Convert.ToInt64(_deger1) - 1).ToString();
                deger = tasmaKontrol(deger, _bit1);

                sonuc(deger);
            }
        }


        void adc()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true && _kontrol2 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }

            if (hatasiz == true && _durum1 == 3 && _durum2 == 3)
            {
                hatasiz = false;
                bilgiLabel.Text = "Adresten adrese toplama olmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            if (hatasiz == true)
            {
                if (hatasiz == true)
                {
                    _deger1 = donusturDec(_deger1);
                    _deger2 = donusturDec(_deger2);
                    deger = (Convert.ToInt64(_deger1) + Convert.ToInt64(_deger2)).ToString();
                    if (_bit1 > _bit2)
                    {
                        _bit1 = 1;
                    }
                    else
                    {
                        if (_bit1 == _bit2)
                        {
                        }
                        else
                        {
                            _bit1 = 0;
                        }
                    }


                    if (bC.Text.Equals("1"))
                    {
                        deger = (Convert.ToInt64(deger) + 1).ToString();
                    }


                    sonuc(deger);
                }
            }
        }

        void sbb()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true && _kontrol2 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }

            if (hatasiz == true && _durum1 == 3 && _durum2 == 3)
            {
                hatasiz = false;
                bilgiLabel.Text = "Adresten adrese toplama olmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            if (hatasiz == true)
            {
                if (hatasiz == true)
                {
                    _deger1 = donusturDec(_deger1);
                    _deger2 = donusturDec(_deger2);
                    deger = (Convert.ToInt64(_deger1) - Convert.ToInt64(_deger2)).ToString();
                    if (_bit1 > _bit2)
                    {
                        _bit1 = 1;
                    }
                    else
                    {
                        if (_bit1 == _bit2)
                        {
                        }
                        else
                        {
                            _bit1 = 0;
                        }
                    }


                    sonuc(deger);
                }
            }
        }


        void div()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }


            if (hatasiz == true && (Convert.ToInt64(donusturDec(_deger1)) < 0))
            {
                hatasiz = false;
                bilgiLabel.Text = "İşaretli sayılar için bu komut çalışmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            if (hatasiz == true)
            {
                _deger2 = Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))).ToString();
                if (_bit1 == 0)
                {
                    deger = (Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))) /
                             Convert.ToInt64(donusturDec(_deger1))).ToString();


                    yazmacaDegerAta("al", deger, 0);


                    deger = (Convert.ToInt64(_deger2) %
                             Convert.ToInt64(donusturDec(_deger1))).ToString();

                    yazmacaDegerAta("ah", deger, 0);
                }
                else
                {
                    deger = (Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))) /
                             Convert.ToInt64(donusturDec(_deger1))).ToString();
                    yazmacaDegerAta("ax", deger, 1);

                    deger = (Convert.ToInt64(_deger2) %
                             Convert.ToInt64(donusturDec(_deger1))).ToString();
                    yazmacaDegerAta("dx", deger, 1);
                }
            }
        }

        void idiv()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }


            if (hatasiz == true)
            {
                _deger2 = Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))).ToString();
                if (_bit1 == 0)
                {
                    deger = (Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))) /
                             Convert.ToInt64(donusturDec(_deger1))).ToString();


                    yazmacaDegerAta("al", deger, 0);


                    deger = (Convert.ToInt64(_deger2) %
                             Convert.ToInt64(donusturDec(_deger1))).ToString();

                    yazmacaDegerAta("ah", deger, 0);
                }
                else
                {
                    deger = (Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))) /
                             Convert.ToInt64(donusturDec(_deger1))).ToString();
                    yazmacaDegerAta("ax", deger, 1);

                    deger = (Convert.ToInt64(_deger2) %
                             Convert.ToInt64(donusturDec(_deger1))).ToString();
                    yazmacaDegerAta("dx", deger, 1);
                }
            }
        }

        void mul()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }


            if (hatasiz == true && (Convert.ToInt64(donusturDec(_deger1)) < 0))
            {
                hatasiz = false;
                bilgiLabel.Text = "İşaretli sayılar için bu komut çalışmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            if (hatasiz == true)
            {
                if (_bit1 == 0)
                {
                    deger = (Convert.ToInt64(donusturDec(al.Text.Substring(3, 3))) *
                             Convert.ToInt64(donusturDec(_deger1))).ToString();

                    yazmacaDegerAta("ax", deger, 1);
                }
                else
                {
                    deger = (Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))) *
                             Convert.ToInt64(donusturDec(_deger1))).ToString();
                    yazmacaDegerAta("dx", deger, 1);
                }
            }
        }

        void imul()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }


            if (hatasiz == true)
            {
                if (_bit1 == 0)
                {
                    deger = (Convert.ToInt64(donusturDec(al.Text.Substring(3, 3))) *
                             Convert.ToInt64(donusturDec(_deger1))).ToString();

                    yazmacaDegerAta("ax", deger, 1);
                }
                else
                {
                    deger = (Convert.ToInt64(donusturDec(ax.Text.Substring(3, 5))) *
                             Convert.ToInt64(donusturDec(_deger1))).ToString();
                    yazmacaDegerAta("dx", deger, 1);
                }
            }
        }

        void cmp()
        {
            // ---- hatalar -----//
            if (_kontrol1 == true && _kontrol2 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler geçersizdir";
                labelSifirla();
            }

            if (hatasiz == true && _durum1 == 3 && _durum2 == 3)
            {
                hatasiz = false;
                bilgiLabel.Text = "Adresten adrese toplama olmaz";
                labelSifirla();
            }
            else
            {
                if (hatasiz == true)
                {
                    hatasiz = true;
                }
            }


            if (hatasiz == true)
            {
                if (hatasiz == true)
                {
                    if (_bit1 > _bit2)
                    {
                        _bit1 = 1;
                    }
                    else
                    {
                        if (_bit1 == _bit2)
                        {
                        }
                        else
                        {
                            _bit1 = 0;
                        }
                    }

                    _deger1 = donusturDec(_deger1);
                    _deger2 = donusturDec(_deger2);
                    deger = (Convert.ToInt64(_deger1) - Convert.ToInt64(_deger2)).ToString();

                    if (Convert.ToInt64(deger) > 0)
                    {
                        bilgiLabel.Text = $"{deger1Text.Text} > {deger2Text.Text}";
                        labelSifirla();
                    }

                    if (Convert.ToInt64(deger) < 0)
                    {
                        bilgiLabel.Text = $"{deger1Text.Text} < {deger2Text.Text}";
                        labelSifirla();
                        bS.Text = "1";
                    }

                    if (Convert.ToInt64(deger) == 0)
                    {
                        bilgiLabel.Text = $"{deger1Text.Text} = {deger2Text.Text}";
                        labelSifirla();
                        bZ.Text = "1";
                    }
                }
            }
        }


        private int _basamakTut;
        private string sifirEkle;

        void or()
        {
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                hatasiz = false;
            }

            if (hatasiz == true)
            {
                /*  _deger1 = Convert.ToString(int.Parse(donusturDec(_deger1)), 2);
                _deger2 = Convert.ToString(int.Parse(donusturDec(_deger2)), 2);


                if (_bit1 == 1 || _bit2 == 1)
                {
                    if (_deger1.Length < 16)
                    {
                        _basamakTut = 16 - _deger1.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger1 = sifirEkle + _deger1;
                    }

                    sifirEkle = "";

                    if (_deger2.Length < 16)
                    {
                        _basamakTut = 16 - _deger2.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger2 = sifirEkle + _deger2;
                    }
                }
                else
                {
                    if (_deger1.Length < 8)
                    {
                        _basamakTut = 8 - _deger1.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger1 = sifirEkle + _deger1 + "b";
                    }

                    sifirEkle = "";

                    if (_deger2.Length < 8)
                    {
                        _basamakTut = 8 - _deger2.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger2 = sifirEkle + _deger2 + "b";
                    }
                }*/
                _basamakTut = 0;
                sifirEkle = "";


                _deger1 = binCon(_deger1);
                _deger2 = binCon(_deger2);

                _deger1 = bitle(_deger1, _bit1);
                _deger2 = bitle(_deger2, _bit2);

                if (_bit1 == 1 || _bit2 == 1)
                {
                    if (_bit1 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger1.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger1 = sifirEkle + _deger1;
                    }

                    if (_bit2 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger2.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger2 = sifirEkle + _deger2;
                    }
                }


                deger = "";
                for (int i = 0; i < _deger1.Length; i++)
                {
                    if (_deger1[i] == '1' || _deger2[i] == '1')
                    {
                        deger += "1";
                    }
                    else
                    {
                        deger += "0";
                    }
                }


                if (_bit1 == 0 && deger.Length > 8)
                {
                    deger = deger.Substring(deger.Length - 8) + "b";
                }
                else
                {
                    deger = deger + "b";
                }

                deger = donusturDec(deger);


                sonuc(deger);
            }
        }

        void and()
        {
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                hatasiz = false;
            }

            if (hatasiz == true)
            {
                _basamakTut = 0;
                sifirEkle = "";

                _basamakTut = 0;
                sifirEkle = "";


                _deger1 = binCon(_deger1);
                _deger2 = binCon(_deger2);

                _deger1 = bitle(_deger1, _bit1);
                _deger2 = bitle(_deger2, _bit2);

                if (_bit1 == 1 || _bit2 == 1)
                {
                    if (_bit1 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger1.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger1 = sifirEkle + _deger1;
                    }

                    if (_bit2 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger2.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger2 = sifirEkle + _deger2;
                    }
                }


                deger = "";
                for (int i = 0; i < _deger1.Length; i++)
                {
                    if (_deger1[i] == '1' && _deger2[i] == '1')
                    {
                        deger += "1";
                    }
                    else
                    {
                        deger += "0";
                    }
                }


                if (_bit1 == 0 && deger.Length > 8)
                {
                    deger = deger.Substring(deger.Length - 8) + "b";
                }
                else
                {
                    deger = deger + "b";
                }

                deger = donusturDec(deger);
                sonuc(deger);
            }
        }

        void xor()
        {
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                hatasiz = false;
            }

            if (hatasiz == true)
            {
                _basamakTut = 0;
                sifirEkle = "";

                _basamakTut = 0;
                sifirEkle = "";


                _deger1 = binCon(_deger1);
                _deger2 = binCon(_deger2);

                _deger1 = bitle(_deger1, _bit1);
                _deger2 = bitle(_deger2, _bit2);

                if (_bit1 == 1 || _bit2 == 1)
                {
                    if (_bit1 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger1.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger1 = sifirEkle + _deger1;
                    }

                    if (_bit2 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger2.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger2 = sifirEkle + _deger2;
                    }
                }


                deger = "";
                for (int i = 0; i < _deger1.Length; i++)
                {
                    if (_deger1[i] != _deger2[i])
                    {
                        deger += "1";
                    }
                    else
                    {
                        deger += "0";
                    }
                }


                if (_bit1 == 0 && deger.Length > 8)
                {
                    deger = deger.Substring(deger.Length - 8) + "b";
                }
                else
                {
                    deger = deger + "b";
                }

                deger = donusturDec(deger);
                sonuc(deger);
            }
        }

        void test()
        {
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                hatasiz = false;
            }

            if (hatasiz == true)
            {
                _basamakTut = 0;
                sifirEkle = "";

                _basamakTut = 0;
                sifirEkle = "";


                _deger1 = binCon(_deger1);
                _deger2 = binCon(_deger2);

                _deger1 = bitle(_deger1, _bit1);
                _deger2 = bitle(_deger2, _bit2);

                if (_bit1 == 1 || _bit2 == 1)
                {
                    if (_bit1 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger1.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger1 = sifirEkle + _deger1;
                    }

                    if (_bit2 == 0)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _deger2.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _deger2 = sifirEkle + _deger2;
                    }
                }


                deger = "";
                for (int i = 0; i < _deger1.Length; i++)
                {
                    if (_deger1[i] == '1' && _deger2[i] == '1')
                    {
                        deger += "1";
                    }
                    else
                    {
                        deger += "0";
                    }
                }


                if (_bit1 == 0 && deger.Length > 8)
                {
                    deger = deger.Substring(deger.Length - 8) + "b";
                }
                else
                {
                    deger = deger + "b";
                }


                _bitSayisi = "";
                birleriSay = 0;

                for (int i = 0; i < deger.Length - 1; i++)
                {
                    if (deger[i] == '1')
                    {
                        birleriSay++;
                    }
                }

                if (birleriSay != 0 && birleriSay % 2 == 0)
                {
                    bPP.Text = "1";
                }
                else
                {
                    bPP.Text = "0";
                }


                deger = donusturDec(deger);
                bilgiLabel.Text = "Geçici sonuç: " + deger;
                labelSifirla();
                if (Convert.ToInt64(donusturDec(deger)) == 0)
                {
                    bZ.Text = "1";
                }
                else
                {
                    bZ.Text = "1";
                }
                if (Convert.ToInt64(donusturDec(deger)) < 0)
                {
                    bS.Text = "1";
                }
                else
                {
                    bS.Text = "1";
                }
            }
        }


        private List<stack> _ssDeger = new List<stack>();

        void push()
        {
            hatasiz = false;
            if (_kontrol1)
            {
                hatasiz = true;
            }

            if (hatasiz)
            {
                _deger1 = (Convert.ToInt64(donusturDec(_deger1))).ToString();
                stack s = new stack();
                s.deger = _deger1;

                if (_ssDeger.Count == 0)
                {
                    s.adres = dataSegment[0];
                }
                else
                {
                    for (int i = 0; i < dataSegment.Count; i++)
                    {
                        if (_ssDeger[_ssDeger.Count - 1].adres.Equals(dataSegment[i]))
                        {
                            s.adres = dataSegment[i + 2];
                            break;
                        }
                    }
                }

                _ssDeger.Add(s);
            }
        }

        void pop()
        {
            hatasiz = false;
            if (_kontrol1 == true)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Geçersiz Değişken";
                labelSifirla();
            }

            if (_bit1 != 1)
            {
                hatasiz = false;

                if (_durum1 == 3)
                {
                    hatasiz = true;
                }
                else
                {
                    bilgiLabel.Text = "8 bitlik değerler ile POP işlemi yapılamaz";
                    labelSifirla();
                }
            }

            if (_ssDeger.Count == 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Bellekte değer yok";
                labelSifirla();
            }


            if (hatasiz)
            {
                if (_durum1 == 0)
                {
                    yazmacaDegerAta(deger1Text.Text, _ssDeger[_ssDeger.Count - 1].deger, _bit1);
                }

                if (_durum1 == 1)
                {
                    foreach (var i in degiskenListesi)
                    {
                        if (deger1Text.Text.Equals(i.degiskenAdi))
                        {
                            i.degiskenDegeri = _ssDeger[_ssDeger.Count - 1].deger;
                        }
                    }
                }

                if (_durum1 == 2)
                {
                    bilgiLabel.Text = "Değere POP uygulanmaz";
                    labelSifirla();
                }

                if (_durum1 == 3)
                {
                    adresDegeriAta(adres1, _ssDeger[_ssDeger.Count - 1].deger, _bit1);
                }

                _ssDeger.Remove(_ssDeger[_ssDeger.Count - 1]);
            }
            else
            {
            }
        }

        void not()
        {
            hatasiz = false;
            if (_kontrol1)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değer hatalı";
                labelSifirla();
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);
                deger = "";
                for (int i = 0; i < _deger1.Length; i++)
                {
                    if (_deger1[i] == '1')
                    {
                        deger = deger + "0";
                    }
                    else
                    {
                        deger = deger + "1";
                    }
                }

                deger = deger + "b";

                sonuc(donusturDec(deger));
            }
        }

        void neg()
        {
            hatasiz = false;
            if (_kontrol1)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değer hatalı";
                labelSifirla();
            }

            if (hatasiz)
            {
                if (Convert.ToInt64(donusturDec(_deger1)) > 0)
                {
                    bS.Text = "1";
                }

                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);
                deger = "";
                for (int i = 0; i < _deger1.Length; i++)
                {
                    if (_deger1[i] == '1')
                    {
                        deger = deger + "0";
                    }
                    else
                    {
                        deger = deger + "1";
                    }
                }

                deger = deger + "b";
                deger = (Convert.ToInt64(donusturDec(deger)) + 1).ToString();

                sonuc(donusturDec(deger));
            }
        }

        private int _rint;

        void shl()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                labelSifirla();
                hatasiz = false;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
                labelSifirla();
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);

                _rint = int.Parse(donusturDec(_deger1 + "b"));


                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    bC.Text = _deger1[0].ToString();
                    _r = "0";
                    _deger1 = _deger1.Substring(1, _deger1.Length - 1) + _r;
                }

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    if (_deger1[i] == '1')
                    {
                        bC.Text = "1";
                    }
                }


                sonuc(donusturDec(_deger1 + "b"));
            }
        }

        void shr()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                labelSifirla();
                hatasiz = false;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
                labelSifirla();
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);
                _rint = int.Parse(donusturDec(_deger1 + "b"));


                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    _rint = _rint / 2;
                }

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    if (_deger1[_deger1.Length - 1 - i] == '1')
                    {
                        bC.Text = "1";
                    }
                    else
                    {
                        bC.Text = "1";
                    }
                }


                sonuc(_rint.ToString());
            }
        }

        void sal()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
                labelSifirla();
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                labelSifirla();
                hatasiz = false;
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);

                _rint = int.Parse(donusturDec(_deger1 + "b"));


                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    bC.Text = _deger1[0].ToString();
                    _r = bC.Text;
                    _deger1 = _deger1.Substring(1, _deger1.Length - 1) + _r;
                }

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    if (_deger1[i] == '1')
                    {
                        bC.Text = "1";
                        break;
                    }
                }


                sonuc(_rint.ToString());
            }
        }

        void sar()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                labelSifirla();
                hatasiz = false;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
                labelSifirla();
            }

            if (hatasiz)
            {
                if (int.Parse(donusturDec(_deger1)) < 0)
                {
                    bS.Text = "1";
                }

                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);
                _rint = int.Parse(donusturDec(_deger1 + "b"));


                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    _rint = _rint / 2;
                }

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    if (_deger1[_deger1.Length - 1 - i] == '1')
                    {
                        bC.Text = "1";
                    }
                    else
                    {
                        bC.Text = "1";
                    }
                }


                if (bS.Text.Equals("1"))
                {
                    sonuc(("-" + _rint.ToString()).ToString());
                }
                else
                {
                    sonuc(_rint.ToString());
                }
            }
        }

        private string _r;

        void rcl()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                labelSifirla();

                hatasiz = false;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
                labelSifirla();
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    _r = bC.Text;
                    bC.Text = _deger1[0].ToString();
                    _deger1 = _deger1.Substring(1, _deger1.Length - 1) + _r;
                }

                ;

                sonuc(donusturDec(_deger1 + "b"));
            }
        }

        void rcr()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                labelSifirla();
                hatasiz = false;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
                labelSifirla();
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    _r = bC.Text;
                    bC.Text = _deger1[_deger1.Length - 1].ToString();
                    _deger1 = _r + _deger1.Substring(0, _deger1.Length - 1);
                }


                sonuc(donusturDec(_deger1 + "b"));
            }
        }

        void ror()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                labelSifirla();
                hatasiz = false;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
                labelSifirla();
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    bC.Text = _deger1[_deger1.Length - 1].ToString();
                    _r = bC.Text;
                    _deger1 = _r + _deger1.Substring(0, _deger1.Length - 1);
                }


                sonuc(donusturDec(_deger1 + "b"));
            }
        }

        void rol()
        {
            hatasiz = false;
            if (_kontrol1 && _kontrol2)
            {
                hatasiz = true;
            }
            else
            {
                bilgiLabel.Text = "Değerler hatalıdır";
                hatasiz = false;
            }

            if (Convert.ToInt64(donusturDec(_deger2)) < 0)
            {
                hatasiz = false;
                bilgiLabel.Text = "Shift edileceği sayı negatif olamaz";
            }

            if (hatasiz)
            {
                _deger1 = binCon(_deger1);
                _deger1 = bitle(_deger1, _bit1);

                for (int i = 0; i < int.Parse(donusturDec(_deger2)); i++)
                {
                    bC.Text = _deger1[0].ToString();
                    _r = bC.Text;
                    _deger1 = _deger1.Substring(1, _deger1.Length - 1) + _r;
                }


                sonuc(donusturDec(_deger1 + "b"));
            }
        }

        private int birleriSay;
        private string _bitSayisi;
        void sonuc(string _deger)
        {
            deger = _deger;
            
            _bitSayisi = binCon(int.Parse(donusturDec(deger)).ToString());
            birleriSay = 0;
           
            for (int i = 0; i < _bitSayisi.Length; i++)
            {
                if (_bitSayisi[i] == '1')
                { 
                    birleriSay++;
                }
            }

            if (birleriSay != 0 && birleriSay % 2 == 0)
            {
                bPP.Text = "1";
            }
            else
            {
                bPP.Text = "0";
            }
            if (int.Parse(donusturDec(deger)) < 0)
            {
                bS.Text = "1";
            }else
            {
                bS.Text = "0";
            }

            if (_bit1 == 0)
            {
                if (Convert.ToInt64(donusturDec(deger)) < -128)
                {
                    deger = "-128";
                    bC.Text = "1";
                }else
                {
                    bC.Text = "0";
                }

                if (Convert.ToInt64(donusturDec(deger)) > 255)
                {
                    deger = "255";
                    bC.Text = "1";
                }
                else
                {
                    bC.Text = "0";
                }
            }
            else
            {
                if (Convert.ToInt64(donusturDec(deger)) > 65535)
                {
                    deger = "65535";
                    bC.Text = "1";
                }
                else
                {
                    bC.Text = "0";
                }

                if (Convert.ToInt64(donusturDec(deger)) < -32768)
                {
                    deger = "-32768";
                    bC.Text = "1";
                }
                else
                {
                    bC.Text = "0";
                }
            }


            if (Convert.ToInt64(donusturDec(deger)) == 0)
            {
                bZ.Text = "1";
            }else
            {
                bZ.Text = "0";
            }

            if (_durum1 == 0)
            {
                yazmacaDegerAta(deger1Text.Text, deger, _bit1);
            }

            if (_durum1 == 1)
            {
                foreach (var i in degiskenListesi)
                {
                    if (i.degiskenAdi.Equals(deger1Text.Text))
                    {
                        i.degiskenDegeri = deger;
                        break;
                    }
                }
            }

            if (_durum1 == 2)
            {
            }

            if (_durum1 == 3)
            {
                if (_bit1 != 0)
                {
                    bilgiLabel.Text = "Adresin kapasitesini aştığı için işleme izin verilmiyor";
                    labelSifirla();
                }
                else
                {
                    adresDegeriAta(adres1, deger, _bit1);
                }
            }

            bilgiLabel.Text = "Sonuc: " + deger;
            labelSifirla();
            
        }

        void sonuc2(string _deger)
        {
            if (_durum1 == 0)
            {
                yazmacaDegerAta(deger1Text.Text, _deger, _bit1);
            }

            if (_durum1 == 1)
            {
                foreach (var i in degiskenListesi)
                {
                    if (i.degiskenAdi.Equals(deger1Text.Text))
                    {
                        i.degiskenDegeri = _deger;
                        break;
                    }
                }
            }

            if (_durum1 == 2)
            {
            }

            if (_durum1 == 3)
            {
                if (_bit2 != 0)
                {
                    bilgiLabel.Text = "Adresin kapasitesini aştığı için işleme izin verilmiyor";
                    labelSifirla();
                }
                else
                {
                    adresDegeriAta(adres1, _deger, _bit1);
                }
            }
        }

        void sonuc3(string _deger)
        {
            if (_durum2 == 0)
            {
                yazmacaDegerAta(deger2Text.Text, _deger, _bit2);
            }

            if (_durum2 == 1)
            {
                foreach (var i in degiskenListesi)
                {
                    if (i.degiskenAdi.Equals(deger2Text.Text))
                    {
                        i.degiskenDegeri = _deger;
                        break;
                    }
                }
            }

            if (_durum2 == 2)
            {
                bilgiLabel.Text = _deger;
            }

            if (_durum2 == 3)
            {
                if (_bit2 != 0)
                {
                    bilgiLabel.Text = "Adresin kapasitesini aştığı için işleme izin verilmiyor";
                    labelSifirla();
                }
                else
                {
                    adresDegeriAta(adres2, _deger, _bit2);
                }
            }
        }


        void yazmacaDegerAta(string _yazmac, string _deger, int _bit)
        {
            if (_bit == 1 && (Convert.ToInt64(_deger) >= 65536 || Convert.ToInt64(_deger) < -32768))
            {
                if (Convert.ToInt64(_deger) >= 65536)
                {
                    _deger = (Convert.ToInt64(_deger) - 65536).ToString();
                }
                else
                {
                    _deger = ((-1) * (Convert.ToInt64(_deger) + 32768)).ToString();
                }
            }
            else
            {
                if (_bit == 0)
                {
                    if (Convert.ToInt64(_deger) >= 256)
                    {
                        _deger = (Convert.ToInt64(_deger) - 256).ToString();
                    }

                    if (Convert.ToInt64(_deger) < -128)
                    {
                        _deger = ((-1) * (Convert.ToInt64(_deger) + 128)).ToString();
                    }
                }
            }

            yAdi.Text = _yazmac;
            yDegeriBox.Text = _deger;
            yDegistir_Click(null, EventArgs.Empty);
            yAdi.Text = "";
            yDegeriBox.Text = "";
        }

        private bool tasmaOldu;

        string tasmaKontrol(string _deger, int _bit)
        {
            tasmaOldu = false;
            if (_bit == 1 && (Convert.ToInt64(_deger) >= 65536 || Convert.ToInt64(_deger) < -32768))
            {
                if (Convert.ToInt64(_deger) >= 65536)
                {
                    _deger = (Convert.ToInt64(_deger) - 65536).ToString();
                    tasmaOldu = true;
                }
                else
                {
                    _deger = ((-1) * (Convert.ToInt64(_deger) + 32768)).ToString();
                    tasmaOldu = true;
                }
            }
            else
            {
                if (_bit == 0)
                {
                    if (Convert.ToInt64(_deger) >= 256)
                    {
                        _deger = (Convert.ToInt64(_deger) - 256).ToString();
                        tasmaOldu = true;
                    }

                    if (Convert.ToInt64(_deger) < -128)
                    {
                        _deger = ((-1) * (Convert.ToInt64(_deger) + 128)).ToString();
                        tasmaOldu = true;
                    }
                }
            }


            return _deger;
        }


        void carryBayragi(string _deger, int _bit)
        {
            if (_bit == 0)
            {
                if (Convert.ToInt64(_deger) < 255 && Convert.ToInt64(_deger) >= -128)
                {
                }
                else
                {
                    bC.Text = 1.ToString();
                }
            }

            if (_bit == 1)
            {
                if (Convert.ToInt64(_deger) < 65536 && Convert.ToInt64(_deger) >= -32768)
                {
                }
                else
                {
                    bC.Text = 1.ToString();
                }
            }

            if (tasmaOldu == true)
            {
                bC.Text = "1";
            }
        }


        string donusturDec(string _deger)
        {
            if (_deger[_deger.Length - 1] == 'b')
            {
                _deger = BtoDec(_deger.Substring(0, _deger.Length - 1));
            }

            if (_deger[_deger.Length - 1] == 'h')
            {
                _deger = HtoDec(_deger.Substring(0, _deger.Length - 1));
            }

            return _deger;
        }


        private bool _olabilir;

        private void adresDegeriAta(string _adres, string _deger, int _bit)
        {
            for (int i = 0; i < dataSegment.Count; i++)
            {
                _olabilir = false;
                _adresVar = false;
                if (_adres.Equals(dataSegment[i]))
                {
                    if (adresDegiskenBul(_adres) == true)
                    {
                        bilgiLabel.Text = "Bu adrese yönelik işlem yapılamaz";
                        labelSifirla();
                        break;
                    }
                    else
                    {
                        if (i != 0)
                        {
                            if (adresDegiskenBul(dataSegment[i - 1]) == true)
                            {
                                if (_adressBiti.Equals("8") || _adressBiti.Equals(""))
                                {
                                }
                                else
                                {
                                    bilgiLabel.Text = "Bu adrese yönelik işlem yapılamaz";
                                    labelSifirla();
                                    break;
                                }
                            }
                        }

                        if (adresDegiskenBul(dataSegment[i + 1]) == true)
                        {
                            _olabilir = true;
                        }

                        degisken d = new degisken();
                        d.degiskenAdi = "(tanimsiz)";
                        d.degiskenDegeri = _deger;
                        d.degiskenAdresi = _adres;
                        if (_bit == 0)
                        {
                            d.degiskenBiti = "8";
                        }
                        else
                        {
                            d.degiskenBiti = "16";
                        }


                        if (_olabilir == true)
                        {
                            if (_bit == 0)
                            {
                                degiskenListesi.Add(d);
                                break;
                            }
                            else
                            {
                                bilgiLabel.Text = "Korumalı alan etki ettiği için işlem yapılmaz.";
                                labelSifirla();
                                break;
                            }
                        }
                        else
                        {
                            degiskenListesi.Add(d);
                            break;
                        }
                    }
                }
            }
        }


        private bool _adresVar;
        private string _adressBiti;

        bool adresDegiskenBul(string _adres)
        {
            _adresVar = false;
            _adressBiti = "";

            foreach (var i in degiskenListesi)
            {
                if (i.degiskenAdresi.Equals(_adres))
                {
                    _adressBiti = i.degiskenBiti;
                    _adresVar = true;
                    if (i.degiskenAdi.Equals("(tanimsiz)"))
                    {
                        degiskenListesi.Remove(i);
                        _adresVar = false;
                        _adressBiti = "";
                    }

                    break;
                }
            }


            return _adresVar;
        }


        string BtoDec(string _deger)
        {
            return Convert.ToInt64(_deger, 2).ToString();
        }

        string HtoDec(string _deger)
        {
            return Convert.ToInt64(_deger, 16).ToString();
        }

        private Label l;

        private Label yazmacBul(string _deger)
        {
            l = null;
            foreach (var i in yazmacListesi)
            {
                if (i.Name.ToUpper().Equals(_deger.ToUpper()))
                {
                    l = i;
                }
                else
                {
                    l = null;
                }
            }

            return l;
        }


        private bool mixedSize;
        private bool ikiDeger;
        private bool tekDeger;
        private bool m_m;

        private void hatalar()
        {
            mixedSize = false;
            m_m = false;

            if (_bit1 == 0 && _bit2 == 1)
            {
                mixedSize = true;
            }

            if (_durum1 == 3 && _durum2 == 3)
            {
                m_m = true;
            }
        }

        private bool degiskenVarMi;
        private bool _16Bit;


        bool degiskenBul(string adres)
        {
            _16Bit = false;
            degiskenVarMi = false;
            foreach (var i in degiskenListesi)
            {
                if (adres.Equals(i.degiskenAdresi))
                {
                    if (i.degiskenBiti.Equals("16"))
                    {
                        _16Bit = true;
                    }

                    if (i.degiskenAdi == "(tanimsiz)")
                    {
                        degiskenVarMi = false;
                    }
                    else
                    {
                        degiskenVarMi = true;
                    }
                }
            }

            return degiskenVarMi;
        }


        #region Kontrol Birimi

        private bool gecerliDeger = false;
        private bool _gecerliDeger = false;
        private string deger;
        private System.Windows.Forms.Label deger1Lab;
        private string deger2;

        private string yazmac;
        private bool _isString;

        bool kontrol(TextBox _deger)
        {
            deger = "";
            gecerliDeger = false;
            //-----Yazmaç Kontrolü-----// 
            if (gecerliDeger == false)
            {
                gecerliDeger = yazmacMi(_deger.Text);
                if (gecerliDeger == true)
                {
                    deger = yazmacDegeriAl(_deger.Text);
                    durum = 0;
                }
            }

            //-----Değişken Kontrolü----//
            if (gecerliDeger == false)
            {
                if (_deger.Text[_deger.Text.Length - 1] != 'b' && _deger.Text[_deger.Text.Length - 1] != 'h')
                {
                    gecerliDeger = degiskenKontrol(_deger.Text);
                }

                if (gecerliDeger == true)
                {
                    deger = degiskenAta(_deger.Text);
                    durum = 1;
                    if (_isString)
                    {
                        durum = 10;
                    }
                }
            }

            // ---- Değer Kontrolü ----- //
            if (gecerliDeger == false)
            {
                gecerliDeger = degerMi(_deger.Text);


                if (gecerliDeger == true)
                {
                    durum = 2;
                    deger = _deger.Text;
                }
            }


            //----Adres Kontrolü-------//

            if (_deger.Text.Length > 2)
            {
                if (_deger.Text.Substring(1, _deger.Text.Length - 2).Length > 0)
                {
                    if (gecerliDeger == false && (_deger.Text[0] == '[' && _deger.Text[_deger.Text.Length - 1] == ']'))
                    {
                        gecerliDeger = AdresMi(_deger.Text.Substring(1, _deger.Text.Length - 2));
                        durum = 3;
                    }
                }
            }

            if (gecerliDeger == false && (_deger.Text[0] == '\'' && _deger.Text[_deger.Text.Length - 1] == '\''))
            {
                if (_deger.Text.Substring(1, 1).Length == 1)
                {
                    deger = ((int)_deger.Text[1]).ToString();
                    durum = 2;
                    bit = 0;
                    gecerliDeger = true;
                }
            }

            return gecerliDeger;
        }

        #endregion


        #region yazmacKontrolü

        bool yazmacMi(string _deger)
        {
            _gecerliDeger = false;

            foreach (var i in yazmacListesi)
            {
                if (_deger.ToUpper().Equals(i.Name.ToUpper()))
                {
                    _gecerliDeger = true;
                    break;
                }
            }

            return _gecerliDeger;
        }

        #endregion

        #region deger kontrolü

        private TextBox boxDeger = new TextBox();

        bool degerMi(string _deger)
        {
            boxDeger.Text = _deger;
            //binary
            if (boxDeger.Text[boxDeger.Text.Length - 1] == 'b')
            {
                _gecerliDeger = binary(boxDeger);
            }

            //hex
            if (_gecerliDeger == false && boxDeger.Text[boxDeger.Text.Length - 1] == 'h')
            {
                _gecerliDeger = hex(boxDeger);
                ;
            }

            //dec
            if (_gecerliDeger == false && boxDeger.Text[boxDeger.Text.Length - 1] != 'b' &&
                boxDeger.Text[boxDeger.Text.Length - 1] != 'h')
            {
                _gecerliDeger = dec(boxDeger);
                if (_gecerliDeger == true)
                {
                }
            }


            return _gecerliDeger;
        }

        #endregion

        #region Yazmaç Degeri al

        string yazmacDegeriAl(string _deger)
        {
            deger = "";
            foreach (var i in yazmacListesi)
            {
                if (i.Name.ToUpper().Equals(_deger.ToUpper()))
                {
                    if (i.Name.ToUpper()[1] == 'X' ||
                        i.Name.ToUpper()[1] == 'J' ||
                        i.Name.ToUpper()[1] == 'P')
                    {
                        deger = i.Text.Substring(3, 5);
                        bit = 1;
                    }
                    else
                    {
                        deger = i.Text.Substring(3, 3);
                        bit = 0;
                    }

                    break;
                }
            }

            return deger;
        }

        #endregion

        #region degiskenKontrol

        bool degiskenKontrol(string _deger)
        {
            _gecerliDeger = false;

            foreach (var i in degiskenListesi)
            {
                if (i.degiskenAdi.Equals(_deger))
                {
                    _gecerliDeger = true;
                    if (i._string)
                    {
                        _isString = i._string;
                    }

                    break;
                }
            }

            return _gecerliDeger;
        }

        #endregion

        #region degiskenAta

        string degiskenAta(string _deger)
        {
            deger = "";
            foreach (var i in degiskenListesi)
            {
                if (i.degiskenAdi.Equals(_deger))
                {
                    deger = i.degiskenDegeri;
                    if (i.degiskenBiti.Equals("8"))
                    {
                        bit = 0;
                    }
                    else
                    {
                        bit = 1;
                    }
                }
            }

            return deger;
        }

        #endregion

        #region Adres Kontrolü

        private string geciciDeger;

        bool AdresMi(string _deger)
        {
            _gecerliDeger = false;
            // 1. Yazmaç mı?
            if (_gecerliDeger == false)
            {
                _gecerliDeger = yazmacMi(_deger);
                if (_gecerliDeger == true)
                {
                    deger = yazmacDegeriAl(_deger);

                    if (deger.Length > 3)
                    {
                        deger = degerAl(deger, "yazmac");
                        bit = 0;
                    }
                    else
                    {
                        deger = "00" + deger;
                        deger = degerAl(deger, "yazmac");
                        bit = 0;
                    }
                }
            }

            // 2. Değişken mi?
            if (_gecerliDeger == false)
            {
                _gecerliDeger = degiskenKontrol(_deger);
                if (_gecerliDeger == true)
                {
                    deger = degiskenAta(_deger);
                    deger = donusumler(deger, "high") + donusumler(deger, "low");
                    deger = deger.Substring(0, 2) + deger.Substring(3, 3);
                    deger = degerAl(deger.ToLower(), "yazmac");
                }
            }

            // 3. değer mi?
            if (_gecerliDeger == false)
            {
                _gecerliDeger = degerMi(_deger);
                if (_gecerliDeger == true)
                {
                    deger = donusumler(_deger, "high") + donusumler(_deger, "low");
                    deger = deger.Substring(0, 2) + deger.Substring(3, 3);
                    deger = degerAl(deger.ToLower(), "yazmac");
                    bit = 0;
                }
            }

            #region geçersiz yazmaçlar

            if (_deger.ToUpper().Equals("AX"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("AL"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("AH"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("CX"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("CL"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("CH"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("DX"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("DL"))
            {
                _gecerliDeger = false;
            }

            if (_deger.ToUpper().Equals("DH"))
            {
                _gecerliDeger = false;
            }

            #endregion


            return _gecerliDeger;
        }

        #endregion

        #region degerAl

        private bool _gececiDegerMi = false;
        private string adres;

        string degerAl(string _deger, string durum)
        {
            adres = _deger;
            // --- Yazmac ise ----///
            if (durum.Equals("yazmac"))
            {
                deger = "0";
                foreach (var i in degiskenListesi)
                {
                    if (_deger.Equals(i.degiskenAdresi))
                    {
                        if (i.degiskenBiti.Equals("8"))
                        {
                            deger = i.degiskenDegeri;

                            break;
                        }
                        else
                        {
                            if (i.degiskenBiti.Equals("16"))
                            {
                                deger = donusumler(i.degiskenDegeri, "low");

                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < dataSegment.Count; j++)
                        {
                            if (j != 0)
                            {
                                if (i.degiskenAdresi.Equals(dataSegment[j - 1]))
                                {
                                    if (i.degiskenBiti.Equals("8"))
                                    {
                                    }
                                    else
                                    {
                                        deger = donusumler(i.degiskenDegeri, "high");

                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //---- Değişken ise -----//


            return deger;
        }


        private string donusumluDeger = "";

        string donusumler(string _deger, string _bit)
        {
            donusumluDeger = "";
            if (_deger[_deger.Length - 1] == 'h')
            {
                if (_bit.Equals("high"))
                {
                    donusumluDeger = _deger.Substring(0, 2) + "h";
                }

                if (_bit.Equals("low"))
                {
                    donusumluDeger = _deger.Substring(2, 3);
                }
            }

            if (_deger[_deger.Length - 1] == 'b')
            {
                donusumluDeger = BinaryStringToHexString(_deger.Substring(0, _deger.Length - 2));
                if (_bit.Equals("low"))
                {
                    donusumluDeger = donusumluDeger.Substring(2, 3);
                }

                if (_bit.Equals("high"))
                {
                    donusumluDeger = donusumluDeger.Substring(0, 2) + "h";
                }
            }

            if (_deger[_deger.Length - 1] != 'b' && _deger[_deger.Length - 1] != 'h')
            {
                donusumluDeger = DectoHex2(_deger);
                if (_bit.Equals("low"))
                {
                    donusumluDeger = donusumluDeger.Substring(2, 3);
                }

                if (_bit.Equals("high"))
                {
                    donusumluDeger = donusumluDeger.Substring(0, 2) + "h";
                }
            }

            return donusumluDeger;
        }

        #endregion

        string DectoHex(string _deger)
        {
            a = "";
            a = int.Parse(_deger).ToString("X");

            if (a.Length == 0 || a.Length == 1 || a.Length == 2)
            {
                a = "00h";
            }


            if (a.Length == 3)
            {
                a = "0" + a.Substring(0, 1) + "h";
            }

            if (a.Length == 4)
            {
                a = a.Substring(0, 2) + "h";
            }


            return a;
        }

        private string a = "";

        string DectoHex2(string _deger)
        {
            a = "";
            a = int.Parse(_deger).ToString("X");

            if (a.Length == 1)
            {
                a = "000" + a + "h";
            }


            if (a.Length == 2)
            {
                a = "00" + a + "h";
            }


            if (a.Length == 3)
            {
                a = "0" + a + "h";
            }

            if (a.Length == 4)
            {
                a = a + "h";
            }


            return a;
        }


        public string BinaryStringToHexString(string binary)
        {
            string _result = "";
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);


            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            if (result.Length == 0)
            {
                _result = "0000h".ToLower();
            }

            if (result.Length == 1)
            {
                string a = "000" + result.ToString() + "h";
                _result = a.ToLower();
            }

            if (result.Length == 2)
            {
                string a = "00" + result.ToString() + "h";
                _result = a.ToLower();
            }

            if (result.Length == 3)
            {
                string a = "0" + result.ToString() + "h";
                _result = a.ToLower();
            }

            if (result.Length == 4)
            {
                string a = result.ToString() + "h";
                _result = a.ToLower();
            }

            return _result;
        }


        string bitleriAyir(degisken i)
        {
            if (i.degiskenDegeri[i.degiskenDegeri.Length - 1] == 'b')
            {
                if (i.degiskenDegeri.Length < 10)
                {
                    deger = i.degiskenDegeri;
                }
                else
                {
                    deger = i.degiskenDegeri.Substring(i.degiskenDegeri.Length - 9, 9);
                }
            }

            if (i.degiskenDegeri[i.degiskenDegeri.Length - 1] == 'h')
            {
                if (i.degiskenDegeri.Length < 4)
                {
                    deger = i.degiskenDegeri;
                }
                else
                {
                    deger = i.degiskenDegeri.Substring(i.degiskenDegeri.Length - 3, 3);
                }
            }

            if (i.degiskenDegeri[i.degiskenDegeri.Length - 1] != 'h' &&
                i.degiskenDegeri[i.degiskenDegeri.Length - 1] != 'b')
            {
                if (int.Parse(i.degiskenDegeri) < 256 && int.Parse(i.degiskenDegeri) >= -1)
                {
                    deger = i.degiskenDegeri;
                }
                else
                {
                    if (int.Parse(i.degiskenDegeri) > 0)
                    {
                        deger = 255.ToString();
                    }
                    else
                    {
                        deger = (-128).ToString();
                    }
                }
            }

            return deger;
        }


        private void segmentData_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < degiskenListesi.Count; i++)
            {
                if (segmentData.SelectedItem.ToString().Equals(degiskenListesi[i].degiskenAdresi))
                {
                    dsGercekAdres.Text = 0.ToString() + (degiskenListesi[i].degiskenAdresi);
                    dsDegiskenAdiText.Text = degiskenListesi[i].degiskenAdi;
                    dsDegiskenDegeriText.Text = degiskenListesi[i].degiskenDegeri;
                    dondurGelsin(dsDegiskenDegeriText.Text);
                    dsDegiskenBitiText.Text = degiskenListesi[i].degiskenBiti;
                    break;
                }
                else
                {
                    dsGercekAdres.Text = "";
                    dsDegiskenAdiText.Text = "";
                    dsDegiskenDegeriText.Text = "";
                    dsDegiskenBitiText.Text = "";
                }
            }
        }


        private void bit16_CheckedChanged(object sender, EventArgs e)
        {
            if (bit8.Checked == true)
            {
                bit8.Checked = false;
                bit16.Checked = true;
            }
        }

        private void bit8_CheckedChanged(object sender, EventArgs e)
        {
            if (bit16.Checked == true)
            {
                bit16.Checked = false;
                bit8.Checked = true;
            }
        }


        private void oto_CheckedChanged(object sender, EventArgs e)
        {
            if (oto.Checked)
            {
                dAdresText.Enabled = false;
            }
            else
            {
                dAdresText.Enabled = true;
            }
        }

        private bool _string;
        private bool dHataYok = false;
        private int dBit = 0;
        private bool dBool = false;
        bool dOto = false;
        List<string> adresler = new List<string>();
        private bool adresKontrol = false;

        private List<string> gAdres = new List<string>();
        private bool _degiskenHatasi;
        private bool _stringDeger;
        private string _s;
        private int _indisDeger;
        private bool adresYokDevam;

        private void dOlustur_Click(object sender, EventArgs e)
        {
            _indisDeger = 0;
            _stringDeger = false;
            _s = "";
            _degiskenHatasi = false;
            degisken d = new degisken();

            foreach (var i in degiskenListesi)
            {
                if (dAdiText.Text.Equals(i.degiskenAdi))
                {
                    _degiskenHatasi = true;
                    dHata.Text = "Böyle bir değişken mevcuttur";
                    labelSifirla();
                }
            }

            if (!_degiskenHatasi)
            {
                d.degiskenAdi = dAdiText.Text;

                if (dDegeriText.Text[0] == '"' && dDegeriText.Text[dDegeriText.Text.Length - 1] == '"')
                {
                    _stringDeger = true;
                    d._string = true;
                    d._tam = _s;

                    _s = dDegeriText.Text.Substring(1, dDegeriText.Text.Length - 2);
                }
                else
                {
                    d.degiskenDegeri = donusturDec(dDegeriText.Text);

                    if (bit8.Checked)
                    {
                        if (Convert.ToInt64(d.degiskenDegeri) > 255 || Convert.ToInt64(d.degiskenDegeri) < -128)
                        {
                            dHata.Text = "8 bitlik değişken değildir";
                            labelSifirla();
                            _degiskenHatasi = true;
                        }
                        else
                        {
                            d.degiskenBiti = "8";
                        }
                    }
                    else
                    {
                        d.degiskenBiti = "16";
                    }
                }
            }

            if (_stringDeger)
            {
                if (bit8.Checked)
                {
                    d.degiskenBiti = "8";
                }
                else
                {
                    d.degiskenBiti = "16";
                }

                d.degiskenDegeri = _s;
            }

            int _sayac = 0;
            int degiskenBit = 0;
            if (!_degiskenHatasi && oto.Checked)
            {
                for (int i = 0; i < dataSegment.Count; i++)
                {
                    if (d.degiskenBiti.Equals("16"))
                    {
                        degiskenBit = 1;
                    }

                    _adresVar = false;
                    degiskenDegeriAta(d.degiskenAdi, dataSegment[i], d.degiskenDegeri, degiskenBit);
                    if (!_adresVar)
                    {
                        degiskenListBox.Items.Add(d.degiskenAdi);
                        dHata.Text = "";
                        labelSifirla();
                        break;
                    }
                }
            }

            if (!_degiskenHatasi && !oto.Checked)
            {
                if (dAdresText.Text.Length == 4 && dAdresText.Text[dAdresText.Text.Length - 1] == 'h')
                {
                    dHata.Text = "adress 4 basamaklı, hexadecimal olmalıdır" + " Örnek: 0000h";
                    labelSifirla();
                    _degiskenHatasi = true;
                }

                if (!_degiskenHatasi)
                {
                    if (!hex(dAdresText))
                    {
                        dHata.Text = "Geçersiz hexadecimal sayı" + " Örnek: 0000h";
                        labelSifirla();
                        _degiskenHatasi = true;
                    }
                }

                if (_stringDeger)
                {
                    _degiskenHatasi = true;
                    dHata.Text = "String tanımları otomatik olmalıdır";
                    labelSifirla();
                    _stringDeger = false;
                }

                if (!_degiskenHatasi)

                    if (!_degiskenHatasi)
                    {
                        if (d.degiskenBiti.Equals("16"))
                        {
                            degiskenBit = 1;
                        }

                        _adresVar = false;
                        degiskenDegeriAta(d.degiskenAdi, dAdresText.Text, d.degiskenDegeri, degiskenBit);
                        if (!_adresVar)
                        {
                            degiskenListBox.Items.Add(d.degiskenAdi);
                            dHata.Text = "";
                        }
                    }
            }

            if (_stringDeger)
            {
                string gBit = d.degiskenBiti;
                dHata.Text = d.degiskenAdresi;

                _indisDeger = 0;
                bool adresSil = false;


                _indisDeger = 0;
                gAdres.Clear();
                if (oto.Checked)
                {
                    if (bit8.Checked)
                    {
                        for (int i = 0; i < dataSegment.Count; i++)
                        {
                            for (int j = 0; j < _s.Length; j++)
                            {
                                if (degiskenAyir(dataSegment[i + j]))
                                {
                                    if (_bit16)
                                    {
                                        i++;
                                    }

                                    gAdres.Clear();
                                    break;
                                }
                                else
                                {
                                    gAdres.Add(dataSegment[i + j - 1]);
                                }
                            }

                            if (gAdres.Count == _s.Length)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dataSegment.Count; i++)
                        {
                            for (int j = 0; j < _s.Length * 2; j++)
                            {
                                if (degiskenAyir(dataSegment[i + j]))
                                {
                                    if (_bit16)
                                    {
                                        i++;
                                    }

                                    gAdres.Clear();
                                    break;
                                }
                                else
                                {
                                    gAdres.Add(dataSegment[i + j - 2]);
                                }
                            }

                            if (gAdres.Count == _s.Length * 2)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (!oto.Checked)
                    {
                        dHata.Text = "String tanımları otomatik olmalıdır";
                        labelSifirla();
                    }
                }


                int _a = 0;
                for (int i = 0; i < _s.Length; i++)
                {
                    if (gAdres.Count > 0)
                    {
                        degisken a = new degisken();
                        a.degiskenAdi = d.degiskenAdi + "[" + i.ToString() + "]";
                        if (i == 0)
                        {
                            a.degiskenAdi = d.degiskenAdi;
                            a._tam = _s;
                            a._string = true;
                        }

                        a.degiskenDegeri = ((int)(_s[i])).ToString();
                        a.degiskenBiti = gBit;
                        a._tam = _s;
                        a._string = true;
                        if (d.degiskenBiti.Equals("8"))
                        {
                            a.degiskenAdresi = gAdres[i];

                            degiskenListesi.Add(a);
                            _indisDeger++;
                        }
                        else
                        {
                            a.degiskenAdresi = gAdres[2 * i];
                            a.degiskenDegeri = ((int)(_s[i])).ToString();
                            degiskenListesi.Add(a);
                        }
                    }
                    else
                    {
                        dHata.Text = "Adresler dolu";
                        labelSifirla();
                    }
                }


                foreach (var i in degiskenListesi)
                {
                    if (d.degiskenDegeri.Equals(i.degiskenDegeri))
                    {
                        degiskenListesi.Remove(i);
                        break;
                    }
                }
            }
        }


        bool DegiskenBul(string _adres)
        {
            _adresVar = false;
            _adressBiti = "";

            foreach (var i in degiskenListesi)
            {
                if (i.degiskenAdresi.Equals(_adres))
                {
                    _adressBiti = i.degiskenBiti;
                    _adresVar = true;
                    if (i.degiskenAdi.Equals("(tanimsiz)"))
                    {
                        degiskenListesi.Remove(i);
                        _adresVar = false;
                        _adressBiti = "";
                    }

                    break;
                }
            }


            return _adresVar;
        }


        private void degiskenDegeriAta(string _ad, string _adres, string _deger, int _bit)
        {
            for (int i = 0; i < dataSegment.Count; i++)
            {
                _olabilir = false;
                _adresVar = false;
                if (_adres.Equals(dataSegment[i]))
                {
                    if (DegiskenBul(_adres) == true)
                    {
                        dHata.Text = "Bu adrese yönelik işlem yapılamaz";
                        labelSifirla();
                        break;
                    }
                    else
                    {
                        if (i != 0)
                        {
                            if (DegiskenBul(dataSegment[i - 1]) == true)
                            {
                                if (_adressBiti.Equals("8") || _adressBiti.Equals(""))
                                {
                                }
                                else
                                {
                                    dHata.Text = "Bu adrese yönelik işlem yapılamaz";
                                    labelSifirla();
                                    break;
                                }
                            }
                        }

                        if (DegiskenBul(dataSegment[i + 1]) == true)
                        {
                            _olabilir = true;
                        }

                        degisken d = new degisken();
                        d.degiskenAdi = _ad;
                        d.degiskenDegeri = _deger;
                        d.degiskenAdresi = _adres;
                        if (_bit == 0)
                        {
                            d.degiskenBiti = "8";
                        }
                        else
                        {
                            d.degiskenBiti = "16";
                        }


                        if (_olabilir == true)
                        {
                            if (_bit == 0)
                            {
                                degiskenListesi.Add(d);
                                break;
                            }
                            else
                            {
                                dHata.Text = "Korumalı alan etki ettiği için işlem yapılmaz.";
                                labelSifirla();
                                break;
                            }
                        }
                        else
                        {
                            degiskenListesi.Add(d);
                            break;
                        }
                    }
                }
            }
        }

        private bool _degiskenAta;
        private bool _bit16;

        bool degiskenAyir(string _adresAl)
        {
            _degiskenAta = false;
            _bit16 = false;

            for (int i = 0; i < degiskenListesi.Count; i++)
            {
                if (_adresAl.Equals(degiskenListesi[i].degiskenAdresi))
                {
                    _degiskenAta = true;
                    if (degiskenListesi[i].degiskenBiti.Equals("16"))
                    {
                        _bit16 = true;
                    }

                    break;
                }
            }


            return _degiskenAta;
        }

        bool _dAta = false;


        void DegiskenSil(string _dAdres)
        {
            foreach (var i in degiskenListesi)
            {
                if (i.degiskenAdresi.Equals(_dAdres))
                {
                    degiskenListesi.Remove(i);
                    break;
                }
            }
        }

        int _indisAl(string _adresAl)
        {
            for (int i = 0; i < dataSegment.Count; i++)
            {
                if (_adresAl.Equals(dataSegment[i]))
                {
                    _indisDeger = i;
                }
            }

            return _indisDeger;
        }


        bool binary(TextBox _deger)
        {
            dBool = false;

            int binaryBasamak = 0;
            for (int i = 0; i < _deger.Text.Length - 1; i++)
            {
                try
                {
                    binaryBasamak = (int)char.GetNumericValue(_deger.Text[i]);
                    if (binaryBasamak == 0 || binaryBasamak == 1)
                    {
                        if (_deger.Text.Length <= 9)
                        {
                            dBit = 0;
                            bit = 0;
                        }
                        else
                        {
                            if (_deger.Text.Length <= 17)
                            {
                                dBit = 1;
                                bit = 1;
                            }
                        }

                        dBool = true;
                    }
                    else
                    {
                        dBool = false;
                        break;
                    }
                }
                catch (FormatException e)
                {
                    dBool = false;
                    break;
                }
            }

            if (_deger.Text.Length > 17)
            {
                dBool = false;
            }

            return dBool;
        }

        bool hex(TextBox _deger)
        {
            dBool = false;

            int binaryBasamak = 0;
            bool basamakKontrol = false;
            for (int i = 0; i < _deger.Text.Length - 1; i++)
            {
                try
                {
                    binaryBasamak = int.Parse(_deger.Text[i].ToString());
                    if (_deger.Text.Length <= 3)
                    {
                        dBit = 0;
                        bit = 0;
                    }
                    else
                    {
                        if (_deger.Text.Length <= 5)
                        {
                            dBit = 1;
                            bit = 1;
                        }
                        else
                        {
                            dBit = -1;
                            bit = -1;
                        }
                    }

                    dBool = true;
                }
                catch (FormatException e)
                {
                    if (!basamakKontrol && (_deger.Text[i] == 'a' || _deger.Text[i] == 'A'))
                    {
                        basamakKontrol = true;
                    }

                    if (!basamakKontrol && (_deger.Text[i] == 'b' || _deger.Text[i] == 'B'))
                    {
                        basamakKontrol = true;
                    }

                    if (!basamakKontrol && (_deger.Text[i] == 'c' || _deger.Text[i] == 'C'))
                    {
                        basamakKontrol = true;
                    }

                    if (!basamakKontrol && (_deger.Text[i] == 'd' || _deger.Text[i] == 'D'))
                    {
                        basamakKontrol = true;
                    }

                    if (!basamakKontrol && (_deger.Text[i] == 'e' || _deger.Text[i] == 'E'))
                    {
                        basamakKontrol = true;
                    }

                    if (!basamakKontrol && (_deger.Text[i] == 'f' || _deger.Text[i] == 'F'))
                    {
                        basamakKontrol = true;
                    }

                    if (!basamakKontrol)
                    {
                        dBool = false;
                        break;
                    }
                    else
                    {
                        if (_deger.Text.Length <= 2)
                        {
                            dBit = 0;
                            bit = 0;
                        }
                        else
                        {
                            if (_deger.Text.Length <= 4)
                            {
                                dBit = 1;
                                bit = 1;
                            }
                            else
                            {
                                dBit = -1;
                                bit = -1;
                            }
                        }

                        dBool = true;
                        basamakKontrol = false;
                    }
                }
            }

            if (_deger.Text.Length > 5)
            {
                dBool = false;
            }

            return dBool;
        }

        bool dec(TextBox _deger)
        {
            dBool = false;
            int binaryBasamak = 0;
            bool basamakKontrol = false;

            // string to dec format exception hatası
            int d = 0;


            if (int.TryParse(_deger.Text, out d))
            {
                if (int.Parse(_deger.Text) < 256 && int.Parse(_deger.Text) >= -128)
                {
                    dBit = 0;
                    bit = 0;
                    dBool = true;
                }
                else
                {
                    if (int.Parse(_deger.Text) < 65536 && int.Parse(_deger.Text) >= -32768)
                    {
                        dBit = 1;
                        bit = 1;
                        dBool = true;
                    }
                    else
                    {
                        dBit = -1;
                        bit = -1;
                        dBool = false;
                    }
                }
            }
            else
            {
                dBool = false;
                dBit = -1;
                bit = -1;
            }


            return dBool;
        }

        private void degiskenListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            for (int i = 0; i < degiskenListesi.Count; i++)
            {
                if (degiskenListBox.Items.Count != 0 && degiskenListBox.SelectedItem != null&&
                    degiskenListBox.SelectedItem.ToString().Equals(degiskenListesi[i].degiskenAdi))
                {
                    degiskenAdiText.Text = degiskenListesi[i].degiskenAdi;
                    degiskenAdresiText.Text = degiskenListesi[i].degiskenAdresi;
                    degiskenDegeriText.Text = degiskenListesi[i].degiskenDegeri;
                    degiskenBitiText.Text = degiskenListesi[i].degiskenBiti;
                    if (degiskenListesi[i]._string)
                    {
                        degiskenDegeriText.Text = degiskenListesi[i]._tam;
                    }
                }
            }
        }

        private bool yBool = false;
        private string yBasamak = "";
        private string yText = "";
        private bool yKontrol = false;

        private void yDegistir_Click(object sender, EventArgs e)
        {
            yBool = false;
            yBasamak = "";
            yText = "";
            yKontrol = false;
            if (yAdi.Text.ToUpper().Equals("Sİ") || yAdi.Text.ToUpper().Equals("SI"))
            {
                yAdi.Text = "sj";
            }

            if (yAdi.Text.ToUpper().Equals("Dİ") || yAdi.Text.ToUpper().Equals("DI"))
            {
                yAdi.Text = "dj";
            }


            foreach (var label in yazmacListesi)
            {
                if (yAdi.Text.ToUpper().Equals(label.Name.ToUpper()))
                {
                    yKontrol = true;
                    break;
                }
            }

            if (yDegeriBox.Text.Equals(""))
            {
                yKontrol = false;
            }

            if (yAdi.Text.Equals(""))
            {
                yKontrol = false;
            }

            if (Convert.ToInt64(donusturDec(yDegeriBox.Text)) < 0)
            {
                bit = 0;
                if (yAdi.Text.ToUpper()[1].ToString().Equals("X") ||
                    yAdi.Text.ToUpper()[1].ToString().Equals("J") ||
                    yAdi.Text.ToUpper()[1].ToString().Equals("J") ||
                    yAdi.Text.ToUpper()[1].ToString().Equals("P"))
                {
                    bit = 1;
                }

                yDegeriBox.Text = binCon(yDegeriBox.Text);
                yDegeriBox.Text = bitle(yDegeriBox.Text, bit) + "b";
            }


            if (yKontrol == true)
            {
                foreach (var label in yazmacListesi)
                {
                    yBool = false;
                    if (label.Name.ToUpper().Equals(yAdi.Text.ToUpper()))
                    {
                        if (yDegeriBox.Text[yDegeriBox.Text.Length - 1] == 'b')
                        {
                            yBool = binary(yDegeriBox);
                        }

                        if (yDegeriBox.Text[yDegeriBox.Text.Length - 1] == 'h')
                        {
                            yBool = hex(yDegeriBox);
                        }

                        if (yDegeriBox.Text[yDegeriBox.Text.Length - 1] != 'b' &&
                            yDegeriBox.Text[yDegeriBox.Text.Length - 1] != 'h')
                        {
                            yBool = dec(yDegeriBox);
                        }

                        if (yBool == true)
                        {
                            yBasamak = hexConvert(yDegeriBox.Text);
                            if (yBasamak.Length > 4)
                            {
                                yBool = false;
                            }
                        }


                        if (yBool == true && (
                                yAdi.Text.ToString().ToUpper()[1] == 'X' ||
                                yAdi.Text.ToString().ToUpper()[1] == 'J' ||
                                yAdi.Text.ToString().ToUpper()[1] == 'P'))
                        {
                            yBasamak = hexConvert(yDegeriBox.Text);
                            label.Text = label.Text.Substring(0, 2) + " " + hexConvert(yDegeriBox.Text);


                            if (yBasamak.Length == 1)
                            {
                                label.Text = label.Text.Substring(0, 2) + " 000" + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak.Length == 2)
                            {
                                label.Text = label.Text.Substring(0, 2) + " 00" + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak.Length == 3)
                            {
                                label.Text = label.Text.Substring(0, 2) + " 0" + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak.Length == 0)
                            {
                                label.Text = label.Text.Substring(0, 2) + " " + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak[yBasamak.Length - 1] == 'h')
                            {
                            }
                            else
                            {
                                label.Text = label.Text + "h";
                            }


                            if (yAdi.Text.ToUpper()[1] == 'X')
                            {
                                foreach (Label _label in yazmacListesi)
                                {
                                    if (_label.Name.ToUpper().Equals(yAdi.Text[0].ToString().ToUpper() + "H"))
                                    {
                                        _label.Text = yAdi.Text[0].ToString().ToUpper() + "H" + " " +
                                                      label.Text.Substring(label.Text.Length - 5, 2) + "h";
                                    }

                                    if (_label.Name.ToUpper().Equals(yAdi.Text[0].ToString().ToUpper() + "L"))
                                    {
                                        _label.Text = yAdi.Text[0].ToString().ToUpper() + "L" + " " +
                                                      label.Text.Substring(label.Text.Length - 3, 2) + "h";
                                    }
                                }
                            }


                            break;
                        }

                        if (yBasamak.Length > 2)
                        {
                            yBool = false;
                        }

                        if (yBool == true && yAdi.Text.ToString().ToUpper()[1] == 'H')
                        {
                            // High yada Low ise 

                            if (yBasamak.Length == 1)
                            {
                                label.Text = label.Text.Substring(0, 2) + " 0" + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak.Length == 2)
                            {
                                label.Text = label.Text.Substring(0, 2) + " " + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak[yBasamak.Length - 1] == 'h')
                            {
                            }
                            else
                            {
                                label.Text = label.Text + "h";
                            }

                            foreach (Label _label in yazmacListesi)
                            {
                                if (_label.Name.ToUpper().Equals(yAdi.Text[0].ToString().ToUpper() + "X"))
                                {
                                    _label.Text = _label.Text.Substring(0, 3) +
                                                  yBasamak +
                                                  _label.Text.Substring(_label.Text.Length - 3, 3);

                                    if (_label.Text.Length < 8)
                                    {
                                        _label.Text = _label.Text.Substring(0, 3) + "0" +
                                                      _label.Text.Substring(3, 4);
                                    }
                                    break;
                                    
                                }
                            }

                            break;
                        }

                        if (yBool == true && yAdi.Text.ToString().ToUpper()[1] == 'L')
                        {
                            // High yada Low ise 

                            if (yBasamak.Length == 1)
                            {
                                label.Text = label.Text.Substring(0, 2) + " 0" + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak.Length == 2)
                            {
                                label.Text = label.Text.Substring(0, 2) + " " + hexConvert(yDegeriBox.Text);
                            }

                            if (yBasamak[yBasamak.Length - 1] == 'h')
                            {
                            }
                            else
                            {
                                label.Text = label.Text + "h";
                            }

                            foreach (Label _label in yazmacListesi)
                            {
                                if (_label.Name.ToUpper().Equals(yAdi.Text[0].ToString().ToUpper() + "X"))
                                {
                                    _label.Text = _label.Text.Substring(0, 5) + yBasamak + "h";
                                    if (_label.Text.Length < 8)
                                    {
                                        _label.Text = _label.Text.Substring(0, 5) + "0" +
                                                      _label.Text.Substring(5, 2);
                                    }
                                    break;
                                }
                                
                            }


                            break;
                        }
                    }
                }
            }
            else
            {
                if (yAdi.Text.Equals(""))
                {
                    yBilgi.Text = "Yazmaç belirtilmedi";
                    labelSifirla();
                }
                else
                {
                    if (yDegeriBox.Text.Equals(""))
                    {
                        yBilgi.Text = "Değer alanı boş olamaz";
                        labelSifirla();
                    }
                    else
                    {
                        yBilgi.Text = "Böyle bir yazmaç belirtilmedi";
                        labelSifirla();
                    }
                }

                if (yAdi.Text.ToUpper().Equals("SJ") || yAdi.Text.ToUpper().Equals("SI"))
                {
                    yAdi.Text = "si";
                }

                if (yAdi.Text.ToUpper().Equals("SJ") || yAdi.Text.ToUpper().Equals("DI"))
                {
                    yAdi.Text = "di";
                }
            }

            if (yAdi.Text.ToUpper().Equals("SJ") || yAdi.Text.ToUpper().Equals("SI"))
            {
                yAdi.Text = "si";
            }

            if (yAdi.Text.ToUpper().Equals("DJ") || yAdi.Text.ToUpper().Equals("DI"))
            {
                yAdi.Text = "di";
            }
        }


        private string degerReturn;


        string hexConvert(string _deger)
        {
            degerReturn = "";

            #region Dec sayı Dec ise

            if (_deger[_deger.Length - 1] != 'b' && _deger[_deger.Length - 1] != 'h')
            {
                degerReturn = int.Parse(_deger).ToString("X");
            }

            #endregion


            #region bit Sayı bit ise

            if (_deger[_deger.Length - 1] == 'b')
            {
                degerReturn = Convert.ToInt32(_deger.Substring(0, _deger.Length - 1), 2).ToString("X");
            }

            #endregion


            if (_deger[_deger.Length - 1] == 'h')
            {
                degerReturn = _deger.Substring(0, _deger.Length - 1);
            }


            return degerReturn;
        }


        void yazmacIsle(Label _label)
        {
            if (_label.Name.ToUpper()[1] == 'X')
            {
                foreach (Label i in yazmacListesi)
                {
                    if (i.Name.ToUpper().Equals(_label.Name[0].ToString().ToUpper() + "H"))
                    {
                        i.Text = i.Name.ToUpper() + " "
                                                  + _label.Text.Substring(_label.Text.Length - 5, 2) +
                                                  "h";
                    }

                    if (i.Name.ToUpper().Equals(_label.Name[0].ToString().ToUpper() + "L"))
                    {
                        i.Text = i.Name.ToUpper() + " "
                                                  + _label.Text.Substring(_label.Text.Length - 3, 2) +
                                                  "h";
                    }
                }
            }
            else
            {
                if (_label.Name.ToUpper()[1] == 'L')
                {
                    foreach (Label i in yazmacListesi)
                    {
                        if (i.Name.ToUpper().Equals(_label.Name[0].ToString().ToUpper() + "X"))
                        {
                            i.Text = i.Text.Substring(0, 5) + _label.Text.Substring(_label.Text.Length - 3, 3);
                        }
                    }
                }

                if (_label.Name.ToUpper()[1] == 'H')
                {
                    foreach (Label i in yazmacListesi)
                    {
                        if (i.Name.ToUpper().Equals(_label.Name[0].ToString().ToUpper() + "X"))
                        {
                            i.Text = i.Text.Substring(0, 3)
                                     + _label.Text.Substring(_label.Text.Length - 3, 2) +
                                     i.Text.Substring(i.Text.Length - 3, 2) + "h";
                        }
                    }
                }
            }
        }

        private bool gecerliBirAdres = false;
        private TextBox boxDeneme = new TextBox();

        bool adresKontrolEtme(TextBox box)
        {
            gecerliBirAdres = false;
            boxDeneme.Text = box.Text.Substring(1, box.Text.Length - 2);
            string _deger = boxDeneme.Text;
            foreach (var yazmac in yazmacListesi)
            {
                if (_deger.ToUpper().Equals(yazmac.Name.ToUpper()))
                {
                    gecerliBirAdres = true;
                    adresDurumu = "yazmac";
                    break;
                }
            }

            if (gecerliBirAdres == false)
            {
                if (_deger.ToLower()[_deger.Length - 1] == 'b')
                {
                    gecerliBirAdres = binary(boxDeneme);
                }

                if (_deger.ToLower()[_deger.Length - 1] == 'h')
                {
                    gecerliBirAdres = hex(boxDeneme);
                }
                else
                {
                    if (_deger.ToLower()[_deger.Length - 1] != 'h' && _deger.ToLower()[_deger.Length - 1] != 'b')
                    {
                        gecerliBirAdres = dec(boxDeneme);
                    }
                }

                if (gecerliBirAdres == true)
                {
                    adresDurumu = "deger";
                }
            }

            if (gecerliBirAdres == false)
            {
                foreach (var d in degiskenListesi)
                {
                    if (d.degiskenAdi.Equals(_deger))
                    {
                        gecerliBirAdres = true;
                        adresDurumu = "degisken";
                        break;
                    }
                }
            }

            return gecerliBirAdres;
        }


        private List<kodlar> kodListesi = new List<kodlar>();
        private int kodSayisi = 0;

        private void segmentCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            csCodeText.Text = "";
            foreach (var i in kodListesi)
            {
                if (i.adres.Equals(segmentCode.SelectedItem.ToString()))
                {
                    csCodeText.Text = i.kod;
                    break;
                }
            }
        }

        private void segmentStack_SelectedIndexChanged(object sender, EventArgs e)
        {
            ssDeger.Text = "";
            for (int i = 0; i < _ssDeger.Count; i++)
            {
                if (_ssDeger[i].adres.Equals(segmentStack.SelectedItem))
                {
                    ssDeger.Text = _ssDeger[i].deger;
                    ssDondur(ssDeger.Text);
                    break;
                }
            }
        }

        private int _adet = 0;
        private ListBox _lb;


        private void ileriDS_Click(object sender, EventArgs e)
        {
            if (segmentData.Items[segmentData.Items.Count - 1].Equals(dataSegment[dataSegment.Count - 1]))
            {
            }
            else
            {
                for (int i = 0; i < dataSegment.Count; i++)
                {
                    if (dataSegment[i].Equals(segmentData.Items[segmentData.Items.Count - 1]))
                    {
                        _adet = i;
                        break;
                    }
                }

                segmentData.Items.Clear();
                for (int i = _adet + 1; i < _adet + 1 + 4096; i++)
                {
                    segmentData.Items.Add(dataSegment[i]);
                }
            }
        }

        private List<string> geciciBox = new List<string>();

        private void geriDS_Click(object sender, EventArgs e)
        {
            if (segmentData.Items[0].Equals(dataSegment[0]))
            {
            }
            else
            {
                for (int i = 0; i < dataSegment.Count; i++)
                {
                    if (dataSegment[i].Equals(segmentData.Items[0]))
                    {
                        _adet = i;
                        break;
                    }
                }

                segmentData.Items.Clear();
                geciciBox.Clear();


                for (int i = _adet - 1; i > _adet - 1 - 4096; i--)
                {
                    geciciBox.Add(dataSegment[i]);
                }

                geciciBox.Reverse();

                foreach (var i in geciciBox)
                {
                    segmentData.Items.Add(i);
                }
            }
        }

        private void ilerCS_Click(object sender, EventArgs e)
        {
            if (segmentCode.Items[segmentCode.Items.Count - 1].Equals(dataSegment[dataSegment.Count - 1]))
            {
            }
            else
            {
                for (int i = 0; i < dataSegment.Count; i++)
                {
                    if (dataSegment[i].Equals(segmentCode.Items[segmentCode.Items.Count - 1]))
                    {
                        _adet = i;
                        break;
                    }
                }

                segmentCode.Items.Clear();
                for (int i = _adet + 1; i < _adet + 1 + 4096; i++)
                {
                    segmentCode.Items.Add(dataSegment[i]);
                }
            }
        }

        private void geriCS_Click(object sender, EventArgs e)
        {
            if (segmentCode.Items[0].Equals(dataSegment[0]))
            {
            }
            else
            {
                for (int i = 0; i < dataSegment.Count; i++)
                {
                    if (dataSegment[i].Equals(segmentCode.Items[0]))
                    {
                        _adet = i;
                        break;
                    }
                }

                segmentCode.Items.Clear();
                geciciBox.Clear();


                for (int i = _adet - 1; i > _adet - 1 - 4096; i--)
                {
                    geciciBox.Add(dataSegment[i]);
                }

                geciciBox.Reverse();

                foreach (var i in geciciBox)
                {
                    segmentCode.Items.Add(i);
                }
            }
        }

        private void geriSS_Click(object sender, EventArgs e)
        {
            if (segmentStack.Items[0].Equals(dataSegment[0]))
            {
            }
            else
            {
                for (int i = 0; i < dataSegment.Count; i++)
                {
                    if (dataSegment[i].Equals(segmentStack.Items[0]))
                    {
                        _adet = i;
                        break;
                    }
                }

                segmentStack.Items.Clear();
                geciciBox.Clear();


                for (int i = _adet - 1; i > _adet - 1 - 4096; i--)
                {
                    geciciBox.Add(dataSegment[i]);
                }

                geciciBox.Reverse();

                foreach (var i in geciciBox)
                {
                    segmentStack.Items.Add(i);
                }
            }
        }

        private void ileriSS_Click(object sender, EventArgs e)
        {
            if (segmentStack.Items[segmentStack.Items.Count - 1].Equals(dataSegment[dataSegment.Count - 1]))
            {
            }
            else
            {
                for (int i = 0; i < dataSegment.Count; i++)
                {
                    if (dataSegment[i].Equals(segmentStack.Items[segmentStack.Items.Count - 1]))
                    {
                        _adet = i;
                        break;
                    }
                }

                segmentStack.Items.Clear();
                for (int i = _adet + 1; i < _adet + 1 + 4096; i++)
                {
                    segmentStack.Items.Add(dataSegment[i]);
                }
            }
        }

        private void sHex_CheckedChanged(object sender, EventArgs e)
        {
            if (sHex.Checked)
            {
                sDec.Checked = false;
                sBin.Checked = false;
            }

            if (dsDegiskenDegeriText.Text.Equals(""))
            {
            }
            else
            {
                dondurGelsin(dsDegiskenDegeriText.Text);
            }
        }

        private void sDec_CheckedChanged(object sender, EventArgs e)
        {
            if (sDec.Checked)
            {
                sHex.Checked = false;
                sBin.Checked = false;
            }

            if (dsDegiskenDegeriText.Text.Equals(""))
            {
            }
            else
            {
                dondurGelsin(dsDegiskenDegeriText.Text);
            }

            if (ssDeger.Text.Equals(""))
            {
            }
            else
            {
                ssDondur(ssDeger.Text);
            }
        }


        string binCon(string s)
        {
            _ds = donusturDec(s);
            _ds = Convert.ToInt64(_ds).ToString("X").ToLower();
            _ds = Convert.ToString(Convert.ToInt64(_ds, 16), 2);
            return _ds;
        }


        private string _ds;

        void dondurGelsin(string s)
        {
            _ds = donusturDec(s);
            if (sHex.Checked)
            {
                dsDegiskenDegeriText.Text = Convert.ToInt64(_ds).ToString("X").ToLower() + "h";
            }

            if (sDec.Checked)
            {
                dsDegiskenDegeriText.Text = _ds;
            }

            if (sBin.Checked)
            {
                dsDegiskenDegeriText.Text = Convert.ToInt64(_ds).ToString("X").ToLower();
                dsDegiskenDegeriText.Text = Convert.ToString(Convert.ToInt64(dsDegiskenDegeriText.Text, 16), 2) + "b";
                /*  dsDegiskenDegeriText.Text = dsDegiskenDegeriText.Text.Substring
                  (
                      dsDegiskenDegeriText.Text.Length - 8
                  ) + "b";*/
            }
        }

        void ssDondur(string s)
        {
            _ds = donusturDec(s);
            if (sHex.Checked)
            {
                ssDeger.Text = Convert.ToInt64(_ds).ToString("X").ToLower() + "h";
            }

            if (sDec.Checked)
            {
                ssDeger.Text = _ds;
            }

            if (sBin.Checked)
            {
                ssDeger.Text = Convert.ToInt64(_ds).ToString("X").ToLower();
                ssDeger.Text = Convert.ToString(Convert.ToInt64(ssDeger.Text, 16), 2) + "b";
                /*  dsDegiskenDegeriText.Text = dsDegiskenDegeriText.Text.Substring
                  (
                      dsDegiskenDegeriText.Text.Length - 8
                  ) + "b";*/
            }
        }


        private int _c;
        private int quot;
        string bin = "";

        string decToMin(string _s)
        {
            _c = int.Parse(_s);

            quot = 0;
            string rem = "";
            while (_c >= 1)
            {
                quot = _c / 2;
                rem += (_c % 2).ToString();
                _c = quot;
            }

            bin = "";
            for (int i = rem.Length - 1; i >= 0; i--)
            {
                bin = bin + rem[i];
            }

            return bin;
        }


        private void sBin_CheckedChanged(object sender, EventArgs e)
        {
            if (sBin.Checked)
            {
                sDec.Checked = false;
                sHex.Checked = false;
            }

            if (dsDegiskenDegeriText.Text.Equals(""))
            {
            }
            else
            {
                dondurGelsin(dsDegiskenDegeriText.Text);
            }
        }


        private string _bDeger;

        string bitle(string _s, int bit)
        {
            _basamakTut = 0;
            sifirEkle = "";
            _bDeger = _s;

            if (bit == 0)
            {
                if (_bDeger.Length > 8)
                {
                    _bDeger = _bDeger.Substring(_bDeger.Length - 8);
                }
                else
                {
                    if (_bDeger.Length < 8)
                    {
                        sifirEkle = "";
                        _basamakTut = 8 - _bDeger.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _bDeger = sifirEkle + _bDeger;
                    }
                }
            }
            else
            {
                if (_bDeger.Length > 16)
                {
                    _bDeger = _bDeger.Substring(_bDeger.Length - 16);
                }
                else
                {
                    if (_bDeger.Length < 16)
                    {
                        sifirEkle = "";
                        _basamakTut = 16 - _bDeger.Length;
                        for (int i = 0; i < _basamakTut; i++)
                        {
                            sifirEkle += "0";
                        }

                        _bDeger = sifirEkle + _bDeger;
                    }
                }
            }

            return _bDeger;
        }

        private Stopwatch stopwatch = new Stopwatch();

        private void komutText_TextChanged(object sender, EventArgs e)
        {
            deger1Text.Enabled = false;
            deger2Text.Enabled = false;
            if (komutText.Text.ToUpper().Equals("MOV") ||
                komutText.Text.ToUpper().Equals("ADD") ||
                komutText.Text.ToUpper().Equals("ADC") ||
                komutText.Text.ToUpper().Equals("SUB") ||
                komutText.Text.ToUpper().Equals("SBB") ||
                komutText.Text.ToUpper().Equals("XOR") ||
                komutText.Text.ToUpper().Equals("OR") ||
                komutText.Text.ToUpper().Equals("AND") ||
                komutText.Text.ToUpper().Equals("TEST") ||
                komutText.Text.ToUpper().Equals("SHL") ||
                komutText.Text.ToUpper().Equals("SAL") ||
                komutText.Text.ToUpper().Equals("SAR") ||
                komutText.Text.ToUpper().Equals("SHR") ||
                komutText.Text.ToUpper().Equals("ROL") ||
                komutText.Text.ToUpper().Equals("ROR") ||
                komutText.Text.ToUpper().Equals("RCL") ||
                komutText.Text.ToUpper().Equals("RCR") ||
                komutText.Text.ToUpper().Equals("XCHG") ||
                komutText.Text.ToUpper().Equals("CMP") ||
                komutText.Text.ToUpper().Equals("RCR"))
            {
                deger1Text.Enabled = true;
                deger2Text.Enabled = true;
            }

            if (komutText.Text.ToUpper().Equals("INC") ||
                komutText.Text.ToUpper().Equals("DEC") ||
                komutText.Text.ToUpper().Equals("PUSH") ||
                komutText.Text.ToUpper().Equals("POP") ||
                komutText.Text.ToUpper().Equals("NOT") ||
                komutText.Text.ToUpper().Equals("NEG")
               )
            {
                deger1Text.Enabled = true;
            }
        }

        async Task labelSifirla()
        {
            await Task.Delay(2000);
            bilgiLabel.Text = "";
            dHata.Text = "";
            yBilgi.Text = "";
        }


        private void deger1Text_TextChanged(object sender, EventArgs e)
        {
            if (deger1Text.Text.Equals(""))
            {
                durumLab1.Text = "";
                deger1Lab.Text = "";
                bit1.Text = "";
            }
            else
            {
                _kontrol1 = kontrol(deger1Text);
                if (bit == 0)
                {
                    bit1.Text = "8-";
                }
                else
                {
                    bit1.Text = "16-";
                }

                _deger1 = deger;
                _durum1 = durum;
                deger1Lab.Text = _deger1;

                if (_durum1 == 0)
                {
                    durumLab1.Text = "Yazmaç";
                }

                if (_durum1 == 1)
                {
                    durumLab1.Text = "Değişken";
                }

                if (_durum1 == 2)
                {
                    durumLab1.Text = "Değer";
                }

                if (_durum1 == 3)
                {
                    durumLab1.Text = "Adres";
                }

                if (!_kontrol1)
                {
                    durumLab1.Text = "Geçersiz";
                    bit2.Text = "";
                    deger2Lab.Text = "";
                }

                if (_durum1 == 3)
                {
                    adres1 = adres;
                }
            }
        }

        private void deger2Text_TextChanged(object sender, EventArgs e)
        {
            if (deger2Text.Text.Equals(""))
            {
                durumLab2.Text = "";
                deger2Lab.Text = "";
                bit2.Text = "";
            }
            else
            {
                _kontrol2 = kontrol(deger2Text);
                if (bit == 0)
                {
                    bit2.Text = "8-";
                }
                else
                {
                    bit2.Text = "16-";
                }

                _bit2 = bit;
                _deger2 = deger;
                _durum2 = durum;
                deger2Lab.Text = _deger2;

                if (_durum2 == 0)
                {
                    durumLab2.Text = "Yazmaç";
                }

                if (_durum2 == 1)
                {
                    durumLab2.Text = "Değişken";
                }

                if (_durum2 == 2)
                {
                    durumLab2.Text = "Değer";
                }

                if (_durum2 == 3)
                {
                    durumLab2.Text = "Adres";
                }

                if (!_kontrol2)
                {
                    durumLab2.Text = "Geçersiz";
                    bit2.Text = "";
                    deger2Lab.Text = "";
                }


                if (_durum2 == 3)
                {
                    adres2 = adres;
                }
            }
        }
    }
}

class degisken
{
    public string degiskenAdi;
    public string degiskenAdresi;
    public string degiskenBiti;
    public string degiskenDegeri;
    public bool _string;
    public string _tam;
}

class kodlar
{
    public string kod;
    public string adres;
}

class stack
{
    public string adres;
    public string deger;
    public string bit;
}