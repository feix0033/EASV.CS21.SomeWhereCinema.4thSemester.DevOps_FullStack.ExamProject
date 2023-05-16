import {Injectable} from '@angular/core';
import axios from 'axios';
import {MatSnackBar} from "@angular/material/snack-bar";
import {catchError} from "rxjs";

export  const customAxios = axios.create({
  baseURL: 'http://localhost:7000'
});

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private matSnackbar: MatSnackBar) {
    customAxios.interceptors.response.use(
      response => {
        if(response.status == 201) {
          this.matSnackbar.open("great job")
        }
        return response;
      },
      rejected => {
        if(rejected.response.status >= 400 && rejected.repones.status <500)
        {
          matSnackbar.open(rejected.response.data);
        } else if (rejected.response.status > 499){
          this.matSnackbar.open("something wrong")
        }
        catchError(rejected);
      }
    )
  }

  async getAllMovie() {
    return (await customAxios.get('Movie/GetAllMovie')).data;
  }

  async createMovie(dto: { price: number; name: string }) {
    return (await customAxios.post('Movie/CreateMovie', dto)).data;
  }

  async getMovie(dto: { price:number; name:string }) {
    return (await customAxios.patch('Movie/ReadMovie',dto)).data;
  }

  async updateMovie(dto: {price:number; name: string }) {
    return (await customAxios.put('Movie/UpdateMovie',dto)).data;
  }

  async deleteMovie(dto: {name:string}) {
    return (await customAxios.delete("Movie/"+dto.name)).data;
  }

  async resetDb() {
    return (await customAxios.get("Movie/CreateDatabase")).data;
  }



}
