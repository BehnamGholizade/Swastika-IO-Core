﻿
app.component('portalPageMain', {
    templateUrl: '/app-portal/pages/portal-page/components/main/main.html',
    controller: ['$rootScope', '$scope', '$routeParams',function ($rootScope, $scope, $routeParams) {
        var ctrl = this;
        ctrl.settings = $rootScope.settings;
        ctrl.setPageType = function (type) {
            ctrl.page.type = $index;
        };
        ctrl.generateKeyword = function (text) {
            if (!$routeParams.id) {
                ctrl.page.textKeyword = 'portal_' + text.replace(/[^a-zA-Z0-9]+/g, '_')
                    .replace(/([A-Z]+)([A-Z][a-z])/g, '$1-$2')
                    .replace(/([a-z])([A-Z])/g, '$1-$2')
                    .replace(/([0-9])([^0-9])/g, '$1-$2')
                    .replace(/([^0-9])([0-9])/g, '$1-$2')
                    .replace(/-+/g, '_')
                    .toLowerCase();
            }
        };
    }],
    bindings: {
        page: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});