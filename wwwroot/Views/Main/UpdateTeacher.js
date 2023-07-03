
var token = localStorage.getItem('token');

function TeacherDetails() {
    debugger
    $.ajax({
        url: '/Admin/GetTeacherbyId?id=' + id,
        success: function (response) {
            $('#UserNewImge1').append('<img src="' + response.teacherImage + '" style="width:150px ; height : 150px" class="float-start rounded-pill img-thumbnail" alt="UserImage" />');
            $('#UserName').val(response.teacherName);
            $('#Gender').val(response.gender);
            $('#Age').val(response.age);
            $('#Email').val(response.email);
            $('#Religion').val(response.religion);
            $('#PhoneNo').val(response.phone);
            $('#CNIC').val(response.cnic);
            $('#PostalCode').val(response.postalCode);
            $('#Address').val(response.address);
            $('#City').val(response.city);
            $('#Nationality').val(response.nationality);
            $('#Password').val(response.password);
            $('#classname').val(response.classId);
            $('#sectionname').val(response.sectionName);
            $('#FatherName').val(response.parent?.name);
            $('#PFatherName').val(response.parent?.fatherName);
            $('#ParentsId').val(response.parent?.id);
            $('#PCNIC').val(response.parent?.cnic);
            $('#PPhoneNo').val(response.parent?.phoneNo);
            $('#PGender').val(response.parent?.gender);
            $('#PReligion').val(response.parent?.religion);
            $('#PEmail').val(response.parent?.email);
            $('#PRelation').val(response.parent?.relation);
            $('#AccountNumber').val(response.account?.accountNumber);
            $('#BankName').val(response.account?.bankName);
            $('#PayDecided').val(response.sailoryDecided);
            if (response.account?.accountStatus != false) {
                $('#BankAccountStatus').attr('checked', true);
            }
            else
            {
                $('#BankAccountStatus').attr('checked', false);
            }
            //$('#AccountStatus').val(response.account?.accountStatus);

            if (response.status == true || response.status == null) {
                $('#AccountStatus').attr('checked', true);
            }
            else {
                $('#AccountStatus').attr('checked', false);
            }
            var html = "";
            for (var i = 0; i < response.teacherExperience.length; i++) {
                html += '<div class="row mb-4 mt-4"><div class="col inputinput d-flex"><input type="text" class="InputPositionExp form-control" placeholder="Position" value="' + response.teacherExperience[i].designation + '" name="mytext[]" /><input type="text" class="InputInstituteExp form-control" value="' + response.teacherExperience[i].institution + '" placeholder="Institution Name" name="mytext[]" /><input type="text" class="InputDurationExp form-control" value="' +  response.teacherExperience[i].duration +'" placeholder="Duration" name="mytext[]" /></div></div>';
            }
            $('#Experience').append(html);
            var Quali = "";
            for (var i = 0; i < response.teacherQualification.length; i++) {
                Quali += '<div class="row mb-4 mt-4"><div class="col inputinput d-flex"><input type="text" class="InputDegreeName form-control" placeholder="Degree Name" value="' + response.teacherQualification[i].degreeName + '" name="mytext[]" /><input type="text" class="InputInstitutionName  form-control" value="' + response.teacherQualification[i].institute + '" placeholder="Institution Name" name="mytext[]" /><input type="text" class="InputPassingYear form-control" value="' + response.teacherQualification[i].passingYear + '" placeholder="PassingYear" name="mytext[]" /></div></div>';
            }
            $('#Qualification').append(Quali);
        },
        error: function (data) {
            alert('Error');
        }
    })
}

function UpdateTeacher() {
    $('#ModalHeader').empty();
    $('#ModalBody').empty();
    var AccountStatus = true;
    var form = new FormData();
    var TeacherAccount = $('.AccountSta:checkbox');
    $.each(TeacherAccount, function (key, item) {
        if (item.checked == false) {
            AccountStatus = false;
        }
    })
    var file = $('#multiple')[0].files[0];

    form.append('TeacherImage', $('#multiple')[0].files[0]);
    form.append('Teacherid', id);
    form.append('TeacherName', $('#UserName').val());
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
    form.append('AccountStatus', AccountStatus);
    form.append('AccountNumber', $('#AccountNumber').val());
    form.append('BankName', $('#BankName').val());
    var BankAccountStatus = true;
    var BankStatus = $('.BankAccountStatus1:checkbox');
    $.each(BankStatus, function (key, item) {
        if (item.checked == false) {
            BankAccountStatus = false;
        }
    })
    form.append('BankAccountStatus', BankAccountStatus);
    var InputDegreeName = $('.InputDegreeName');
    var InputInstitutionName = $('.InputInstitutionName');
    var InputPassingYear = $('.InputPassingYear');
    var InputPositionExp = $('.InputPositionExp');
    var InputInstituteExp = $('.InputInstituteExp');
    var InputDurationExp = $('.InputDurationExp');

    for (var i = 0; i < InputInstitutionName.length; i++) {
        if ($(InputInstitutionName[i]).val() != "")
        {
            form.append('InstitutionName', $(InputInstitutionName[i]).val());
        }
    }

    for (var i = 0; i < InputDegreeName.length; i++) {
        if ($(InputInstitutionName[i]).val() != ""){
            form.append('DegreeName', $(InputDegreeName[i]).val());

        }
    }

    for (var i = 0; i < InputPassingYear.length; i++) {
        if ($(InputPassingYear[i]).val() != "")
        {
            form.append('PassingYear', $(InputPassingYear[i]).val());

        }
    }

    for (var i = 0; i < InputPositionExp.length; i++) {
        if ($(InputPositionExp[i]).val() != "")
        {
            form.append('ExpPosition', $(InputPositionExp[i]).val());
        }
    }

    for (var i = 0; i < InputInstituteExp.length; i++) {
        if ($(InputInstituteExp[i]).val() != "") 
        {
            form.append('ExpInstitutionName', $(InputInstituteExp[i]).val());
        }
    }

    for (var i = 0; i < InputDurationExp.length; i++) {
        if ($(InputDurationExp[i]).val() != "")
        {
            form.append('ExpDuration', $(InputDurationExp[i]).val());
        }
    }
    form.append('SailoryDecided', $('#PayDecided').val());
    $.ajax({
        headers: {
            'Authorization': 'Bearer ' + token
        },
        url: '/Admin/UpdateTeacher',
        type: 'POST',
        data: form,
        processData: false,
        contentType: false,
        success: function (response) {
            console.log('res', response);
            $('#ModalHeader').append('<h4>Sucees</h4>');
            $('#ModalBody').append('<p>Operation Successfully Completed.</p>');
            $('#MyModal').modal('show');
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Error While Saving Product</p>');
            $('#MyModal').modal('show');
        }
    })
}