//Penerapan inheritance dan Polymorphism

using System;

namespace AplikasiBank
{
    public class RekeningTabungan : Rekening
    {
        public double SukuBungaPertahun { get; set; }

        public RekeningTabungan(string nomorRekening, string namaPemilik, decimal saldoAwal, double sukuBungaPertahun)
            : base(nomorRekening, namaPemilik, saldoAwal)
        {
            SukuBungaPertahun = sukuBungaPertahun;
        }

        public override void TarikUang(decimal jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("[ERROR] Jumlah tarik harus lebih dari 0.");
                return;
            }

            if (jumlah > Saldo)
            {
                Console.WriteLine("[GAGAL] Saldo Tabungan tidak mencukupi!");
                return;
            }

            Saldo -= jumlah;
            Console.WriteLine($"[SUKSES] Tarik {jumlah:C0} dari Tabungan berhasil. Sisa Saldo: {Saldo:C0}");
        }

        public override void HitungBungaHarian()
        {
            if (Saldo > 0)
            {
                decimal bungaHarian = Saldo * (decimal)(SukuBungaPertahun / 365.0);
                Saldo += bungaHarian;
                Console.WriteLine($"[BUNGA HARIAN] +{bungaHarian:C2} ditambahkan ke {NomorRekening}. Saldo Baru: {Saldo:C2}");
            }
        }

        public override void TampilkanInformasi()
        {
            Console.WriteLine("=== REKENING TABUNGAN ===");
            base.TampilkanInformasi();
            Console.WriteLine($"Suku Bunga     : {SukuBungaPertahun * 100}% / tahun");
        }
    }
}