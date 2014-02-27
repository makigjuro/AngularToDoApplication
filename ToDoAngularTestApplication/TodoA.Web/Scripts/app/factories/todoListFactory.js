/*
    Define the service that will retrieve the 
*/
(function () {
    // get the application module already defined in the TodoApp.js script file
    var todoApp = angular.module("todoApp");

    todoApp.factory("todoListFactory", function ($http, $q) {
        // define the factory object
        var factory = {};

        /*
            The method will retrieve the user User To-do lists.
            =====================================================
        */

        factory.getUserTodoLists = function () {
            var deferred = $q.defer();

            $http.get("/api/TodoListData")
                .success(function (data) {
                    // Resolve the promise with data objcet.
                    deferred.resolve(data);
                });
                
            // Return the promise emidietly(will be solved in the future)    
            return deferred.promise;
        };
        
        /*
            Returns details for a given to do list
            =====================================================
        */

        factory.getListDetailsById = function(id) {
            var deffered = $q.defer();

            $http.get("/api/TodoListData/" + id).success(function(data) {
                deffered.resolve(data);
            });

            return deffered.promise;
        };
        

        /*
            Save To do List. Make a call to the server passing new to do list data
            =====================================================
        */

        factory.saveNewTodoList = function (data) {
            
        };

        // return the factory object
        return factory;
    });
})();
