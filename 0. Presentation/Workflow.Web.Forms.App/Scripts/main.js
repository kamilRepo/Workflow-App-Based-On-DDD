$(document).ready(function(){
    $('.show-left-panel').click(function () {
        if ($('.profile').is(':visible')) {
            $('.profile').addClass("hidden-sm").addClass("hidden-xs").removeClass("col-sm-2").removeClass("fixed");
        }else{
            $('.profile').removeClass("hidden-sm").removeClass("hidden-xs").addClass("col-sm-2").addClass("fixed");
        }
    });
    $(window).resize(function(){
        if ($(document).width() > 992) {
            $('.profile').removeClass('fixed');
        } else {
            $('.profile').addClass('fixed');
        }
    })
    /*HR Active links*/
     $('.btn-group>input').each(function () {
        var lnk = $(this).attr('name').split('$');
        var lnkSub = lnk[lnk.length - 1].substring(4);
        var pathname = window.location.pathname;
        if (pathname.search(lnkSub) != -1) {
            $(this).addClass('active');
        } else if (pathname.search('FromSalary') != -1) {
            $('.btn-group>input:first-child').addClass('active');
        }
    });
    /*$('.left-nav>li>a').each(function () {
        var plink = window.location.pathname.split('/');
        var plinkSub = plink[plink.length - 1];
        var alnk = $(this).attr('href');
       
        if (alnk.search(plinkSub) != -1) {
            alert("asd");
        }
    });*/
    $('[data-toggle="tooltip"]').tooltip();
});