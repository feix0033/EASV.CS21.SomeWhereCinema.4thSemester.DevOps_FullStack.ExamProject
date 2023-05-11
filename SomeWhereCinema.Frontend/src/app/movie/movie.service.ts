import { Injectable } from '@angular/core';
import {HttpService} from "../httpService/http.service";

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  movie: any;

  constructor(private http:HttpService) { }

  getAllMovie(){
    return this.http.getAllMovie();
  }

  createMovie(dto) {
    return this.http.createMovie(dto);
  }

  deleteMovie(dto){
    return this.http.deleteMovie(dto);
  }

  resetData(){
    this.http.resetDb();
  }
}
