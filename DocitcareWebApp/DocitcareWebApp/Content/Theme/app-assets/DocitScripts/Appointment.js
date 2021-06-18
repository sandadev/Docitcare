$(document).ready(function () {
    LoggedUserBranchList();
    GetDepartmentDoctorList();
    GetDoctorSlotDetails();
    
    $("#btnSlotBooking").click(function () {
        $('#bootstrap').modal('show');
      
    });
});

function LoggedUserBranchList() {
    $.ajax({
        cache: false,
        type: "GET",
        url: AppointmentUserBranchUrl,
        dataType: "json",
        data: "",
        success: function (data) {
            if (data != null) {
                $.each(data.LoggedUserBranch, function (i, item) {
                    $("#ddlAppointmentBranchList").append($("<option 'data-icon='fa fa - user - md'>'</option>").val(item.BranchId).html(item.BranchName));
                });
                $.each(data.TotalDepartment, function (i, item) {
                    $("#ddlAppointmentDepartment").append($("<option 'data-icon='fa fa - user - md'>'</option>").val(item.DepartmentId).html(item.DepartmentName));
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
    $("#ddlAppointmentDepartment").change(function () {
        $("#ddlAppointmentDoctor").empty();
        var departmentId = $(this).children("option:selected").val();
        $.ajax({
            cache: true,
            type: "GET",
            url: AppointmentDepartmentDoctorUrl,
            dataType: "json",
            data: { departmentId },
            success: function (data) {
                if (data != null) {
                    $("#ddlAppointmentDoctor").append($("<option></option>").val("0").html("Select Doctor"));
                    $.each(data, function (i, item) {
                        $("#ddlAppointmentDoctor").append($("<option>'</option>").val(item.UserId).html(item.FirstName + " " + item.LastName));
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
    });
}

function GetDoctorSlotDetails() {
    $("#btnFilter").on('click', function () {
        var userId = $("#ddlAppointmentDoctor").val();
        $.ajax({
            cache: true,
            type: "GET",
            url: AppointmentDoctorUrl,
            dataType: "json",
            data: { userId },
            success: function (data) {
                if (data != null) {
                    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
                    $.each(data, function (i, item) {
                        $("#doctorName").html(item.DoctorName);
                        $("#_doctorFee").html(" (" + item.Fee + ")");
                        $("#_department").html(item.DepartmentName);
                        var CurrentDate = new Date();
                        var slotdate = ConvertJsonDate(item.SlotDate)
                        const dayOfWeek = new Date(slotdate).getDay();
                       /* alert('current-' + CurrentDate + " slotDate-" + slotdate)*/
                        if (slotdate.getDate() === CurrentDate.getDate()) {
                            $("#_today").html(days[dayOfWeek]+"   " + item.SlotStartTime.substring(0, 5) + " - " + item.SlotEndTime.substring(0, 5));
                        }
                        else {
                            $("#_weekly").append(days[dayOfWeek] + "   " +item.SlotStartTime.substring(0, 5) + " - " + item.SlotEndTime.substring(0, 5) + '<br/>');
                        }
                       
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
    });

   

}

function showAppointmentBookingForm() {
   
    $('#bootstrap').on('show.bs.modal', function () {
    });
   
}