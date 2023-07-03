
$(document).ready(function () {
    GetAllResults();
    GetClassNames();
})

function GetAllResults() {
    $.ajax({
        url: '/Admin/LastUpdatedResult',
        success: function (response) {
            $('#tbody').empty();
            $('#tableheader').empty();
            var html = "";
            var th = [];
            var x = 1;
            $.each(response, function (key, item) {
                debugger
                var Total = 0;
                var TotalGot = 0;
                var Percentage = 0;
                var xx = x++;
                html += '<tr id="Serialkey" class="border">';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + xx + ' </td>';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + item[0].studentName + ' </td>';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + item[0].studentId + ' </td>';
                $.each(item, function (key, itemss) {
                    th.push(itemss.subjectName);
                    Total += (itemss.total);
                    TotalGot += (itemss.score);
                    html += '<td class="border align-middle text-center text-dark">' + itemss.score + ' </td>';
                })
                //To Adjust Date And Time in Good Format
                var DateTimeUploadOn = item[0].uploadOn;
                var JustDate = DateTimeUploadOn.split('T')[0];
                var newdate = moment(JustDate).format('DD-MM-YYYY');
                var justtime = DateTimeUploadOn.split('T')[1];
                var ts = justtime;
                var H = +ts.substr(0, 2);
                var h = (H % 12) || 12;
                h = (h < 10) ? ("0" + h) : h;
                var ampm = H < 12 ? " AM" : " PM";
                ts = h + ts.substr(2, 3) + ampm;

                Percentage = Math.round((TotalGot / Total) * 100);
                html += '<td class="border align-middle text-center text-dark">' + TotalGot + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + Total + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + Percentage + '% </td>';
                html += '<td class="border align-middle text-center text-dark">' + item[0].month + '   ' + item[0].batchYear + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + newdate + '   ' + ts + '</td>';
            })
            html += '</tr>';
            var UniqueArray = th.filter(function (element, index, self) {
                return index === self.indexOf(element);
            });

            for (var i = 0; i < UniqueArray.length; i++) {
                if (i == 0) {
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Sr.</th>');
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Name </th>');
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Roll No</th>');
                }
                $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > ' + UniqueArray[i] + '</th>');
            };

            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Got </th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Total </th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Percentage</th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Month / Year</th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Result On</th>');
            $("#tbody").append(html);
        },
        error: function (data) {
            debugger
            console.log(data);
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Error While Searching Result</p>');
            $('#MyModal').modal('show');
        }
    })
}

function CheckResultbyId() {
    var sectionName = $('#SectionName123').val();
    var id = $('#StudentId').val();
    $.ajax({
        url: '/Admin/GetResultbyStudentId?StudentId=' + id,
        success: function (response) {
            $('#tbody').empty();
            $('#tableheader').empty();
            var html = "";
            var th = [];
            var x = 1;
            $.each(response, function (key, item) {
                var Total = 0;
                var TotalGot = 0;
                var Percentage = 0;
                var xx = x++;
                html += '<tr id="Serialkey" class="border">';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + xx + ' </td>';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + item[0].studentName + ' </td>';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + item[0].studentId + ' </td>';
                $.each(item, function (key, itemss) {
                    th.push(itemss.subjectName);
                    Total += (itemss.total);
                    TotalGot += (itemss.score);
                    html += '<td class="border align-middle text-center text-dark">' + itemss.score + ' </td>';
                })
                //To Adjust Date And Time in Good Format
                var DateTimeUploadOn = item[0].uploadOn;
                var JustDate = DateTimeUploadOn.split('T')[0];
                var newdate = moment(JustDate).format('DD-MM-YYYY');
                var justtime = DateTimeUploadOn.split('T')[1];
                var ts = justtime;
                var H = +ts.substr(0, 2);
                var h = (H % 12) || 12;
                h = (h < 10) ? ("0" + h) : h;
                var ampm = H < 12 ? " AM" : " PM";
                ts = h + ts.substr(2, 3) + ampm;

                Percentage = Math.round((TotalGot / Total) * 100);
                html += '<td class="border align-middle text-center text-dark">' + TotalGot + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + Total + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + Percentage + '% </td>';
                html += '<td class="border align-middle text-center text-dark">' + item[0].month + '   ' + item[0].batchYear + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + newdate + '   ' + ts + '</td>';
            })
            html += '</tr>';
            var UniqueArray = th.filter(function (element, index, self) {
                return index === self.indexOf(element);
            });

            for (var i = 0; i < UniqueArray.length; i++) {
                if (i == 0) {
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Sr.</th>');
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Name </th>');
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Roll No</th>');
                }
                $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > ' + UniqueArray[i] + '</th>');
            };

            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Got </th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Total </th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Percentage</th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Month / Year</th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Result On</th>');
            $("#tbody").append(html);
        },
        error: function (data) {
            console.log(data);
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Error While Searching Result</p>');
            $('#MyModal').modal('show');
        }
    })
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
                html += '<div class="ms-2" >';
                html += '<input type="radio" id="' + response[i].id + '" name="fav_language" value="' + response[i].name + '" onclick="ResultFilter(\'' + response[i].name + '\')">';
                html += '<label class="h6" for="css"> ' + response[i].name + ' </label><br>';
                html += '</div>';
            }
            $('#SectionName').append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Wrong Input</p>');
            $('#MyModal').modal('show');
        }
    })
}

