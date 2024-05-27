$(document).ready(function () {
    // Set User Type Dropdown
    $.ajax({
        type: "GET",
        url: "/Common/GetUserTypeDropdown",
        success: function (respone) {
            var userTypeDrodown = '<option value=""> --Select-- </option>';
            $.each(respone, function (index, value) {
                userTypeDrodown += '<option value="' + value.id + '">' + value.title + '</option>';
            })
            $("#ddlUserType").html(userTypeDrodown);
        },
        error: function () {

        },
        complete: function () {

        }
    })

    // Set Country Dropdown
    $.ajax({
        type: "GET",
        url: "/Common/GetCountryDropdown",
        success: function (respone) {
            var countryDrodown = '<option value=""> --Select-- </option>';
            $.each(respone, function (index, value) {
                countryDrodown += '<option value="' + value.id + '">' + value.title + '</option>';
            })
            $("#ddlCountry").html(countryDrodown);
        },
        error: function () {

        },
        complete: function () {

        }
    })

    // Set State Dropdown
    $("#ddlCountry").change(function () {
        $.ajax({
            type: "GET",
            url: "/Common/GetStateDropdown?countryId=" + $("#ddlCountry").val(),
            success: function (respone) {
                var stateDrodown = '<option value=""> --Select-- </option>';
                $.each(respone, function (index, value) {
                    stateDrodown += '<option value="' + value.id + '">' + value.title + '</option>';
                })
                $("#ddlState").html(stateDrodown);
            },
            error: function () {

            },
            complete: function () {

            }
        })
    })

    // Set City Dropdown
    $("#ddlState").change(function () {
        $.ajax({
            type: "GET",
            url: "/Common/GetCityDropdown?stateId=" + $("#ddlState").val(),
            success: function (respone) {
                var cityDrodown = '<option value=""> --Select-- </option>';
                $.each(respone, function (index, value) {
                    cityDrodown += '<option value="' + value.id + '">' + value.title + '</option>';
                })
                $("#ddlCity").html(cityDrodown);
            },
            error: function () {

            },
            complete: function () {

            }
        })
    })


    // Save User Details
    $("#btnSubmit").click(function () {

        let userName = $("#txtName").val().trim();
        if (userName == '') {
            $("#txtName").css("border", "red solid 1px");
            return;
        }
        else
            $("#txtName").css("border", "#dee2e6 solid 1px");

        let userTypeId = $("#ddlUserType").val().trim();
        if (userTypeId == '') {
            $("#ddlUserType").css("border", "red solid 1px");
            return;
        }
        else
            $("#ddlUserType").css("border", "#dee2e6 solid 1px");

        let emailId = $("#txtEmailId").val().trim();
        if (emailId == '' || !isEmail(emailId)) {
            $("#txtEmailId").css("border", "red solid 1px");
            return;
        }
        //else if (isEmail(emailId)) {
        //    $("#txtEmailId").css("border", "red solid 1px");
        //    return;
        //}
        else
            $("#txtEmailId").css("border", "#dee2e6 solid 1px");

        let password = $("#txtPassword").val().trim();
        if (password == '') {
            $("#txtPassword").css("border", "red solid 1px");
            return;
        }
        else
            $("#txtPassword").css("border", "#dee2e6 solid 1px");

        let country = $("#ddlCountry").val().trim();
        if (country == '') {
            $("#ddlCountry").css("border", "red solid 1px");
            return;
        }
        else
            $("#ddlCountry").css("border", "#dee2e6 solid 1px");

        let state = $("#ddlState").val().trim();
        if (state == '') {
            $("#ddlState").css("border", "red solid 1px");
            return;
        }
        else
            $("#ddlState").css("border", "#dee2e6 solid 1px");

        let city = $("#ddlCity").val().trim();
        if (city == '') {
            $("#ddlCity").css("border", "red solid 1px");
            return;
        }
        else
            $("#ddlCity").css("border", "#dee2e6 solid 1px");

        let userDetails = {
            "Id": 0,
            "UserTypeId": $("#ddlUserType").val(),
            "Name": $("#txtName").val(),
            "MobileNumber": $("#txtMobileNumber").val(),
            "EmailId": $("#txtEmailId").val(),
            "ProfileURL": '',
            "Password": $("#txtPassword").val(),
            "CurrentAddress": $("#txtCurrentAddress").val(),
            "PermanentAddress": $("#txtPermanentAddress").val(),
            "CityId": $("#ddlCity").val(),
            "StateId": $("#ddlState").val(),
            "CountryId": $("#ddlCountry").val(),
            "ZipCode": $("#txtZipCode").val()
        };

        $.ajax({
            type: "POST",
            url: "/User/Add",
            data: { user: userDetails },
            beforeSend: function () {
                $("#dvLoader").show();
            },
            success: function (respone) {
                console.log(respone);
                if (respone.statusCode > 0) {
                    toastr.success(respone.statusMessage);
                   // alert(respone.statusMessage);
                    $("#ddlUserType").val('');
                    $("#txtName").val('');
                    $("#txtMobileNumber").val('');
                    $("#txtEmailId").val('');

                    $("#txtPassword").val('');
                    $("#txtCurrentAddress").val('');
                    $("#txtPermanentAddress").val('');
                    $("#ddlCity").val('');
                    $("#ddlState").val('');
                    $("#ddlCountry").val('');
                    $("#txtZipCode").val('');
                }
                else {
                    toastr.error(respone.statusMessage);
                }
            },
            error: function (error) {
                toastr.error(error.responseText);
            },
            complete: function () {
                $("#dvLoader").hide();
            }
        })
    })
})
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}