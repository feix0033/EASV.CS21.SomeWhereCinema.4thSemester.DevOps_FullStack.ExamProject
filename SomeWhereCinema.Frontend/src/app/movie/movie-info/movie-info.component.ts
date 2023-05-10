import {Component, OnInit} from '@angular/core';
import {HttpService} from "../../httpService/http.service";

@Component({
  selector: 'app-movie-info',
  templateUrl: './movie-info.component.html',
  styleUrls: ['./movie-info.component.scss']
})
export class MovieInfoComponent implements OnInit{


  constructor(private http:HttpService) {
  }


  async ngOnInit() {
    const movie = await this.http.getMovie();
    console.log(movie);
  }
}
