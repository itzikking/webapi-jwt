import { Component, OnInit } from '@angular/core';
import { AutenticationService } from '../Services/Autentication.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: FormGroup;
  IsLogIn;
  constructor
    (
      private _AutenticationService: AutenticationService,
      private _formBuilder: FormBuilder,
      public router: Router,
  ) { }

  ngOnInit(): void {
    this.login = this._formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
    // this._AutenticationService.Get();
  }

  onSubmit() {
    const username = this.login.value.username;
    const password = this.login.value.password;
    this._AutenticationService.Post(username, password).subscribe(
      res => {
        this.IsLogIn = res;
        if (this.IsLogIn.status != 200) { // catch
          console.log(this.IsLogIn);
        }
        else {
          this.router.navigate(['home']);
          localStorage.setItem('token', this.IsLogIn.autentication)
          console.log(this.IsLogIn);
        }
      },
      err => {
        console.log(err)
      });
  }
}
