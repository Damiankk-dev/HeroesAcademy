import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SigninRedirectCallbackComponent } from '../signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from '../signout-redirect-callback/signout-redirect-callback.component';



@NgModule({
  declarations: [
  
    SigninRedirectCallbackComponent,
       SignoutRedirectCallbackComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'signin-callback', component: SigninRedirectCallbackComponent },
      { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
    ])
  ]
})
export class AuthenticationModule { }
