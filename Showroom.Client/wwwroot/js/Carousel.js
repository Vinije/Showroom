window.initializeCarousel = () => {
    $('#carouselExampleSlidesOnly').carousel({ interval: 5000 })
    $('#carouselExampleSlidesOnly-prev').click(
        () => $('#carouselExampleSlidesOnly').carousel('prev'));
    $('#carouselExampleSlidesOnly-next').click(
        () => $('#carouselExampleSlidesOnly').carousel('next'));
}