using System;
using System.Text;
using System.Text.Json;

public class DanhSachSinhVien {
    public static string duongdandanhsach = "data/danhsachsinhvien.json";
    public static List<Sinhvien> ?danhsach;

    public static void napdulieudanhsach(){
        if(!Directory.Exists("data")){
            Console.WriteLine("Chưa có thư mục data. Tạo thư mục data/");
            Directory.CreateDirectory("data");
        }
        // demo database 
        if(File.Exists(duongdandanhsach)){
            string dulieudanhsach = File.ReadAllText(duongdandanhsach);
            danhsach = JsonSerializer.Deserialize<List<Sinhvien>>(dulieudanhsach);
        } 
        else {
            danhsach = [
                new Sinhvien {masosinhvien = "DH52400001", tensinhvien = "Trường Chinh", diemgpa = 4.0f},
                new Sinhvien {masosinhvien = "DH52400002", tensinhvien = "Nguyễn Gia Bảo", diemgpa = 3.5f},
                new Sinhvien {masosinhvien = "DH52400003", tensinhvien = "Trần Minh Anh", diemgpa = 3.2f},
                new Sinhvien {masosinhvien = "DH52400004", tensinhvien = "Lê Hoàng Nam", diemgpa = 2.8f},
                new Sinhvien {masosinhvien = "DH52400005", tensinhvien = "Phạm Thanh Tùng", diemgpa = 3.7f},
                new Sinhvien {masosinhvien = "DH52400006", tensinhvien = "Hoàng Ngọc Hân", diemgpa = 3.9f},
                new Sinhvien {masosinhvien = "DH52400007", tensinhvien = "Vũ Tuấn Kiệt", diemgpa = 3.0f},
                new Sinhvien {masosinhvien = "DH52400008", tensinhvien = "Đặng Phương Thảo", diemgpa = 3.6f},
                new Sinhvien {masosinhvien = "DH52400009", tensinhvien = "Bùi Đức Anh", diemgpa = 2.5f},
                new Sinhvien {masosinhvien = "DH52400010", tensinhvien = "Đỗ Khánh Linh", diemgpa = 3.8f},
                new Sinhvien {masosinhvien = "DH52400011", tensinhvien = "Ngô Quốc Huy", diemgpa = 3.1f},
                new Sinhvien {masosinhvien = "DH52400012", tensinhvien = "Hồ Thùy Dương", diemgpa = 3.4f},
                new Sinhvien {masosinhvien = "DH52400013", tensinhvien = "Lý Hoàng Long", diemgpa = 2.9f},
                new Sinhvien {masosinhvien = "DH52400014", tensinhvien = "Phan Mai Phương", diemgpa = 3.3f},
                new Sinhvien {masosinhvien = "DH52400015", tensinhvien = "Võ Đình Khang", diemgpa = 3.9f}
            ];
            string dulieujson = JsonSerializer.Serialize(
                danhsach,
                new JsonSerializerOptions { WriteIndented = true }
            );
            File.WriteAllText(duongdandanhsach, dulieujson);
        }
    }

    public static void luudulieudanhsach(){
        string dulieujson = JsonSerializer.Serialize(
            danhsach, 
            new JsonSerializerOptions {
                WriteIndented = true,
            }
        );
        File.WriteAllText(duongdandanhsach, dulieujson, Encoding.UTF8);
    }
}