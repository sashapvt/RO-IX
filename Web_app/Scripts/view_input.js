if (!jQuery) { throw new Error("view_input.js requires jQuery") }

$(document).ready(function () {

    OptionsRO();
    OptionsIX();

    $('#OptionsROEditOn').click(function () {
        OptionsRO();
    });

    $('#OptionsIXEditOn').click(function () {
        OptionsIX();
    });

    $('input#OptionsROUFOn').click(function () {
        OptionsRO();
    });

    $('input#OptionsROROOn').click(function () {
        OptionsRO();
    });

    $('input#OptionsROIXOn').click(function () {
        OptionsRO();
    });

    $('input#OptionsIXUFOn').click(function () {
        OptionsIX();
    });

    $('input#OptionsIXIX1On').click(function () {
        OptionsIX();
    });

    $('input#OptionsIXIX2On').click(function () {
        OptionsIX();
    });

    $('input#OptionsROUFPermeate').change(function () {
        CalculateProductivity();
    });

    $('input#OptionsROROPermeate').change(function () {
        CalculateProductivity();
    });

    $('input#OptionsROIXPermeate').change(function () {
        CalculateProductivity();
    });

    $('input#OptionsIXUFPermeate').change(function () {
        CalculateProductivity();
    });

    $('input#OptionsIXIX1Permeate').change(function () {
        CalculateProductivity();
    });

    $('input#OptionsIXIX2Permeate').change(function () {
        CalculateProductivity();
    });

    function OptionsRO() {
        $('input#OptionsROUFPermeate').prop("disabled", !$('input#OptionsROUFOn').prop("checked"));
        $('input#OptionsROUFProductivity').prop("disabled", !$('input#OptionsROUFOn').prop("checked") || $('input#OptionsROEditOn').prop("checked"));

        $('input#OptionsROROPermeate').prop("disabled", !$('input#OptionsROROOn').prop("checked"));
        $('input#OptionsROROProductivity').prop("disabled", !$('input#OptionsROROOn').prop("checked") || $('input#OptionsROEditOn').prop("checked"));

        $('input#OptionsROIXPermeate').prop("disabled", !$('input#OptionsROIXOn').prop("checked"));
        $('input#OptionsROIXProductivity').prop("disabled", !$('input#OptionsROIXOn').prop("checked") || $('input#OptionsROEditOn').prop("checked"));

        CalculateProductivity();
    }

    function OptionsIX() {
        $('input#OptionsIXUFPermeate').prop("disabled", !$('input#OptionsIXUFOn').prop("checked"));
        $('input#OptionsIXUFProductivity').prop("disabled", !$('input#OptionsIXUFOn').prop("checked") || $('input#OptionsIXEditOn').prop("checked"));

        $('input#OptionsIXIX1Permeate').prop("disabled", !$('input#OptionsIXIX1On').prop("checked"));
        $('input#OptionsIXIX1Productivity').prop("disabled", !$('input#OptionsIXIX1On').prop("checked") || $('input#OptionsIXEditOn').prop("checked"));

        $('input#OptionsIXIX2Permeate').prop("disabled", !$('input#OptionsIXIX2On').prop("checked"));
        $('input#OptionsIXIX2Productivity').prop("disabled", !$('input#OptionsIXIX2On').prop("checked") || $('input#OptionsIXEditOn').prop("checked"));

        CalculateProductivity();
    }

    function CalculateProductivity() {
        if ($('input#OptionsROEditOn').prop("checked"))
        {
            var BoilerBlowdownRO = $('#WaterROConductivity').val() / ($('#WaterROConductivityMax').val() - $('#WaterROConductivity').val());
            var BoilerBlowdownFlowRO = $('#BoilerProductivity').val() * (1 + BoilerBlowdownRO) * BoilerBlowdownRO;
            $('input#OptionsROIXProductivity').val(Math.round(100 * (+$('#BoilerProductivity').val() + BoilerBlowdownFlowRO)) / 100);
            $('input#OptionsROROProductivity').val(Math.round(100 * $('#OptionsROIXProductivity').val() / (($('#OptionsROIXOn').prop("checked")) ? $('#OptionsROIXPermeate').val() / 100 : 1)) / 100);
            $('input#OptionsROUFProductivity').val(Math.round(100 * $('#OptionsROROProductivity').val() / (($('#OptionsROROOn').prop("checked")) ? $('#OptionsROROPermeate').val() / 100 : 1)) / 100);
            $('input#OptionsRORawProductivity').val(Math.round(100 * $('#OptionsROUFProductivity').val() / (($('#OptionsROUFOn').prop("checked")) ? $('#OptionsROUFPermeate').val() / 100 : 1)) / 100);
            //alert($('input#OptionsRORawProductivity').val());
        }
        if ($('input#OptionsIXEditOn').prop("checked"))
        {
            var BoilerBlowdownIX = $('#WaterIXConductivity').val() / ($('#WaterIXConductivityMax').val() - $('#WaterIXConductivity').val());
            var BoilerBlowdownFlowIX = $('#BoilerProductivity').val() * (1 + BoilerBlowdownIX) * BoilerBlowdownIX;
            $('input#OptionsIXIX2Productivity').val(Math.round(100 * (+$('#BoilerProductivity').val() + BoilerBlowdownFlowIX)) / 100);
            $('input#OptionsIXIX1Productivity').val(Math.round(100 * $('#OptionsIXIX2Productivity').val() / (($('#OptionsIXIX2On').prop("checked")) ? $('#OptionsIXIX2Permeate').val() / 100 : 1)) / 100);
            $('input#OptionsIXUFProductivity').val(Math.round(100 * $('#OptionsIXIX1Productivity').val() / (($('#OptionsIXIX1On').prop("checked")) ? $('#OptionsIXIX1Permeate').val() / 100 : 1)) / 100);
            $('input#OptionsIXRawProductivity').val(Math.round(100 * $('#OptionsIXUFProductivity').val() / (($('#OptionsIXUFOn').prop("checked")) ? $('#OptionsIXUFPermeate').val() / 100 : 1)) / 100);
            //alert($('input#OptionsIXRawProductivity').val());
        }
    }

    // Show/hide html block

    $('#InputDataClick').click(function () {
        showHide('InputData');
        document.getElementById('InputOptions').style.display = "none";
        $("html, body").animate({
            scrollTop: 0
        }, 600);

    });

    $('#InputOptionsClick').click(function () {
        showHide('InputOptions');
        document.getElementById('InputData').style.display = "none";
        $("html, body").animate({
            scrollTop: 0
        }, 600);

    });

    function showHide(element_id) {
        if (document.getElementById(element_id)) {
            var obj = document.getElementById(element_id);
            if (obj.style.display == "block") {
                obj.style.display = "none";
            }
            else obj.style.display = "block";
        }
    }

});
