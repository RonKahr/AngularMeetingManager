angular
    .module('ammApp')
    .config(function ($stateProvider, $urlRouterProvider) {

        // For any unmatched url, send to /
        $urlRouterProvider.otherwise("/rooms")

        $stateProvider
            .state('rooms', {
                url: "/rooms",
                templateUrl: "/app/rooms/rooms.html",
                controller: "RoomsController"
            })
            .state('meetings', {
                url: "/meetings",
                templateUrl: "/app/meetings/meetings.html",
                controller: "MeetingsController"
            })
    })