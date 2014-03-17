/*
    Define the todoLists controller responsible for rendering the users created to do lists
*/
(function () {
    var todoApp = angular.module("todoApp");

    todoApp.controller("ToDoListsController", function ($scope, todoListFactory, $modal, $log) {
        $scope.TodoLists = [];

        /*
            Initialization
            ==========================================
        */

        // get the to-do lists from the server
        var promise = todoListFactory.getUserTodoLists();

        // This code will happen in 'future'.
        promise.then(function (data) {
            $scope.TodoLists = data;
        });

        /*
            Event handling
            ==========================================
        */

        /*
            The handler for the add to do list button. Should display the modal dialog.
        */

        $scope.AddTodoList = function () {

            // dislay the modal dialog
            var modalInstance = $modal.open({
                templateUrl: 'editListContent.html',
                controller: "ListEditModalController",
                scope: $scope,
                
                // we can pass in data here 
            });

            // setup what to do when modal is closed either with ok or cancel?
            modalInstance.result.then(
                function (data) {
                    var promise = todoListFactory.saveNewTodoList(data);
                }
                , function () {
                    // modal dismissed, and we will do nothing here
                }
            );
        };
    });
})();
