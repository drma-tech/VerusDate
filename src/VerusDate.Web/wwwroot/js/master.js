"use strict";

// loadScript: returns a promise that completes when the script loads
window.loadScript = function (scriptPath) {
    // check list - if already loaded we can ignore
    if (loaded[scriptPath]) {
        console.log(scriptPath + " already loaded");
        // return 'empty' promise
        return new this.Promise(function (resolve, reject) {
            resolve();
        });
    }

    return new Promise(function (resolve, reject) {
        // create JS library script element
        var script = document.createElement("script");
        script.src = scriptPath;
        script.type = "text/javascript";
        //console.log(scriptPath + " created");

        // flag as loading/loaded
        loaded[scriptPath] = true;

        // if the script returns okay, return resolve
        script.onload = function () {
            //console.log(scriptPath + " loaded ok");
            resolve(scriptPath);
        };

        // if it fails, return reject
        script.onerror = function () {
            console.log(scriptPath + " load failed");
            reject(scriptPath);
        }

        // scripts will load at end of body
        setTimeout(() => {
            document["body"].appendChild(script);
        }, 1000);
    });
}
// store list of what scripts we've loaded
var loaded = [];

var RealDate = function () {
    function getAuthorization() {
        return JSON.parse(sessionStorage.getItem('oidc.user:' + window.location.origin + ':VerusDate.Client')).access_token;
    }

    function clearClass() {
        $("#divMessage").removeClass("alert alert-secondary");
        $("#divMessage").removeClass("alert alert-warning");
        $("#divMessage").removeClass("alert alert-success");
        $("#divMessage").removeClass("alert alert-danger");
    }

    function hideVideo() {
        document.getElementById('video').style.display = "none";
    }

    function showVideo() {
        document.getElementById('video').style.display = "block";
    }

    function hidePhoto() {
        document.getElementById('photo').style.display = "none";
    }

    function showPhoto() {
        document.getElementById('photo').style.display = "block";
    }

    const ExecutaVideo = async function () {
        RealDate.Notification.Warning("Habilitando câmera...");

        navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.oGetUserMedia || navigator.msGetUserMedia;

        if (navigator.getUserMedia) {
            navigator.getUserMedia({ video: true }, streamWebCam, error => throwError('ExecutaVideo', error));
        }
    }

    var publicStream;

    function streamWebCam(stream) {
        publicStream = stream;

        let video = document.getElementById('video');
        video.srcObject = publicStream;

        showVideo();
        hidePhoto();

        let playPromise = video.play();

        if (playPromise !== undefined) {
            playPromise.then(_ => {
                // Automatic playback started!
                // Show playing UI.
                //video.pause();
            });
        }
    }

    async function takeShot() {
        const canvas = document.createElement("canvas");
        canvas.width = video.videoWidth;
        canvas.height = video.videoHeight;
        canvas.getContext('2d').drawImage(video, 0, 0, video.videoWidth, video.videoHeight);

        canvas.toBlob(function (blob) {
            let fileReader = new FileReader();
            fileReader.readAsDataURL(blob);

            fileReader.onload = function (event) {
                var dataUrl = fileReader.result;

                stopCamera();

                let photo = document.getElementById('photo');

                photo.src = dataUrl;

                hideVideo();
                showPhoto();
            };
        }, 'image/jpeg');
    }

    function sendPhoto() {
        let photo = document.getElementById('photo');
        var dataUrl = photo.src;
        var base64 = dataUrl.split(',')[1];

        RealDate.Notification.Warning("Favor, aguarde enquanto validamos sua foto");

        fetch('http://localhost:7071/api/Storage/UploadPhotoValidation', {
            method: 'PUT',
            body: JSON.stringify({
                Stream: base64
            }),
            headers: {
                // 'Authorization': `bearer ${getAuthorization()}`,
                'Content-Type': 'application/json; charset=utf-8',
            }
        })
            .then(function (response) {
                if (!response.ok) {
                    return response.text().then(result => {
                        throw new Error(result)
                    })
                }
                return response.text();
            }).then(function (response) {
                RealDate.Notification.Success(response);
            }).catch(function (error) {
                RealDate.Notification.Error(error);
            });
    }

    function stopCamera() {
        publicStream.getTracks().forEach(function (track) {
            track.stop();
        });

        let video = document.getElementById('video');

        if (video) {
            video.srcObject = null;
        }

        RealDate.Notification.Info("webcam desativada");
    }

    function throwError(origem, e) {
        RealDate.Notification.Error(origem + ' - ' + e);
    }

    return {
        Notification: {
            Info: function (message) {
                clearClass();
                $("#divMessage").addClass("alert alert-secondary");
                $("#lblMessage").text(message);
            },
            Warning: function (message) {
                clearClass();
                $("#divMessage").addClass("alert alert-warning");
                $("#lblMessage").text(message);
            },
            Success: function (message) {
                clearClass();
                $("#divMessage").addClass("alert alert-success");
                $("#lblMessage").text(message);
            },
            Error: function (message) {
                clearClass();
                $("#divMessage").addClass("alert alert-danger");
                $("#lblMessage").text(message);
            }
        },
        Face: {
            startDetection: () => {
                ExecutaVideo();
            },
            takeShot: () => {
                takeShot();
            },
            sendPhoto: () => {
                sendPhoto();
            },
            finishDetection: () => {
                stopCamera();
            }
        }
    }
}();