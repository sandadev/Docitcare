var sourceValue = [];
var totalUsers;
var slot;
$(document).ready(function () {
    addBranchDropDownToNavBar();
    hideSlotUserForm();
    LoggerUserBranchList();
    GetDepartmentDoctorList();
    showSlots();
    $('#showHideSlots').hide();
    $('#patientform').hide();
    $("#txtSelectDate").prop("disabled", true);
    $("#ddlAppointType").prop("disabled", true);
    SubmitForm();
    userAutoComplete();
});

function addBranchDropDownToNavBar() {

    var element = '<li class="dropdown dropdown - notification nav - item" id="liNavAdded"><div class="row nav-link nav-link-label" id="ddlUserBranch"><div class="col-md-12"> <div class="form-group"><select class="select2-icons form-control" id="ddlNavBranchList"></select></div></div></div></li>'
    $("#addElementToNav").prepend(element);
}

function hideSlotUserForm() {
    $('.hideClass').hide();
    
}

function LoggerUserBranchList() {
    $.ajax({
        cache: false,
        type: "GET",
        url: UserBranchUrl,
        dataType: "json",
        data: "",
        success: function (data) {
            if (data != null) {
                $.each(data.LoggedUserBranch, function (i, item) {
                    $("#ddlNavBranchList").append($("<option 'data-icon='fa fa - user - md'>'</option>").val(item.BranchId).html(item.BranchName));
                });
                $.each(data.TotalDepartment, function (i, item) {
                    $("#ddlDepartment").append($("<option 'data-icon='fa fa - user - md'>'</option>").val(item.DepartmentId).html(item.DepartmentName));
                });
            }
        },
        error: function (errMsg) {
            console.log("error");
        },
        failure: function (errMsg) {
            console.log("failure");
        }
    });
}

function GetDepartmentDoctorList() {
    $("#ddlDepartment").change(function () {
        var departmentId = $(this).children("option:selected").val();
        $.ajax({
            cache: true,
            type: "GET",
            url: DepartmentDoctorUrl,
            dataType: "json",
            data: { departmentId },
            success: function (data) {
                if (data != null) {
                    $.each(data, function (i, item) {
                        $("#ddlDoctorSlotBooking").append($("<option 'data-icon='fa fa - user - md'>'</option>").val(item.UserId).html(item.FirstName + " " + item.LastName));
                    });
                    $("#txtSelectDate").prop("disabled", false);
                    $("#ddlAppointType").prop("disabled", false);
                }
            },
            error: function (errMsg) {
                console.log("error");
            },
            failure: function (errMsg) {
                console.log("failure");
            }
        });
    });
}

function showSlots() {
    $("#ddlAppointType").change(function () {
        $("#showSlots").empty();
        var appointType = $(this).children("option:selected").val();
        var selectedDate = $("#txtSelectDate").val();
        var userId = $("#ddlDoctorSlotBooking option:selected").val();
        var branchId = $("#ddlNavBranchList option:selected").val();
        $.ajax({
            cache: false,
            type: "GET",
            url: SlotUrl,
            dataType: "json",
            data: { userId: userId, appointType: appointType, selectedDate: selectedDate, branchId: branchId },
            success: function (data) {
                $('#showHideSlots').show();
                $('#showSlots').show();
                $('#showNoSlots').hide();
                var isSlotListEmpty = jQuery.isEmptyObject(data)
                if (!isSlotListEmpty) {
                    $.each(data, function (i, item) {
                        var minutes;
                        if (item.SlotTime.Minutes == '0') { minutes = "00" } else { minutes = item.SlotTime.Minutes }
                        if (item.Available) {
                            $("#showSlots").append($('<li class="btn btn-outline-success mb-2 selectslot" data-toggle="modal" data-target="#bootstrap" value=' + item.SlotId + '>' + item.SlotTime.Hours + ':' + minutes + '</li > '))
                        }
                        else {
                            $("#showSlots").append($('<li class="btn btn-danger mb-2 disabled selectslot" value=' + item.SlotId + '>' + item.SlotTime.Hours + ':' + minutes + '</li > '))
                        }
                    });
                   
                    $(".selectslot").on("click", function () {

                        /* $('#showHideSlots').children('li').removeClass('active')*/
                        if ($(this).hasClass('disabled')) {
                            $('#patientform').hide();
                            $("#showSlots>li.active").removeClass("active");
                        }
                        else {
                            $("#showSlots>li.active").removeClass("active");
                            $(this).addClass("active");
                            var slotTime = $(this).val();
                            slot = $(this).html();
                            getSlot(slotTime);
                            showPatientForm();
                        }
                    });
                }
                else {
                    $('#showSlots').hide();
                    $('#showNoSlots').show();
                    $('#patientform').hide();
                }
            },
            error: function (errMsg) {
                console.log("error");
            },
            failure: function (errMsg) {
                console.log("failure");
            }
        });
    });
}

