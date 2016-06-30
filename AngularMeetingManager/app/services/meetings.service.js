angular
    .module('ammApp')
    .factory('meetingsService', function ($http) {
        var hosturl = window.location.protocol + "//" + window.location.host;
        var service = {
            getAllMeetings: getAllMeetings,
            getMeetingsByRoom: getMeetingsByRoom,
            addMeeting: addMeeting,
            deleteMeeting: deleteMeeting
        };
        return service;

        function getAllMeetings() {
            var test = "";
            return $http.get(hosturl + "/api/meetings/GetAllMeetings")
                .then(function (data) {
                    var test = "";
                    return data.data;
                }).catch(function (response) {
                    test = "";
                    alert("An error occurred in GetListItems." + response.data.Message)
                });
            test = "";
        }

        function getMeetingsByRoom(room_id) {
            var test = "";
            return $http.get(hosturl + "/api/meetings/GetMeetingsByRoom/" + room_id)
                .then(function (data) {
                    var test = "";
                    return data.data;
                }).catch(function (response) {
                    test = "";
                    alert("An error occurred in GetListItems." + response.data.Message)
                });
            test = "";
        }

        function addMeeting(obj) {
            var test = "";
            return $http.post(hosturl + "/api/meetings/AddMeeting", obj).then(function (data) {
                var test = "";
                return data.data;
            }).catch(function (response) {
                var test = "";
                alert("An error occurred in addMeeting." + response.data.Message)
            });
        }

        function deleteMeeting(meetingid) {
            var test = "";
            return $http.get(hosturl + "/api/meetings/DeleteMeeting/" + meetingid)
                .then(function (data) {
                    var test = "";
                    return data.data;
                }, function errorCallback(response) {
                    test = "";
                    alert("An error occurred in /rooms/Delete/" + response.data.Message)
                });
            test = "";
        }
    });