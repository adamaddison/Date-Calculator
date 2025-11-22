// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
var appTheme = 0;
const LIGHT = 0;
const DARK = 1;
const ADD = 0;
var appAutoTheme = false;
// Write your JavaScript code.
var saveDateToDateInput = function()
{
    localStorage["DateToDate.startDate"] = $("#startDate").val();
    localStorage["DateToDate.endDate"] = $("#endDate").val();
}

var saveAddSubtractInput = function()
{
    localStorage["AddSubtract.date"] = $("#addSubtractDateField").val();
    localStorage["AddSubtract.operationType"] = $("#OperationType").val();
    localStorage["AddSubtract.lengthOfTimeDays"] = $("#daysField").val();
    localStorage["AddSubtract.lengthOfTimeWeeks"] = $("#weeksField").val();
    localStorage["AddSubtract.lengthOfTimeMonths"] = $("#monthsField").val();
    localStorage["AddSubtract.lengthOfTimeYears"] = $("#yearsField").val();
    localStorage["AddSubtract.addSubtractRepeatField"] = $("#addSubtractRepeatField").val();
}

var initialiseDateToDateValues = function()
{
    if(localStorage["DateToDate.startDate"] !== undefined)
    {
        $("#startDate").val(localStorage["DateToDate.startDate"]);
        $("#endDate").val(localStorage["DateToDate.endDate"]);
    }
}
var initialiseAddSubtractValues = function()
{
    if(localStorage["AddSubtract.date"] !== undefined)
    {
        $("#addSubtractDateField").val(localStorage["AddSubtract.date"]);
        $("#OperationType").val(localStorage["AddSubtract.operationType"]);
        $("#daysField").val(localStorage["AddSubtract.lengthOfTimeDays"]);
        $("#weeksField").val(localStorage["AddSubtract.lengthOfTimeWeeks"]);
        $("#monthsField").val(localStorage["AddSubtract.lengthOfTimeMonths"]);
        $("#yearsField").val(localStorage["AddSubtract.lengthOfTimeYears"]);
        $("#addSubtractRepeatField").val(localStorage["AddSubtract.addSubtractRepeatField"]);

        if($("#OperationType").val() == ADD){ $("#OperationTypeText").html("Add") }
        else{ $("#OperationTypeText").html("Subtract"); }
    }
}
var initialiseTheme = function()
{
    if(localStorage["DateCalculator.theme"] !== undefined)
    {
        appTheme = parseInt(localStorage["DateCalculator.theme"]);
    }
    if(localStorage["DateCalculator.autoTheme"] !== undefined)
    {
        appAutoTheme = localStorage["DateCalculator.autoTheme"] === "true";
    }

    if(appAutoTheme)
    {
        setAutoTheme();
    }
    else
    {
        setTheme(appTheme);
    }
}
$(document).ready(function(){
    initialiseDateToDateValues();
    initialiseAddSubtractValues();
    initialiseTheme();
});

var toggleOperationTypeDropdown = function()
{
    if($("#OperationTypeDropdownMenu").css("visibility") == "hidden")
    {
        $("#OperationTypeDropdownMenu").addClass("elementAppear");
        if(appTheme == LIGHT)
        {
            $("#OperationTypeDropDownImage").attr("src", "closeDropdownLight.svg");
        }
        else
        {
            $("#OperationTypeDropDownImage").attr("src", "closeDropdownDark.svg");
        }
    }
    else
    {
        $("#OperationTypeDropdownMenu").removeClass("elementAppear");
        if(appTheme == LIGHT)
        {
            $("#OperationTypeDropDownImage").attr("src", "openDropdownLight.svg");
        }
        else
        {
            $("#OperationTypeDropDownImage").attr("src", "openDropdownDark.svg");
        }
    }
}

var setOperationType = function(operationType)
{
    $("#OperationType").val(operationType);
    if(operationType == ADD){ $("#OperationTypeText").html("Add") }
    else{ $("#OperationTypeText").html("Subtract"); }

    saveAddSubtractInput();
    toggleOperationTypeDropdown();
}

var toggleThemeDropdown = function()
{
    if($("#themeDropdownMenu").css("visibility") == "hidden")
    {
        $("#themeDropdownMenu").addClass("elementAppear");
        if(appTheme == LIGHT)
        {
            $("#themeDropDownImage").attr("src", "closeDropdownLight.svg");
        }
        else
        {
            $("#themeDropDownImage").attr("src", "closeDropdownDark.svg");
        }
    }
    else
    {
        $("#themeDropdownMenu").removeClass("elementAppear");
       if(appTheme == LIGHT)
        {
            $("#themeDropDownImage").attr("src", "openDropdownLight.svg");
        }
        else
        {
            $("#themeDropDownImage").attr("src", "openDropdownDark.svg");
        }
    }
}