function showPatientForm() {
    $('#bootstrap').on('show.bs.modal', function () {
        $("#txtSlotTime").val(slot);
        var selectedDate = $("#txtSelectDate").val();
        $("#txtSlotDate").val(selectedDate);
    });
    $('#patientform').show();
}
var selectedSlot;
function getSlot(slotTime) {
    selectedSlot  = slotTime;
}

function SubmitForm() {
    $("#btnBookAppointment").click(function () {
        var slotId = selectedSlot;
        var date = $("#txtDob").val();
        var branchId = $("#ddlNavBranchList option:selected").val();
        var userDetails = {
            FirstName: $("#txtFirstName").val(),
            LastName: $("#txtLastName").val(),
            TelephoneNumber1: $("#txtMobileNumber").val(),
            DateOfBirth: $("#txtDob").val(),
            Gender : $("input[name='gender']:checked").val(),
            MartialStatus: $("input[name='martialstatus']:checked").val(),
            Address1: $("#txtAddress1").val(),
            Address2: $("#txtAddress2").val(),
            Country: $("#txtCountry").val(),
            State: $("#txtState").val(),
            City: $("#txtCity").val(),
        }
        var slotBooking = {
            SlotId: slotId,
            UserId: $("#txtUserId").val(),
            TotalAmount: $("#txtFeeAmount").val(),
            RefferedBy: $("#txtRefferedBy").val(),
            Note: $("#txtNote").val()
        }
        $.ajax({
            cache: false,
            type: "POST",
            url: BookingUrl,
            dataType: "json",
            data: { userDetails: userDetails, slotBooking: slotBooking, branchId: branchId  },
            success: function (data) {
                
            },
            error: function (errMsg) {
                console.log("error");
            },
            failure: function (errMsg) {
                console.log("failure");
            }
        });
    });
}

function userAutoComplete() {
    $("#txtSearchBox").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: AutocompleteUrl,
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: "Name: " + item.FirstName + " " + item.LastName + ",  MRNo: " + item.UserId + ",  Mobile Number: " + item.TelephoneNumber1, value: item.UserId };
                    }))

                }
            })
        },
       
        select: function (e, ui) {
            var userId = ui.item.value;
            bindPatientForm(userId);
        },
        messages: {
            noResults: "No Records Found!", results: ""
        }
    });  
    }

function bindPatientForm(userId) {
    $.ajax({
        cache: false,
        type: "GET",
        url: PatientDetailsUrl,
        dataType: "json",
        data: { userId: userId },
        success: function (data) {
            $("#txtUserId").val(data.UserId);
            $("#txtFirstName").val(data.FirstName);
            $("#txtLastName").val(data.LastName);
            $("#txtMobileNumber").val(data.TelephoneNumber1);
            var dob = data.DateOfBirth;
            var parseDOB = dob.replace(/\/+Date\(([\d+-]+)\)\/+/, '$1');
            var convertedDOB = new Date(parseInt(parseDOB));
            
            $("#txtDob").val(convertedDOB);
           
            if (data.Gender == 0) {
                $("#rdoMale").prop("checked", true)
            }
            else {
                $("#rdoFemale").prop("checked", true)
            }
            if (data.MartialStatus == 0) {
                $("#rdoMarried").prop("checked", true)
            }
            else if (data.MartialStatus == 1)
            {
                $("#rdoSingle").prop("checked", true)
            }
            else {
                $("#rdoOthers").prop("checked", true)
            }
            $("#txtFirstName").val();
            $("#txtFirstName").val();
            $("#txtAddress1").val(data.Address1);
            $("#txtCountry").val(data.Country);
            $("#txtState").val(data.State);
            $("#txtCity").val(data.City);
        },
        error: function (errMsg) {
            console.log("error");
        },
        failure: function (errMsg) {
            console.log("failure");
        }
    });
}



