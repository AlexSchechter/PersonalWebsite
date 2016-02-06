angular.module('app', []).controller('appController', ['$scope', '$http', '$sce', '$timeout', function ($scope, $http, $sce, $timeout) {
    $scope.blogEntryPick = null;
    $scope.blogEntries = null;
    $scope.blogEntryID = 0;
    $scope.blogBody = null;
    $scope.comments = null;
    $scope.title = "Enter Title";
    $scope.body = "Enter Body"
    $scope.searchStr = null;
    $scope.searchBlogOn = true;
    $scope.displaySearch = "Search Blog";
    $scope.searchInput = "";

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
            $scope.convertHTML($scope.blogEntryPick.Body);
        });
    }

    $scope.getComments = function () {
        $http.get('../Comments/GetComments').then(function (response) {
            $scope.comments = response.data;
        });
    }

    $scope.getCommentsWithDelay = function () {
        $timeout(function () {
            $scope.getComments();
            document.getElementById("commentForm").reset();
            $scope.title = "Your comment has been saved and is now displayed at the top of the comments section";
            $scope.body = "Enter another comment here";
        }, 500);
    }

    $scope.getPrettyDateFormat = function (rawDate) {
        var myDate = new Date(parseInt(rawDate.substr(6)));
        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]
        return myDate.getDate() + " " + monthNames[myDate.getMonth()] + " " + myDate.getFullYear();
    }

    $scope.convertHTML = function (myHTML) {
        $scope.blogBody = $sce.trustAsHtml(myHTML);
    }


    $scope.getComments();

    $scope.getBlogEntries();

    $scope.searchBlog = function () {
        if ($scope.searchBlogOn) {
            var options = { params: { searchStr: $scope.searchStr } };
            $http.get('../BlogEntries/SearchBlog', options).then(function (response) {
                $scope.blogEntries = response.data;
            });
            $scope.displaySearch = "Display All Blogs"
            $scope.searchInput = document.getElementById('searchStr').value;
        }
        else {
            $scope.getBlogEntries();
            $scope.displaySearch = "Search Blog";
            document.getElementById('searchStr').value = null;
        }
        $scope.searchBlogOn = !$scope.searchBlogOn;
    }
}])