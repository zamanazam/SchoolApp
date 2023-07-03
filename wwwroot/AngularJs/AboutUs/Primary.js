
var apps = angular.module('app', []);
apps.controller('PrimaryController', ['$scope', '$http','$window','$filter','$location','$timeout',
    function ($scope, $http, $window, $filter, $location, $timeout) {

        $scope.OnLoad = function () {
            $scope.ShowImage2 = false;
            $scope.PrimaryImage = false;
            $scope.ShowImage = false;
            $scope.ShowUpdateButton = false;
        $http({
            url: 'https://localhost:7079/Education/GetPrimary',
            method: 'Get',
        }).then(function (response) {
            var Primary = response.data;
            for (var i = 0; i < Primary.length; i++) {
                $scope.MainImage = Primary[0].mainImage;
                $scope.PrimaryHeading = Primary[0].primaryTextHeading;
                $scope.PrimaryHeadingText = Primary[0].mainText;
            }
            $scope.PrimaryData = response.data;;
        }), function () {

        }
    }

        $scope.ChangeImage = function (imgdata) {
            var RoleIds = localStorage.getItem('RoleId');
            if (RoleIds == 1) {
                $scope.ShowUpdateButton = true;
                if (imgdata == 'PrimaryImage') {
                    $scope.PrimaryImage = true;
                    $scope.ShowImage = false;
                }
                if (imgdata == 'ShowImage') {
                    $scope.ShowImage = true;
                    $scope.PrimaryImage = false;
                }
            }
        }

        $scope.ChangeData = function (id) {
            var RoleIds = localStorage.getItem('RoleId');

            if (RoleIds == 1) {
                $scope.ShowUpdateButton = true;
                const Prices = document.getElementById(id).contentEditable = "true";
            }
        }

        $scope.UpdatePrimaryEducation = function () {
            var token = localStorage.getItem('token');
            var MainImage = document.getElementById('multipleShowImage').files[0];
            var PrimaryImage = document.getElementById('multipleprimaryimage').files[0];
            var Id = angular.element(document.getElementById('DataId')).text();
            var PrimaryTextHeading = ltrim(angular.element(document.getElementById('PrimaryHeading1'))[0].innerText);
            var MainText = ltrim(angular.element(document.getElementById('PrimaryHeadingText1'))[0].innerText);
            var Text = ltrim(angular.element(document.getElementById('PrimaryText1'))[0].innerText);
            var UpdatePrimaryDTO = new FormData();
            UpdatePrimaryDTO.append('Id', Id);
            UpdatePrimaryDTO.append('MainImage', MainImage);
            UpdatePrimaryDTO.append('MainText', MainText);
            UpdatePrimaryDTO.append('PrimaryTextHeading', PrimaryTextHeading);
            UpdatePrimaryDTO.append('Text', Text);
            UpdatePrimaryDTO.append('PrimaryImage', PrimaryImage);
            $http({
                url: "https://localhost:7079/Education/UpdatePrimaryEducation",
                method: "Post",
                datatype: 'Json',
                data: UpdatePrimaryDTO,
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
}])
