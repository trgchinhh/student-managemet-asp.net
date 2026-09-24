using System.Text.Json;

var app = WebApplication.CreateBuilder(args).Build(); 
 
app.UseDefaultFiles(); 
app.UseStaticFiles(); 

// nạp database 
DanhSachSinhVien.napdulieudanhsach();

// lấy thông tin 1 sinh viên  
app.MapGet("/sinhvien/{masosinhvien}", (string masosinhvien) => { 
    Sinhvien? sinhvien = DanhSachSinhVien.danhsach.FirstOrDefault( 
        x => x.masosinhvien == masosinhvien 
    ); 
    if(sinhvien == null){ 
        return Results.NotFound(); 
    } 
    return Results.Ok(sinhvien); 
}); 
 
// thêm thông tin sinh viên  
app.MapPost("/sinhvien", (Sinhvien sinhvien) => { 
    DanhSachSinhVien.danhsach.Add(sinhvien); 
    DanhSachSinhVien.luudulieudanhsach();
    return Results.Ok(DanhSachSinhVien.danhsach); 
}); 
 
// sửa thông tin sinh viên  
app.MapPut("/sinhvien/{masosinhvien}", (string masosinhvien, Sinhvien sinhvienmoi) => { 
    Sinhvien? sinhvien = DanhSachSinhVien.danhsach.FirstOrDefault( 
        x => x.masosinhvien == masosinhvien 
    ); 
    if(sinhvien == null){ 
        return Results.NotFound(); 
    } 
    sinhvien.tensinhvien = sinhvienmoi.tensinhvien; 
    sinhvien.diemgpa = sinhvienmoi.diemgpa; 
    DanhSachSinhVien.luudulieudanhsach();
    return Results.Ok(sinhvien); 
}); 
 
// xóa thông tin sinh viên  
app.MapDelete("/sinhvien/{masosinhvien}", (string masosinhvien) => { 
    Sinhvien? sinhvien = DanhSachSinhVien.danhsach.FirstOrDefault( 
        x => x.masosinhvien == masosinhvien 
    ); 
    if(sinhvien == null){ 
        return Results.NotFound(); 
    } 
    DanhSachSinhVien.danhsach.Remove(sinhvien); 
    DanhSachSinhVien.luudulieudanhsach();
    return Results.Ok(sinhvien); 
}); 

// sắp xếp thông tin sinh viên
// lấy thông tin tất cả sinh viên
app.MapGet("/sinhvien", (string? sapxep) => {
    if(sapxep == "ten"){
        DanhSachSinhVien.danhsach = DanhSachSinhVien.danhsach
            .OrderBy(x => x.tensinhvien.Split(' ').Last())
            .ToList();
        DanhSachSinhVien.luudulieudanhsach();
    }
    if(sapxep == "tengiam"){
        DanhSachSinhVien.danhsach = DanhSachSinhVien.danhsach
            .OrderByDescending(x => x.tensinhvien.Split(' ').Last())
            .ToList();
        DanhSachSinhVien.luudulieudanhsach();
    }
    if(sapxep == "diem"){
        DanhSachSinhVien.danhsach = DanhSachSinhVien.danhsach
            .OrderBy(x => x.diemgpa)
            .ToList();
        DanhSachSinhVien.luudulieudanhsach();
    }
    if(sapxep == "diemgiam"){
        DanhSachSinhVien.danhsach = DanhSachSinhVien.danhsach
            .OrderByDescending(x => x.diemgpa)
            .ToList();
        DanhSachSinhVien.luudulieudanhsach();
    }
    return Results.Ok(DanhSachSinhVien.danhsach);
});
 
app.Run();

