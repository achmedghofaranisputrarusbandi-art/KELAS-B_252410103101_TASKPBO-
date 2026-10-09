using System;
using System.Collections.Generic;

namespace SistemPerpustakaan
{
    // ===== Kelas dasar =====
    public class Item
    {
        public string Judul { get; set; }
        public int Tahun { get; set; }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual void Deskripsi()
        {
            Console.WriteLine($"Item: {Judul} ({Tahun})");
        }

        public void InfoItem()
        {
            Console.WriteLine($"Judul: {Judul}, Tahun: {Tahun}");
        }
    }

    // ===== Buku =====
    public class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public void CekPenulis()
        {
            Console.WriteLine($"Penulis buku '{Judul}' adalah {Penulis}");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Buku: {Judul} ({Tahun}) - Penulis: {Penulis}");
        }
    }

    public class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void BacaSinopsis()
        {
            Console.WriteLine($"Sinopsis novel '{Judul}': sebuah cerita fiksi karya {Penulis}.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Novel: {Judul} ({Tahun}) - Penulis: {Penulis}");
        }
    }

    public class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine($"Menampilkan ilustrasi dari komik '{Judul}'.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Komik: {Judul} ({Tahun}) - Penulis: {Penulis}");
        }
    }

    // ===== Majalah =====
    public class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public void InfoEdisi()
        {
            Console.WriteLine($"Majalah '{Judul}' edisi ke-{Edisi}");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah: {Judul} ({Tahun}) - Edisi {Edisi}");
        }
    }

    public class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void KategoriAnak()
        {
            Console.WriteLine($"'{Judul}' termasuk kategori majalah anak-anak.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah Anak: {Judul} ({Tahun}) - Edisi {Edisi}");
        }
    }

    public class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void TopikTeknologi()
        {
            Console.WriteLine($"'{Judul}' membahas topik teknologi terbaru.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah Teknologi: {Judul} ({Tahun}) - Edisi {Edisi}");
        }
    }

    // ===== Perpustakaan =====
    public class Perpustakaan
    {
        private List<Item> daftarItem = new List<Item>();

        public void TambahItem(Item item)
        {
            daftarItem.Add(item);
            Console.WriteLine($"Item '{item.Judul}' berhasil ditambahkan.");
        }

        public void DaftarItem()
        {
            Console.WriteLine("\n=== Daftar Item Perpustakaan ===");
            foreach (Item item in daftarItem)
            {
                item.Deskripsi();
            }
        }
    }

    // ===== Main =====
    class Program
    {
        static void Main(string[] args)
        {
            // a. Buat objek perpustakaan
            Perpustakaan perpus = new Perpustakaan();

            // b. Buat beberapa objek item
            Novel novel = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
            Komik komik = new Komik("Si Juki", 2012, "Faza Meonk");
            MajalahAnak majAnak = new MajalahAnak("Bobo", 2024, 15);
            MajalahTeknologi majTek = new MajalahTeknologi("Tech Today", 2025, 8);

            // c. Tambahkan ke perpustakaan
            perpus.TambahItem(novel);
            perpus.TambahItem(komik);
            perpus.TambahItem(majAnak);
            perpus.TambahItem(majTek);

            // d. Tampilkan semua data
            perpus.DaftarItem();

            // e. Demonstrasi polymorphism
            Console.WriteLine("\n=== Polymorphism ===");
            Item[] semuaItem = { novel, komik, majAnak, majTek };
            foreach (Item i in semuaItem)
            {
                i.Deskripsi(); // method yang jalan sesuai tipe objek aslinya
            }

            // f. Panggil method khusus
            Console.WriteLine("\n=== Method Khusus ===");
            novel.BacaSinopsis();
            novel.CekPenulis();
            komik.TampilkanIlustrasi();
            majAnak.KategoriAnak();
            majAnak.InfoEdisi();
            majTek.TopikTeknologi();

            // ===== Jawaban soal 1-5 (demonstrasi) =====
            Console.WriteLine("\n=== Soal 1 ===");
            novel.Deskripsi();
            majAnak.Deskripsi();

            Console.WriteLine("\n=== Soal 2 ===");
            novel.BacaSinopsis();

            Console.WriteLine("\n=== Soal 3 ===");
            novel.InfoItem();    // judul & tahun
            novel.CekPenulis();  // penulis

            Console.WriteLine("\n=== Soal 4 ===");
            majTek.TopikTeknologi();

            Console.WriteLine("\n=== Soal 5 ===");
            Item itemKomik = new Komik("Doraemon", 1990, "Fujiko F. Fujio");
            itemKomik.Deskripsi();

            Console.ReadKey();
        }
    }
}
