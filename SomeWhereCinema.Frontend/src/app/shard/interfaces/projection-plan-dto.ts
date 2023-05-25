import {MovieDto} from "./movie-dto";
import {Time} from "@angular/common";
import {TheatreDto} from "./theatre-dto";

export interface ProjectionPlanDto {
  id?:number,
  movieId?: number,
  theatreId?: number,
  startTime?: Date
}
