
$(document).ready(function () {
    $('#AddResultForm').hide();
    $('#ResultYear').show();
    GetClassNames();
    GetMonthName();
})

function GetClassNames() {
    $.ajax({
        url: '/Admin/GetClassSectionsData',
        type: 'Get',
        success: function (response) {
            var html = "";
            var sect = "";
            var clas = response.class;
            var section = response.sections;
            html += '<option style="font-family: initial;" class="border border-bottom" value="0">Select Class</option>';
            for (var i = 0; i < clas.length; i++) {
                html += '<option style="font-family: initial;" class="border border-bottom" value="' + clas[i].id + '">' + clas[i].name + '</option>';
            }
            $('#Classes').append(html);
        }
    })
}

function GetMonthName() {
    $.ajax({
        url: '/Fees/GetAllMonthsName',
        success: function (response) {
            debugger
            var Mont = response;
            var html = "";
            $('#ResultMonth').empty();
            html += '<option style="font-family: initial;" class="border border-bottom" value="0">Select Month</option>';
            for (var i = 0; i < Mont.length; i++) {
                html += '<option style="font-family: initial;" class="border border-bottom" value="' + Mont[i].id + '">' + Mont[i].name + '</option>';
            }
            $('#ResultMonth').append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Wrong Input</p>');
            $('#MyModal').modal('show');
        }
    })
}


function GetSectionNames() {
    $('#SubjectResults').empty();
    $('#StudentsName').empty();
    $('#StdRollNoValue').empty();
    var ClassId = $('#Classes').val();
    $.ajax({
        url: '/Admin/GetSectionNames?ClassId=' + ClassId,
        success: function (response) {
            var html = "";
            $('#SectionName').empty();

            for (var i = 0; i < response.length; i++) {
                html += '<input type="radio" id="' + response[i].id + '" class="ms-2" name="fav_language" value="' + response[i].name + '" onclick="GetSubject(\'' + response[i].name + '\')">';
                html += '<label class="h6 me-4 mt-2 ms-1" for="css"> ' + response[i].name + ' </label><br>';
            }
            $('#SectionName').append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
            $('#ModalBody').append('<p style="font-family: system-ui">Wrong Input</p>');
            $('#MyModal').modal('show');
        }
    })
}

function GetSubject(SectionName) {
    $('#sectionval').empty();
    $('#sectionval').val(SectionName);
    $('#SubjectResults').empty();
    $('#StudentsName').empty();
    $('#StdRollNoValue').empty();
    var MonthId = $('#ResultMonth').val();
    var BatchYear = $('#ResultYear').val();

    var ClassId = $('#Classes').val();
    $.ajax({
        url: '/Admin/GetStudentsSubjects',
        data: { ClassId, SectionName, MonthId, BatchYear },
        success: function (response) {
            debugger
            console.log('res', response);
            if (response == null) {
                $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
                $('#ModalBody').append('<p style="font-family: system-ui">No Subject found in Selected Section.</p>');
                $('#MyModal').modal('show');
            }
            else {
                var html = "";
                var subj = "";
                var x = 0;

                html += '<option href="#" value="0">Select Student</option>';

                for (var i = 0; i < response.students.length; i++) {
                    html += '<option href="#" value="' + response.students[i].id + '">' + response.students[i].name + '</option>';
                }

                for (var i = 0; i < response.subjectsNames.length; i++) {
                    var xx = x++;
                    subj += '<div class="row mb-2">';
                    subj += '<div class="col-lg-4 col-md-6 col-sm-12 CentreText">';
                    subj += '<label class="float-lg-start float-sm-start float-md-start" style="font-weight: bold; font-family: monospace; ">' + response.subjectsNames[i].name + '</label>';
                    subj += '</div>';
                    subj += '<div class="col-lg-4 col-md-6 col-sm-12 text-bg-danger">';
                    subj += '<input class="subjectscores12 form-control" placeholder="Got Marks" id="' + response.subjectsNames[i].id + '" type="text"' + response.subjectsNames[i].name + '/>';
                    subj += '</div>';
                    subj += '<div class="col-lg-4 col-md-6 col-sm-12">';
                    subj += '<input class="subjectTotalscores12 form-control" placeholder="Total Marks" id="' + response.subjectsNames[i].id + '" type="text"' + response.subjectsNames[i].name + '/>';
                    subj += '</div>';
                    subj += '</div>';
                }
                $('#SubjectResults').append(subj);
                $('#StudentsName').append(html);
                $('#AddResultForm').show();
            }
        },
        error: function (data) {
            $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
            $('#ModalBody').append('<p style="font-family: system-ui">Error while Operating.</p>');
            $('#MyModal').modal('show');
        }
    })
}

