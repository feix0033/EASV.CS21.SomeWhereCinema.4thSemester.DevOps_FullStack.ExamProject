import {Component, OnInit} from '@angular/core';
import {HttpService} from "../../httpService/http.service";
import {MovieService} from "../movie.service";

@Component({
  selector: 'app-movie-manage',
  templateUrl: './movie-manage.component.html',
  styleUrls: ['./movie-manage.component.scss']
})
export class MovieManageComponent implements OnInit{
  movieName: string = "";
  moviePrice: number = 1;
  movie: any;


  constructor(private movieService:MovieService) {
  }


  async ngOnInit() {
    this.movie = await this.movieService.getAllMovie();
  }

  async createMovie() {
    let dto = {
      name: this.movieName,
      price: this.moviePrice,
    }
    const result = await this.movieService.createMovie(dto);
    this.movie.push(result);
  }

  async deleteMovie(dto){
    const result =  await this.movieService.deleteMovie(dto);
    this.movie = this.movie.filter( m => m.id != result.id)
  }

  async resetData(){
    await this.movieService.resetData();
  }
}
