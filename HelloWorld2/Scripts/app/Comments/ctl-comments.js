(function () {
    

    var CommentsController = function ($scope, $http) {
        var Comments = this;
        this.comments = [];

        this.getComments = function () {
            $http.get("/api/posts/4/comments").then(function (response) {
                Comments.comments = response.data;
            });
        }
        this.getComments();

        this.addComment = function () {

        };

    }
    helloworldapp.controller('CommentsController', ['$scope', '$http', CommentsController]);
}());