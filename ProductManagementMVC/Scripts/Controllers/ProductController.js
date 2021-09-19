var ProductController = function ($scope, $http, $rootScope) {
    $rootScope.showLogout = true;
    $scope.btntext = "Save";
    //// Add record
    $scope.query = {}
    $scope.queryBy = '$'
    $scope.savedata = function () {

        $scope.btntext = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Home/Add',

            data: $scope.register

        }).success(function (d) {

            $scope.btntext = "Save";

            $scope.register = null;

            alert(d);
            $http.get("/Home/GetAll").then(function (d) {

                $scope.record = d.data;

            }, function (error) {

                alert('Failed');

            });

        }).error(function () {

            alert('Failed');

        });

    };

    // Display all record

    $http.get("/Home/GetAll").then(function (d) {

        $scope.record = d.data;

    }, function (error) {

        alert('Failed');

    });

    // Display record by id

    $scope.loadrecord = function (id) {

        $http.get("/Home/Get?id=" + id).then(function (d) {
          
            $scope.register = d.data;
            
        }, function (error) {

            alert('Failed');

        });

    };

    // Delete record

    $scope.deleterecord = function (id) {

        $http.get("/Home/Delete?id=" + id).then(function (d) {

            alert(d.data);

            $http.get("/Home/GetAll").then(function (d) {

                $scope.record = d.data;

            }, function (error) {

                alert('Failed');

            });

        }, function (error) {

            alert('Failed');

        });

    };

    // Update record

    $scope.updatedata = function () {

        $scope.btntext = "Please Wait..";
        
        $http({

            method: 'POST',

            url: '/Home/Update',

            data: $scope.register

        }).success(function (d) {

            $scope.btntext = "Update";

            $scope.register = null;

            alert(d);

            $http.get("/Home/GetAll").then(function (d) {

                $scope.record = d.data;

            }, function (error) {

                alert('Failed');

            });

        }).error(function () {

            alert('Failed');

        });

    };
}

ProductController.$inject = ['$scope', '$http', '$rootScope'];
