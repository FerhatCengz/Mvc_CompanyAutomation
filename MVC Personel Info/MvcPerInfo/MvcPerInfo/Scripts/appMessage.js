



$(".user_img").click(function(e)
{
    let imgSrc = e.target.src;
    panel.src = imgSrc;
    userKad.textContent = e.target.getAttribute("value");


});