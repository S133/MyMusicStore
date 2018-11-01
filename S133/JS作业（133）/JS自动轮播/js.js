window.onload=function(){
    var slider=document.getElementById('slider');
    var ul=document.getElementById('ad_ul');
    var ol=document.getElementById('ad_ol').getElementsByTagName('li');
    
    var index=0;
    var times=null;
    var leader=0;
    var target=0;
    times=setInterval(automatic,1000);
    function automatic(){
        index++;
        if(index >=ol.length){
            index=0;
        }
        currentimages(index);
    }
    function currentimages(currentindex){
        for(var i=0;i<ol.length;i++){
            for(var i=0;i<ol.length;i++){
                ol[i].className='';
            }
            ol[currentindex].className='current';
            target=ol[currentindex].index*-500;
        }
    }
    
    setInterval(function(){
        leader=leader+(target-leader)/10;
        ul.style.left=leader+'px';
    },20)

    slider.onmouseover=function(){
        clearInterval(times);
    }
    slider.onmouseout=function(){
        times=setInterval(automatic,2000);
    }
    for(var i=0;i<ol.length;i++){
        ol[i].index=i;
        ol[i].onmouseover=function(){
            clearInterval(times);
            currentimages(this.index);
            index=this.index;
        }
    }
    
}