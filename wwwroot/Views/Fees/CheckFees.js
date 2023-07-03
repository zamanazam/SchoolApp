//$(function () {
//    $('#Fromdatepicker').datepicker();
//    $('#Todatepicker').datepicker();
//});

var RoleId = localStorage.getItem('RoleId');
var UserId = localStorage.getItem('UserId');

$(document).ready(function () {
    $('#LabelSectionName').hide();
    if (RoleId != 1) {
        OtherUserExceptAdmin();
        GetCurrentMonthUnPaidforCurrentUser();

    }
    else {
        GetClassNames();
        GetCurrentMonthUnPaid();
    }
})

function OtherUserExceptAdmin() {
    $('#RoleNo').val(UserId);
    const changereadonly = $('.RollNoInput')[0].readOnly = true;
    $('#FeeDecidedColumnHeader').hide();
}


function GetClassNames() {
    $.ajax({
        url: '/Admin/GetClassSectionsData',
        type: 'Get',
        success: function (response) {
            var html = "";
            var sect = "";
            var clas = response.class;
            var section = response.sections;
            html += '<option style="font-family: initial;" class="border border-bottom" value="0">Please Select Class</option>';

            for (var i = 0; i < clas.length; i++) {
                html += '<option style="font-family: initial;" class="border border-bottom" value="' + clas[i].id + '">' + clas[i].name + '</option>';
            }
            $('#ClassIds').append(html);
        }
    })
}

function GetSectionNames() {
    var ClassId = $('#ClassIds').val();
    $.ajax({
        url: '/Admin/GetSectionNames?ClassId=' + ClassId,
        success: function (response) {
            var html = "";
            $('#SectionName').empty();
            for (var i = 0; i < response.length; i++) {
                html += '<div class="ms-2">';
                html += '<input type="radio" id="' + response[i].id + '" name="fav_language" value="' + response[i].name + '" onclick="SearchData();" class="radiosectionname ms-5" onclick="ResultFilter(\'' + response[i].name + '\')">';
                html += '<label class="h6 ms-3" for="css"> ' + response[i].name + ' </label><br>';
                html += '</div>';
            }
            $('#LabelSectionName').show();
            $('#SectionName').append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Wrong Input</p>');
            $('#MyModal').modal('show');
        }
    })
}
var token = localStorage.getItem('token');
function GetCurrentMonthUnPaid() {
    console.log(token);
    debugger
    $.ajax({
        headers: {
            'Authorization': 'Bearer ' + token
        },
        url: '/Fees/GetFeesData',
        success: function (response) {
            $('#tbody').empty();
            var html = "";
            var x = 1;
            for (var i = 0; i < response.length; i++) {
                var xx = x++;
                html += '<tr id="Serialkey" class="border">';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + xx + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].studentId + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].studentName + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].feesGiven + ' </td>';
                if (RoleId == 1) {
                    html += '<td class=" align-middle text-center text-dark" id="FeeDecidedColumn" style="border: hidden;">' + response[i].feesDecided + ' </td>';
                }
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].classId + '/' + response[i].sectionName + '</td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].month + '  ' + response[i].year + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].collectedByName + ' </td>';

                var DateTimeUploadOn = response[i].collectedOn;
                var JustDate = DateTimeUploadOn.split('T')[0];
                var newdate = moment(JustDate).format('DD-MM-YYYY');
                var justtime = DateTimeUploadOn.split('T')[1];
                var ts = justtime;
                var H = +ts.substr(0, 2);
                var h = (H % 12) || 12;
                h = (h < 10) ? ("0" + h) : h;
                var ampm = H < 12 ? " AM" : " PM";
                ts = h + ts.substr(2, 3) + ampm;

                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + newdate + '      ' + ts + ' </td>';
                html += '</tr>';
            }
            $('#tbody').append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Wrong Input</p>');
            $('#MyModal').modal('show');
        }
    })
}

