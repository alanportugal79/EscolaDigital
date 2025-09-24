import { Injectable } from "@angular/core";
import Keycloak, {KeycloakConfig, KeycloakInitOptions} from 'keycloak-js';
import KeycloakAuthorization from "keycloak-js/authz";
import {environment} from '../../environments/environment';
import { forkJoin, from, mergeMap, Observable, Observer, of, switchMap } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    private keycloak?: Keycloak;
    private authorization?: KeycloakAuthorization;    
    
    get isAuthenticated(): boolean {
        return this.keycloak?.authenticated ?? false;
    }

    get userId(): string | undefined {
        return this.keycloak?.profile?.id;
    }

    get username(): string | undefined {
        return this.keycloak?.profile?.username;
    }

    get fullName(): string | undefined {
        return `${this.keycloak?.profile?.firstName ?? "" } ${this.keycloak?.profile?.lastName ?? ""}`
    }

    get email(): string | undefined {
        return this.keycloak?.profile?.email;
    }

    public init(): Observable<any> {
        const authorityUrl = new URL(environment.authority);
        const keycloakConfig: KeycloakConfig = {
            url: authorityUrl.origin,
            realm: authorityUrl.pathname.split('/').filter(segment => segment != '').pop() ?? '',
            clientId: environment.clientId,
        };

        this.keycloak = new Keycloak(keycloakConfig);
        this.keycloak.resourceAccess

        return this.initKeycloak(this.keycloak)
            .pipe(
                switchMap(isAuthenticated =>
                    forkJoin([this.initAuthorization(), this.loadUserProfile(isAuthenticated)])
                )
            );
    }

    public getAccessToken(): string | undefined {
        if (!this.keycloak)
        throw Error('Keycloak authentication service not initialized');
        this.keycloak.updateToken(5);       
        return this.keycloak.token;
    }

    public login(): void {
        if (!this.keycloak)
        throw Error('Keycloak authentication service not initialized');
        this.keycloak.login();
    }

    public logout(): void {
        if (!this.keycloak)
        throw Error('Keycloak authentication service not initialized');
        this.keycloak.logout();
    }

    private initKeycloak(keycloak: Keycloak): Observable<any> {
        const initOptions: KeycloakInitOptions = {                    
            enableLogging: true,
            checkLoginIframe: false,
            flow: 'standard',
            onLoad: 'check-sso',
            scope: 'session_api.all'            
        }
        return from(keycloak.init(initOptions));
    }

    private initAuthorization(): Observable<void> {
        if (!this.keycloak)
            throw Error('Keycloak authentication service not initialized');

        this.authorization = new KeycloakAuthorization(this.keycloak);
        this.authorization.init();
        return of(void 0);
    }

    private loadUserProfile(isAuthenticated: boolean): Observable<any> {
        return isAuthenticated ? from(this.keycloak!.loadUserProfile()) : of(undefined);
    }    
}