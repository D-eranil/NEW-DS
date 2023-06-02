$(function(){

    let i=0;
    function change(){  
        ++i;
        $($(".blog-slider .blog-detail")[i-1]).animate({width:"10%"},0.01).removeClass("a");
        $($('.slide li')[i-1]).removeClass("b");
        if(i==5){
            i=0;
        }
        $($(".blog-slider .blog-detail")[i]).animate({width:"50%"}).addClass("a");
        $($('.slide li')[i]).addClass("b");
    }
    var a=setInterval(change,90000);
    
    let j=0;    
    $('.blog-slider .blog-detail').click(function(){
        clearInterval(a);
        j=$(this).index();
        if(j!=0 || j!=4){
            $('.fas').removeClass('c');
        }
        if($(this).hasClass("a")){}
        else{
            $('.blog-slider .blog-detail').animate({width:"10%"},0.5).removeClass('a');
            $('.slide li').removeClass('b');
            $(this).animate({width:"50%"},200).addClass('a');
            $( $('.slide li')[$(this).index()] ).addClass('b');
        }
    });
    
    $('.fas').click(function(){
        clearInterval(a);
        j=$('.a').index();
        if(j==0 && $(this).hasClass('prev')){
            $($('.blog-slider .blog-detail')[0]).animate({width:"10%"},0.01).removeClass("a")
            $($('.slide li')[0]).removeClass("b");
            $($('.blog-slider .blog-detail')[4]).animate({width:"50%"},200).addClass("a")
            $($('.slide li')[4]).addClass("b");
        }
        else if(j==4 && $(this).hasClass('next')){
            $($('.blog-slider .blog-detail')[4]).animate({width:"10%"},0.01).removeClass("a")
            $($('.slide li')[4]).removeClass("b");
            $($('.blog-slider .blog-detail')[0]).animate({width:"50%"},200).addClass("a")
            $($('.slide li')[0]).addClass("b");
        }
        else{
            if($(this).hasClass("prev")){
                $($('.blog-slider .blog-detail')[j]).animate({width:"10%"},0.01).removeClass("a")
                $($('.slide li')[j]).removeClass("b");
                $($('.blog-slider .blog-detail')[j-1]).animate({width:"50%"},200).addClass("a")
                $($('.slide li')[j-1]).addClass("b");
            }
            else{
                $($('.blog-slider .blog-detail')[j]).animate({width:"10%"},0.01).removeClass("a")
                $($('.slide li')[j]).removeClass("b");
                $($('.blog-slider .blog-detail')[j+1]).animate({width:"50%"},200).addClass("a")
                $($('.slide li')[j+1]).addClass("b");
            }
        }
            
    });

});
$(function(){
    $(".partner-slider").slick({
    dots: false,
    vertical: false,
    centerMode: false,
    slidesToShow: 4,
    slidesToScroll: 2,
    prevArrow:"<button type='button' class='slick-prev pull-left' aria-label='prev-arrow'><svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 256 512'><path d='M192 448c-8.188 0-16.38-3.125-22.62-9.375l-160-160c-12.5-12.5-12.5-32.75 0-45.25l160-160c12.5-12.5 32.75-12.5 45.25 0s12.5 32.75 0 45.25L77.25 256l137.4 137.4c12.5 12.5 12.5 32.75 0 45.25C208.4 444.9 200.2 448 192 448z'/></svg></button>",
    nextArrow:"<button type='button' class='slick-next pull-right' aria-label='next-arrow'><svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 256 512'><path d='M64 448c-8.188 0-16.38-3.125-22.62-9.375c-12.5-12.5-12.5-32.75 0-45.25L178.8 256L41.38 118.6c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0l160 160c12.5 12.5 12.5 32.75 0 45.25l-160 160C80.38 444.9 72.19 448 64 448z'/></svg></button>",
    responsive: [
        {
        breakpoint: 991,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
        }
    },
    {
            breakpoint: 500,
            settings: {
              slidesToShow: 1,
              slidesToScroll: 1,
        }
      }]
}),
  $(".testimonial-slider").slick({
    dots: false,
    vertical: false,
    centerMode: false,
    slidesToShow: 1,
    slidesToScroll: 1,
    prevArrow:"<button type='button' class='slick-prev pull-left' aria-label='prev-arrow'><svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 256 512'><path d='M192 448c-8.188 0-16.38-3.125-22.62-9.375l-160-160c-12.5-12.5-12.5-32.75 0-45.25l160-160c12.5-12.5 32.75-12.5 45.25 0s12.5 32.75 0 45.25L77.25 256l137.4 137.4c12.5 12.5 12.5 32.75 0 45.25C208.4 444.9 200.2 448 192 448z'/></svg></button>",
    nextArrow:"<button type='button' class='slick-next pull-right' aria-label='next-arrow'><svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 256 512'><path d='M64 448c-8.188 0-16.38-3.125-22.62-9.375c-12.5-12.5-12.5-32.75 0-45.25L178.8 256L41.38 118.6c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0l160 160c12.5 12.5 12.5 32.75 0 45.25l-160 160C80.38 444.9 72.19 448 64 448z'/></svg></button>"
  
  }),
  $(".activity-slider").slick({
    dots: false,
    vertical: false,
    centerMode: false,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: false,
    prevArrow:"<button type='button' class='slick-prev pull-left' aria-label='prev-arrow'><svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 512 512'><path d='M256 0C114.6 0 0 114.6 0 256c0 141.4 114.6 256 256 256s256-114.6 256-256C512 114.6 397.4 0 256 0zM310.6 345.4c12.5 12.5 12.5 32.75 0 45.25s-32.75 12.5-45.25 0l-112-112C147.1 272.4 144 264.2 144 256s3.125-16.38 9.375-22.62l112-112c12.5-12.5 32.75-12.5 45.25 0s12.5 32.75 0 45.25L221.3 256L310.6 345.4z'/></svg></button>",
    nextArrow:"<button type='button' class='slick-next pull-right' aria-label='next-arrow'><svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 512 512'><path d='M256 0C114.6 0 0 114.6 0 256c0 141.4 114.6 256 256 256s256-114.6 256-256C512 114.6 397.4 0 256 0zM358.6 278.6l-112 112c-12.5 12.5-32.75 12.5-45.25 0s-12.5-32.75 0-45.25L290.8 256L201.4 166.6c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0l112 112C364.9 239.6 368 247.8 368 256S364.9 272.4 358.6 278.6z'/></svg></button>"
  });
});
$(window).scroll(function() {
    if ($(this).scrollTop() > 450){
       $('.breadcrumbs').addClass("fixed-breadcrumb");
    } else {
       $('.breadcrumbs').removeClass("fixed-breadcrumb");
    }
 });
 $('#activities').on('show.bs.collapse', function (e) {
    $('.activity-slider').slick('refresh');
});
$(window).scroll(function() {
    if ($(this).scrollTop() > 100){
       $('.sticky-header').addClass("active");
    } else {
       $('.sticky-header').removeClass("active");
    }
 });

 window.onscroll = function() {scrollFunction()};
 function scrollFunction() {
     if (document.body.scrollTop > 500 || document.documentElement.scrollTop > 500) {
         document.getElementById("scroll-top").style.display = "block";
     } else {
         document.getElementById("scroll-top").style.display = "none";
     }
 }
 
 // When the user clicks on the button, scroll to the top of the document
 function topFunction() {
      $('html, body').animate({scrollTop:0}, 'smooth');
 }
$('#contact-us-popup').on('click', function(){
  $('#navbar').removeClass('show');
});

