using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buoi02_DanhSach
{
    // Định nghĩa Node cho danh sách liên kết đơn
    public class Node
    {
        public int Info;
        public Node? Link;
        public Node(int x)
        {
            Info = x;
            Link = null;
        }
    }

    // Định nghĩa DNode cho danh sách liên kết kép
    public class DNode
    {
        public string Data;
        public DNode? Prev;
        public DNode? Next;
        public DNode(string data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }

    // Bài 1: Chèn phần tử vào mảng
    public class Bai1
    {
        public static void run(bool auto = true)
        {
            int[] a;
            int x, k;

            if (auto)
            {
                a = new int[] { 10, 25, 40, 55, 70 };
                x = 35;
                k = 2;
                Console.WriteLine("Mảng ban đầu: " + string.Join(", ", a));
                Console.WriteLine($"Chèn giá trị x = {x} vào vị trí k = {k}");
            }
            else
            {
                Console.Write("Nhập số lượng phần tử n: ");
                if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) n = 5;
                a = new int[n];
                Console.WriteLine("Nhập các phần tử của mảng:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"a[{i}] = ");
                    if (!int.TryParse(Console.ReadLine(), out a[i])) a[i] = (i + 1) * 10;
                }
                Console.WriteLine("Mảng hiện tại: " + string.Join(", ", a));
                Console.Write("Nhập giá trị cần chèn x: ");
                if (!int.TryParse(Console.ReadLine(), out x)) x = 99;
                Console.Write($"Nhập vị trí cần chèn k (0-{a.Length}): ");
                if (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k > a.Length) k = 0;
            }

            int[] tmp = new int[a.Length + 1];
            for (int i = 0; i < k; i++) tmp[i] = a[i];
            tmp[k] = x;
            for (int i = k; i < a.Length; i++) tmp[i + 1] = a[i];
            a = tmp;

            Console.WriteLine("Mảng sau khi chèn: " + string.Join(", ", a));
        }
    }

    // Bài 2: Quản lý nhân viên
    public class Bai2
    {
        public struct Nhanvien
        {
            public string MaNV;
            public string TenNV;
            public int NamSinh;
            public string phongBan;
            public int LuongCD;
            public int Thuong;
            public int ThucLinh() => LuongCD + Thuong;
        }

        public static void run()
        {
            Nhanvien[] dsNV = new Nhanvien[]
            {
                new Nhanvien { MaNV = "NV01", TenNV = "Tru Tiến Lam", NamSinh = 1900, phongBan = "IT", LuongCD = 1400000, Thuong = 200000 },
                new Nhanvien { MaNV = "NV02", TenNV = "Nê Trí Chường", NamSinh = 1950, phongBan = "IT", LuongCD = 1500000, Thuong = 200000 },
                new Nhanvien { MaNV = "NV03", TenNV = "Đặng Thành Đạt", NamSinh = 2000, phongBan = "IT", LuongCD = 1500000, Thuong = 200000 },
            };

            int tongLuong = dsNV.Sum(nv => nv.ThucLinh());
            Console.WriteLine($"Tổng thực lương toàn công ty: {tongLuong:N0} VNĐ");

            int minLuong = dsNV.Min(nv => nv.ThucLinh());
            Console.WriteLine($"Nhân viên có thực lĩnh thấp nhất ({minLuong:N0} VNĐ):");
            foreach (var nv in dsNV.Where(nv => nv.ThucLinh() == minLuong))
            {
                Console.WriteLine($"  - {nv.TenNV} (Mã: {nv.MaNV}, Phòng: {nv.phongBan}, Lương thực lĩnh: {nv.ThucLinh():N0})");
            }

            int demThuong = dsNV.Count(nv => nv.Thuong >= 1200000);
            Console.WriteLine($"Số lượng nhân viên có thưởng >= 1.200.000 VNĐ: {demThuong}");

            var sortedDsNV = dsNV.OrderBy(nv => nv.phongBan).ThenByDescending(nv => nv.MaNV).ToArray();
            Console.WriteLine("Danh sách nhân viên sau khi sắp xếp (Phòng ban ASC, Mã NV DESC):");
            foreach (var nv in sortedDsNV)
            {
                Console.WriteLine($"  - Phòng: {nv.phongBan} | Mã NV: {nv.MaNV} | Tên NV: {nv.TenNV}");
            }

            for (int i = 0; i < dsNV.Length; i++)
            {
                dsNV[i].LuongCD = (int)(dsNV[i].LuongCD * 1.05);
            }

            Console.WriteLine("Danh sách sau khi tăng 5% lương cơ bản:");
            foreach (var nv in dsNV)
            {
                Console.WriteLine($"  - Mã NV: {nv.MaNV} | Tên NV: {nv.TenNV} | Lương CĐ mới: {nv.LuongCD:N0} | Thực lĩnh mới: {nv.ThucLinh():N0}");
            }
        }
    }

    // Bài 3: Xử lý ma trận 2 chiều
    public class Bai3
    {
        public static void run()
        {
            int[,] a =
            {
                { 2, 5, 1 },
                { 4, 8, 9 },
                { 7, 3, 12 }
            };
            int n = 3;

            Console.WriteLine("Ma trận 3x3:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) Console.Write($"{a[i, j],4}");
                Console.WriteLine();
            }

            int tong = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    tong += a[i, j];
            Console.WriteLine($"Tổng các phần tử trong ma trận: {tong}");

            int minDuong = int.MaxValue;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] > 0 && a[i, j] < minDuong)
                        minDuong = a[i, j];
            Console.WriteLine($"Số dương nhỏ nhất trong ma trận: {minDuong}");

            int tongcheo = 0;
            for (int i = 0; i < n; i++)
                tongcheo += a[i, n - 1 - i];
            Console.WriteLine($"Tổng các phần tử trên đường chéo phụ: {tongcheo}");

            bool tangDan = true;
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i, i] >= a[i + 1, i + 1])
                {
                    tangDan = false;
                    break;
                }
            }
            Console.WriteLine($"Đường chéo chính có tăng dần không: {(tangDan ? "Có" : "Không")}");
        }
    }

    // Bài 4: Tìm kiếm và xóa phần tử trên mảng
    public class Bai4
    {
        public static void run()
        {
            int[] a = { -3, 5, 2, 7, 5, 10, -1 };
            Console.WriteLine("Mảng ban đầu: " + string.Join(" ", a));

            int x = 5;
            int dem = a.Count(v => v == x);
            Console.WriteLine($"Số phần tử bằng {x}: {dem}");

            int min = a.Where(v => v > 0).DefaultIfEmpty(-1).Min();
            if (min == -1) Console.WriteLine("Không có số dương trong mảng.");
            else Console.WriteLine($"Số dương nhỏ nhất trong mảng: {min}");

            int index = Array.IndexOf(a, x);
            if (index != -1)
            {
                int[] newa = a.Where((val, idx) => idx != index).ToArray();
                Console.WriteLine($"Mảng sau khi xoá phần tử {x} đầu tiên: " + string.Join(" ", newa));
            }
            else
            {
                Console.WriteLine($"Không tìm thấy {x} để xoá.");
            }
        }
    }

    // Bài 5: Thống kê số nguyên
    public class Bai5
    {
        static bool Songuyen(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        public static void run()
        {
            int[] a = { -4, 2, 3, 5, 0, 7, 12, -8 };
            int x = 3;
            Console.WriteLine("Mảng a: " + string.Join(" ", a));
            Console.WriteLine($"Phần tử lớn nhất: {a.Max()}");
            Console.WriteLine($"Tổng các phần tử: {a.Sum()}");
            Console.WriteLine($"Số phần tử là số nguyên tố: {a.Count(Songuyen)}");
            Console.WriteLine($"Số lượng số dương: {a.Count(v => v > 0)} | Số lượng số âm: {a.Count(v => v < 0)}");
            Console.WriteLine($"Số lượng phần tử bằng {x}: {a.Count(v => v == x)}");

            int minDuong = a.Where(v => v > 0).DefaultIfEmpty(-1).Min();
            if (minDuong == -1) Console.WriteLine("Không có số dương trong mảng.");
            else Console.WriteLine($"Số dương nhỏ nhất trong mảng: {minDuong}");
        }
    }

    // Bài 7: Quản lý nhiệt độ
    public class Bai7
    {
        public static void run(bool auto = true)
        {
            double[] temps;
            if (auto)
            {
                temps = new double[] { 28.5, 30.0, 32.2, 29.8, 27.0, 31.5, 33.0 };
            }
            else
            {
                Console.Write("Nhập số ngày n (hoặc nhấn Enter để dùng mẫu 7 ngày): ");
                string? inp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inp))
                    temps = new double[] { 28.5, 30.0, 32.2, 29.8, 27.0, 31.5, 33.0 };
                else
                {
                    int n = int.Parse(inp);
                    temps = new double[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"Nhiệt độ ngày {i + 1}: ");
                        temps[i] = double.Parse(Console.ReadLine() ?? "0");
                    }
                }
            }

            double max = temps[0], min = temps[0], tong = 0;
            int ngayMax = 1, ngayMin = 1;
            for (int i = 0; i < temps.Length; i++)
            {
                tong += temps[i];
                if (temps[i] > max) { max = temps[i]; ngayMax = i + 1; }
                if (temps[i] < min) { min = temps[i]; ngayMin = i + 1; }
            }

            Console.WriteLine("Dữ liệu nhiệt độ 7 ngày: " + string.Join("°C, ", temps) + "°C");
            Console.WriteLine($"- Ngày nhiệt độ cao nhất: Ngày {ngayMax} ({max}°C)");
            Console.WriteLine($"- Ngày nhiệt độ thấp nhất: Ngày {ngayMin} ({min}°C)");
            Console.WriteLine($"- Nhiệt độ trung bình: {(tong / temps.Length):F2}°C");
        }
    }

    // Bài 8: Thống kê tần suất từ
    public class Bai8
    {
        public static void run(bool auto = true)
        {
            string text = "Học cấu trúc dữ liệu và giải thuật, học lập trình C# rất thú vị!";
            if (!auto)
            {
                Console.Write("Nhập chuỗi văn bản (Enter để dùng mẫu): ");
                string? inp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inp)) text = inp;
            }

            StringBuilder sb = new StringBuilder();
            foreach (char c in text.ToLower())
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)) sb.Append(c);
            }

            string[] words = sb.ToString().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> freq = new Dictionary<string, int>();
            foreach (string w in words)
            {
                if (freq.ContainsKey(w)) freq[w]++;
                else freq[w] = 1;
            }

            Console.WriteLine($"Văn bản: \"{text}\"");
            Console.WriteLine("Tần suất xuất hiện của từng từ:");
            foreach (var item in freq.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"  - {item.Key,-15}: {item.Value} lần");
            }
        }
    }

    // Bài 9: Xử lý số nguyên nâng cao
    public class Bai9
    {
        static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++) if (n % i == 0) return false;
            return true;
        }

        static bool LaSoHoanHao(int n)
        {
            if (n <= 1) return false;
            int sum = 1;
            for (int i = 2; i <= n / 2; i++) if (n % i == 0) sum += i;
            return sum == n;
        }

        public static void run(bool auto = true)
        {
            int[] arr = { 2, 6, 7, 10, 13, 28, 15, 4, 29 };
            if (!auto)
            {
                Console.Write("Nhập dãy số nguyên cách nhau dấu cách (Enter dùng mẫu): ");
                string? inp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inp))
                    arr = inp.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            Console.WriteLine("Dãy số: " + string.Join(" ", arr));
            Console.WriteLine("- Các số nguyên tố: " + string.Join(", ", arr.Where(LaSoNguyenTo)));
            Console.WriteLine("- Các số chẵn:      " + string.Join(", ", arr.Where(x => x % 2 == 0)));
            Console.WriteLine("- Các số hoàn hảo:  " + string.Join(", ", arr.Where(LaSoHoanHao)));
        }
    }

    // Bài 10: Ma trận xoắn ốc
    public class Bai10
    {
        public static void run()
        {
            int[,] mat = {
                {  1,  2,  3,  4 },
                {  5,  6,  7,  8 },
                {  9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };

            int m = mat.GetLength(0), n = mat.GetLength(1);
            Console.WriteLine("Ma trận gốc 4x4:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++) Console.Write($"{mat[i, j],4}");
                Console.WriteLine();
            }

            int top = 0, bottom = m - 1, left = 0, right = n - 1;
            List<int> result = new List<int>();
            while (top <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++) result.Add(mat[top, i]);
                top++;

                for (int i = top; i <= bottom; i++) result.Add(mat[i, right]);
                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--) result.Add(mat[bottom, i]);
                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--) result.Add(mat[i, left]);
                    left++;
                }
            }
            Console.WriteLine("Thứ tự duyệt xoắn ốc: " + string.Join(" -> ", result));
        }
    }

    // Bài 11: Kiểm tra ma trận đặc biệt
    public class Bai11
    {
        static bool LaMaTranDonVi(int[,] a)
        {
            int n = a.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if ((i == j && a[i, j] != 1) || (i != j && a[i, j] != 0)) return false;
            return true;
        }

        static bool LaMaTranDoiXung(int[,] a)
        {
            int n = a.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (a[i, j] != a[j, i]) return false;
            return true;
        }

        public static void run()
        {
            int[,] m1 = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] m2 = { { 1, 2, 3 }, { 2, 4, 5 }, { 3, 5, 6 } };

            Console.WriteLine($"Ma trận m1 -> Đơn vị: {LaMaTranDonVi(m1)}, Đối xứng: {LaMaTranDoiXung(m1)}");
            Console.WriteLine($"Ma trận m2 -> Đơn vị: {LaMaTranDonVi(m2)}, Đối xứng: {LaMaTranDoiXung(m2)}");
        }
    }

    // Bài 12: Trò chơi Minesweeper
    public class Bai12
    {
        public static void run(bool auto = true)
        {
            int m = 5, n = 5;
            if (!auto)
            {
                Console.Write("Nhập số dòng m (mặc định 5): ");
                string? sm = Console.ReadLine();
                m = string.IsNullOrWhiteSpace(sm) ? 5 : int.Parse(sm);
                Console.Write("Nhập số cột n (mặc định 5): ");
                string? sn = Console.ReadLine();
                n = string.IsNullOrWhiteSpace(sn) ? 5 : int.Parse(sn);
            }

            int soMin = (m * n) / 5;
            char[,] board = new char[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++) board[i, j] = '.';

            Random rnd = new Random(12345); // Seed cố định để kết quả chạy ổn định
            int placed = 0;
            while (placed < soMin)
            {
                int r = rnd.Next(m), c = rnd.Next(n);
                if (board[r, c] != '*') { board[r, c] = '*'; placed++; }
            }

            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            Console.WriteLine($"Bảng Minesweeper {m}x{n} ({soMin} mìn):");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == '*') Console.Write(" * ");
                    else
                    {
                        int count = 0;
                        for (int k = 0; k < 8; k++)
                        {
                            int ni = i + dx[k], nj = j + dy[k];
                            if (ni >= 0 && ni < m && nj >= 0 && nj < n && board[ni, nj] == '*') count++;
                        }
                        Console.Write($" {count} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    // Bài 13: Đảo ngược DSLK đơn
    public class Bai13
    {
        static void ThemCuoi(ref Node? head, int x)
        {
            Node newNode = new Node(x);
            if (head == null) { head = newNode; return; }
            Node p = head;
            while (p.Link != null) p = p.Link;
            p.Link = newNode;
        }

        static void InDSLK(Node? head)
        {
            Node? p = head;
            while (p != null) { Console.Write(p.Info + " -> "); p = p.Link; }
            Console.WriteLine("null");
        }

        static Node? DaoNguoc(Node? head)
        {
            Node? prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.Link;
                current.Link = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public static void run()
        {
            Node? head = null;
            foreach (int x in new[] { 10, 20, 30, 40, 50 }) ThemCuoi(ref head, x);

            Console.Write("Ban đầu:   "); InDSLK(head);
            head = DaoNguoc(head);
            Console.Write("Đảo ngược: "); InDSLK(head);
        }
    }

    // Bài 14: Gộp hai DSLK đã sắp xếp
    public class Bai14
    {
        static void ThemCuoi(ref Node? head, int x)
        {
            Node newNode = new Node(x);
            if (head == null) { head = newNode; return; }
            Node p = head;
            while (p.Link != null) p = p.Link;
            p.Link = newNode;
        }

        static void InDSLK(Node? head)
        {
            Node? p = head;
            while (p != null) { Console.Write(p.Info + " -> "); p = p.Link; }
            Console.WriteLine("null");
        }

        static Node? GopHaiDSLK(Node? l1, Node? l2)
        {
            Node dummy = new Node(0);
            Node tail = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.Info <= l2.Info)
                {
                    tail.Link = l1;
                    l1 = l1.Link;
                }
                else
                {
                    tail.Link = l2;
                    l2 = l2.Link;
                }
                tail = tail.Link;
            }
            tail.Link = (l1 != null) ? l1 : l2;
            return dummy.Link;
        }

        public static void run()
        {
            Node? l1 = null, l2 = null;
            foreach (int x in new[] { 1, 4, 7, 10 }) ThemCuoi(ref l1, x);
            foreach (int x in new[] { 2, 3, 6, 8, 12 }) ThemCuoi(ref l2, x);

            Console.Write("Danh sách 1: "); InDSLK(l1);
            Console.Write("Danh sách 2: "); InDSLK(l2);
            Node? merged = GopHaiDSLK(l1, l2);
            Console.Write("Sau khi gộp: "); InDSLK(merged);
        }
    }

    // Bài 15: Phát hiện chu trình (Floyd)
    public class Bai15
    {
        static void ThemCuoi(ref Node? head, int x)
        {
            Node newNode = new Node(x);
            if (head == null) { head = newNode; return; }
            Node p = head;
            while (p.Link != null) p = p.Link;
            p.Link = newNode;
        }

        static bool CoChuTrinh(Node? head)
        {
            Node? slow = head, fast = head;
            while (fast != null && fast.Link != null)
            {
                slow = slow?.Link;
                fast = fast.Link.Link;
                if (slow == fast) return true;
            }
            return false;
        }

        public static void run()
        {
            Node n2 = new Node(2), n3 = new Node(3), n4 = new Node(4), n5 = new Node(5), n6 = new Node(6);
            n2.Link = n3; n3.Link = n4; n4.Link = n5; n5.Link = n6; n6.Link = n2;

            Node? listThuong = null;
            foreach (int x in new[] { 1, 2, 3, 4 }) ThemCuoi(ref listThuong, x);

            Console.WriteLine($"Danh sách 1 (2 -> 3 -> 4 -> 5 -> 6 -> 2 [vòng]) có chu trình: {CoChuTrinh(n2)}");
            Console.WriteLine($"Danh sách 2 (1 -> 2 -> 3 -> 4 -> null) có chu trình: {CoChuTrinh(listThuong)}");
        }
    }

    // Bài 16: Lịch sử duyệt web (DSLK kép)
    public class Bai16
    {
        public static void run(bool auto = true)
        {
            DNode current = new DNode("google.com");

            void Visit(string url)
            {
                DNode newNode = new DNode(url);
                current.Next = newNode;
                newNode.Prev = current;
                current = newNode;
                Console.WriteLine($"Truy cập trang mới: {current.Data}");
            }

            Console.WriteLine($"Trang khởi tạo: {current.Data}");
            Visit("github.com");
            Visit("utehy.edu.vn");

            if (auto)
            {
                Console.WriteLine("\n[Mô phỏng điều hướng]");
                if (current.Prev != null)
                {
                    current = current.Prev;
                    Console.WriteLine($"Thao tác Back -> {current.Data}");
                }
                if (current.Prev != null)
                {
                    current = current.Prev;
                    Console.WriteLine($"Thao tác Back -> {current.Data}");
                }
                if (current.Next != null)
                {
                    current = current.Next;
                    Console.WriteLine($"Thao tác Forward -> {current.Data}");
                }
                Console.WriteLine($"Trang hiện tại kết thúc: [{current.Data}]");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine($"\nTrang hiện tại: [{current.Data}]");
                    Console.WriteLine("1. Truy cập trang mới | 2. Back | 3. Forward | 0. Quay lại");
                    Console.Write("Chọn: ");
                    string? c = Console.ReadLine();
                    if (c == "1") { Console.Write("Nhập URL: "); Visit(Console.ReadLine() ?? ""); }
                    else if (c == "2")
                    {
                        if (current.Prev != null) { current = current.Prev; Console.WriteLine($"Back -> {current.Data}"); }
                        else Console.WriteLine("Không thể Back thêm!");
                    }
                    else if (c == "3")
                    {
                        if (current.Next != null) { current = current.Next; Console.WriteLine($"Forward -> {current.Data}"); }
                        else Console.WriteLine("Không thể Forward thêm!");
                    }
                    else if (c == "0") return;
                }
            }
        }
    }

    // Bài 17: Playlist nhạc (DSLK kép)
    public class Bai17
    {
        public static void run(bool auto = true)
        {
            DNode? head = null, tail = null, current = null;

            void ThemBai(string ten)
            {
                DNode node = new DNode(ten);
                if (head == null) { head = tail = current = node; }
                else { tail!.Next = node; node.Prev = tail; tail = node; }
            }

            ThemBai("Lạc Trôi - Sơn Tùng M-TP");
            ThemBai("Nàng Thơ - Hoàng Dũng");
            ThemBai("Cắt Đôi Nỗi Sầu - Tăng Duy Tân");

            Console.WriteLine("Khởi tạo playlist:");
            DNode? p = head;
            int idx = 1;
            while (p != null) { Console.WriteLine($"  {idx++}. {p.Data}"); p = p.Next; }

            if (auto)
            {
                Console.WriteLine("\n[Mô phỏng phát nhạc]");
                Console.WriteLine($"Đang phát: {current?.Data}");
                if (current?.Next != null)
                {
                    current = current.Next;
                    Console.WriteLine($"Next bài hát -> Đang phát: {current.Data}");
                }
                Console.WriteLine("Thêm bài: Chúng Ta Của Tương Lai");
                ThemBai("Chúng Ta Của Tương Lai - Sơn Tùng M-TP");
                Console.WriteLine($"Xóa bài đang phát ({current?.Data})");
                if (current != null)
                {
                    if (current.Prev != null) current.Prev.Next = current.Next; else head = current.Next;
                    if (current.Next != null) current.Next.Prev = current.Prev; else tail = current.Prev;
                    current = current.Next ?? current.Prev;
                }
                Console.WriteLine($"Đang phát bài thay thế: {current?.Data}");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine($"\nĐang phát: {(current != null ? current.Data : "Trống")}");
                    Console.WriteLine("1. Next | 2. Previous | 3. Thêm bài | 4. Xóa bài đang phát | 0. Quay lại");
                    Console.Write("Chọn: ");
                    string? c = Console.ReadLine();
                    if (c == "1")
                    {
                        if (current?.Next != null) current = current.Next;
                        else Console.WriteLine("Đã ở cuối playlist!");
                    }
                    else if (c == "2")
                    {
                        if (current?.Prev != null) current = current.Prev;
                        else Console.WriteLine("Đã ở đầu playlist!");
                    }
                    else if (c == "3")
                    {
                        Console.Write("Tên bài hát: "); ThemBai(Console.ReadLine() ?? "");
                        Console.WriteLine("Đã thêm vào cuối playlist!");
                    }
                    else if (c == "4" && current != null)
                    {
                        Console.WriteLine($"Đã xóa: {current.Data}");
                        if (current.Prev != null) current.Prev.Next = current.Next; else head = current.Next;
                        if (current.Next != null) current.Next.Prev = current.Prev; else tail = current.Prev;
                        current = current.Next ?? current.Prev;
                    }
                    else if (c == "0") return;
                }
            }
        }
    }

    // Bài 18: Hệ thống đặt hàng (DSLK kép)
    public class Bai18
    {
        public static void run(bool auto = true)
        {
            DNode s1 = new DNode("Chờ xử lý");
            DNode s2 = new DNode("Đang giao");
            DNode s3 = new DNode("Hoàn thành");
            s1.Next = s2; s2.Prev = s1;
            s2.Next = s3; s3.Prev = s2;

            DNode trangThaiHienTai = s1;
            string maDon = "DH_12425044";

            Console.WriteLine($"Đơn hàng [{maDon}] - Khởi tạo trạng thái: >>> {trangThaiHienTai.Data} <<<");

            if (auto)
            {
                Console.WriteLine("\n[Mô phỏng chuyển đổi trạng thái đơn hàng]");
                if (trangThaiHienTai.Next != null)
                {
                    trangThaiHienTai = trangThaiHienTai.Next;
                    Console.WriteLine($"Chuyển bước tiếp theo: >>> {trangThaiHienTai.Data} <<<");
                }
                if (trangThaiHienTai.Next != null)
                {
                    trangThaiHienTai = trangThaiHienTai.Next;
                    Console.WriteLine($"Chuyển bước tiếp theo: >>> {trangThaiHienTai.Data} <<<");
                }
                if (trangThaiHienTai.Prev != null)
                {
                    trangThaiHienTai = trangThaiHienTai.Prev;
                    Console.WriteLine($"Lùi lại bước trước: >>> {trangThaiHienTai.Data} <<<");
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine($"\nĐơn hàng [{maDon}] - Trạng thái hiện tại: >>> {trangThaiHienTai.Data} <<<");
                    Console.WriteLine("1. Chuyển trạng thái tiếp theo | 2. Lùi lại trạng thái trước | 0. Quay lại");
                    Console.Write("Chọn: ");
                    string? c = Console.ReadLine();
                    if (c == "1")
                    {
                        if (trangThaiHienTai.Next != null) trangThaiHienTai = trangThaiHienTai.Next;
                        else Console.WriteLine("Đơn hàng đã hoàn thành!");
                    }
                    else if (c == "2")
                    {
                        if (trangThaiHienTai.Prev != null) trangThaiHienTai = trangThaiHienTai.Prev;
                        else Console.WriteLine("Đơn hàng đang ở trạng thái ban đầu!");
                    }
                    else if (c == "0") return;
                }
            }
        }
    }

    class Program
    {
        static void ChayTatCa()
        {
            Console.WriteLine("=== Bài 1: Chèn phần tử vào mảng ===");
            Bai1.run(auto: true);

            Console.WriteLine("\n=== Bài 2: Quản lý nhân viên ===");
            Bai2.run();

            Console.WriteLine("\n=== Bài 3: Xử lý ma trận 2 chiều ===");
            Bai3.run();

            Console.WriteLine("\n=== Bài 4: Tìm kiếm và xóa phần tử trên mảng ===");
            Bai4.run();

            Console.WriteLine("\n=== Bài 5: Thống kê số nguyên ===");
            Bai5.run();

            Console.WriteLine("\n=== Bài 7: Quản lý nhiệt độ ===");
            Bai7.run(auto: true);

            Console.WriteLine("\n=== Bài 8: Thống kê tần suất từ ===");
            Bai8.run(auto: true);

            Console.WriteLine("\n=== Bài 9: Xử lý số nguyên nâng cao ===");
            Bai9.run(auto: true);

            Console.WriteLine("\n=== Bài 10: Ma trận xoắn ốc ===");
            Bai10.run();

            Console.WriteLine("\n=== Bài 11: Kiểm tra ma trận đặc biệt ===");
            Bai11.run();

            Console.WriteLine("\n=== Bài 12: Trò chơi Minesweeper ===");
            Bai12.run(auto: true);

            Console.WriteLine("\n=== Bài 13: Đảo ngược DSLK đơn ===");
            Bai13.run();

            Console.WriteLine("\n=== Bài 14: Gộp hai DSLK đã sắp xếp ===");
            Bai14.run();

            Console.WriteLine("\n=== Bài 15: Phát hiện chu trình (Floyd) ===");
            Bai15.run();

            Console.WriteLine("\n=== Bài 16: Lịch sử duyệt web (DSLK kép) ===");
            Bai16.run(auto: true);

            Console.WriteLine("\n=== Bài 17: Playlist nhạc (DSLK kép) ===");
            Bai17.run(auto: true);

            Console.WriteLine("\n=== Bài 18: Hệ thống đặt hàng (DSLK kép) ===");
            Bai18.run(auto: true);
        }

        static void ChayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- CHƯƠNG TRÌNH BÀI TẬP ÁP DỤNG CTDL&GT (BUỔI 02 - DANH SÁCH) ---");
                Console.WriteLine("1. Bài 1: Chèn phần tử vào mảng");
                Console.WriteLine("2. Bài 2: Quản lý nhân viên");
                Console.WriteLine("3. Bài 3: Xử lý ma trận 2 chiều");
                Console.WriteLine("4. Bài 4: Tìm kiếm và xóa phần tử trên mảng");
                Console.WriteLine("5. Bài 5: Thống kê số nguyên (Nguyên tố, âm, dương...)");
                Console.WriteLine("7. Bài 7: Quản lý nhiệt độ");
                Console.WriteLine("8. Bài 8: Thống kê tần suất từ");
                Console.WriteLine("9. Bài 9: Xử lý số nguyên nâng cao (Số hoàn hảo, nguyên tố)");
                Console.WriteLine("10. Bài 10: Ma trận xoắn ốc");
                Console.WriteLine("11. Bài 11: Kiểm tra ma trận đặc biệt");
                Console.WriteLine("12. Bài 12: Trò chơi Minesweeper");
                Console.WriteLine("13. Bài 13: Đảo ngược danh sách liên kết đơn");
                Console.WriteLine("14. Bài 14: Gộp hai danh sách liên kết đã sắp xếp");
                Console.WriteLine("15. Bài 15: Phát hiện chu trình (Floyd)");
                Console.WriteLine("16. Bài 16: Lịch sử duyệt web (DSLKK)");
                Console.WriteLine("17. Bài 17: Playlist nhạc (DSLKK)");
                Console.WriteLine("18. Bài 18: Hệ thống đặt hàng (DSLKK)");
                Console.WriteLine("A. Chạy tất cả các bài");
                Console.WriteLine("0. Thoát");
                Console.Write("Nhập lựa chọn của bạn: ");
                string? choice = Console.ReadLine();
                Console.WriteLine();
                if (choice == "0") break;
                switch (choice?.ToUpper())
                {
                    case "1": Bai1.run(auto: false); break;
                    case "2": Bai2.run(); break;
                    case "3": Bai3.run(); break;
                    case "4": Bai4.run(); break;
                    case "5": Bai5.run(); break;
                    case "7": Bai7.run(auto: false); break;
                    case "8": Bai8.run(auto: false); break;
                    case "9": Bai9.run(auto: false); break;
                    case "10": Bai10.run(); break;
                    case "11": Bai11.run(); break;
                    case "12": Bai12.run(auto: false); break;
                    case "13": Bai13.run(); break;
                    case "14": Bai14.run(); break;
                    case "15": Bai15.run(); break;
                    case "16": Bai16.run(auto: false); break;
                    case "17": Bai17.run(auto: false); break;
                    case "18": Bai18.run(auto: false); break;
                    case "A": ChayTatCa(); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            if (args.Length > 0 && args[0].ToLower() == "menu")
            {
                ChayMenu();
            }
            else
            {
                ChayTatCa();
            }
        }
    }
}
