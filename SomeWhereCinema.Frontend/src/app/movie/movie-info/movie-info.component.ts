import {Component, OnInit} from '@angular/core';
import {MovieService} from "../movie.service";

@Component({
  selector: 'app-movie-info',
  templateUrl: './movie-info.component.html',
  styleUrls: ['./movie-info.component.scss']
})
export class MovieInfoComponent implements OnInit{
  movie: any;
  constructor(private movieService: MovieService) {
  }
  async ngOnInit() {
    this.movie = await this.movieService.getAllMovie();
  }
}
