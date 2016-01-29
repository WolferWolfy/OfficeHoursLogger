System.register(['angular2/platform/browser', './app.component', 'angular2/router', 'angular2/http', 'angular2-jwt', 'angular2/core'], function(exports_1) {
    var browser_1, app_component_1, router_1, http_1, angular2_jwt_1, core_1;
    return {
        setters:[
            function (browser_1_1) {
                browser_1 = browser_1_1;
            },
            function (app_component_1_1) {
                app_component_1 = app_component_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (angular2_jwt_1_1) {
                angular2_jwt_1 = angular2_jwt_1_1;
            },
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            browser_1.bootstrap(app_component_1.AppComponent, [
                http_1.HTTP_PROVIDERS,
                router_1.ROUTER_PROVIDERS,
                core_1.provide(angular2_jwt_1.AuthConfig, {
                    useFactory: function () {
                        return new angular2_jwt_1.AuthConfig();
                    }
                }),
                angular2_jwt_1.AuthHttp // breaks with SyntaxError: expected expression, got '<' 	node_modules/angular2-jwt/angular2-jwt
            ]);
        }
    }
});
//# sourceMappingURL=boot.js.map