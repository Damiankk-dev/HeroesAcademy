import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Hero } from '../heroes-list/hero.model';
@Injectable({
  providedIn: 'root'
})
export class HeroService {
  private heroesApi: string = 'https://localhost:7133/api/heroes';
  constructor(private httpClient:HttpClient) {}
  getHeroes() : Observable<Hero[]>{
    return this.httpClient.get<Hero[]>(this.heroesApi);
  }
  
  getHero(id:string | null) : Observable<Hero>{
    return this.httpClient.get<Hero>(this.heroesApi + `/${id}`);
  }

  createHero(hero:Hero):Observable<Hero>{
    const headers = new HttpHeaders({'Content-Type':'application/json'})
    const newHero = {...hero, id:null}
    return this.httpClient.post<Hero>(this.heroesApi, {hero:newHero}, {headers});
  }
}
