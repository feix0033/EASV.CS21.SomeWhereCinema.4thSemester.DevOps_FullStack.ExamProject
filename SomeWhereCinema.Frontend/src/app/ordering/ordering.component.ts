import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MovieService} from "../shard/services/movie.service";
import {ProjectionPlanService} from "../shard/services/projection-plan.service";
import {TheatreService} from "../shard/services/theatre.service";
import {ProjectionPlanDto} from "../shard/interfaces/projection-plan-dto";
import {MovieDto} from "../shard/interfaces/movie-dto";

@Component({
  selector: 'app-ordering',
  templateUrl: './ordering.component.html',
  styleUrls: ['./ordering.component.scss']
})
export class OrderingComponent implements OnInit{
  private id:any;
  movie:MovieDto = {id:0};
  sitsNumbers:number[] = [];
  chooseDate = new Date();
  projectionPlan;

  constructor(
    private route:ActivatedRoute,
    private movieService:MovieService,
    private projectionPlanService:ProjectionPlanService,
    private theatreService:TheatreService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(data =>{

      console.log("data: ", data);
      this.id = this.route.snapshot.paramMap.get('id');

      console.log("id: ",this.id);
      this.movieService.getMovieById(this.id)
        .then( m => this.movie = m);

      this.projectionPlanService.getProjectionPlanByMovie({movieId:this.id})
        .then(plist => this.projectionPlan = plist);
    })
  }

  getSitList(p:ProjectionPlanDto) {
    this.sitsNumbers = [];
    this.theatreService.getTheatre(p.theatreId)
      .then(theatre => {
        for (let i = 1; i <= theatre.sitNumber; i++) {
          this.sitsNumbers.push(i);
        }
      })
  }
}
