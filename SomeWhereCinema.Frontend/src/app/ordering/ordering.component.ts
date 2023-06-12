import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MovieService} from "../shard/services/movie.service";
import {ProjectionPlanService} from "../shard/services/projection-plan.service";
import {TheatreService} from "../shard/services/theatre.service";
import {ProjectionPlanDto} from "../shard/interfaces/projection-plan-dto";
import {MovieDto} from "../shard/interfaces/movie-dto";
import {OrderDto} from "../shard/interfaces/order-dto";
import {FirebaseAuthService} from "../shard/services/firebaseService/firebase-auth.service";
import {HttpService} from "../shard/services/httpService/http.service";

@Component({
  selector: 'app-ordering',
  templateUrl: './ordering.component.html',
  styleUrls: ['./ordering.component.scss']
})
export class OrderingComponent implements OnInit{
  private id:any;
  movie:MovieDto = {id:0};
  sitsNumbers:number[] = [];

  projectionPlans: ProjectionPlanDto[] = [{}]
  projectionPlan:ProjectionPlanDto = {
    movieId:0,
    theatreId:0
  };

  order:OrderDto = {
    orderId:0,
    projectionPlanId:0,
    userId:0,
    sitNumber:0
  }

  constructor(
    private route:ActivatedRoute,
    private movieService:MovieService,
    private projectionPlanService:ProjectionPlanService,
    private theatreService:TheatreService,
    private firebaseAuthService: FirebaseAuthService,
    private httpService:HttpService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(data =>{
      this.id = this.route.snapshot.paramMap.get('id');
      this.movieService.getMovieById(this.id)
        .then( m => {
          this.movie = m;
          console.log(this.movie);
        });
      this.getProjectionPlanbyMovie(this.id);
    })
  }

  getProjectionPlanbyMovie(id){
    this.projectionPlanService.getProjectionPlanByMovie({movieId:id})
      .then(plist => this.projectionPlans = plist);
  }

  getSitList(p:ProjectionPlanDto) {
    this.sitsNumbers = [];
    this.theatreService.getTheatre(p.theatreId)
      .then(theatre => {
        for (let i = 1; i <= theatre.sitNumber; i++) {
          this.sitsNumbers.push(i);
        }
      })
    this.projectionPlan = p;
  }

  setOrder(s:number) {
    this.order = {
      orderId:this.projectionPlan.id + this.firebaseAuthService.auth.currentUser.uid + s,
      projectionPlanId: this.projectionPlan.id,
      userId: this.firebaseAuthService.auth.currentUser.uid,
      sitNumber: s
    }
    console.log(this.order);
    alert("You have been choose :" + this.order.projectionPlanId + '   ' + this.order.sitNumber);
    this.httpService.create('http://127.0.0.1:5001/somewherecinema-76ded/us-central1/api/order/creatOrder',this.order);
  }
}
