import {HttpInterceptorFn, HttpRequest} from '@angular/common/http';
import {AuthenticationService} from "./authentication.service";
import {inject} from "@angular/core";

export const authenticationInterceptor: HttpInterceptorFn = (req, next) => {
  
  const authenticationService = inject(AuthenticationService);
  
  if (!authenticationService.isAuthenticated)
    return next(req);

  const token = authenticationService.getAccessToken();
  
  if (token == undefined)
    return next(req);

  const authenticatedRequest = authenticate(req, token!);

  return next(authenticatedRequest);  
};

function authenticate<T>(request: HttpRequest<T>, token: string): HttpRequest<T> {
    console.log(request.url);
    return request.clone({headers: request.headers.set('Authorization', `Bearer ${token}`)});
}