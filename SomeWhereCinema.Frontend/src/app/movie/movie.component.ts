import {Component, Input, OnInit} from '@angular/core';
import {MovieDto} from "../dtoes/movie-dto";
import {HttpService} from "../httpService/http.service";
import {OrderingComponent} from "../ordering/ordering.component";

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent {
  movies: MovieDto[] = [];
  newMovie: MovieDto = {name:'',price:120};
  constructor(private httpService:HttpService) {
    this.getAllMoives();
  }
  public async getAllMoives() {
    await this.httpService.getAll('movie/GetAllMovie')
      .then(movie => {
        for (let m of movie) {
          this.movies.push({
            name: m.name,
            price: m.price
          })
        }
      });
  }
  deleteMovie(dto) {
    this.httpService.delete('movie/delete/',dto)
      .then(movie => {
        this.movies = [];
        for (let m of movie) {
          this.movies.push({
            name: m.name,
            price: m.price
          })
        };
      });
  }
  createMovie() {
    this.httpService.create('movie/CreateMovie',this.newMovie)
      .then(movie => {
        for (let m of movie) {
          this.movies.push({
            name: m.name,
            price: m.price
          })
        }
      });
  }
  chooseMovie(m: MovieDto) {

  }

  protected readonly OrderingComponent = OrderingComponent;
}
