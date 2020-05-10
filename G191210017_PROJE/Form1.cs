//*****************************************************************************//
//*
//*					     SAKARYA ÜNİVERSİTESİ
//*				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
//*				     BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
//*				    NESNEYE DAYALI PROGRAMLAMA DERSİ
//*					     2019-2020 BAHAR DÖNEMİ
//*	                          PROJE ÖDEVİ
//*				
//*				ÖĞRENCİ ADI............: RAİF AKYOL
//*				ÖĞRENCİ NUMARASI.......: G191210017
//*             DERSİN ALINDIĞI GRUP...: 2.ÖĞRETİM C GRUBU
//*
//*****************************************************************************//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static G191210017_PROJE.Form1;
namespace G191210017_PROJE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int tiklamaSayisi=0; //Yeni Oyun butonu için gerekli. her tıklamada yeniden oyunu başlatması için.
        public interface IAtik
        {
            int hacim { get; }  //IAtik isimli interfacete hacim 
        }
        public interface IDolabilen
        {
            int Kapasite { get; set; }
            int DoluHacim { get; }
            int DolulukOrani { get; }
        }
        public class AtikKutusu :IDolabilen
        {
            private int _bosaltmaPuani;
            private int _kapasite;
            private int _doluHacim;
            private int _dolulukOrani;
            public AtikKutusu()
            {

            }
            public int BosaltmaPuani
            {
                get { return _bosaltmaPuani; }
            }
            public int Kapasite
            {
                get { return _kapasite; }
                set { _kapasite = value; }
            }
            public int DoluHacim
            {
                get { return _doluHacim; }
            }
            public int DolulukOrani
            {
                get { return _dolulukOrani; }
            }
        }
        public class Atik : IAtik
        {
            private int _hacim;
            public int hacim
            {
                get { return _hacim; }
                set { _hacim = value; }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();        // ÇIKIŞ butonuna tıklayınca
            Application.Exit();  // uygulamayı kapatması için.
        }
        Image[] images = new Image[8]; //resimleri almak için image  oluşturuyoruz
        public void resim()
        {
            Random r = new Random(); //resimleri random almak için
            images[0] = System.Drawing.Image.FromFile("domates.jpg"); //images[0] proje-> debug-> bin klasöründeki resimlerden domatesi seç.
            images[1] = System.Drawing.Image.FromFile("salatalık.jpg"); //images[1] proje-> debug-> bin klasöründeki resimlerden salatalığı seç.
            images[2] = System.Drawing.Image.FromFile("cam şişe.jpg"); //images[2] proje-> debug-> bin klasöründeki resimlerden cam şişeyi seç.
            images[3] = System.Drawing.Image.FromFile("bardak.jpg"); //images[3] proje-> debug-> bin klasöründeki resimlerden bardağı seç.
            images[4] = System.Drawing.Image.FromFile("gazete.jpg");//images[4] proje-> debug-> bin klasöründeki resimlerden gazeteyi seç.
            images[5] = System.Drawing.Image.FromFile("dergi.png");//images[5] proje-> debug-> bin klasöründeki resimlerden dergiyi seç.
            images[6] = System.Drawing.Image.FromFile("kola kutusu.jpg");//images[6] proje-> debug-> bin klasöründeki resimlerden kola kutusunu seç.
            images[7] = System.Drawing.Image.FromFile("salça kutusu.jpg");//images[7] proje-> debug-> bin klasöründeki resimlerden salça kutusu seç.
            pictureBox1.Image = images[r.Next(0, 8)]; //picturebox1 e imagesleri random yazdır
        }
        int puan = 0; //puan kısmı için gerekli.
        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            button9.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            button7.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            button11.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            button5.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            button6.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            button8.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            button10.Enabled = false;//yeni oyun butonuna tıklamadan bütün atık kutularının butonları disabled olsun. 
            label3.Text = "60";//label3 yani süre ilk açıldığında (oyun başlamadan) oyun 60 olarak gözüksün.
            label4.Text = "0";//label4 yani puan ilk açıldığında (oyun başlamadan) 0 puan olarak gözüksün.       
        }
        public void atikPuan()
        {
            AtikKutusu organikAtik = new AtikKutusu();
            AtikKutusu kagit = new AtikKutusu();
            AtikKutusu cam = new AtikKutusu();
            AtikKutusu metal = new AtikKutusu();
            organikAtik.Kapasite = 700;//organik atık kutusunun kapasitesi 700
            kagit.Kapasite = 1200;//kağıt atık kutusunun kapasitesi 1200
            cam.Kapasite = 2200;//cam atık kutusunun kapasitesi 2200
            metal.Kapasite = 2300;//metal atık kutusunun kapasitesi 2300
            Atik domates = new Atik();
            Atik camSise = new Atik();
            Atik bardak = new Atik();
            Atik gazete = new Atik();
            Atik dergi = new Atik();
            Atik salatalik = new Atik();
            Atik kolaKutusu = new Atik();
            Atik salcaKutusu = new Atik();
            domates.hacim = 150;//domatesin hacmi 150
            camSise.hacim = 600;//cam şişenin hacmi 600
            bardak.hacim = 250;//bardağın hacmi 250
            gazete.hacim = 250;//gazetenin hacmi 250
            dergi.hacim = 200;//derginin hacmi 200
            salatalik.hacim = 120;//salatalığın hacmi 120
            kolaKutusu.hacim = 350;//kola kutusunun hacmi 350
            salcaKutusu.hacim = 550;//salça kutusunun hacmi 550

            if (pictureBox1.Image == images[0])//eğer picturebox taki resim images[0] yani domates ise
            {
               puan += domates.hacim; //puan a domatesin hacmini ekle.
            }
            else if (pictureBox1.Image == images[1])//eğer picturebox taki resim images[1] yani salatalık ise
            {
                puan += salatalik.hacim; //puan a salatalığın hacmini ekle.
            }
            else if (pictureBox1.Image == images[4])//eğer picturebox taki resim images[2] yani gazete ise
            {
               puan += gazete.hacim; //puan a gazetenin hacmini ekle.
            }
            else if (pictureBox1.Image == images[5])//eğer picturebox taki resim images[3] yani dergi ise
            {
               puan += dergi.hacim; //puan a derginin hacmini ekle.
            }
            else if (pictureBox1.Image == images[2])//eğer picturebox taki resim images[4] yani cam şişe ise
            {
               puan += camSise.hacim; //puan a cam şişenin hacmini ekle.
            }
            else if (pictureBox1.Image == images[3])//eğer picturebox taki resim images[5] yani bardak ise
            {
                puan+= bardak.hacim; //puan a bardağın hacmini ekle.
            }
            else if (pictureBox1.Image == images[6])//eğer picturebox taki resim images[6] yani kola kutusu ise
            {
                puan += kolaKutusu.hacim; //puan a kola kutusunun hacmini ekle.
            }
            else if (pictureBox1.Image == images[7])//eğer picturebox taki resim images[7] yani salça kutusu ise
            {
                puan += salcaKutusu.hacim; //puan a salça kutusunun hacmini ekle.
            }
            label4.Text = puan.ToString(); //label4 yani puan değişkenine puan ı yaz
        }
        int saniye;//süre için gerekli
        private void button1_Click(object sender, EventArgs e)//yeni oyun butonu
        {
            if(tiklamaSayisi==0)//eğer butona ilk defa tıklanmışsa (ilk tıklama)
            {
                resim(); //picturebox a resimlerin random gelmesi için
                button4.Enabled = true; //butonların enabled olup kullanılabilmesi için
                button7.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button9.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button11.Enabled = true;//butonların enabled olup kullanılabilmesi için
                timer1.Enabled = true;//timerın aktif edilmesi
                timer1.Interval = 1000;//saniye için gerekli
                saniye = 60;//süre 60 tan geriye sayması için
                tiklamaSayisi++;//tıklama sayısı değişkenini ++ yapıp yeni oyun butonuna bir sonrki tıklamaların olması için 
            }
            if(tiklamaSayisi>0)//eğer tıklama sayısı 1 den büyükse yani ilk tıklamadan sonraki her tıklamada
            {
                resim();//picturebox a resimlerin random gelmesi için
                listBox1.Items.Clear(); //önceden listboxlarda atık kalmışsa yeni oyun başladığından temizler.
                listBox2.Items.Clear();//önceden listboxlarda atık kalmışsa yeni oyun başladığından temizler.
                listBox3.Items.Clear();//önceden listboxlarda atık kalmışsa yeni oyun başladığından temizler.
                listBox4.Items.Clear();//önceden listboxlarda atık kalmışsa yeni oyun başladığından temizler.
                label4.Text = "0";//puan ın textini 0 yap.
                button4.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button7.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button9.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button11.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button5.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button6.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button8.Enabled = true;//butonların enabled olup kullanılabilmesi için
                button10.Enabled = true;//butonların enabled olup kullanılabilmesi için
                timer1.Enabled = true;//timerın aktif edilmesi
                timer1.Interval = 1000;//saniye için gerekli
                saniye = 60;//süre 60 tan geriye sayması için
                progressBar1.Value = 0;//progressbarların değerlerinin yeni oyun başladığı için sıfırlanması 
                progressBar2.Value = 0;//progressbarların değerlerinin yeni oyun başladığı için sıfırlanması 
                progressBar3.Value = 0;//progressbarların değerlerinin yeni oyun başladığı için sıfırlanması 
                progressBar4.Value = 0;//progressbarların değerlerinin yeni oyun başladığı için sıfırlanması 
                puan = 0;//puanın yeni oyun başladığı için sıfırlanması 
                tiklamaSayisi++;//tıklama sayısı değişkenini ++ yapıp yeni oyun butonuna bir sonrki tıklamaların olması için 
            }
        }
        private void timer1_Tick(object sender, EventArgs e)//sürenin 60 tan geriye sayması
        {
            saniye -= 1;//60 tan bir bir sürenin azalması 
            label3.Text = (saniye % 60).ToString("0");//label3 süre nin textine süre 0 olunca texte 0 yazırma
            if (saniye == 00)//eğer saniye 0 sa bitmişse
            {
                timer1.Stop();//timer ı durdur.
                button4.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
                button7.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
                button9.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
                button11.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
                button5.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
                button6.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
                button8.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
                button10.Enabled = false;//süre bittiğinden butonlara daha tıklanamamasın
            }
        }
        private void button4_Click(object sender, EventArgs e)//organik atık butonu
        {
          
            if (pictureBox1.Image == images[0])//eğer picturebox a gelen resim domates ise
            {
                if(700-progressBar1.Value>=150)//eğer progressbarın kalan değeri domatesin hacminden büyükse
                {
                    listBox1.Items.Add("Domates (150)");//listboxa domates(150) yazdır.
                    progressBar1.Value += 150;//progressbar a domatesin hacmini ekle.
                    atikPuan();//puana domatesin hacmini ekle.
                    resim();//yeni random resim getir.
                } 
            }
            if (pictureBox1.Image == images[1])//eğer picturebox a gelen resim Salatalık ise
            {
                if(700-progressBar1.Value>=120)//eğer progressbarın kalan değeri Salatalığın hacminden büyükse
                {
                    listBox1.Items.Add("Salatalık (120)");//listboxa Salatalık(120) yazdır.
                    progressBar1.Value += 120;//progressbar a Salatalığın hacmini ekle.
                    atikPuan();//puana Salatalığın hacmini ekle.
                    resim();//yeni random resim getir.
                } 
            }
        }
        private void button9_Click(object sender, EventArgs e)//kağıt atık butonu
        {
            if (pictureBox1.Image == images[4])//eğer picturebox a gelen resim Gazete ise
            {
                if (1200 - progressBar2.Value >= 250)//eğer progressbarın kalan değeri Gazetenin hacminden büyükse
                {
                    listBox2.Items.Add("Gazete (250)");//listboxa Gazete(250) yazdır.
                    progressBar2.Value += 250;//progressbar a Gazetenin hacmini ekle.
                    atikPuan();//puana Gazetenin hacmini ekle.
                    resim();//yeni random resim getir.
                }
            }
            if (pictureBox1.Image == images[5])//eğer picturebox a gelen resim Dergi ise
            {
                if (1200 - progressBar2.Value >= 200)//eğer progressbarın kalan değeri Derginin hacminden büyükse
                {
                    listBox2.Items.Add("Dergi (200)");//listboxa Dergi(200) yazdır.
                    progressBar2.Value += 200;//progressbar a Derginin hacmini ekle.
                    atikPuan();//puana Derginin hacmini ekle.
                    resim();//yeni random resim getir.
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)//cam atık butonu
        {
            if (pictureBox1.Image == images[2])//eğer picturebox a gelen resim Cam Şişe ise
            {
                if (2200 - progressBar3.Value >= 600)//eğer progressbarın kalan değeri Cam Şişenin hacminden büyükse
                {
                    listBox3.Items.Add("Cam Şişe (600)");//listboxa Cam Şişe(600) yazdır.
                    progressBar3.Value += 600;//progressbar a Cam Şişenin hacmini ekle.
                    atikPuan();//puana Cam Şişenin hacmini ekle.
                    resim();//yeni random resim getir.
                }
            }
            if (pictureBox1.Image == images[3])//eğer picturebox a gelen resim Bardak ise
            {
                if (2200 - progressBar3.Value >= 250)//eğer progressbarın kalan değeri Bardağın hacminden büyükse
                {
                    listBox3.Items.Add("Bardak (250)");//listboxa Bardağın(250) yazdır.
                    progressBar3.Value += 250;//progressbar a Bardağın hacmini ekle.
                    atikPuan();//puana Bardağın hacmini ekle.
                    resim();//yeni random resim getir.
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)//metal atık butonu
        {
            if (pictureBox1.Image == images[6])//eğer picturebox a gelen resim Kola Kutusu ise
            {
                if (2300 - progressBar4.Value >= 350)//eğer progressbarın kalan değeri Kola Kutusunun hacminden büyükse
                {
                    listBox4.Items.Add("Kola Kutusu (350)");//listboxa Kola Kutusu(350) yazdır.
                    progressBar4.Value += 350;//progressbar a Kola Kutusunun hacmini ekle.
                    atikPuan();//puana Kola Kutusunun hacmini ekle.
                    resim();//yeni random resim getir.
                }   
            }
            if (pictureBox1.Image == images[7])//eğer picturebox a gelen resim Salça Kutusu ise
            {
                if (2300 - progressBar4.Value >= 550)//eğer progressbarın kalan değeri Salça Kutusunun hacminden büyükse
                {
                    listBox4.Items.Add("Salça Kutusu (550)");//listboxa Salça Kutusu(550) yazdır.
                    progressBar4.Value += 550;//progressbar a Salça Kutusunun hacmini ekle.
                    atikPuan();//puana Salça Kutusunun hacmini ekle.
                    resim();//yeni random resim getir.
                }
            }
            
        }
        private void button5_Click(object sender, EventArgs e)//boşalt butonu
        {
            if (progressBar1.Value >= 525)//progressbar1 in değeri 700 ün %75 inden büyük veya eşitse 
            {
                listBox1.Items.Clear();//listbox1 deki itemsleri temizle
                progressBar1.Value = 0;//progressbarın değerini sıfırla
                saniye += 3;//atık kutusu boşaltıldığı için süreye 3 saniye ekle
            }
        }
        private void button8_Click(object sender, EventArgs e)//boşalt butonu
        {
            if (progressBar2.Value >= 900)//progressbar1 in değeri 1200 ün %75 inden büyük veya eşitse 
            {
                listBox2.Items.Clear();//listbox2 deki itemsleri temizle
                progressBar2.Value = 0;//progressbarın değerini sıfırla
                puan += 1000;//kağıt atık boşlatıldığından puana 1000 puan ekle
                label4.Text = puan.ToString();//label4 yani puan değişkenine yeni puanı yaz
                saniye += 3;//atık kutusu boşaltıldığı için süreye 3 saniye ekle
            }
        }
        private void button6_Click(object sender, EventArgs e)//boşalt butonu
        {
            if (progressBar3.Value >= 1650)//progressbar1 in değeri 2200 ün %75 inden büyük veya eşitse 
            {
                listBox3.Items.Clear();//listbox3 deki itemsleri temizle
                progressBar3.Value = 0;//progressbarın değerini sıfırla
                puan += 600;//cam atık boşlatıldığından puana 600 puan ekle
                label4.Text = puan.ToString();////label4 yani puan değişkenine yeni puanı yaz
                saniye += 3;//atık kutusu boşaltıldığı için süreye 3 saniye ekle
            }
        }
        private void button10_Click(object sender, EventArgs e)//boşalt butonu
        {
            if (progressBar4.Value >= 1725)//progressbar1 in değeri 2300 ün %75 inden büyük veya eşitse 
            {
                listBox4.Items.Clear();//listbox4 deki itemsleri temizle
                progressBar4.Value = 0;//progressbarın değerini sıfırla
                puan += 800;//metal atık boşlatıldığından puana 800 puan ekle
                label4.Text = puan.ToString();//label4 yani puan değişkenine yeni puanı yaz
                saniye += 3;//atık kutusu boşaltıldığı için süreye 3 saniye ekle
            }
        }
        private void button8_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
