(function () {
    

    var CommentsController = function ($scope, $http, $sce) {
        var Comments = this;
        this.comments = [];
        this.newComment = {};
        var baseUri = "/api/posts/";

        this.getComments = function () {
            var postid = document.getElementById('comments-post-id').value;
            $http.get(baseUri + postid + "/comments").then(function (response) {
                for (var i = 0; i < response.data.length; ++i) {
                    response.data[i].displayContent = $sce.trustAsHtml(response.data[i].displayContent);
                }
                Comments.comments = response.data;
            });
        }
        this.getComments();

        this.addComment = function (acomment) {
            var postid = document.getElementById('comments-post-id').value;
            var data = { Author: 'fooer', Date: '4/4/2018', Content: 'fooing some more' };

            $http.post(baseUri + postid + "/add", acomment).then(function (response) {
                var goo = 42;
                this.comments.push(response.data);
            }.bind(this));
        };

    }
    helloworldapp.controller('CommentsController', ['$scope', '$http', '$sce', CommentsController]);
}());