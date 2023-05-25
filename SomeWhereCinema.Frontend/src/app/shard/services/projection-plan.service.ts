import { Injectable } from '@angular/core';
import {HttpService} from "./httpService/http.service";
import {MovieDto} from "../interfaces/movie-dto";
import {ProjectionPlanDto} from "../interfaces/projection-plan-dto";

@Injectable({
  providedIn: 'root'
})
export class ProjectionPlanService {
  private projectionPlanUrl: string = 'https://localhost:7000/api/ProjectionPlan/';

  constructor(private httpService:HttpService) { }

  getAllProjectionPlan(){
    console.log("get all projection plan ...");
    return this.httpService.getAll(this.projectionPlanUrl);
  }

  getProjectionPlanByMovie(planDto: ProjectionPlanDto) {
    console.log("get all projection plan by movie ..");
    console.log("movieID: " + planDto.movieId);
    return this.httpService.get(this.projectionPlanUrl + "ReadProjectionPlanByMovie", planDto);
  }

  getProjectionPlanByDate(movie:MovieDto, date:Date){
    console.log("get projection plan by movie and date");
  }

}
