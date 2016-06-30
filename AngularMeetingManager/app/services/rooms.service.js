angular
    .module('ammApp')
    .factory('roomsService', function ($http) {
        var hosturl = window.location.protocol + "//" + window.location.host;
        var service = {
            getAllRooms: getAllRooms,
            getRoomByID: getRoomByID,
            updateRoom: updateRoom,
            addRoom: addRoom,
            deleteRoom: deleteRoom
        };
        return service;

        function getAllRooms() {
            var test = "";
            return $http.get(hosturl + "/api/rooms/GetAllRooms")
                .then(function (data) {
                    var test = "";
                    return data.data;
                }).catch(function (response) {
                    test = "";
                    alert("An error occurred in GetAllRooms. rooms.service " + response.data.Message)
                });
            test = "";
        }

        function getRoomByID(room_id) {
            var test = "";
            return $http.get(hosturl + "/api/rooms/GetRoomByID/" + room_id)
                .then(function (data) {
                    var test = "";
                    return data.data;
                }, function errorCallback(response) {
                    test = "";
                    alert("An error occurred in GetListItems." + response.data.Message)
                });
            test = "";
        }

        function updateRoom(obj) {
            return $http.post(hosturl + "/api/rooms/UpdateRoom", obj).then(function (data) {
                var test = "";
                return data.data;
            }).catch(function (response) {
                var test = "";
                alert("An error occurred in updateRoom." + response.data.Message)
            });
        }

        function addRoom(obj) {
            var test = "";
            return $http.post(hosturl + "/api/rooms/AddRoom", obj).then(function (data) {
                var test = "";
                return data.data;
            }).catch(function (response) {
                var test = "";
                alert("An error occurred in updateRoom." + response.data.Message)
            });
        }

        function deleteRoom(room_id) {
            var test = "";
            return $http.get(hosturl + "/api/rooms/DeleteRoom/" + room_id)
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