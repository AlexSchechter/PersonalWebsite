angular.module('app', []).controller('appController', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {
    $scope.blogEntryPick = null;
    $scope.blogEntries = null;
    $scope.blogEntryID = 0;
    $scope.blogBody = null;

    $scope.getBlogEntries = function () {
        $http.get('../BlogEntries/GetBlogEntries').then(function (response) {
            $scope.blogEntries = response.data;
        });
    }

    $scope.goList = function () {
        $scope.blogEntryPick = null;
    }
    

    $scope.getBlogEntry = function (id) {
        var options = { params: { id: id }}
        $http.get('../BlogEntries/GetBlogEntry', options).then(function (response){
            $scope.blogEntryPick = response.data;
            //$scope.blogBody = $sce.trustAsHtml($scope.blogEntryPick.Body);
            $scope.convertHTML($scope.blogEntryPick.Body);
        });
    }

    $scope.getPrettyDateFormat = function (rawDate) {
        var myDate = new Date(parseInt(rawDate.substr(6)));
        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]
        return myDate.getDate() + " " + monthNames[myDate.getMonth()] + " " + myDate.getFullYear();
    }

    $scope.convertHTML = function (myHTML) {
        $scope.blogBody = $sce.trustAsHtml(myHTML);
    }

    $scope.getBlogEntries();

}])