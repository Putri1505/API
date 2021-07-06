//function detail(id) {
//    $.ajax({
//        url: 'https://localhost:44368/API/person/GetProfileById/' + id
//    }).done((result) => {
//        text2 = "";
//        text2 += `<h4>NIK: ${result.nik}</h4>
//                    <h4>Name: ${result.firstName + ' ' + result.lastName}</h4>
//                     <h4>Email: ${result.email}</h4>
//                      <h4>Phone: ${result.phone}</h4>
//                        <h4>salary: ${result.salary}</h4>
//                        <h4>BirthDate: ${format(result.birthDate)}</h4>
//                        <h4>Degree: ${result.degree}</h4>
//                        <h4>GPA: ${result.gpa}</h4>
//                        <h4>University: ${result.Universityid}</h4>`;

//        $('#modalPoke').html(text2);
//    }).fail((error) => {
//        console.log(error);
//    });
//}
function format(inputDate) {
    var date = new Date(inputDate);
    if (!isNaN(date.getTime())) {
        return date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear();
    }
}
var table = null;
$(document).ready(function () {
    table = $('#tableUsers').DataTable({
        ajax: {
            url: 'https://localhost:44368/API/person/GetAllProfile',
            dataSrc: ''
        },
        columns: [
            {
                "data": null, "sortable": false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {

                "data": function (row) {
                    return `${row['firstName'] + " " + row['lastName']}`
                }
            },
            {
                "data": "nik"
            },
            {
                "data": "email"
            },
            {
                "data": "phone"
            },
            {
                "data": "salary"
            },
            {
                "render": function (data, type, row) {
                    return format(row['birthDate'])
                }
            },
            {
                "render": function (data,type,row) {
                    return row['degree']
                }
            },
            {
                "render": function (data, type, row) {
                    return row['gpa']
                }
            },
            {
                "render": function (data, type, row) {
                    return row['universityid']
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick= "Detail('${row['nik']}')" data-toggle="modal" data-target="#modalUpdate">Update</button>
                            <button type="button" class="btn btn-danger" onclick= "Delete('${row.nik}')">Delete</button>
                            `;
                }
            }
        ]
    });
    $("#createmodal").on("hidden.bs.modal", function () {
        $(this).find('form').trigger('reset');
        table.clear().draw();
        table.ajax.reload();
    });
    $("#modalUpdate").on("hidden.bs.modal", function () {
        $(this).find('form').trigger('reset');
        table.clear().draw();
        table.ajax.reload();
    });
});

function Insert() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.FirstName = $("#inputfirstName").val();
    obj.LastName = $("#inputlastName").val();
    obj.Email = $("#inputemail").val();
    obj.Password = $("#inputpassword").val();
    obj.salary = parseInt($("#inputsalary").val());
    obj.Phone = $("#inputphone").val();
    obj.BirthDate = $("#inputbirthDate").val();
    obj.Degree = $("#inputdegree").val();
    obj.GPA = $("#inputgpa").val();
    obj.Universityid = parseInt($("#inputuniversityid").val());
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: 'https://localhost:44368/API/person/Register',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj),
        dataType: "json"
    }).done((result) => {
        Swal.fire(
            'success',
            'Berhasil dibuat!',
            'success'
        )
        $("#createmodal").modal('hide');
        //buat alert pemberitahuan jika success
    }).fail((error) => {
        Swal.fire(
            'error',
            'oops..',
            'error'
        )
    });
    return false;
}

    // Disable form submissions if there are invalid fields
(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()


function Delete(id) {
    Swal.fire({
        title: 'Yakin ingin menghapus data?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44368/API/person/DeleteProfileById/' + id,
                type: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            }).done((result) => {
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
                table.clear().draw();
                table.ajax.reload();
            }).fail((error) => {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: '<a href="">Why do I have this issue?</a>'
                })
            });
        }
    })
}

function Detail(id) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: 'https://localhost:44368/API/person/GetProfileById/' + id,
        type: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).done((result) => {
        $("#nik").val(result.nik);
        $("#firstName1").val(result.firstName);
        $("#lastName1").val(result.lastName);
        $("#email1").val(result.email);
        $("#password1").val(result.password);
        $("#salary1").val(result.salary);
        $("#phone1").val(result.phone);
        $("#birthDate1").val(result.birthDate.split("T")[0]);
        $("#degree1").val(result.degree);
        $("#gpa1").val(result.gpa);
        console.log(result.universityid);
        console.log(result.password);
        $("#universityid1").val(result.universityid);
        $("#modalUpdate").modal("show");
    }).fail((error) => {
        console.log("Error: " + error);
        alert("gagal")
    });
    return false;
}
function UpdateProfile() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.nik = $("#nik").val();
    obj.FirstName = $("#firstName1").val();
    obj.LastName = $("#lastName1").val();
    obj.Email = $("#email1").val();
    obj.Password = $("#password1").val();
    obj.salary = parseInt($("#salary1").val());
    obj.Phone = $("#phone1").val();
    obj.BirthDate = $("#birthDate1").val();
    obj.Degree = $("#degree1").val();
    obj.GPA = $("#gpa1").val();
    obj.Universityid = parseInt($("#universityid1").val());
    Swal.fire({
        title: 'Anda yakin ingin mengubah data?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ya',
        cancelButtonText: 'Tidak'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44368/API/person/UpdateProfile',
                type: "PUT",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(obj),
                dataType: "json"
            }).done((result) => {
                Swal.fire({
                    icon: 'success',
                    title: 'Success',
                    text: 'Berhasil update data',
                })
                $("#modalUpdate").modal('hide');
                //buat alert pemberitahuan jika success
            }).fail((error) => {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: '<a href="">Why do I have this issue?</a>'
                })
            });
        }
    })
    return false;
}

//function InsertOrUpdate() {
//    var inserOrUpdate = $("#inserOrUpdate").val();
//    if (inserOrUpdate == "0") {
//        return Insert();
//    } else if (inserOrUpdate == "1") {
//        return UpdateProfile();
//    }
//}

$("#btnCreate").on('click', function () {
    $("#btnSubmit").show();
    $("#btnUpdate").hide();
    $("#createmodal").modal("show");
});

$("#inputbirthDate").on('change', function () {
    console.log("tanggalLahir: "+$(this).val());
});