//Interface yang mendefinisikan abstarksi

using System;

namespace AplikasiBank
{
    public interface ITransaksi
    {
        void SetorUang(decimal jumlah);
        void TarikUang(decimal jumlah);
        bool Transfer(Rekening rekeningTujuan, decimal jumlah);
    }
}