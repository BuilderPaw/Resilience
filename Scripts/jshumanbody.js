//public Canvas object to use in all the functions.
//Main canvas declaration 
var canvas;
var ctx;
var x = 75;
var y = 50;
//Width and Height of the canvas
var WIDTH = 1024;
var HEIGHT = 740;
// var dragok = false;
//Global color variable which will be used to store the selected color name.
var Colors = "";
var newPaint = false;
var DrawingTypes = "";
// Rectangle array
rect = {},
    //drag= false defult to test for the draging
    drag = false;
// Array to store all the old Shapes drawing details
var rectStartXArray = new Array();
var rectStartYArray = new Array();
var rectWArray = new Array();
var rectHArray = new Array();
var rectColor = new Array();
var DrawType_ARR = new Array();
var radius_ARR = new Array();

var Text_ARR = new Array();
// Declared for the Free hand pencil Drawing.
var prevX = 0,
    currX = 0,
    prevY = 0,
    currY = 0;
//to add the Image
var imageObj = new Image();

//to clear the Canvas
function clear() {
    ctx.clearRect(0, 0, WIDTH, HEIGHT);
}
//Initialize the Canvas and Mouse events for Canvas
function init(DrawType) {
    newPaint = true;
    canvas = document.getElementById("canvas");
    x = 5;
    y = 5;
    DrawingTypes = DrawType;
    ctx = canvas.getContext("2d");
    canvas.addEventListener('mousedown', mouseDown, false);
    canvas.addEventListener('mouseup', mouseUp, false);
    //canvas.addEventListener('mousemove', mouseMove, false);

    imageObj.src = 'images/human-body.jpg';

    return setInterval(draw, 70);
}
//Mouse down event method
function mouseDown(e) {
    rect.startX = e.pageX - this.offsetLeft;
    rect.startY = e.pageY - this.offsetTop;
    prevX = e.clientX - canvas.offsetLeft;
    prevY = e.clientY - canvas.offsetTop;
    currX = e.clientX - canvas.offsetLeft;
    currY = e.clientY - canvas.offsetTop;
    //drag = true;
    rect.w = 45;
    rect.h = 30;
    draw();
    drawOldShapes();
}
//Mouse UP event Method
function mouseUp() {
    rectStartXArray[rectStartXArray.length] = rect.startX;
    rectStartYArray[rectStartYArray.length] = rect.startY;
    rectWArray[rectWArray.length] = rect.w;
    rectHArray[rectHArray.length] = rect.h;
    rectColor[rectColor.length] = "#FF1251";
    DrawType_ARR[DrawType_ARR.length] = DrawingTypes;
    Text_ARR[Text_ARR.length] = $('#txtInput').val();
}
//Draw all Shaps,Text and add images 
function draw() {
    ctx.beginPath();
    ctx.fillStyle = "#FF1251";
    ctx.strokeStyle = "#FF1251";
    switch (DrawingTypes) {
        case "FillRect":
            ctx.rect(rect.startX, rect.startY, rect.w, rect.h);
            break;
        case "Image":
            ctx.drawImage(imageObj, 0, -30, 950, 750);
            init("FillRect");
            break;
        case "DrawText":
            ctx.font = '12pt Arial';
            ctx.fillText($('#txtInput').val(), rect.startX, rect.startY);
            break;
        case "Erase":
            ctx.beginPath();
            ctx.moveTo(prevX, prevY);
            ctx.lineTo(currX, currY);
            ctx.strokeStyle = "#FFFFFF";
            ctx.lineWidth = 6;
            ctx.stroke();
            ctx.closePath();
            break;
    }
    ctx.stroke();
}
//Redraw all shapes and images
function drawOldShapes() {
    if (DrawingTypes === "ClearAll") {
        return;
    }

    for (var i = 0; i < rectStartXArray.length; i++) {
        if (rectStartXArray[i] !== rect.startX && rectStartYArray[i] !== rect.startY && rectWArray[i] !== rect.w && rectHArray[i] !== rect.h) {
            ctx.beginPath();
            ctx.fillStyle = rectColor[i];
            ctx.strokeStyle = rectColor[i];
            switch (DrawType_ARR[i]) {
                case "FillRect":
                    ctx.rect(rectStartXArray[i], rectStartYArray[i], rectWArray[i], rectHArray[i]);
                    break;
                case "DrawText":
                    ctx.font = '12pt Arial';
                    ctx.fillText(Text_ARR[i], rectStartXArray[i], rectStartYArray[i]);
                    break;
            }
            ctx.stroke();
        }
    }
}

//Save as Image file
function SaveImage1() {
    var m = confirm("Are you sure to Save ");
    if (m) {
        // generate the image data
        var image_NEW = document.getElementById("canvas").toDataURL("image/jpeg");
        image_NEW = image_NEW.replace('data:image/jpeg;base64,', '');

        $.ajaxSetup({
            headers: {
                'X-CSRF-Token': $('meta[name="csrf-token"]').attr('content')
            }
        });

        $.ajax({
            type: 'POST',
            url: 'Default.aspx/SaveHumanBodyImage',
            data: '{ "imageData" : "' + image_NEW + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                alert('Human Body Form Saved.');
            }
        });
    }
}

//new Canvas Drawing
function ClearAll() {
    var m = confirm("Are you sure to clear All ");
    if (m) {
        DrawingTypes = "ClearAll";
        rectStartXArray.length = 0;
        rectStartYArray.length = 0;
        rectWArray.length = 0;
        rectHArray.length = 0;

        rectColor.length = 0;
        DrawType_ARR.length = 0;
        radius_ARR.length = 0;
        try {
            ctx.clearRect(0, 0, canvas.width, 1024);
            init("Image");
        }
        catch (err) {
            init("Image");
        }
    }
}