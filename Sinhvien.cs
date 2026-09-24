public class Sinhvien {
    public string tensinhvien { get; set; }
    public string masosinhvien { get; set; }
    public float diemgpa { get; set; }

    public Sinhvien(){
        this.tensinhvien = "";
        this.masosinhvien = "";
        this.diemgpa = 0f;
    }

    public Sinhvien(string tensinhvien, string masosinhvien, float diemgpa){
        this.tensinhvien = tensinhvien;
        this.masosinhvien = masosinhvien;
        this.diemgpa = diemgpa;
    }
}