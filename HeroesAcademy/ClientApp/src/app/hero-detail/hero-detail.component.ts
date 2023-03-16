import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { HeroService } from '../hero/hero.service';
import { Hero } from '../heroes-list/hero.model';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css']
})
export class HeroDetailComponent implements OnInit {
  pageTitle = "Info o herosie";
  hero: any = {};
  constructor(
    private activatedRoute:ActivatedRoute, 
    private router:Router,
    private heroService: HeroService) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.pageTitle += `: ${id}`;
    this.heroService.getHero(id).subscribe((hero: Hero) => {
      this.hero = hero;
    })
  }

  onClick(): void{
  this.router.navigate(['/heroes']);
 }
}
