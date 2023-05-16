import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, from, catchError, lastValueFrom } from 'rxjs';
import { AuthenticationService } from 'src/app/authentication/authentication.service';
import { Constants } from 'src/app/constants/constants';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor(
    private _authService: AuthenticationService,
    private _router: Router
    ) { }
  
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(req.url.startsWith(Constants.apiRoot)){
      console.log("Hello from interceptor");
    return from(
      this._authService.getAccessToken()
      .then(token => {
        const headers = req.headers.set('Authorization', `Bearer ${token}`);
        const authRequest = req.clone({ headers });
        console.log("Token: ", token);
        console.log("Headers: ", headers);
        const res = next.handle(authRequest)
        .pipe(
          catchError((err : HttpErrorResponse) => {
            if(err && (err.status === 401 || err.status === 403)){
              this._router.navigate(['/unauthorized']);
            }
            throw 'error in a request ' + err.status;
          })
        );
        return lastValueFrom(res);
      })
    );
    }
    else {
      return next.handle(req);
    }
  }
}