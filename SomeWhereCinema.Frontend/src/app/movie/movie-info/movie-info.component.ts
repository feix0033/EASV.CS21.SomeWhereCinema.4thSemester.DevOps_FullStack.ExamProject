import {Component, OnInit} from '@angular/core';
import {HttpService} from "../../httpService/http.service";

@Component({
  selector: 'app-movie-info',
  templateUrl: './movie-info.component.html',
  styleUrls: ['./movie-info.component.scss']
})
export class MovieInfoComponent implements OnInit{
  movieName: string = "";
  moviePrice: number = 1;
  movie: any;


  constructor(private http:HttpService) {
  }


  async ngOnInit() {
    this.movie = await this.http.getAllMovie();
  }

  async createMovie() {
    let dto = {
      name: this.movieName,
      price: this.moviePrice,
    }
    const result = await this.http.createMovie(dto);
    this.movie.push(result);
  }

  async deleteMovie(dto){
    const result =  await this.http.deleteMovie(dto);
    this.movie = this.movie.filter( m => m.id != result.id)
  }

  async resetData(){
    await this.http.resetDb();
  }
}
