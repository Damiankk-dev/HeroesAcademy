import { NgForOf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HeroService } from '../hero/hero.service';
import { Hero } from '../heroes-list/hero.model';

@Component({
  selector: 'app-hero-edit',
  templateUrl: './hero-edit.component.html',
  styleUrls: ['./hero-edit.component.css']
})
export class HeroEditComponent implements OnInit {
  pageTitle="edycja herosa";
  teams= ["League","X-Men", "Avengers", "others"];
  isPasswordVisible = false;
  inputType = "password";
  hero: Hero={
    name: '',
    team: '',
    secretIdentity: '',
    salary: 0,
    strength: 0,
    description: '',
    active: false,
    logoUrl: ''
  } as Hero;

  constructor(private heroService:HeroService, private router:Router) {

   }

  ngOnInit(): void {
  }
  onIconClick(): void{
    this.isPasswordVisible = !this.isPasswordVisible;
    this.inputType = this.isPasswordVisible?"text":"password";
  }

  onSubmit(form:NgForm):void{
    if (form.valid){
      this.heroService.createHero(this.hero).subscribe(()=>{
        this.router.navigate(['/heroes']);
      });
    }
  }
}
