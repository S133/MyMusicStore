function updateTime(){
    var endTime=new Date('2018/10/25,12:00:00');

    var currenTime=new Date();

    var leftSecond=parseInt((endTime.getTime()-currenTime.getTime())/1000);

    h=parseInt(leftSecond /3600);

    m=parseInt(leftSecond /60%60);

    s=parseInt(leftSecond %60);

    if(h<10)
    h="0"+h;
    if(m<10&&m>=0)
    m="0"+m;
    else if(m<0)
    m="00";
    if(s<10&&s>=0)
    s="0"+s;
    else if(s<0)
    s="00";

    document.getElementById('hour').innerHTML=h;
    document.getElementById('minute').innerHTML=m;
    document.getElementById('second').innerHTML=s;

    if(leftSecond<=0){
        document.getElementById('end_box').style.background='url(images/flash_end.png)no-repeat'
        document.getElementById('end_box').style.display="block";
        document.getElementById('end_box').innerHTML="秒杀已结束";
    }
}
var countDown=setInterval(updateTime,1000);