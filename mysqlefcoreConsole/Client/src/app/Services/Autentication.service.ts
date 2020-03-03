import { Injectable } from '@angular/core';
import { HttpClient, } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AutenticationService {
  Server = "https://localhost:44394/api/Authentication";

  constructor(private _http: HttpClient) { }

  GetToken() {
    return localStorage.getItem('token')
  }
  GetUser() {
    return this._http.get(this.Server);
  }
  Get() {
    return this._http.get(this.Server).subscribe(
      res => {
        console.log(res)
      },
      err => {
        console.log(err)
      });
  }

  Post(username, password) {
    const user = { username, password }
    return this._http.post(this.Server, user);
  }

}
