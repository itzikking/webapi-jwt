import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor } from "@angular/common/http";
import { AutenticationService } from './Autentication.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private injector: Injector) { }

  intercept(req, next) {
    let userService = this.injector.get(AutenticationService)
    let tokenizedReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${userService.GetToken()}`
      }
    })
    return next.handle(tokenizedReq)
  }
}
