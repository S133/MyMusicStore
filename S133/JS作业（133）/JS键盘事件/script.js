window.onload=function(){
    document.body.onkeydown=function(evt){
        //定义小球的步长
        var step=10;
        //获取球台和小球的元素
        var box=document.getElementById('box');
        var ball=document.getElementById('ball');
        //获取小球相对于球台div左侧和顶部的距离
        var left =ball.offsetLeft;
        var top =ball.offsetTop;
        console.log('球的初始位置:'+left+','+top);

        var box_width=box.offsetWidth;
        var box_height=box.offsetHeight;
        console.log('球桌的高和宽:'+box_width+','+box_height);

        var ball_width=ball.width;
        var ball_height=ball.height;
        console.log('球桌的高和宽:'+box_width+','+box_height);


        var x_max=box_width- ball_width - step;
        var y_max=box_height- ball_height - step;
        console.log('x,y最大距离'+x_max+','+y_max);

        var e=evt?evt:window.event;
        if(e.keyCode==37 && (left-10)>step){
            ball.style.left=left-step+'px';
        }
        if(e.keyCode==39&& left<=(x_max-20)){
            ball.style.left=left+step+'px';
        }
        if(e.keyCode==38&& (top-10)>step){
            ball.style.top=top-step+'px';
        }
        if(e.keyCode==40&& top<=(y_max-19)){
            ball.style.top= top+ step +'px';
        }
    }
}