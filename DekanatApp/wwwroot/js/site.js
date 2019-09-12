// Write your JavaScript code.

$(function () {
    var mainUrl = "http://localhost:5654";
    //http://localhost:5654 http://www.dream-solutions.xyz

    $("#findBtn").click(function () {
        window.location.replace(mainUrl + "/Home/Contracts?studentId=" + $("#studentsSelect").val());
    });

    $("#findPlansBtn").click(function () {
        window.location.replace(mainUrl + "/Home/TeachPlans?facultyId=" + $("#teachPlansSelect").val());
    });

    $("#findDiplomasBtn").click(function () {
        window.location.replace(mainUrl + "/Home/Diplomas?groupId=" + $("#diplomasSelect").val());
    });
});
