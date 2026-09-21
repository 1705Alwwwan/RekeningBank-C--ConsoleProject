using System;
using System.Collections.Generic;

namespace AplikasiBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            RekeningTabungan tabunganBudi = new RekeningTabungan("TAB-001", "Budi Santoso", 1000000, 0.06);
            RekeningGiro giroPT = new RekeningGiro("GIR-001", "PT. Maju Bersama", 500000, 300000, 0.002);

            List<Rekening> daftarRekening = new List<Rekening> { tabunganBudi, giroPT };

            Console.WriteLine("==================================================");
            Console.WriteLine("               KONDISI AWAL REKENING              ");
            Console.WriteLine("==================================================");
            foreach (var r in daftarRekening)
            {
                r.TampilkanInformasi();
                Console.WriteLine();
            }

            // Demo Fitur Transfer
            Console.WriteLine("==================================================");
            Console.WriteLine("               DEMO FITUR TRANSFER                ");
            Console.WriteLine("==================================================");

            tabunganBudi.Transfer(giroPT, 300000);
            giroPT.Transfer(tabunganBudi, 900000);
            giroPT.Transfer(tabunganBudi, 500000); // Gagal: melebih batas overdraft

            // Demo Simulasi Bunga Harian
            Console.WriteLine("\n==================================================");
            Console.WriteLine("      SIMULASI PERJALANAN WAKTU (3 HARI)         ");
            Console.WriteLine("==================================================");

            for (int hari = 1; hari <= 3; hari++)
            {
                Console.WriteLine($"\n>>> HARI KE-{hari} <<<");
                foreach (var r in daftarRekening)
                {
                    r.HitungBungaHarian();
                }
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("               KONDISI AKHIR REKENING             ");
            Console.WriteLine("==================================================");
            foreach (var r in daftarRekening)
            {
                r.TampilkanInformasi();
                Console.WriteLine();
            }
        }
    }
}