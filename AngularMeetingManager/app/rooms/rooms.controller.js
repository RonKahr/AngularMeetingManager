angular
    .module('ammApp')
    .controller("RoomsController", function ($rootScope, $scope, roomsService, meetingsService, $uibModal) {
        $scope.rooms = [];
        $scope.roomsCopy = [];
        $scope.selectRoom = selectRoom;
        $scope.updateRoom = updateRoom;
        $scope.cancelUpdateRoom = cancelUpdateRoom;
        $scope.selectedRoom = {};
        $scope.selectedRoomCopy = {};
        $scope.meetings = [];
        $scope.addRoom = addRoom;
        $scope.deleteRoom = deleteRoom;
        $scope.addMeeting = addMeeting;
        $scope.deleteMeeting = deleteMeeting;
        //$scope.newRoom = {};
       
        var hosturl = window.location.protocol + "//" + window.location.host;

        activate();

        function activate() {
            var test = "";
            return getAllRooms().then(function () {
                test = "";
            });
            test = "";
        }

        function getAllRooms() {
            return roomsService.getAllRooms().then(function (data) {
                $scope.rooms = data;
                return $scope.rooms;
            });
        }

        function selectRoom(room) {
            $scope.selectedRoom = room;
            $scope.selectedRoomCopy = angular.copy(room);
            $scope.roomsCopy = angular.copy($scope.rooms);
            getMeetingsByRoom();
        }

        $scope.isSelected = function (rm) {
            return $scope.selectedRoom === rm;
        }

        function updateRoom(room) {
            var test = "";
            return roomsService.updateRoom(room).then(function (data) {
                test = "";
                alert('Room updated');
                $scope.selectedRoomCopy = room;
                $scope.roomsCopy = $scope.rooms;
            });
        }

        function getMeetingsByRoom() {
            var test = "";
            return meetingsService.getMeetingsByRoom($scope.selectedRoom.id).then(function (data) {
                $scope.meetings = data;
                return $scope.meetings;
            });
        }

        function cancelUpdateRoom() {
            $scope.selectedRoom = $scope.selectedRoomCopy;
            $scope.rooms = $scope.roomsCopy;
        }

        function addRoom() {
            var modalInstance = $uibModal.open({
                animation: false,
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                resolve: {
                    items: function () {
                        return $scope.items;
                    }
                },
                windowClass: 'rooms-add-modal'
            });
            modalInstance.result.then(function (selectedItem) {
                //$scope.newRoom = selectedItem;
                var test = "";
                if (selectedItem != null) {
                    var newRoom = {};
                    return roomsService.addRoom(selectedItem).then(function (data) {
                        test = "";
                        alert('Room added');
                        newRoom = selectedItem;
                        newRoom.id = data;
                        $scope.rooms.push(newRoom);
                    });
                }
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }

        function deleteRoom(room) {
            var test = "";
            return roomsService.deleteRoom(room.id).then(function (data) {
                test = "";
                var index = $scope.rooms.indexOf(room);
                $scope.rooms.splice(index, 1);
            });
        }

        function addMeeting(selectedRoom) {
            var roomid = selectedRoom.id;
            var modalInstance = $uibModal.open({
                animation: false,
                templateUrl: 'addMeetingModal.html',
                controller: 'AddMeetingModalCtrl',
                resolve: {
                    items: function () {
                        return $scope.items;
                    },
                    item: function () {
                        return roomid;
                    }
                },
                windowClass: 'meetings-add-modal'
            });
            modalInstance.result.then(function (selectedItem) {
                //$scope.newRoom = selectedItem;
                var test = "";
                if (selectedItem != null) {
                    var newMeeting = {};
                    return meetingsService.addMeeting(selectedItem).then(function (data) {
                        test = "";
                        alert('Meeting added');
                        newMeeting = selectedItem;
                        newMeeting.id = data;
                        $scope.meetings.push(newMeeting);
                    });
                }
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }

        function deleteMeeting(mt) {
            var test = "";
            return meetingsService.deleteMeeting(mt.id).then(function (data) {
                test = "";
                var index = $scope.meetings.indexOf(mt);
                $scope.meetings.splice(index, 1);
            });
        }

    });

angular.module('ammApp').controller('ModalInstanceCtrl', function ($scope, $uibModalInstance) {

    var test = "";
    $scope.newRoom = {'roomname':'','floor':'','capacity':0};

    $scope.ok = function () {
        $uibModalInstance.close($scope.newRoom);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

angular.module('ammApp').controller('AddMeetingModalCtrl', function ($scope, $uibModalInstance,item) {

    var test = "";
    $scope.newMeeting = { 'title': '', 'end': '', 'start': '', 'room_id':item };

    $scope.ok = function () {
        $uibModalInstance.close($scope.newMeeting);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
