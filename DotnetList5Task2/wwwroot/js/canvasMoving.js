function clearCanvas(canvas) {
    canvas.context.clearRect(0, 0, canvas.width, canvas.height);
}
function connectToCorners(canvas, xCoordinate, yCoordinate) {
    function connectToPoint(ptX, ptY) {
        canvas.context.moveTo(xCoordinate, yCoordinate);
        canvas.context.lineTo(ptX, ptY);
        canvas.context.stroke();
    }
    canvas.context.beginPath();
    connectToPoint(0, 0);
    connectToPoint(0, canvas.height);
    connectToPoint(canvas.width, 0);
    connectToPoint(canvas.width, canvas.height);
    canvas.context.closePath();
}

const canvasAll = document.querySelectorAll(".mainCanvas");
const canvasObjects = [];
canvasAll.forEach(function (canvas) {
    let ctx = canvas.getContext("2d");
    ctx.strokeStyle = '#ff0000';
    ctx.lineWidth = 4;
    canvasObjects.push({
        element: canvas,
        context: ctx,
        width: canvas.width,
        height: canvas.height,
    });
});
canvasObjects.forEach(function (canvas) {
    connectToCorners(canvas, canvas.width / 2, canvas.height / 2);

    canvas.element.addEventListener("mousemove", function (event) {
        var rect = canvas.element.getBoundingClientRect();
        var x = event.clientX - rect.left;
        var y = event.clientY - rect.top;
        clearCanvas(canvas);
        connectToCorners(canvas, x, y);
    });

    canvas.element.addEventListener("mouseout", function () {
        clearCanvas(canvas);
    });
});