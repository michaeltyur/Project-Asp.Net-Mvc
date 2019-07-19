
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
    let firstImage = document.getElementById("first-image");
    let secondImage = document.getElementById("second-image");
    let thirdImage = document.getElementById("third-image");
   

    //var value = firstImage.attributes["value"].value

    let src = firstImage.src;
    let value = firstImage.attributes["value"].value;

    firstImage.src = secondImage.src;
    firstImage.attributes["value"].value = secondImage.attributes["value"].value

    
    secondImage.src = thirdImage.src;
    secondImage.attributes["value"].value = thirdImage.attributes["value"].value

    thirdImage.src = src;
    thirdImage.attributes["value"].value = value;

}

