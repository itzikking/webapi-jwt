import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutenticationService } from '../Services/Autentication.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  user;

  constructor(
    public router: Router,
    private _AutenticationService: AutenticationService,
  ) {
    if (!localStorage.getItem('token')) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
    this.GetUser();
  }

  GetUser() {
    this._AutenticationService.GetUser().subscribe(
      res => {
        console.log("GetUser", res)
        //user=res
      },
      err => {
        console.log(err)
      })
  }
  logout(e) {
    this.router.navigate(['/']);
    localStorage.removeItem('token')
  }
}
