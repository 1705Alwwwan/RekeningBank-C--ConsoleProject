// Penerapan Abstarksi dan Enkapsulasi 

using System;

namespace AplikasiBank
{
    public abstract class Rekening : ITransaksi
    {
        private string _nomorRekening;
        private string _namaPemilik;
        private decimal _saldo;

        public Rekening(string nomorRekening, string namaPemilik, decimal saldoAwal)
        {
            _nomorRekening = nomorRekening;
            _namaPemilik = namaPemilik;
            _saldo = saldoAwal;
        }

        public string NomorRekening => _nomorRekening;

        public string NamaPemilik
        {
            get => _namaPemilik;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("[GAGAL] Nama pemilik tidak boleh kosong.");
                else
                    _namaPemilik = value;
            }
        }

        public decimal Saldo
        {
            get => _saldo;
            protected set => _saldo = value;
        }

        public virtual void SetorUang(decimal jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("[ERROR] Jumlah setor harus lebih dari 0.");
                return;
            }

            Saldo += jumlah;
            Console.WriteLine($"[SUKSES] Setor {jumlah:C0} ke {NomorRekening} ({NamaPemilik}). Saldo saat ini: {Saldo:C0}");
        }

        public abstract void TarikUang(decimal jumlah);

        public abstract void HitungBungaHarian();

        public virtual bool Transfer(Rekening rekeningTujuan, decimal jumlah)
        {
            if (rekeningTujuan == null)
            {
                Console.WriteLine("[ERROR] Rekening tujuan tidak valid!");
                return false;
            }

            if (rekeningTujuan == this)
            {
                Console.WriteLine("[ERROR] Tidak dapat melakukan transfer ke rekening sendiri!");
                return false;
            }

            Console.WriteLine($"\n--- Memproses Transfer {jumlah:C0} dari {NomorRekening} ({NamaPemilik}) -> {rekeningTujuan.NomorRekening} ({rekeningTujuan.NamaPemilik}) ---");

            decimal saldoAwal = Saldo;
            TarikUang(jumlah);

            if (Saldo < saldoAwal)
            {
                rekeningTujuan.SetorUang(jumlah);
                Console.WriteLine($"[TRANSFER SUKSES] Transfer sebesar {jumlah:C0} berhasil dikirim ke {rekeningTujuan.NamaPemilik}.");
                return true;
            }

            Console.WriteLine("[TRANSFER GAGAL] Transaksi dibatalkan.");
            return false;
        }

        public virtual void TampilkanInformasi()
        {
            Console.WriteLine($"Nomor Rekening : {NomorRekening}");
            Console.WriteLine($"Nama Pemilik   : {NamaPemilik}");
            Console.WriteLine($"Saldo          : {Saldo:C0}");
        }
    }
}