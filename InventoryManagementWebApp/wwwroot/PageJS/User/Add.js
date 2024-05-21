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
            success: function (respone) {
                if (respone > 0) {
                    alert("User registered successfully!");
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

                }
            },
            error: function () {

            },
            complete: function () {

            }
        })
    })
})