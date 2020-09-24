$(document).ready(function () { 
    $("#Profile_ProfileUrl").change(function () { 
        var Profile_ProfileUrl_val = $("#Profile_ProfileUrl").val().replace("www.", "");
        var Profile_PROCODE_val = $("#Profile_PROCODE").val(); 
        if (Profile_PROCODE_val == '') {
            var myRegexp = /(?:^|.*):\/\/(.*?)\.(?:.*|$)/g;
            var match = myRegexp.exec(Profile_ProfileUrl_val);
            if (match != null) {
                $("#Profile_PROCODE").val(match[1].toUpperCase()); 
            }
        } 
    });
    $("#Profile_PROCODE").change(function () { 
        var Profile_PROCODE_val = $("#Profile_PROCODE").val();
        if (Profile_PROCODE_val != '') { 
            $("#Profile_PROCODE").val(Profile_PROCODE_val.toUpperCase()); 
        }
    });
});