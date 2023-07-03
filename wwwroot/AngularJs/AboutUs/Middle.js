
var app = angular.module('app', []);
app.controller('MiddleController', ['$scope', '$http','$window', '$filter', '$location', '$timeout',
    function ($scope, $http, $modal, $window, $filter, $location, $timeout) {
        $scope.OnLoad = function () {
            $scope.ShowImage2 = false;
            $scope.ShowImage1 = false;
            $scope.ShowImage = false;
            $scope.ShowUpdateButton = false;
            $http({
                url: 'https://localhost:7079/Education/GetMiddle',
                method: 'Get',
            }).then(function (response) {
                var Middle = response.data;
                for (var i = 0; i < Middle.length; i++) {
                    $scope.MainImage = Middle[0].mainImage;
                    $scope.MiddleHeading = Middle[0].middleTextHeading;
                    $scope.MiddleHeadingText = Middle[0].mainText;
                }
                $scope.MiddleData = response.data;
            }), function () {

            }
        }

        $scope.UpdateMiddle = function () {
            var token = localStorage.getItem('token');
            var MainImage = document.getElementById('multipleShowImage').files[0];
            var MiddleImage = document.getElementById('multipleShowImage1').files[0];
            var Id = angular.element(document.getElementById('DataId')).text();
            var MainText = ltrim(angular.element(document.getElementById('MiddleHeadingText1'))[0].innerText);
            var MiddleTextHeading = ltrim(angular.element(document.getElementById('MiddleHeading1'))[0].innerText);
            var Text = ltrim(angular.element(document.getElementById('MiddleText1'))[0].innerText);
            var UpdateMiddleDTO = new FormData();
            UpdateMiddleDTO.append('Id', Id);
            UpdateMiddleDTO.append('MainImage', MainImage);
            UpdateMiddleDTO.append('MiddleTextHeading', MiddleTextHeading);
            UpdateMiddleDTO.append('MainText', MainText);
            UpdateMiddleDTO.append('MiddleImage', MiddleImage);
            UpdateMiddleDTO.append('Text', Text);
            $http({
                url: "https://localhost:7079/Education/UpdateMiddleEducation",
                method: "Post",
                datatype: 'Json',
                data: UpdateMiddleDTO,
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
                if (imgdata == 'ShowImage2') {
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
