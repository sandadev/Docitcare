$(document).ready(function () {
    //getting doctors list
    DoctorList();
    //on doctors dropdown change
    onDoctorDropDownChange()
    createSlots();
    checkAllCheckBoxes();
});

//Fetching doctor's list

function DoctorList() {
    $.ajax({
        cache: true,
        type: "GET",
        url: DoctorListUrl,
        dataType: "json",
        data: "",
        success: function (data) {
            if (data != null) {
                $.each(data, function (i, item) {
                    $("#ddlDoctor").append($("<option 'data-icon='fa fa - user - md'>'</option>").val(item.UserId).html(item.FirstName + " " + item.LastName));
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


function createSlots() {
    $("#btnSlotCreation").click(function () {
        var prefferedays = fetchPrefferedDays();
        var startDate = $("#txtStartDate").val();
        var endDate = $("#txtEndDate").val();
       // alert(prefferedays);
        var slotCreation = {
            UserId:$('#ddlDoctor option:selected').val(),
            BranchId: $('#ddlBranchList option:selected').val(),
            StartDate: startDate,
            EndDate: endDate,
            StartTime: $("#txtStartTime").val(),
            EndTime: $("#txtEndTime").val(),
            Duration: $("#ddlDuration").val(),
            PrefferedDays: fetchPrefferedDays
        }
        $.ajax({
            cache: false,
            type: "POST",
            url: SubmitNewSlot,
            dataType: "json",
            data: {slotCreation: slotCreation},
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

function onDoctorDropDownChange() {
    $("#ddlDoctor").change(function () {
        var doctorId = $(this).children("option:selected").val();
        if (doctorId == 0) {
            location.reload(true);
        }
        $.ajax({
            cache: true,
            type: "GET",
            url: DoctorDropDownChangeUrl,
            dataType: "json",
            data: { doctorId},
            success: function (data) {
                if (data != null) {
                    var department = data.UserDepartment.DepartmentName;
                    $("#lblDepartmentName").html(department)
                    $.each(data.GetBranches, function (i, item) {
                        $("#ddlBranchList").append($("<option 'data-icon='fa fa - user - md'>'</option>").val(item.BranchId).html(item.BranchName));
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


function fetchPrefferedDays() {
    var result = $('input[name="preferreddays"]:checked');
    
    var resString = [];
    result.each(function () {
        var days = $(this).val();

        if (days !="AllDays") {
            resString.push($(this).val());
        }
       
    })
    
    //$.each(result, function (i, item) {
       
    //});
  //  alert(resString);
    return resString;
}

function checkAllCheckBoxes() {
    
    $("#chkAll").click(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });

}




