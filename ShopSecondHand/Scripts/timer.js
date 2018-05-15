
var timer;
var timerFlag = false;
start();


function start () {
    if (timerFlag === true) {
        return;
    }
    timerFlag = true;


    timer = setInterval(function () {
        slideshow();
        }, 3000);
}

function slideshow()
{
    var firstImage = document.getElementById("first-image");
    var secondImage = document.getElementById("second-image");
    var thirdImage = document.getElementById("third-image");
   

    //var value = firstImage.attributes["value"].value

    var src = firstImage.src;
    var value = firstImage.attributes["value"].value;

    firstImage.src = secondImage.src;
    firstImage.attributes["value"].value = secondImage.attributes["value"].value

    
    secondImage.src = thirdImage.src;
    secondImage.attributes["value"].value = thirdImage.attributes["value"].value

    thirdImage.src = src;
    thirdImage.attributes["value"].value = value;

}

