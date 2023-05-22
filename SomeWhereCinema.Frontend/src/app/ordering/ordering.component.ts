import {Component, Input} from '@angular/core';
import {MovieDto} from "../dtoes/movie-dto";

@Component({
  selector: 'app-ordering',
  templateUrl: './ordering.component.html',
  styleUrls: ['./ordering.component.scss']
})
export class OrderingComponent {
  @Input() choosenMovie:MovieDto = {name: "", price: 0};
  constructor() {
  }
}
