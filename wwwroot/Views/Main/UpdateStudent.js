/// <reference path="updateteacher.js" />
/// <reference path="updatesatff.js" />

    var id = 0;
    var RoleId = 0;
    var token = localStorage.getItem('token');
    $(document).ready(function () {
    let url_str = window.location.href;
    let url = new URL(url_str);
    let search_params = url.searchParams;
    let text = search_params.get('id');
    const myArray = text.split(",");
    id = myArray[0];
    RoleId = myArray[1];
    OnLoad();



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

    function OnLoad() {
        $('#UserNewImages').hide();
        $('#AccountInfo').hide();
        $('#NewDesignation').hide();
        $('#Qualification').hide();
        $('#Experience').hide();
        $('#ParentsInfo').hide();
        $('#ClassDetails').hide();
        $('#UpdateStudent').hide();
        $('#UpdateTeacher').hide();
        $('#UpdateStaff').hide();
    
    if (RoleId == 4 || RoleId == 5) {
        $('#AccountInfo').show();
        $('#NewDesignation').show();
        $('#Qualification').show();
        $('#Experience').show();
        $('#ParentsInfo').hide();
        $('#ClassDetails').hide();
        $('#UpdateStudent').hide();
        $('#UpdateTeacher').hide();
        $('#UpdateStaff').show();
        StaffDetails();
        }
    if (RoleId == 2) {
        $('#AccountInfo').show();
        $('#Qualification').show();
        $('#Experience').show();
        $('#ParentsInfo').hide();
        $('#ClassDetails').hide();
        $('#NewDesignation').hide();
        $('#UpdateStudent').hide();
        $('#UpdateTeacher').show();
        $('#UpdateStaff').hide();
        TeacherDetails();
        }
    if (RoleId == 3) {
        $('#ParentsInfo').show();
        $('#ClassDetails').show();
        $('#AccountInfo').hide();
        $('#Qualification').hide();
        $('#Experience').hide();
        $('#NewDesignation').hide();
        $('#UpdateStudent').show();
        $('#UpdateTeacher').hide();
        $('#UpdateStaff').hide();
        SutdentDetails();
        }
    }

    function SutdentDetails() {
    $.ajax({
        url: '/Admin/GetUserbyId?id=' + id,
        success: function (response) {
    $('#UserNewImge1').append('<img src="' + response.image + '" style="width:150px ; height : 150px" class="float-start rounded-pill img-thumbnail" alt="UserImage" />');
    $('#UserName').val(response.name);
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
    $('#FeesDecided').val(response.feesDecided);
    if (response.status == true || response.status == null)
    {
        $('#AccountStatus').attr('checked', true);
                }
    else
    {
        $('#AccountStatus').attr('checked', false);
                }
    if (response.parent?.isAlive == true) {
             $('#PIsAlive').attr('checked', true);
          }
    else {
             $('#PIsAlive').attr('checked', false);
         }
            GetClassSectionsData();
            },
    error: function (data) {
                debugger
            }
        })
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

    function OtherRoleDetails() {
        debugger
    }

    function changesection(){
    var section = $('#section').val();
    $('#sectionname').val(section);
    }

    function changeclass() {
    var class1 = $('#class').val();
    $('#classname').empty();
    $('#classname').val(class1);
    }

    function ShowNewImage(input) {
    $('#UserNewImages').show();
    var file = $("input[type=file]").get(0).files[0];
    if (file) {
            var reader = new FileReader();
    reader.onload = function () {
        $('#UserNewImages').attr("src", reader.result);
            }
    reader.readAsDataURL(file);
        }
    }

    function UpdateStudent() {
    $('#ModalHeader').empty();
    $('#ModalBody').empty();

    var Isalive = false;
    var AccountStatus = true;
    var form = new FormData();
    var alivestauts1 = $('.AliveStauts:checkbox');
    $.each(alivestauts1, function (key, item) {
            if (item.checked == true) {
        Isalive = true;
            }
        })

    var StudentAccount = $('.AccountSta:checkbox');
    $.each(StudentAccount, function (key, item) {
            if (item.checked == false) {
        AccountStatus = false;
            }
        })
    var file = $('#multiple')[0].files[0];
    form.append('SudentImage', $('#multiple')[0].files[0]);
    form.append('StudentName', $('#UserName').val());
    var classss = $('#class').val();
    var sectionsss = $('#section').val();
    var Student = $('#UserName').val();
    var Religion = $('#Religion').val();
    var Password = $('#Password').val();
    form.append('id',id);
    form.append('ClassName', $('#class').val());
    form.append('SectionName', $('#section').val());
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
    form.append('AliveStatus', Isalive);
    form.append('PName', $('#FatherName').val());
    form.append('PFatherName', $('#FatherName').val());
    form.append('PCNIC', $('#PCNIC').val());
    form.append('PPhone', $('#PPhoneNo').val());
    form.append('PGender', $('#PGender').val());
    form.append('PReligion', $('#PReligion').val());
    form.append('PEmail', $('#PEmail').val());
    form.append('PRelation', $('#PRelation').val());
    form.append('Pid', $('#ParentsId').val());
    form.append('NewFeesDecided', $('#FeesDecided').val());
    $.ajax({
    headers:
    {
       'Authorization': 'Bearer ' + token
    },
    url: '/Admin/UpdateStudent',
    type: 'POST',
    data: form,
    processData: false,
    contentType: false,
    success: function (response) {
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