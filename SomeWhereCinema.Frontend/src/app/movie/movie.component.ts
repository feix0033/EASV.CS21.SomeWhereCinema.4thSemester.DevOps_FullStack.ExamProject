import {Component, OnInit} from '@angular/core';
import {MovieDto} from "../shard/interfaces/movie-dto";
import {MovieService} from "../shard/services/movie.service";

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})

export class MovieComponent implements OnInit{
  movies: MovieDto[] = [];
  movie: MovieDto = {id:3, name:'', releaseDate: new Date(), publishDate: new Date(), offDate:new Date(),price:120};


  constructor(
    private movieService:MovieService) {
  }

  public getAllMoives() {
    this.movieService.getAllMovies().then(m => {
      for (let movie of m) {
        this.movies.push({
          id : movie.id,
          name : movie.name,
          releaseDate : movie.releaseDate,
          publishDate : movie.publishDate,
          offDate : movie.offDate,
          price : movie.price,
          length : movie.length,
        })
      }
    });
  }

  deleteMovie(dto: MovieDto) {
    this.movieService.deleteMovie(dto);
    this.getAllMoives();
  }
  createMovie() {
    this.movieService.createMovie(this.movie);
    this.getAllMoives();
  }
  ngOnInit(): void {
    this.getAllMoives();
  }
}
