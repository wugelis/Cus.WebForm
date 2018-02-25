var app = angular.module("app", []);
app.controller("Ctrl", ["$scope", "$http", function ($scope, $http) {
    $scope.Msg = [];
    $scope.EqualHundred = function (obj) {
        $http.get('/api/CusOrderApi/'+obj).success(function (data) {
            $scope.Msg = data;
            //alert($scope.Msg);
        }).error(function (data) {
            alert("擷取資料時發生錯誤。");
        })
    }

    $scope.CusList = [];
    $http.get('/api/CusApi/').success(function (data) {
        $scope.CusList = data;
        $scope.selection = $scope.CusList[0]; //抓一個 Model 的模型
        //alert($scope.Msg);
    }).error(function (data) {
        alert("擷取資料時發生錯誤。");
    })

}])