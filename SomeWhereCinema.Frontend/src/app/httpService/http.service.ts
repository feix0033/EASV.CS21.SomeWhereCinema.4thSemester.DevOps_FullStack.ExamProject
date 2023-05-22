import {Injectable} from '@angular/core';
import axios from 'axios';
import {MatSnackBar} from "@angular/material/snack-bar";
import {catchError} from "rxjs";

export const customAxios = axios.create({
  baseURL: 'http://127.0.0.1:5001/somewherecinema-76ded/us-central1/api'
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
  async getAll(url) {
    return (await customAxios.get(url)).data;
  }
  async create(url, dto) {
    // return (await customAxios.post('Movie/CreateMovie', dto)).data;
    return (await customAxios.post(url,dto)).data;
  }
  async get(url,dto) {
    // return (await customAxios.patch('Movie/ReadMovie',dto)).data;
    return (await customAxios.patch(url,dto)).data;
  }
  async update(url,dto) {
    // return (await customAxios.put('Movie/UpdateMovie',dto)).data;
    return (await customAxios.put(url,dto)).data;

  }
  async delete(url,dto) {
    return (await customAxios.delete(url,dto)).data;
  }
}
