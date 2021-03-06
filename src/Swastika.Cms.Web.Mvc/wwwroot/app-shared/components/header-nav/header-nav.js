﻿(function (angular) {
    app.component('headerNav', {
        templateUrl: '/app-shared/components/header-nav/headerNav.html',
        controller: ['$rootScope', 'commonServices', 'translatorService', function ($rootScope, commonServices, translatorService) {
            var ctrl = this;
            ctrl.changeLang = function (lang, langIcon) {
                ctrl.settings.lang = lang;
                ctrl.settings.langIcon = langIcon;

                commonServices.fillSettings(lang).then(function () {
                    translatorService.reset(lang).then(function () {
                        window.top.location = location.href;
                    });
                });
            };
            ctrl.logOut = function () {
                $rootScope.logOut();
            };
        }],
        bindings: {
            breadCrumbs: '=',
            settings: '='
        }
    });
})(window.angular);