var setTheme = function(theme)
{
    if(theme == LIGHT)
    {
        var infoContainers = $(".infoContainerDark");
        infoContainers.removeClass("infoContainerDark");
        infoContainers.addClass("infoContainerLight");

        var textElements = $(".textDark");
        textElements.removeClass("textDark");
        textElements.addClass("textLight");

        var appContainer = $(".appContainerDark");
        appContainer.removeClass("appContainerDark");
        appContainer.addClass("appContainerLight");

        var headers = $(".headerDark");
        headers.removeClass("headerDark");
        headers.addClass("headerLight");

        var twoColumnRows = $(".twoColumnRowDark");
        twoColumnRows.removeClass("twoColumnRowDark");
        twoColumnRows.addClass("twoColumnRowLight");

        var dropdownButtons = $(".dropDownButtonDark");
        dropdownButtons.removeClass("dropDownButtonDark");
        dropdownButtons.addClass("dropDownButtonLight");

        var dropdownMenu = $(".dropdownMenuDark");
        dropdownMenu.removeClass("dropdownMenuDark");
        dropdownMenu.addClass("dropdownMenuLight");

        var dropdownMenuItems = $(".dropdownMenuItemDark");
        dropdownMenuItems.removeClass("dropdownMenuItemDark");
        dropdownMenuItems.addClass("dropdownMenuItemLight");

        var tabBar = $(".tabBarDark");
        tabBar.removeClass("tabBarDark");
        tabBar.addClass("tabBarLight");

        var tabBarSelected = $(".tabValueSelectedDark")
        tabBarSelected.removeClass("tabValueSelectedDark");
        tabBarSelected.addClass("tabValueSelectedLight");

        var tabBarUnselected = $(".tabValueDark");
        tabBarUnselected.removeClass("tabValueDark");
        tabBarUnselected.addClass("tabValueLight");

        var inputs = $(".inputDark");
        inputs.removeClass("inputDark");
        inputs.addClass("inputLight");

        var inputRows = $(".inputRowDark");
        inputRows.removeClass("inputRowDark");
        inputRows.addClass("inputRowLight");

        var buttons = $(".buttonDark");
        buttons.removeClass("buttonDark");
        buttons.addClass("buttonLight");

        var tableRows = $(".tableRowDark");
        tableRows.removeClass("tableRowDark");
        tableRows.addClass("tableRowLight");

        if($("#themeDropdownMenu").css("visibility") == "hidden")
        {
            $("#themeDropDownImage").attr("src", "openDropdownLight.svg");
        }
        else
        {
            $("#themeDropDownImage").attr("src", "closeDropdownLight.svg");
        }

        if($("#OperationTypeDropdownMenu").css("visibility") == "hidden")
        {
            $("#OperationTypeDropDownImage").attr("src", "openDropdownLight.svg");
        }
        else
        {
            $("#OperationTypeDropDownImage").attr("src", "closeDropdownLight.svg");
        }

        $("#themeText").html("Light");
    }
    else if(theme == DARK)
    {
        var infoContainers = $(".infoContainerLight");
        infoContainers.removeClass("infoContainerLight");
        infoContainers.addClass("infoContainerDark");

        var textElements = $(".textLight");
        textElements.removeClass("textLight");
        textElements.addClass("textDark");

        var appContainer = $(".appContainerLight");
        appContainer.removeClass("appContainerLight");
        appContainer.addClass("appContainerDark");

        var headers = $(".headerLight");
        headers.removeClass("headerLight");
        headers.addClass("headerDark");

        var twoColumnRows = $(".twoColumnRowLight");
        twoColumnRows.removeClass("twoColumnRowLight");
        twoColumnRows.addClass("twoColumnRowDark");

        var dropdownButtons = $(".dropDownButtonLight");
        dropdownButtons.removeClass("dropDownButtonLight");
        dropdownButtons.addClass("dropDownButtonDark");

        var dropdownMenu = $(".dropdownMenuLight");
        dropdownMenu.removeClass("dropdownMenuLight");
        dropdownMenu.addClass("dropdownMenuDark");

        var dropdownMenuItems = $(".dropdownMenuItemLight");
        dropdownMenuItems.removeClass("dropdownMenuItemLight");
        dropdownMenuItems.addClass("dropdownMenuItemDark");

        var tabBar = $(".tabBarLight");
        tabBar.removeClass("tabBarLight");
        tabBar.addClass("tabBarDark");

        var tabBarSelected = $(".tabValueSelectedLight");
        tabBarSelected.removeClass("tabValueSelectedLight");
        tabBarSelected.addClass("tabValueSelectedDark");

        var tabBarUnselected = $(".tabValueLight");
        tabBarUnselected.removeClass("tabValueLight");
        tabBarUnselected.addClass("tabValueDark");

        var inputs = $(".inputLight");
        inputs.removeClass("inputLight");
        inputs.addClass("inputDark");

        var inputRows = $(".inputRowLight");
        inputRows.removeClass("inputRowLight");
        inputRows.addClass("inputRowDark");

        var buttons = $(".buttonLight");
        buttons.removeClass("buttonLight");
        buttons.addClass("buttonDark");

        var tableRows = $(".tableRowLight");
        tableRows.removeClass("tableRowLight");
        tableRows.addClass("tableRowDark");

        if($("#themeDropdownMenu").css("visibility") == "hidden")
        {
            $("#themeDropDownImage").attr("src", "openDropdownDark.svg");
        }
        else
        {
            $("#themeDropDownImage").attr("src", "closeDropdownDark.svg");
        }

        if($("#OperationTypeDropdownMenu").css("visibility") == "hidden")
        {
            $("#OperationTypeDropDownImage").attr("src", "openDropdownDark.svg");
        }
        else
        {
            $("#OperationTypeDropDownImage").attr("src", "closeDropdownDark.svg");
        }

        $("#themeText").html("Dark");
    }
    
    appAutoTheme = false;
    localStorage["DateCalculator.autoTheme"] = false;
    appTheme = theme;
    localStorage["DateCalculator.theme"] = theme;
}

setAutoTheme = function()
{
    var systemInLightMode = window.matchMedia('(prefers-color-scheme: light)');

    if(systemInLightMode.matches)
    {
        setTheme(LIGHT);
    }
    else
    {
        setTheme(DARK);
    }

    appAutoTheme = true;
    localStorage["DateCalculator.autoTheme"] = true;
    $("#themeText").html("Auto / System");
}

window.matchMedia('(prefers-color-scheme: light)').addEventListener('change', (event) => {
            if(appAutoTheme)
            {
                setAutoTheme();
            }
        });