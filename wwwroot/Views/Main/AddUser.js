var token = localStorage.getItem('token');

$(document).ready(function () {
    debugger
   /* GetClassSectionsData();*/
    $('#ParentsInfo').hide();
    $('#AccountInfo').hide();
    $('#Qualification').hide();
    $('#Experience').hide();
    $('#ClassDetails').hide();
    $('#UserNewImage').hide();


    var max_fields = 10;
    var wrapper = $(".input_fields_wrap");
    var add_button = $(".add_field_button");
    var x = 1;

    $(add_button).click(function (e) {
        e.preventDefault();
        if (x < max_fields) {
            $(wrapper).append('<div class="row mb-4 mt-4"><div class="col inputinput d-flex"><input type="text" class="InputDegreeName form-control" placeholder="Degree Name" name="mytext[]" /><input type="text" class="InputInstitutionName form-control" placeholder="Institution Name" name="mytext[]" /><input type="text" class="InputPassingYear form-control" placeholder="PassingYear" name="mytext[]" /><a href="#" class="remove_field btn btn-danger">Remove</a></div></div>');
            x++;
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) {
        e.preventDefault();
        $(this).parent('div').remove();
        x--;
    })


    var max_fieldsexp = 10;
    var wrapperexp = $(".input_fields_wrapexperience");
    var add_buttonexp = $(".add_field_experience");
    var x = 1;

    $(add_buttonexp).click(function (e) {
        e.preventDefault();
        if (x < max_fieldsexp) {
            $(wrapperexp).append('<div class="row mb-4 mt-4"><div class="col inputinput d-flex"><input type="text" class="InputPositionExp form-control" placeholder="Position" name="mytext[]" /><input type="text" class="InputInstituteExp form-control" placeholder="Institution Name" name="mytext[]" /><input type="text" class="InputDurationExp form-control" placeholder="Duration" name="mytext[]" /><a href="#" class="remove_field btn btn-danger">Remove</a></div></div>');
            x++;
        }
    });

    $(wrapperexp).on("click", ".remove_field", function (e) {
        e.preventDefault();
        $(this).parent('div').remove();
        x--;
    })
})


function ShowData() {
    var radioid = $("#Student123").is(":checked");
    var radioid1 = $("#Teacher123").is(":checked");
    var radioid2 = $("#Other123").is(":checked");
    if (radioid == true) {
        $('#ParentsInfo').show();
        $('#ClassDetails').show();
        $('#AccountInfo').hide();
        $('#Qualification').hide();
        $('#Experience').hide();
        $('#NewDesignation').hide();
        GetClassSectionsData();
    }
    if (radioid1 == true) {
        $('#AccountInfo').show();
        $('#Qualification').show();
        $('#Experience').show();
        $('#ParentsInfo').hide();
        $('#ClassDetails').hide();
        $('#NewDesignation').hide();
    }
    if (radioid2 == true) {
        $('#AccountInfo').show();
        $('#NewDesignation').show();
        $('#Qualification').show();
        $('#Experience').show();
        $('#ParentsInfo').hide();
        $('#ClassDetails').hide();
        GetAllRoles();
    }
}

function GetClassSectionsData() {
    $.ajax({
        url: '/Admin/GetClassSectionsData',
        type: 'Get',
        success: function (response) {
            var html = "";
            var sect = "";
            var clas = response.class;
            var section = response.sections;
            for (var i = 0; i < clas.length; i++) {
                html += '<option value="' + clas[i].id + '">' + clas[i].name + '</option>';
            }
            $('#class').append(html);

            for (var i = 0; i < section.length; i++) {
                sect += '<option value="' + section[i].name + '">' + section[i].name + '</option>';
            }
            $('#section').append(sect);
        }
    })
}

function GetAllRoles() {
    $.ajax({
        url: '/Admin/GetAllRoles',
        type: 'Get',
        success: function (response) {
            var html = "";
            var sect = "";
            var clas = response;
            for (var i = 0; i < clas.length; i++) {
                html += '<option value="' + clas[i].id + '">' + clas[i].rolesName + '</option>';
            }
            $('#Designation').append(html);
        }
    })
}

function ShowNewImage(input) {
    $('#UserNewImage').show();
    var file = $("input[type=file]").get(0).files[0];
    if (file) {
        var reader = new FileReader();
        reader.onload = function () {
            $('#UserNewImage').attr("src", reader.result);
        }
        reader.readAsDataURL(file);
    }
}

$('#SaveUser').click(function () {
    debugger
    var radioid = $("#radioid input[type='radio']:checked").val();
    if (radioid == 2) {
        AddStudent();
    }
    if (radioid == 1) {
        AddTeacher();
    }
    if (radioid == 3)
    {
        AddOthers();
    }
    if (radioid == "" || radioid == undefined)
    {
        $('#ModalHeader').empty();
        $('#ModalBody').empty();
        $('#ModalHeader').append('<h4>Error</h4>');
        $('#ModalBody').append('<p>Kindly Select Account Type</p>');
        $('#MyModal').modal('show');
    }
})

function AddOthers() {
    $('#ModalHeader').empty();
    $('#ModalBody').empty();

    var form = new FormData();
    var InputDegreeName = $('.InputDegreeName');
    var InputInstitutionName = $('.InputInstitutionName');
    var InputPassingYear = $('.InputPassingYear');
    var InputPositionExp = $('.InputPositionExp');
    var InputInstituteExp = $('.InputInstituteExp');
    var InputDurationExp = $('.InputDurationExp');
    for (var i = 0; i < InputInstitutionName.length; i++) {
        form.append('InstitutionName', $(InputInstitutionName[i]).val());
    }

    for (var i = 0; i < InputDegreeName.length; i++) {
        form.append('DegreeName', $(InputDegreeName[i]).val());
    }

    for (var i = 0; i < InputPassingYear.length; i++) {
        form.append('PassingYear', $(InputPassingYear[i]).val());
    }

    for (var i = 0; i < InputPositionExp.length; i++) {
        form.append('ExpPosition', $(InputPositionExp[i]).val());
    }

    for (var i = 0; i < InputInstituteExp.length; i++) {
        form.append('ExpInstitutionName', $(InputInstituteExp[i]).val());
    }

    for (var i = 0; i < InputDurationExp.length; i++) {
        form.append('ExpDuration', $(InputDurationExp[i]).val());
    }
    form.append('RoleId', $('#Designation').val());
    var file = $('#multiple')[0].files[0];
    form.append('TeacherName', $('#Name').val());
    form.append('Password', $('#Password').val());
    form.append('FatherName', $('#FatherName').val());
    form.append('Email', $('#Email').val());
    form.append('Phone', $('#PhoneNo').val());
    form.append('CNIC', $('#CNIC').val());
    form.append('Gender', $('#Gender').val());
    form.append('Age', $('#Age').val());
    form.append('City', $('#City').val());
    form.append('Nationality', $('#Nationality').val());
    form.append('Address', $('#Address').val());
    form.append('PostalCode', $('#PostalCode').val());
    form.append('Religion', $('#Religion').val());
    form.append('TeacherImage', $('#multiple')[0].files[0]);
    form.append('AccountNumber', $('#AccountNumber').val());
    form.append('BankName', $('#BankName').val());
    form.append('AccountStatus', $('#AccountStatus').val());
    form.append('SailoryDecided', $('#SailoryDecided').val());
    debugger
    $.ajax({
        headers:
        {
            'Authorization': 'Bearer ' + token
        },
        url: '/Admin/CreateOtherStaff',
        type: 'POST',
        data: form,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response == 0) {
                $('#ModalHeader').empty();
                $('#ModalBody').empty();
                $('#ModalHeader').append('<h4>Error</h4>');
                $('#ModalBody').append('<p>Email OR Password already Exist.</p>');
                $('#MyModal').modal('show');
            } else {
                $('#ModalHeader').empty();
                $('#ModalBody').empty();
                $('#ModalHeader').append('<h4>Sucees</h4>');
                $('#ModalBody').append('<p>Operation Successfully Completed.</p>');
                $('#MyModal').modal('show');
            }    

        },
        error: function (data) {
            $('#ModalHeader').empty();
            $('#ModalBody').empty();
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Error While Saving </p>');
            $('#MyModal').modal('show');
        }
    })
}

