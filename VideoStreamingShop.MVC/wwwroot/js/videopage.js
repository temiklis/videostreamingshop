$('div.box.more span').click(function () {
    $(this).closest('.box').toggleClass('expanded');
})