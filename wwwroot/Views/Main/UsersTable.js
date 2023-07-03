$(document).ready(function () {
    GetAllUsers();
})

function GetAllUsers() {
    var UserName = $('#UserName').val();
    $.ajax({
        url: '/Admin/GetAllUsers',
        data: { UserName },
        success: function (response) {
            $('#tbody').empty();
            var html = "";
            var x = 1;
            for (var i = 0; i < response.length; i++) {
                var xx = x++;
                html += '<tr id="Serialkey"><td class="align-middle text-center text-dark">' + xx + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].name + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].parent?.name + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].roles?.rolesName + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].phone + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].email + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].cnic + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].gender + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].age + '</td>';
                html += '<td class="align-middle text-center text-dark">' + response[i].createdOn + '</td>';
                html += ((response[i].status == false) ? '<td class="align-middle text-center text-dark"> Blocked </td>)' :'<td class=" align-middle text-center text-dark"> Active </td>');
                html += '<td class="item"><img style="height: 70px ; width : 90px" src="' + response[i].image + '"></td>';
               // html += '<td class="border align-middle text-center"><a href="#" onclick="BlockUser(' + response[i].id + ')"><i class="fas fa-trash-alt" style="font-size: 24px"></i></a></td>';
                html += '<td class=" align-middle text-center"><a href="#" onclick="EditUser(' + response[i].id + ',' + response[i].roles?.id +')" ><i class="fa fa-pencil" style="font-size: 24px ; color:darkblue"></i></a></td></tr>';
            }
            $("#tbody").append(html);
        },
        error: function (data) {
            alert('Error');
        }
    })
}

function BlockUser(id) {
    $.ajax({
        url: '/Admin/BlockUserbyId?id=' + id,
        success: function (response) {
            location.reload();
        },
        error: function (data) {
            alert('Error');
        }
    })
}

function EditUser(id, roleid) {
    debugger
    window.location.replace('/Admin/EditUser?id='+ id + ',' + roleid);
}