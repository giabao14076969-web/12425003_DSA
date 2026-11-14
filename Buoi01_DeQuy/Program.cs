using System;

namespace Buoi01_DeQuy
{
    class Program
    {
        // Bài 1: Tính S1(n) = 1 + 2 + ... + n
        static int S1(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return S1(n - 1) + n;
        }

        // Bài 2: Tính S2(n) = 1^2 + 2^2 + ... + n^2
        static int S2(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return S2(n - 1) + n * n;
        }

        // Bài 3: Tính S3(n) = 1 + 1/2 + ... + 1/n
        static double S3(int n)
        {
            if (n == 1) return 1;
            return S3(n - 1) + 1.0 / n;
        }

        // Bài 4: Tính x^n
        static double LuyThua(double x, int n)
        {
            if (n == 0) return 1;
            else if (n < 0) return 1.0 / LuyThua(x, -n);
            return LuyThua(x, n - 1) * x;
        }

        // Bài 5: Tìm ước số lẻ lớn nhất của n
        static int S4(int n)
        {
            if (n % 2 == 1) return 1;
            return S4(n / 2);
        }

        // Bài 6: Tìm ước số chung lớn nhất (UCLN) của a và b
        static int S5(int a, int b)
        {
            if (a % b == 0) return b;
            return S5(b, a % b);
        }

        // Bài 7: Đếm số chữ số của số nguyên dương n
        static int S6(int n)
        {
            if (n == 0) return 0;
            return S6(n / 10) + 1;
        }

        // Bài 8: Tính căn bậc 2 lồng nhau
        static float Can(int i, int n)
        {
            if (i == n) return (float)Math.Sqrt(n);
            return i + Can(i + 1, n);
        }

        static float S7(int n)
        {
            return Can(1, n);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== KẾT QUẢ CHẠY THỬ CÁC HÀM ĐỆ QUY ===");
            Console.WriteLine($"1. S1(5) = {S1(5)}");
            Console.WriteLine($"2. S2(3) = {S2(3)}");
            Console.WriteLine($"3. S3(3) = {S3(3)}");
            Console.WriteLine($"4. LuyThua(2, 3) = {LuyThua(2, 3)}");
            Console.WriteLine($"5. S4(100) (Ước lẻ lớn nhất của 100) = {S4(100)}");
            Console.WriteLine($"6. S5(24, 18) (UCLN) = {S5(24, 18)}");
            Console.WriteLine($"7. S6(12345) (Số chữ số của 12345) = {S6(12345)}");
            Console.WriteLine($"8. S7(3) (Căn lồng nhau với n = 3) = {S7(3)}");
        }
    }
}
