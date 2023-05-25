import { Injectable } from '@angular/core';
import {HttpService} from "./httpService/http.service";
import {TheatreDto} from "../interfaces/theatre-dto";

@Injectable({
  providedIn: 'root'
})
export class TheatreService {
  theatreUrl = 'https://localhost:7000/api/Theatre/';
  constructor(private httpService:HttpService) { }

  getTheatre(id: number | undefined) {
    console.log("start to get theatre by id ...");
    return this.httpService.get(this.theatreUrl + 'ReadTheatre', {id:id});
  }
}
