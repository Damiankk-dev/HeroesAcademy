import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthResponseDto } from '../response/authResponseDto.model';
import { UserForAuthenticationDto } from '../user/userForAuthenticationDto.model';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../authentication/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private returnUrl!: string;
  
  loginForm!: FormGroup;
  errorMessage: string = '';
  showError!: boolean;

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    console.log("Hello from Init");
    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  validateControl = (controlName: string) => {
    return this.loginForm.get(controlName)?.invalid && this.loginForm.get(controlName)?.touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName)?.hasError(errorName)
  }
  
  loginUser = (loginFormValue: any) => {
    this.showError = false;
    const login = {... loginFormValue };
    
    console.log("Hello from loginUser");

    const userForAuth: UserForAuthenticationDto = {
      email: login.email,
      password: login.password
    }

    this.authService.loginUser('Account/Login', userForAuth)
    .subscribe({
      next: (res:AuthResponseDto) => {
       localStorage.setItem("token", res.token);
       this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
       this.router.navigate([this.returnUrl]);
    },
    error: (err: HttpErrorResponse) => {
      this.errorMessage = err.message;
      this.showError = true;
    }})
  }

}
