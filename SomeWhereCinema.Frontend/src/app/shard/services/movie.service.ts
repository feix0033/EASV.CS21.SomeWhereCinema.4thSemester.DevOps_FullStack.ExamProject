import { Injectable } from '@angular/core';
import {MovieDto} from "../interfaces/movie-dto";
import {HttpService} from "./httpService/http.service";

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private httpService:HttpService) {
  }

  public async getAllMovies():Promise<MovieDto[]> {
    console.log("get all moive info ...");
    return await this.httpService.getAll('https://localhost:7000/Movie/GetAllMovie');
  }

  deleteMovie(m: MovieDto) {
    console.log("delete movie ", m.id);
    // this.httpService.delete('movie/delete/',dto)
    //   .then(movie => {
    //     this.movies = [];
    //     for (let m of movie) {
    //       this.movies.push({
    //         name: m.name,
    //         price: m.price
    //       })
    //     };
    //   });
  }

  createMovie(m:MovieDto) {
    // console.log("create movie ", m.name);
    // this.movies.push(m);
    // console.log("all movies : ", this.movies);
    // this.getAllMovies();

    // this.httpService.create('movie/CreateMovie',this.newMovie)
    //   .then(movie => {
    //     for (let m of movie) {
    //       this.movies.push({
    //         name: m.name,
    //         price: m.price
    //       })
    //     }
    //   });
  }

  async getMovieById(id: any) {
    console.log("get movie by id : ",id);
    return await this.httpService.get('https://localhost:7000/Movie/ReadMovie', {id: id});
  }
}
