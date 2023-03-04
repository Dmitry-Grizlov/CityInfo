(function ($, document, window) {
	$(function () {
		var url = window.location.pathname;
		if (url == '/')
			url = 'Home'

		let arr = url.split('/')

		$('.menu-item').each(function () {
			if (this.children[0].text === arr[arr.length - 1]) {
				$(this).addClass('current-menu-item');
			}
		});
	});

	$(document).ready(function () {

		// Cloning main navigation for mobile menu
		$(".mobile-navigation").append($(".main-navigation .menu").clone());

		// Mobile menu toggle 
		$(".menu-toggle").click(function () {
			$(".mobile-navigation").slideToggle();
		});

		var map = $(".map");
		var latitude = map.data("latitude");
		var longitude = map.data("longitude");
		if (map.length) {

			map.gmap3({
				map: {
					options: {
						center: [latitude, longitude],
						zoom: 15,
						scrollwheel: false
					}
				},
				marker: {
					latLng: [latitude, longitude],
				}
			});

		}
	});

	$(window).load(function () {

	});

})(jQuery, document, window);