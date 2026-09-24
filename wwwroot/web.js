function thongbao(noidung, thanhcong){ 
    const element = document.getElementById("thongbao"); 
    element.textContent = noidung; 
    element.className = thanhcong ? "success" : "error"; 
} 
 
async function laysinhvien(){ 
    const response = await fetch("/sinhvien"); 
    const danhsach = await response.json(); 
    const danhsachsinhvien = document.getElementById("danhsachsinhvien"); 
    danhsachsinhvien.innerHTML = ""; 
    danhsach.forEach((sinhvien, index) => { 
        danhsachsinhvien.innerHTML += ` 
            <tr> 
                <td>${index + 1}</td> 
                <td>${sinhvien.masosinhvien}</td> 
                <td>${sinhvien.tensinhvien}</td> 
                <td>${sinhvien.diemgpa}</td> 
            </tr> 
        `; 
    }); 
} 
 
async function laythongtinsinhvien(){ 
    const mssv = document.getElementById("nhap_masosinhvien").value.trim(); 
    if (mssv === ""){ 
        thongbao("Vui lòng nhập mã sinh viên", false); 
        return; 
    } 
    const response = await fetch(`/sinhvien/${mssv}`); 
    if (!response.ok){ 
        thongbao("Không tìm thấy sinh viên", false); 
        return; 
    } 
    const sinhvien = await response.json(); 
    document.getElementById("nhap_tensinhvien").value = sinhvien.tensinhvien; 
    document.getElementById("nhap_diemgpa").value = sinhvien.diemgpa; 
    thongbao("Đã tìm thấy sinh viên", true); 
} 
 
async function themsinhvien(){ 
    const sinhvien = { 
        masosinhvien: document.getElementById("nhap_masosinhvien").value, 
        tensinhvien: document.getElementById("nhap_tensinhvien").value, 
        diemgpa: Number(document.getElementById("nhap_diemgpa").value) 
    }; 
    const response = await fetch("/sinhvien", { 
        method: "POST", 
        headers: { 
            "Content-Type": "application/json" 
        }, 
        body: JSON.stringify(sinhvien) 
    }); 
    if (!response.ok){ 
        thongbao("Thêm sinh viên thất bại", false); 
        return; 
    } 
    thongbao("Đã thêm sinh viên", true); 
    laysinhvien(); 
} 
 
async function suasinhvien(){ 
    const mssv = document.getElementById("nhap_masosinhvien").value; 
    if (mssv === ""){ 
        thongbao("Vui lòng nhập mã sinh viên", false); 
        return; 
    } 
    const sinhvien = { 
        masosinhvien: mssv, 
        tensinhvien: document.getElementById("nhap_tensinhvien").value, 
        diemgpa: Number(document.getElementById("nhap_diemgpa").value) 
    }; 
    const response = await fetch(`/sinhvien/${mssv}`,{ 
        method: "PUT", 
        headers: { 
            "Content-Type": "application/json" 
        }, 
        body: JSON.stringify(sinhvien) 
    }); 
    if (!response.ok){ 
        thongbao("Sửa sinh viên thất bại", false); 
        return; 
    } 
    thongbao("Đã sửa sinh viên", true); 
    laysinhvien(); 
} 
 
async function xoasinhvien(){ 
    const mssv = document.getElementById("nhap_masosinhvien").value; 
    if (mssv === ""){ 
        thongbao("Vui lòng nhập mã sinh viên", false); 
        return; 
    } 
    const response = await fetch(`/sinhvien/${mssv}`,{ 
        method: "DELETE" 
    }); 
    if (!response.ok){ 
        thongbao("Không tìm thấy sinh viên", false); 
        return; 
    } 
    thongbao("Đã xóa sinh viên", true); 
    laysinhvien(); 
} 

function hienluachonsapxep(){
    let luachon = document.getElementById("luachonsapxep");
    luachon.style.display = (
        luachon.style.display === "none" ? "block" : "none"
    );
}

async function sapxep(kieusapxep){
    let url = "/sinhvien?sapxep=" + kieusapxep;
    let response = await fetch(url);
    let danhsach = await response.json();
    let tbody = document.getElementById("danhsachsinhvien");
    tbody.innerHTML = "";
    danhsach.forEach((sinhvien, index) => {
        tbody.innerHTML += `
            <tr>
                <td>${index + 1}</td>
                <td>${sinhvien.masosinhvien}</td>
                <td>${sinhvien.tensinhvien}</td>
                <td>${sinhvien.diemgpa}</td>
            </tr>
        `;
    });
}

laysinhvien();