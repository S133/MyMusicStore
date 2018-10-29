window.onload=function(){
    function $(id){
        return document.getElementById(id);
    }



var pic_top=0;
var timer=null;
//up onmouseover
$('picUp').onmouseover=function(){
    //打开计时器 每秒修改top属性
    clearInterval(timer);
    timer=setInterval(function(){
        pic_top--;
        pic_top>=-1070 ? $('pic').style.top=pic_top+'px': clearInterval(timer);
    }, 20);
}



//down onmouseover
//打开计时器 每秒修改top属性
$('picDown').onmouseover=function(){
    //打开计时器 每秒修改top属性 图片底部时停止
    clearInterval(timer);
    timer=setInterval(function(){
        pic_top++;
        pic_top< 0 ? $('pic').style.top = pic_top + 'px': clearInterval(timer);
    }, 20);
}
//onmouseout 计时器停
$("xiaomi").onmouseout = function () {
    clearInterval(timer);
}
}