
var app = angular.module('app', []);
app.controller('SecondaryController', ['$scope', '$http', '$window', '$filter', '$location', '$timeout',
    function ($scope, $http, $modal, $window, $filter, $location, $timeout) {

        $scope.OnLoad = function () {
            $scope.ShowImage2 = false;
            $scope.ShowImage1 = false;
            $scope.ShowImage = false;
            $scope.ShowUpdateButton = false;
            $http({
                url: 'https://localhost:7079/Education/GetSecondary',
                method: 'Get',
            }).then(function (response) {
                var Secondary = response.data;
                for (var i = 0; i < Secondary.length; i++) {
                    $scope.MainImage = Secondary[0].mainImage;
                    $scope.SecondaryHeading = Secondary[0].secondaryTextHeading;
                    $scope.SecondaryHeadingText = Secondary[0].mainText;
                }
                $scope.SecondaryData = response.data;;
            }), function () {

            }
        }

        function ltrim(str) {
            debugger
            if (!str) return str;
            var rstr = str.replace(/^\s+/g, '');
            if (!rstr) return rstr;
            return rstr.replace(/\s+$/g, '');
        }

        $scope.ChangeData = function (id) {
            debugger
            var RoleIds = localStorage.getItem('RoleId');
            if (RoleIds == 1) {
                $scope.ShowUpdateButton = true;
                const Prices = document.getElementById(id).contentEditable = "true";
            }
        }

        $scope.imgdata;
        $scope.ChangeImage = function (imgdata) {
            debugger
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

        $scope.UpdateSecondary = function () {
            debugger
            var token = localStorage.getItem('token');
            var MainImage = document.getElementById('multipleShowImage').files[0];
            var SecondaryImage = document.getElementById('multipleShowImage1').files[0];
            var Id = angular.element(document.getElementById('DataId')).text();
            var SecondaryHeadingText1 = ltrim(angular.element(document.getElementById('SecondaryHeadingText1'))[0].innerText);
            var SecondaryHeading = ltrim(angular.element(document.getElementById('SecondaryHeading1'))[0].innerText);
            var Text = ltrim(angular.element(document.getElementById('SecondaryText'))[0].innerText);
            debugger
            var UpdateSecondaryDTO = new FormData();
            UpdateSecondaryDTO.append('Id', Id);
            UpdateSecondaryDTO.append('MainImage', MainImage);
            UpdateSecondaryDTO.append('SecondaryTextHeading', SecondaryHeading);
            UpdateSecondaryDTO.append('MainText', SecondaryHeadingText1);
            UpdateSecondaryDTO.append('SecondaryImage', SecondaryImage);
            UpdateSecondaryDTO.append('Text', Text);
            debugger
            $http({

                url: "https://localhost:7079/Education/UpdateSecondaryEducation",
                method: "Post",
                datatype: 'Json',
                data: UpdateSecondaryDTO,
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
    }]);
