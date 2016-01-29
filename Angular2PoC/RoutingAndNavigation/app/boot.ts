import {bootstrap}        from 'angular2/platform/browser';
import {AppComponent}     from './app.component';

import {RouteConfig, Router, APP_BASE_HREF, ROUTER_PROVIDERS, ROUTER_DIRECTIVES, CanActivate} from 'angular2/router';
import {HTTP_PROVIDERS, Http} from 'angular2/http';
import {AuthHttp, AuthConfig, tokenNotExpired, JwtHelper} from 'angular2-jwt';
import {provide} from 'angular2/core';

bootstrap(AppComponent, [
    HTTP_PROVIDERS,
    ROUTER_PROVIDERS,
    provide(AuthConfig, {
        useFactory: () => {
            return new AuthConfig();
        }
    }),
    AuthHttp
]);