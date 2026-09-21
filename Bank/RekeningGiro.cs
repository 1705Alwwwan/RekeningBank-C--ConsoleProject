//Penerapan inheritance dan Polymorphism

using System;

namespace AplikasiBank
{
    public class RekeningGiro : Rekening
    {
        public decimal OverdraftLimit { get; set; }
        public double SukuBungaOverdraftHarian { get; set; }

        public RekeningGiro(string nomorRekening, string namaPemilik, decimal saldoAwal, decimal overdraftLimit, double sukuBungaOverdraftHarian = 0.001)
            : base(nomorRekening, namaPemilik, saldoAwal)
        {
            OverdraftLimit = overdraftLimit;
            SukuBungaOverdraftHarian = sukuBungaOverdraftHarian;
        }

        public override void TarikUang(decimal jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("[ERROR] Jumlah tarik harus lebih dari 0.");
                return;
            }

            if (jumlah > (Saldo + OverdraftLimit))
            {
                Console.WriteLine("[GAGAL] Penarikan melebihi batas overdraft Giro!");
                return;
            }

            Saldo -= jumlah;
            Console.WriteLine($"[SUKSES] Tarik {jumlah:C0} dari Giro berhasil. Sisa Saldo: {Saldo:C0}");
        }

        public override void HitungBungaHarian()
        {
            if (Saldo < 0)
            {
                decimal dendaHarian = Math.Abs(Saldo) * (decimal)SukuBungaOverdraftHarian;
                Saldo -= dendaHarian;
                Console.WriteLine($"[DENDA OVERDRAFT] -{dendaHarian:C2} dikenakan pada {NomorRekening}. Saldo Baru: {Saldo:C2}");
            }
        }

        public override void TampilkanInformasi()
        {
            Console.WriteLine("=== REKENING GIRO ===");
            base.TampilkanInformasi();
            Console.WriteLine($"Batas Overdraft: {OverdraftLimit:C0}");
        }
    }
}