function ShowRollNo() {
    var data = $('#StudentsName').val();
    $('#StdRollNoValue').empty();
    $('#StdRollNoValue').val(data);
}

function SaveResult() {
    debugger
    var token = localStorage.getItem('token');

    var ClassId = $('#Classes').val();
    var StudentId = $('#StdRollNoValue').val();
    var SectionName = $('#sectionval').val()
    var SubjectId = [];
    var SubjectScore = [];
    var TotalScore = [];
    var scores = $('.subjectscores12');
    var MonthId = $('#ResultMonth').val();
    var Yearinput = $('#ResultYear').val();

    var Year = "";
    const yearRegex = /^(19|20)\d{2}$/;
    const Yearresult = yearRegex.test(Yearinput);
    if (Yearresult == true) {
        Year = Yearinput;
    }

    var Totalscores = $('.subjectTotalscores12');
    for (var i = 0; i < scores.length; i++) {
        SubjectScore.push(scores[i].value);
        SubjectId.push(scores[i].id);
        TotalScore.push(Totalscores[i].value);
    }

    if (ClassId == "" || ClassId == null) {
        $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
        $('#ModalBody').append('<p style="font-family: system-ui">Class value Cannot be Null.</p>');
        $('#MyModal').modal('show');
    }
    else {
        if (StudentId == "" || StudentId == null) {
            $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
            $('#ModalBody').append('<p style="font-family: system-ui">Student Name Cannot be Null.</p>');
            $('#MyModal').modal('show');
        }
        else {

            if (SectionName == "" || SectionName == null) {
                $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
                $('#ModalBody').append('<p style="font-family: system-ui">Section Cannot be Null.</p>');
                $('#MyModal').modal('show');
            }
            else {
                if (Year == "" || Year == null) {
                    $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
                    $('#ModalBody').append('<p style="font-family: system-ui">Please Select Valid Year.</p>');
                    $('#MyModal').modal('show');
                }
                else {
                    debugger
                    if (MonthId == "" || MonthId == null || MonthId == 0) {
                        $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
                        $('#ModalBody').append('<p style="font-family: system-ui">Please Select Month.</p>');
                        $('#MyModal').modal('show');
                    }
                    else {
                        var ClassId = $('#Classes').val();
                        var StudentId = $('#StdRollNoValue').val();
                        var SectionName = $('#sectionval').val()
                        var SubjectId = [];
                        var SubjectScore = [];
                        var TotalScore = [];
                        var scores = $('.subjectscores12');
                        var Totalscores = $('.subjectTotalscores12');
                        for (var i = 0; i < scores.length; i++) {
                            if (scores[i].value == "") {
                                SubjectScore.push(0);
                            }
                            else {
                                SubjectScore.push(scores[i].value);
                            }
                            if (Totalscores[i].value == "") {
                                TotalScore.push(0);
                            }
                            else {
                                TotalScore.push(Totalscores[i].value);
                            }
                            SubjectId.push(scores[i].id);
                        }
                        $.ajax({
                            headers: {
                                Authorization: 'Bearer ' + token
                            },
                            url: '/Admin/AddResultbyStudentId',
                            type: 'POST',
                            data: { ClassId, StudentId, SectionName, SubjectId, SubjectScore, TotalScore, MonthId, Year },
                            success: function (response) {
                                if (response != 0) {
                                    $('#ModalHeadera').append('<h4 style="font-family: system-ui">Success</h4>');
                                    $('#ModalBodya').append('<p style="font-family: system-ui">Operation Completed Successfully.</p>');
                                    $('#MyModala').modal('show');
                                }
                                else {
                                    $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
                                    $('#ModalBody').append('<p style="font-family: system-ui">Result Against this RollNo. Already Exist.</p>');
                                    $('#MyModal').modal('show');
                                }

                            },
                            error: function (data) {
                                $('#ModalHeader').append('<h4 style="font-family: system-ui">Error</h4>');
                                $('#ModalBody').append('<p style="font-family: system-ui">Error While Saving Product.</p>');
                                $('#MyModal').modal('show');
                            }
                        })
                    }
                }
            }
        }
    }
}


$('#ModalClosea').click(function () {
    $('#MyModala').hide();
    window.location.reload();
})
$('#ModalCancela').click(function () {
    $('#MyModala').hide();
    window.location.reload();
})