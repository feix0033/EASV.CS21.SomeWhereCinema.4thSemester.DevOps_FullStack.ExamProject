import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-movie-manage',
  templateUrl: './movie-manage.component.html',
  styleUrls: ['./movie-manage.component.scss']
})
export class MovieManageComponent implements OnInit{
  movieName: string = "";
  moviePrice: number = 1;
  movie: any;


  constructor() {
  }


  async ngOnInit() {
  }

  // async createMovie() {
  //   let dto = {
  //     name: this.movieName,
  //     price: this.moviePrice,
  //   }
  //   const result = await this.movieService.createMovie(dto);
  //   this.movie.push(result);
  // }
  //
  // async deleteMovie(dto){
  //   const result =  await this.movieService.deleteMovie(dto);
  //   this.movie = this.movie.filter( m => m.id != result.id)
  // }
  //
  // async resetData(){
  //   await this.movieService.resetData();
  // }
}
