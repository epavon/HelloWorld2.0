$(function () {

    var postTitles = [];

    //
    // Handy support functions
    if (typeof String.prototype.startsWith != 'function') {
        String.prototype.startsWith = function (str) {
            return this.slice(0, str.length) == str;
        };
    }

    function isLetterOrNumber(str) {
        return str.length === 1 && str.match(/[a-zA-Z0-9]/i);
    }

    var isValidEmail = function (email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }

    //
    // sticky menu bar
    function sticky_relocate() {
        var window_top = $(window).scrollTop();
        var div_top = $('#sticky-anchor').offset().top;
        if (window_top > div_top) {
            $('#sticky').addClass('stick');
        } else {
            $('#sticky').removeClass('stick');
        }
    }

    $(window).scroll(sticky_relocate);
    sticky_relocate();

    //
    // Get all the posts' titles
    var fillPostTitles = function () {
        var titles = $('.post-title a');
        titles.each(function (index, ele) {
            postTitles.push(ele.outerText);
        });

    }();


    $('#search-posts').bind('input', function (data) {
        var keyDown = data.target.value.slice(data.target.value.length - 1);
        var searchTerm = $('#search-posts')[0].value;

        postTitles.forEach(function (ele, index) {
            if (!ele.toLowerCase().startsWith(searchTerm.toLowerCase())) {
                // TODO: Find .apost element with Title = ele and add class .hide to it
                $('.apost[data-title=\'' + ele + '\'').addClass('hide');

            } else {
                $('.apost[data-title=\'' + ele + '\'').removeClass('hide');
            }
        });
    });

    var getPosts = function () {
        ajaxCall('GET', '/', function (response) {
            alert('foo');
        },
        function (err) {
            alert('goo');
        });

    }

    //
    /// HANDLE AJAX RESPONSE
    var onContactSuccess = function () {
        $('#contact-comment').val('');
        $('#contact-email').val('');
    }

    var onContactError = function (error) {
        var goo = error;
        var foo = 4;
    }

    //
    // EVENT HANDLERS

    $('#contact-submit').click(function (e) {
        var email = $('#Email').val();
        var comment = $('#Content').val();

        if (!email || email == '' || !isValidEmail(email)) {
            alert('Please enter a valid email');
            return false;
        }

        if (!comment || comment == '') {
            alert('Please enter a comment');
            return false;
        }

    });

    $('#comment-submit').click(function (e) {
        var user = $('#comment-user').val();
        var comment = $('#comment-content').val();
        var postid = $('#post-id').val();

        if (!user || user == '') {
            alert('Please enter a valid email');
            return false;
        }

        if (!comment || comment == '') {
            alert('Please enter a comment');
            return false;
        }

        ajaxCall('POST', '/Posts/AddComment', { 'Content': comment, 'Author': user, 'PostId':postid },
            function (response) {
                $('.acomment .one-comment:last').after(
                    '<div data-comment-id="' + 5 + '" class="one-comment">' +
                    '<span class="shift-slighly-right"><b>' + 'author' + '</b></span>' +
                    '<br />' +
                    '<div class="shift-right" style="margin-left: 5px;">' + 'content' + '</div>' +
                    '<br />'
                );
                alert('success');
            },
            function (err) {
                alert('error');
            }
        );
    });

    $('#add-post').click(function() {
        window.location = "/ManagePosts/Create";
    });

    $('.edit-post-content').click(function () {
        postId = $(this).parent().data('post-id');
        window.location = "/Posts/Edit/" + postId;
    });

    $('.edit-comment').click(function () {
        commentId = $(this).parent().data('comment-id');
        window.location = "/ManageComments/Edit/" + commentId;
    });

    $('.delete-comment').click(function () {
        commentId = $(this).parent().data('comment-id');
        window.location = "/ManageComments/Delete/" + commentId;
    });

    //
    /// ---------
    function imageIsLoaded(e) {
        var imgStr = "<img src=" + e.target.result + " style='width:300px;height:200px;'>";
        $('#Content').append(imgStr);

    }

    function insertImage(img) {
        var cursorPosition = $('#text-here').prop("selectionStart");

    }

    function replaceSelectedText(replacementText) {
        var sel, range;
        if (window.getSelection) {
            sel = window.getSelection();
            if (sel.rangeCount) {
                range = sel.getRangeAt(0);
                range.deleteContents();
                range.insertNode(document.createTextNode(replacementText));
            }
        } else if (document.selection && document.selection.createRange) {
            range = document.selection.createRange();
            range.text = replacementText;
        }
    }

    //
    // Event Handlers 
    $('#file-input').change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = imageIsLoaded;
            reader.readAsDataURL(this.files[0]);
        }
    });

    $('#post-image').click(function () {
        var selection = window.getSelection();
        var range;

        if (selection.rangeCount) {
            range = selection.getRangeAt(0);
            //range.insertNode(
        }

    });

    //
    /// AJAX CALLS

    var ajaxCall = function (type, url, data, onsuccess, onerror) {
        if (type.toLowerCase() == 'post') {
            data = JSON.stringify(data);
        }

        $.ajax({
            type: type,
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: data,
            error: onerror,
            success: onsuccess
        });
    }



    //
    // INIT 
    $('#userActions').popover({
        html: true,
        content: function () {
            return $('#logout-content').html();
        }
    });

});