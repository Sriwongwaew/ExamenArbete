

let CameraButtons = document.getElementById("CameraButtons");
CameraButtons.style.display = "none";

let TalkBubble = document.getElementById("TalkBubble");
TalkBubble.style.display = "none";

function ShowCamera() {

    if (CameraButtons.style.display === "none") {
        CameraButtons.style.display = "block";
        TalkBubble.style.display = "none";
    } else {
        CameraButtons.style.display = "none";
    }

}

function ShowEmoji() {

    if (TalkBubble.style.display === "none") {
        TalkBubble.style.display = "block";
        CameraButtons.style.display = "none";
    } else {
        TalkBubble.style.display = "none";
    }
}


//--------------------
// GET USER MEDIA CODE
//--------------------
navigator.getUserMedia = (navigator.getUserMedia ||
    navigator.webkitGetUserMedia ||
    navigator.mozGetUserMedia ||
    navigator.msGetUserMedia);

var video;
var webcamStream;

function startWebcam() {
    if (navigator.getUserMedia) {
        navigator.getUserMedia(

            // constraints
            {
                video: true,
                audio: false
            },

            // successCallback
            function (localMediaStream) {
                video = document.querySelector('video');
                video.src = window.URL.createObjectURL(localMediaStream);
                webcamStream = localMediaStream;
            },

            // errorCallback
            function (err) {
                console.log("The following error occured: " + err);
            }
        );
    } else {
        console.log("getUserMedia not supported");
    }
}
function convert() {
    let pic = document.getElementById("myCanvas");
    convertCanvasToImage(pic);
}

function stopWebcam() {
    webcamStream.stop();
}
//---------------------
// TAKE A SNAPSHOT CODE
//---------------------
var canvas, ctx;

function init() {
    // Get the canvas and obtain a context for
    // drawing in it
    canvas = document.getElementById("myCanvas");
    ctx = canvas.getContext('2d');
}

function snapshot() {
    // Draws current image from the video element into the canvas
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);
    //convertCanvasToImage(canvas)
}

function convertCanvasToImage(canvas) {
    var url = canvas.toDataURL("image/png");
    //document.getElementById("test1").innerHTML = `<img name="file" src="${image.src}" />`;


    document.getElementById('test2').innerHTML = `<input value="${url}" name="pic" type="text"/>`;


}



function dataURItoBlob(dataURI, type) {
    // convert base64 to raw binary data held in a string
    var byteString = atob(dataURI.split(',')[1]);

    // separate out the mime component
    var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0]

    // write the bytes of the string to an ArrayBuffer
    var ab = new ArrayBuffer(byteString.length);
    var ia = new Uint8Array(ab);
    for (var i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }

    // write the ArrayBuffer to a blob, and you're done
    var bb = new Blob([ab], { type: type });
    return bb;
}
