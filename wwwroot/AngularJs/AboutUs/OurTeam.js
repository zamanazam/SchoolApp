
var app = angular.module('app', []);
app.controller('OurTeamController', ['$scope', '$http', '$window', '$filter', '$location', '$timeout',
    function ($scope, $http, $modal, $window, $filter, $location, $timeout) {
        var token = localStorage.getItem('token');
        var RoleIds = localStorage.getItem('RoleId');

        $scope.OnLoad = function () {
            debugger
            $scope.AddNewModalIcon = false;
            if (RoleIds == 1) {
                $scope.AddNewModalIcon = true;
            }
            $scope.AddNewModal = false;
            $scope.ShowImage = false;
            $http({
                url: 'https://localhost:7079/Education/GetOurTeam',
                method: 'Get',
            }).then(function (response) {
                $scope.OurTeamData = response.data;
            }), function () {

            }
        }

        $scope.ChangeRowData = function (data) {
            if (RoleIds == 1) {
                const btndata = document.getElementById('btn' + data).hidden = false;
                const btndeldata = document.getElementById('delbtn' + data).hidden = false;
                const Designationdata = document.getElementById('Designation' + data).contentEditable = "true";
                const paragraphdata = document.getElementById('OurTeamTextid' + data).contentEditable = "true";
            }
        }

        $scope.GetNewTeamMembers = function () {
            $http({
                url: 'https://localhost:7079/Education/GetNewTeachers',
                method: 'Get',
            }).then(function (response) {
                var html = "";
                console.log('resp', response);
                $scope.NewTeamMembers = [];
                for (var i = 0; i < response.data.length; i++) {
                    html += '<option value="' + response.data[i].id +'">' + response.data[i].name +'</option>'
                    //$scope.NewTeamMembers.push('TeacherName',response.data[i].name);
                    //$scope.NewTeamMembers.push('id',response.data[i].id);
                }
                $('#NewTeachers').append(html);
            }), function () {

            }
        }

        $scope.AddNewMembers = function () {
            var Teacherid = angular.element(document.getElementById('NewTeachers'))[0].selectedOptions[0].value;
            var Designation = angular.element(document.getElementById('NewDesignation'))[0].value;
            var Text = angular.element(document.getElementById('NewDescription'))[0].value;
            var AddNewTeamMember = {
                Teacherid,
                Designation,
                Text
            }
            $http({
                url: 'https://localhost:7079/Education/AddNewTeamMember',
                method: "Post",
                datatype: 'Json',
                data: AddNewTeamMember,
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            }).then(function (response) {
                window.location.reload();
            }, function () {
                $('#ModalHeader').append('<h4>Error</h4>');
                $('#ModalBody').append('<p>Error While Saving Product</p>');
                $('#MyModal').modal('show');
            })
        }

        $scope.DeleteAboutUs = function (id) {
            debugger
            $http({
                url: 'https://localhost:7079/Education/DeleteTeamMemberbyId',
                method: "Post",
                datatype: 'Json',
                data: id,
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            }).then(function (response) {
                window.location.reload();
            }, function () {
                $('#ModalHeader').append('<h4>Error</h4>');
                $('#ModalBody').append('<p>Error While Saving Product</p>');
                $('#MyModal').modal('show');
            })
        }


        $scope.UpdateAboutUs = function (data) {
            var id = data;
            var Designation = ltrim(angular.element(document.getElementById('Designation' + data))[0].innerText);
            var Text = ltrim(angular.element(document.getElementById('OurTeamTextid' + data))[0].innerText);
            var UpdateOurTeamDTO = {
                id,
                Designation,
                Text
            };
            $http({
                url: "https://localhost:7079/Education/UpdateOurTeambyId",
                method: "Post",
                datatype: 'Json',
                data: UpdateOurTeamDTO,
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            }).then(function (response) {
                window.location.reload();
            }, function () {
                $('#ModalHeader').append('<h4>Error</h4>');
                $('#ModalBody').append('<p>Error While Saving Product</p>');
                $('#MyModal').modal('show');
            })
        }

        function ltrim(str) {
            if (!str) return str;
            var rstr = str.replace(/^\s+/g, '');
            if (!rstr) return rstr;
            return rstr.replace(/\s+$/g, '');
        }

        $scope.AddNewMemberInfo = function () {
            if ($scope.AddNewModal == true) {
                $scope.AddNewModal = false;
            }
            else {
                $scope.GetNewTeamMembers();
                $scope.AddNewModal = true;
            }
        }
    }]);