function ResultFilter(SectionName) {
    var ClassId = $('#ClassIds').val();
    $.ajax({
        url: '/Admin/FilterStudentResult',
        data: { ClassId, SectionName },
        success: function (response) {
            $('#tbody').empty();
            $('#tableheader').empty();
            var html = "";
            var th = [];
            var x = 1;
            $.each(response, function (key, item) {
                var Total = 0;
                var TotalGot = 0;
                var Percentage = 0;
                var xx = x++;
                html += '<tr id="Serialkey" class="border">';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + xx + ' </td>';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + item[0].studentName + ' </td>';
                html += '<td class="border align-middle text-center text-dark" style = "border: 1px solid black" > ' + item[0].studentId + ' </td>';
                $.each(item, function (key, itemss) {
                    th.push(itemss.subjectName);
                    Total += (itemss.total);
                    TotalGot += (itemss.score);
                    html += '<td class="border align-middle text-center text-dark">' + itemss.score + ' </td>';
                })
                //To Adjust Date And Time in Good Format
                var DateTimeUploadOn = item[0].uploadOn;
                var JustDate = DateTimeUploadOn.split('T')[0];
                var newdate = moment(JustDate).format('DD-MM-YYYY');
                var justtime = DateTimeUploadOn.split('T')[1];
                var ts = justtime;
                var H = +ts.substr(0, 2);
                var h = (H % 12) || 12;
                h = (h < 10) ? ("0" + h) : h;
                var ampm = H < 12 ? " AM" : " PM";
                ts = h + ts.substr(2, 3) + ampm;

                Percentage = Math.round((TotalGot / Total) * 100);
                html += '<td class="border align-middle text-center text-dark">' + TotalGot + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + Total + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + Percentage + '% </td>';
                html += '<td class="border align-middle text-center text-dark">' + item[0].month + '   ' + item[0].batchYear + ' </td>';
                html += '<td class="border align-middle text-center text-dark">' + newdate + '   ' + ts + '</td>';
            })
            html += '</tr>';
            var UniqueArray = th.filter(function (element, index, self) {
                return index === self.indexOf(element);
            });

            for (var i = 0; i < UniqueArray.length; i++) {
                if (i == 0) {
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Sr.</th>');
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Name </th>');
                    $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col"> Roll No</th>');
                }
                $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > ' + UniqueArray[i] + '</th>');
            };

            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Got </th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Total </th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Percentage</th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Month / Year</th>');
            $("#tableheader").append('<th class="align-middle text-center text-dark" scope = "col" > Result On</th>');
            $("#tbody").append(html);
        },
        error: function (data) {
            $('#ModalHeader').append('<h4>Error</h4>');
            $('#ModalBody').append('<p>Error Occured</p>');
            $('#MyModal').modal('show');
        }
    })
}

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