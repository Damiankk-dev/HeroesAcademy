import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public isUserAuthenticated: boolean = false;
  isUserAdmin: boolean;

  constructor(private _authService: AuthenticationService) { }

  ngOnInit(): void {
    this._authService.loginChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
      this.isAdmin();
    })
  }

  public login = () => {
    this._authService.login();
  }

  public logout = () => {
    this._authService.logout();
  }

  public isAdmin = () => {
    return this._authService.checkIfUserIsAdmin()
    .then(res => {
      this.isUserAdmin = res;
    })
  }
}