var en = true;
function Like(e) {

    var likeNum = e.innerHTML;

    if (e.style.color == "white") {
        likeNum++;
        e.innerHTML = "  " + likeNum;
        e.style.color = "black";
    }
    else {
        likeNum--;
        e.innerHTML = "  " + likeNum;
        e.style.color = "white";
    }
    en = !en;

}
var slides;
// Open the Modal
function openModal(modalName, slideName) {
    //debugger;
    slides = document.getElementsByClassName(`${slideName}`)
    document.getElementById(`${modalName}`).style.display = "block";
    document.getElementById("colorlib-aside").style.visibility = "hidden"
}
//function openModal2(modalName) {
//    //debugger;
//    document.getElementById(`${modalName}`).style.display = "block";
//    document.getElementById("colorlib-aside").style.visibility = "hidden"
//}
// Close the Modal
function closeModal(colseModalName) {
    document.getElementById(`${colseModalName}`).style.display = "none";
    document.getElementById("colorlib-aside").style.visibility = "visible";
}

var slideIndex = -1;
// showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
    showSlides(slideIndex += n);
    //debugger;
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var dots = document.getElementsByClassName("demo");
    var captionText = document.getElementById("caption");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    //for (i = 0; i < dots.length; i++) {
    //    dots[i].className = dots[i].className.replace(" active", "");
    //}
    //debugger;
    slides[slideIndex - 1].style.display = "block";
    //dots[slideIndex - 1].className += " active";
    //captionText.innerHTML = dots[slideIndex - 1].alt;
}