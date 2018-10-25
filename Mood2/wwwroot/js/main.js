let MinCanvaso = document.getElementById("MinCanvaso");
MinCanvaso.style.display = "none";

let CameraButtons = document.getElementById("CameraButtons");
CameraButtons.style.display = "none";

let TalkBubble = document.getElementById("TalkBubble");
TalkBubble.style.display = "none";

let ChoosePicMethod = document.getElementById("ChoosePicMethod");
ChoosePicMethod.style.display = "none";

let UploadPicButtons = document.getElementById("UploadPicButtons");
UploadPicButtons.style.display = "none";


let test2 = document.getElementById("videofeed");

function HideVideoFeed() {
    if (test2.style.display === "block") {
        test2.style.display = "none";
    } 
}

function HideCamPic() {
    if (MinCanvaso === "none") {
        MinCanvaso.style.display = "block";
    }
    else {
        test2.style.display = "block";
    }
}

function HideVideo() {
    if (test2 === "none") {
        test2.style.display = "block";
    }
}

function ShowOptions() {
    if (ChoosePicMethod.style.display === "none") {
        ChoosePicMethod.style.display = "block";
        TalkBubble.style.display = "none";
    } else {
        ChoosePicMethod.style.display = "none";
        CameraButtons.style.display = "none"
        UploadPicButtons.style.display = "none"
    }
}

function ShowUploadPic() {
    if (UploadPicButtons.style.display === "none") {
        UploadPicButtons.style.display = "block";
        CameraButtons.style.display = "none";
        TalkBubble.style.display = "none";
    } else {
        UploadPicButtons.style.display = "none";
    }
}

function ShowCamera() {

    if (CameraButtons.style.display === "none") {
        CameraButtons.style.display = "block";
        TalkBubble.style.display = "none";
        UploadPicButtons.style.display = "none"
    } else {
        CameraButtons.style.display = "none";
    }

}

function ShowEmoji() {

    if (TalkBubble.style.display === "none") {
        TalkBubble.style.display = "block";
        CameraButtons.style.display = "none";
        ChoosePicMethod.style.display = "none";
    } else {
        TalkBubble.style.display = "none";
    }
}


navigator.getUserMedia = (navigator.getUserMedia ||
    navigator.webkitGetUserMedia ||
    navigator.mozGetUserMedia ||
    navigator.msGetUserMedia);

var video;
var webcamStream;

function startWebcam() {
    MinCanvaso.style.display = "none";
    HideCamPic();
    if (navigator.getUserMedia) {
        navigator.getUserMedia(

            {
                video: true,
                audio: false
            },

            function (localMediaStream) {
                video = document.querySelector('video');
                video.src = window.URL.createObjectURL(localMediaStream);
                webcamStream = localMediaStream;
            },

            function (err) {
                console.log("The following error occured: " + err);
            }
        );
    } else {
        console.log("getUserMedia not supported");
    }
}


var canvas, ctx;

function init() {
    canvas = document.getElementById("myCanvas");
    ctx = canvas.getContext('2d');
}

function snapshot() {
    test2.style.display = "block";
    HideVideoFeed();
    MinCanvaso.style.display = "block";
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);
    let pic = document.getElementById("myCanvas");
    var url = pic.toDataURL("image/png");
    document.getElementById('test2').innerHTML = `<input type="hidden" value="${url}" name="pic" type="text"/>`;
}


