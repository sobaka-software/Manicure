$(document).ready(function () {
    $('ul.nav.navbar-nav').find('a[href="' + location.pathname + '"]').closest('li').addClass('active');

    $(".btnAddField").click(function (e) {
        e.preventDefault();
        $(".addField").slideToggle('slow');
    });
 
    $('.gallery-main').slick({
        dots: true,
        infinite: true,
        speed: 300,
        centerMode: true,
        variableWidth: true,
        adaptiveHeight: true,
        autoplay: true,
        autoplaySpeed: 3500,
        slidesToShow: 4,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });

    $('.gallery-masters, .gallery-photo, .gallery-diploms').slick({
        dots: true,
        infinite: true,
        speed: 300,
        centerMode: true,
       variableWidth: true,
        adaptiveHeight: false,
        autoplay: false,
        slidesToShow: 3,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });
    
});
