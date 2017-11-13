$(function () {
    $("#sortable1, #sortable2, #sortable3").sortable({
        connectWith: ".connectedSortable",
        update: function () {
            var column = this.id;
            var newOrder = '';
            newOrder = $('#' + column).sortable('toArray').toString();
            if (newOrder != '') {
            $.ajax({
                type: "GET",
                url: '/Tasks/UpdateNewList',
                contentType: "application/json; charset=utf-8",
                data: {
                    "column": column,
                    "tasks": newOrder
                },
                datatype: "json",
                success: function (data) {
                    //alert("sucesso");
                },
                error: function () {
                    alert("ERRO");
                }
                });
            }  
        }
    }).disableSelection();
});

function UpdateTasks(column, tasksId) {
        var UpdateTasksPostBackURL = '/Tasks/UpdateNewList';
        $.ajax({
            type: "GET",
            url: '/Tasks/UpdateNewList',
            contentType: "application/json; charset=utf-8",
            data: {
                "column": column,
                "tasks": tasksId
            },
            datatype: "json",
            success: function (data) {
               //alert("sucesso");
            },
            error: function () {
                alert("ERRO");
            }
        });   
};


var DetailPostBackURL = '/Tasks/Details';
$(function () {
    $(".anchorDetail").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: DetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#modalDetailsContent').html(data);
                $('#modalDetails').modal(options);
                $('#modalDetails').modal('show');

            },
            error: function () {
                alert("ERRO");
            }
        });
    });

    $("#closbtn").click(function () {
        $('#modalDetails').modal('hide');
    });
});

var DeletePostBackURL = '/Tasks/Delete';
$(function () {
    $(".anchorDelete").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: DeletePostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#modalDeleteContent').html(data);
                $('#modalDelete').modal(options);
                $('#modalDelete').modal('show');

            },
            error: function () {
                alert("ERRO");
            }
        });
    });

    $("#closbtn").click(function () {
        $('#modalDelete').modal('hide');
    });
});

var CreatePostBackURL = '/Tasks/Create';
$(function () {
    $(".anchorCreate").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: CreatePostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#modalCreateContent').html(data);
                $('#modalCreate').modal(options);
                $('#modalCreate').modal('show');

            },
            error: function () {
                alert("ERRO");
            }
        });
    });

    $("#closbtn").click(function () {
        $('#modalCreate').modal('hide');
    });
});

var EditPostBackURL = '/Tasks/Edit';
$(function () {
    $(".anchorEdit").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: EditPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#modalEditContent').html(data);
                $('#modalEdit').modal(options);
                $('#modalEdit').modal('show');

            },
            error: function () {
                alert("ERRO");
            }
        });
    });

    $("#closbtn").click(function () {
        $('#modalEdit').modal('hide');
    });
});
