
var app = angular.module('app', []);
app.controller('VisionandMissionController', ['$scope', '$http', '$window', '$filter', '$location', '$timeout',
    function ($scope, $http, $modal, $window, $filter, $location, $timeout) {

        $scope.isAdmin = false;

        $scope.OnLoad = function () {
            $scope.ShowImage2 = false;
            $scope.ShowImage1 = false;
            $scope.ShowImage = false;
            $scope.ShowUpdateButton = false;
            $http({
                url: 'https://localhost:7079/VisionandMission/VisionandMission',
                method: 'Get',
            }).then(function (response) {
                console.log('res', response);
                let RoleId = localStorage.getItem('RoleId');
                if (RoleId == 1) {
                    $scope.isAdmin = true;
                }
                $scope.VisionandMission = response.data;
                for (var i = 0; i < response.data.length; i++) {
                    $scope.Id = response.data[0].id;
                    $scope.MainImage = response.data[0].mainImage;
                    $scope.MainText1 = response.data[0].ourPlanText;
                }
            }), function (data) {
                alert('Error');
            }
        }

        $scope.ChangeData = function (data) {
            $('#ModalHeader').empty();
            $('#ModalBody').empty();
            $('#MyModal').modal('hide');

            $('#ModalHeader').append('<h5>Change Value</h5>');
            $('#ModalBody').append('<p contenteditable="true" id="ForChangeData">' + data +'</p><button class="btn btn-success" id="UPdatedata" >Update</button>');
            $('#MyModal').modal('show');
        }

        $scope.UpdateVision = function () {
            var token = localStorage.getItem('token');
            var MainImage = document.getElementById('multipleShowImage').files[0];
            var VisionImage = document.getElementById('multipleShowImage1').files[0];
            var MissionImage = document.getElementById('multipleShowImage2').files[0];
            var Id = angular.element(document.getElementById('DataId')).text();
            var OurPlanText = ltrim(angular.element(document.getElementById('MainText2'))[0].innerText);
            var VisionText = ltrim(angular.element(document.getElementById('VisionText2'))[0].innerText);
            var MissionText = ltrim(angular.element(document.getElementById('MissionText2'))[0].innerText);
            var UpdateVisionMission = new FormData();
            UpdateVisionMission.append('Id', Id);
            UpdateVisionMission.append('MainImage', MainImage);
            UpdateVisionMission.append('OurPlanText', OurPlanText);
            UpdateVisionMission.append('VisionText', VisionText);
            UpdateVisionMission.append('VisionImage', VisionImage);
            UpdateVisionMission.append('MissionImage', MissionImage);
            UpdateVisionMission.append('MissionText', MissionText);
            debugger
            $http({
              
                url: "https://localhost:7079/VisionandMission/UpdateVisionMission",
                method: "Post",
                datatype: 'Json',
                data: UpdateVisionMission,
                transformRequest: angular.identity,
                headers: {
                    'Content-Type': undefined,
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

        function ShowNewImage(MainImage1) {
            debugger
            var file = $("input[type=file]").get(0).files[0];
            if (file) {
                var reader = new FileReader();
                reader.onload = function () {
                    $('#UserNewImage').attr("src", reader.result);
                }
                reader.readAsDataURL(file);
            }
        }

 
        $scope.ChangeData = function (id) {
            var RoleIds = localStorage.getItem('RoleId');

            if (RoleIds == 1) {
                $scope.ShowUpdateButton = true;
                const Prices = document.getElementById(id).contentEditable = "true";
            }
        }
        $scope.imgdata;
        $scope.ChangeImage = function (imgdata) {
            var RoleIds = localStorage.getItem('RoleId');
            if (RoleIds == 1) {
                $scope.ShowUpdateButton = true;
                if (imgdata =='ShowImage2') {
                    $scope.ShowImage2 = true;
                    $scope.ShowImage1 = false;
                    $scope.ShowImage = false;
                }
                if (imgdata == 'ShowImage1') {
                    $scope.ShowImage1 = true;
                    $scope.ShowImage2 = false;
                    $scope.ShowImage = false;
                }
                if (imgdata == 'ShowImage') {
                    $scope.ShowImage = true;
                    $scope.ShowImage1 = false;
                    $scope.ShowImage2 = false;
                }
            }
        }
    }]);