function AddStudent() {
    $('#ModalHeader').empty();
    $('#ModalBody').empty();

    var Isalive = false;
    var form = new FormData();
    var alivestauts1 = $('.AliveStatus:checkbox');
    $.each(alivestauts1, function (key, item) {
        if (item.checked == true) {
            Isalive = true;
        }
    })
    var file = $('#multiple')[0].files[0];
    form.append('SudentImage', $('#multiple')[0].files[0]);
    form.append('StudentName', $('#Name').val());
    var classss = $('#class').val();
    var sectionsss = $('#section').val();
    var Student = $('#Name').val();
    form.append('ClassName', $('#class').val());
    form.append('SectionName', $('#section').val());
    form.append('Password', $('#Password').val());
    form.append('FatherName', $('#FatherName').val());
    form.append('Email', $('#Email').val());
    form.append('Phone',$('#PhoneNo').val());
    form.append('CNIC', $('#CNIC').val());
    form.append('Gender', $('#Gender').val());
    form.append('Age', $('#Age').val());
    form.append('City',$('#City').val());
    form.append('Nationality',$('#Nationality').val());
    form.append('Address',$('#Address').val());
    form.append('PostalCode',$('#PostalCode').val());
    form.append('Religion', $('#Religion').val());
    form.append('AliveStatus', Isalive);
    form.append('PName', $('#PName').val());
    form.append('PFatherName', $('#PFatherName').val());
    form.append('PCNIC', $('#PCNIC').val());
    form.append('PPhone', $('#PPhoneNo').val());
    form.append('PGender', $('#PGender').val());
    form.append('PReligion', $('#PReligion').val());
    form.append('PEmail', $('#PEmail').val());
    form.append('PRelation', $('#PRelation').val());
    form.append('FeeDecided', $('#DecidedFees').val());
    debugger
    $.ajax({
        headers:
        {
            'Authorization': 'Bearer ' + token
        },
        url: '/Admin/CreateStudent',
        type: 'POST',
        data: form,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response == 0) {
                $('#ModalHeader').empty();
                $('#ModalBody').empty();
                $('#ModalHeader').append('<h4>Error</h4>');
                $('#ModalBody').append('<p>Email OR Password already Exist.</p>');
                $('#MyModal').modal('show');
            } else
            {
                $('#ModalHeader').empty();
                $('#ModalBody').empty();
                $('#ModalHeader').append('<h4>Sucees</h4>');
                $('#ModalBody').append('<p>Operation Successfully Completed.</p>');
                $('#MyModal').modal('show');
            }          
        },
        error: function (data) {
            $('#ModalHeader').empty();
            $('#ModalBody').empty();
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Error While Saving Product</p>');
            $('#MyModal').modal('show');
        }
    })
}
function AddTeacher() {
    $('#ModalHeader').empty();
    $('#ModalBody').empty();

    var form = new FormData();
    var InputDegreeName = $('.InputDegreeName');
    var InputInstitutionName = $('.InputInstitutionName');
    var InputPassingYear = $('.InputPassingYear');
    var InputPositionExp = $('.InputPositionExp');
    var InputInstituteExp = $('.InputInstituteExp');
    var InputDurationExp = $('.InputDurationExp');

    for (var i = 0; i < InputInstitutionName.length; i++) {
        form.append('InstitutionName', $(InputInstitutionName[i]).val());
    }

    for (var i = 0; i < InputDegreeName.length; i++) {
        form.append('DegreeName', $(InputDegreeName[i]).val());
    }

    for (var i = 0; i < InputPassingYear.length; i++) {
        form.append('PassingYear', $(InputPassingYear[i]).val());
    }

    for (var i = 0; i < InputPositionExp.length; i++) {
        form.append('ExpPosition', $(InputPositionExp[i]).val());
    }

    for (var i = 0; i < InputInstituteExp.length; i++) {
        form.append('ExpInstitutionName', $(InputInstituteExp[i]).val());
    }

    for (var i = 0; i < InputDurationExp.length; i++) {
        form.append('ExpDuration', $(InputDurationExp[i]).val());
    }

    var file = $('#multiple')[0].files[0];
    form.append('TeacherName', $('#Name').val());
    form.append('Password', $('#Password').val());
    form.append('FatherName', $('#FatherName').val());
    form.append('Email', $('#Email').val());
    form.append('Phone', $('#PhoneNo').val());
    form.append('CNIC', $('#CNIC').val());
    form.append('Gender', $('#Gender').val());
    form.append('Age', $('#Age').val());
    form.append('City', $('#City').val());
    form.append('Nationality', $('#Nationality').val());
    form.append('Address', $('#Address').val());
    form.append('PostalCode', $('#PostalCode').val());
    form.append('Religion', $('#Religion').val());
    form.append('TeacherImage', $('#multiple')[0].files[0]);
    form.append('AccountNumber', $('#AccountNumber') .val());
    form.append('BankName', $('#BankName').val());
    form.append('AccountStatus', $('#AccountStatus').val());
    form.append('SailoryDecided', $('#SailoryDecided').val());
    debugger
    $.ajax({
        headers:
        {
            'Authorization': 'Bearer ' + token
        },
        url: '/Admin/CreateTeacher',
        type: 'POST',
        data: form,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response == 0) {
                $('#ModalHeader').empty();
                $('#ModalBody').empty();
                $('#ModalHeader').append('<h4>Error</h4>');
                $('#ModalBody').append('<p>Email OR Password already Exist.</p>');
                $('#MyModal').modal('show');
            } else {
                $('#ModalHeader').empty();
                $('#ModalBody').empty();
                $('#ModalHeader').append('<h4>Sucees</h4>');
                $('#ModalBody').append('<p>Operation Successfully Completed.</p>');
                $('#MyModal').modal('show');
            }    
        },
        error: function (data) {
            $('#ModalHeader').empty();
            $('#ModalBody').empty();
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Error While Saving Product</p>');
            $('#MyModal').modal('show');
        }
    })
    $('#ModalClose').click(function () {
        $('#ModalHeader').empty();
        $('#ModalBody').empty();
        $('#MyModal').modal('hide');
    })
    $('#ModalCancel').click(function () {
        $('#ModalHeader').empty();
        $('#ModalBody').empty();
        $('#MyModal').modal('hide');
    })

   
}