function SearchData() {
    debugger
    var SectionName = "";
    var Paid = false;
    var ClassId = $('#ClassIds').val();
    var Sections = $('.radiosectionname');
    var RollNo = $('#RoleNo').val();
    if (RoleId != 1) {
        RollNo = UserId;
        ClassId = 0;
    }
    var FromDate = $('#FromDate').val();
    var ToDate = $('#ToDate').val();
    var Paidcheckbox = $('.Paid:checkbox');
    if (Paidcheckbox[0].checked == true) {
        Paid = true;
    }
    for (var i = 0; i < Sections.length; i++) {
        if (Sections[i].checked == true) {
            SectionName = Sections[i].value;
        }
    }
    var feesSearch = new FormData();
    feesSearch.append('SectionName', SectionName);
    feesSearch.append('Paid', Paid);
    feesSearch.append('ClassId', ClassId);
    feesSearch.append('RollNo', RollNo);
    feesSearch.append('FromDate', FromDate);
    feesSearch.append('ToDate', ToDate);
    $.ajax({
        headers: {
            'Authorization': 'Bearer ' + token
        },
        url: '/Fees/GetFeesDatabyConditions',
        data: feesSearch,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (response) {
            $('#tbody').empty();
            if (response == null) {
                return null;
            }
            var html = "";
            var x = 1;
            for (var i = 0; i < response.length; i++) {
                var xx = x++;
                html += '<tr id="Serialkey" class="border">';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + xx + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].studentId + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].studentName + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].feesGiven + ' </td>';
                if (RoleId == 1) {
                    html += '<td class=" align-middle text-center text-dark" id="FeeDecidedColumn" style="border: hidden;">' + response[i].feesDecided + ' </td>';
                }
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].classId + '/' + response[i].sectionName + '</td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].month + '  ' + response[i].year + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].collectedByName + ' </td>';

                var DateTimeUploadOn = response[i].collectedOn;
                var JustDate = DateTimeUploadOn.split('T')[0];
                var newdate = moment(JustDate).format('DD-MM-YYYY');
                var justtime = DateTimeUploadOn.split('T')[1];
                var ts = justtime;
                var H = +ts.substr(0, 2);
                var h = (H % 12) || 12;
                h = (h < 10) ? ("0" + h) : h;
                var ampm = H < 12 ? " AM" : " PM";
                ts = h + ts.substr(2, 3) + ampm;

                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + newdate + '      ' + ts + ' </td>';
                html += '</tr>';
            }
            $('#tbody').append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Wrong Input</p>');
            $('#MyModal').modal('show');
        }
    })
}


function GetCurrentMonthUnPaidforCurrentUser() {
    var SectionName = "";
    var Paid = false;
    var ClassId = $('#ClassIds').val();
    var Sections = $('.radiosectionname');
    var RollNo = $('#RoleNo').val();
    if (RoleId != 1) {
        RollNo = UserId;
        ClassId = 0;
    }
    var FromDate = $('#FromDate').val();
    var ToDate = $('#ToDate').val();
    var Paidcheckbox = $('.Paid:checkbox');
    if (Paidcheckbox[0].checked == true) {
        Paid = true;
    }
    for (var i = 0; i < Sections.length; i++) {
        if (Sections[i].checked == true) {
            SectionName = Sections[i].value;
        }
    }
    var feesSearch = new FormData();
    feesSearch.append('SectionName', SectionName);
    feesSearch.append('Paid', Paid);
    feesSearch.append('ClassId', ClassId);
    feesSearch.append('RollNo', RollNo);
    feesSearch.append('FromDate', FromDate);
    feesSearch.append('ToDate', ToDate);
    $.ajax({
        url: '/Fees/GetFeesDatabyConditions',
        data: feesSearch,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (response) {
            $('#tbody').empty();
            var html = "";
            var x = 1;
            for (var i = 0; i < response.length; i++) {
                var xx = x++;
                html += '<tr id="Serialkey" class="border">';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + xx + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].studentId + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].studentName + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].feesGiven + ' </td>';
                if (RoleId == 1) {
                    html += '<td class=" align-middle text-center text-dark" id="FeeDecidedColumn" style="border: hidden;">' + response[i].feesDecided + ' </td>';
                }
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].classId + '/' + response[i].sectionName + '</td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].month + '  ' + response[i].year + ' </td>';
                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + response[i].collectedByName + ' </td>';

                var DateTimeUploadOn = response[i].collectedOn;
                var JustDate = DateTimeUploadOn.split('T')[0];
                var newdate = moment(JustDate).format('DD-MM-YYYY');
                var justtime = DateTimeUploadOn.split('T')[1];
                var ts = justtime;
                var H = +ts.substr(0, 2);
                var h = (H % 12) || 12;
                h = (h < 10) ? ("0" + h) : h;
                var ampm = H < 12 ? " AM" : " PM";
                ts = h + ts.substr(2, 3) + ampm;

                html += '<td class=" align-middle text-center text-dark" style="border: hidden;">' + newdate + '      ' + ts + ' </td>';
                html += '</tr>';
            }
            $('#tbody').append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Wrong Input</p>');
            $('#MyModal').modal('show');
        }
    })
}