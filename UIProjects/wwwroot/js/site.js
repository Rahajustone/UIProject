$.ajax({
    url: "https://localhost:5001/api/entry",
    data: {
        format: 'json'
    },
    error: function (err) {
        console.log(err);
    },
    dataType: 'jsonp',
    contentType: "application/jsonp; charset=utf-8",
    success: function (data) {
        console.log(data);
    },
    type: 'GET'
});