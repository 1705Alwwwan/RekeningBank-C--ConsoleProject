# 🏦 Aplikasi Simulasi Rekening Bank (OOP C#)

Aplikasi konsol berbasis **C#** yang mensimulasikan sistem pengelolaan rekening bank (Tabungan dan Giro) dengan menerapkan prinsip-prinsip utama **Object-Oriented Programming (OOP)** seperti *Abstraction*, *Encapsulation*, *Inheritance*, dan *Polymorphism*.

---

## 📌 Fitur Utama

- **Rekening Tabungan (`RekeningTabungan`)**:
  - Penarikan terbatas pada jumlah saldo yang tersedia.
  - Perhitungan akumulasi bunga harian berdasarkan suku bunga tahunan.
- **Rekening Giro (`RekeningGiro`)**:
  - Fasilitas *Overdraft* (saldo bisa negatif hingga batas tertentu).
  - Pengenaan denda harian jika saldo berada dalam kondisi *overdraft*.
- **Transaksi & Transfer**:
  - Setor tunai dan tarik tunai.
  - Transfer antar-rekening dengan validasi keamanan (mencegah transfer ke diri sendiri atau melebihi batas saldo/overdraft).
- **Simulasi Waktu**:
  - Simulasi perhitungan bunga dan denda harian selama kurun waktu tertentu.

---

## 🧩 Implementasi Konsep OOP

Project ini dirancang untuk mendemonstrasikan pilar utama OOP:

| Konsep OOP | Implementasi pada Kode |
| :--- | :--- |
| **Abstraction** | Menggunakan `interface ITransaksi` dan `abstract class Rekening` sebagai cetak biru operasi perbankan. |
| **Encapsulation** | Penggunaan `private` field (`_saldo`, `_nomorRekening`, `_namaPemilik`) dengan akses terkontrol via `properties`. |
| **Inheritance** | Class `RekeningTabungan` dan `RekeningGiro` menginduk ke `abstract class Rekening`. |
| **Polymorphism** | Penggunaan `virtual` dan `override` pada method `TarikUang()`, `HitungBungaHarian()`, dan `TampilkanInformasi()`. |

---

## 🛠️ Teknologi yang Digunakan

- **Bahasa Pemrograman**: C#
- **Framework Target**: .NET Core / .NET SDK (6.0 / 7.0 / 8.0)
- **Tipe Aplikasi**: Console Application

---

## 🚀 Cara Menjalankan Project

### Prasyarat
Pastikan kamu sudah menginstal [.NET SDK](https://dotnet.microsoft.com/download) di komputer kamu.

### Langkah-langkah
1. **Clone repository ini:**
   ```bash
   git clone [https://github.com/username/repository-kamu.git](https://github.com/username/repository-kamu.git)
   cd repository-kamu
