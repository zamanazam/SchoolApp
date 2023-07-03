
(function () {
    "use strict";
    angular.module('app', [])
        .config(function ($locationProvider) {
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });
        }).value('apiUrl', angular.element(document).find('meta[name=apiUrl]').prop("content"));

    angular.module('app')
        .directive("compareTo", function () {
            return {
                require: "ngModel",
                scope:
                {
                    pass: "=compareTo"
                },

                link: function (scope, element, attributes, paramval) {
                    paramval.$validators.compareTo = function (val) {
                        return val == scope.pass;
                    };

                    scope.$watch("ConfirmPassword", function () {
                        paramval.$validate();
                    });

                }

            };

        });
    angular.module("app").directive('customOnChange', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                const onChangeHandler = scope.$eval(attrs.customOnChange);
                element.on('change', onChangeHandler);
                element.on('$destroy', function () {
                    element.off();
                });

            }
        };
    });

})();


const convertBlobToBase64 = async (blob) => {
    return blobToBase64(blob);
}
const blobToBase64 = blob => new Promise((resolve, reject) => {

    const reader = new FileReader();
    reader.readAsDataURL(blob);
    reader.onload = () => resolve(reader.result.split(',')[1]);
    reader.onerror = error => reject(error);
});
const HandleError = (err) => {
    console.log("Error", err)
    if (err.data)
        toastr.error(err.data.ExceptionMessage + " - " + err.data.InnerException.ExceptionMessage);
    else if (err.statusText)
        toastr.error(err.statusText);
}
const getSessionData = () => {
    let sessionData = window.sessionStorage.getItem("Mandoubak_Session");
    sessionData = JSON.parse(sessionData);
    return sessionData;
}
const getVerificationData = () => {
    const sessionData = getSessionData();
    return {
        Email: sessionData.Email,
        MobileNumber: sessionData.MobileNumber
    };
};
const getPagination = (TotalOrderCount, page) => {
    let totalPages = TotalOrderCount / 10;
    if (totalPages < 1)
        totalPages = 1;
    const currentPage = page ?? 1;
    let startPage = currentPage - 5;
    let endPage = currentPage + 4;
    if (startPage <= 0) {
        endPage -= (startPage - 1);
        startPage = 1;
    }
    if (endPage > totalPages) {
        endPage = totalPages;
        if (endPage > 10) {
            startPage = endPage - 9;
        }
    }
    const pagination = {
        TotalItems: TotalOrderCount,
        CurrentPage: currentPage,
        PageSize: 10,
        TotalPages: totalPages,
        StartPage: startPage,
        EndPage: endPage,
    };
    return pagination;
}
const validateFileSize = (file) => {
    if (file.size > 1048576) {
        toastr.error('File size Should be less than 1 mb');
        return false;
    }
    return true;
}
const ApiRequestConfigs = () => {
    const cookie = getCookie("AuthData");
    if (cookie) {
        const authData = JSON.parse(cookie);
        return {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + (authData?.access_token || "")
            }
        }
    } else {
        return {
            headers: {
                'Content-Type': 'application/json'
            }
        }
    }
}


const setCookie = (name, value, exp_days) => {
    const d = new Date();
    d.setTime(d.getTime() + (exp_days * 24 * 60 * 60 * 1000));
    const expires = "expires=" + d.toGMTString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}

const getCookie = (name) => {
    const cname = name + "=";
    const decodedCookie = decodeURIComponent(document.cookie);
    const ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(cname) == 0) {
            return c.substring(cname.length, c.length);
        }
    }
    return "";
}