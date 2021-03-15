import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private httpClient: HttpClient) { 

  }
  getMakes(){
    return this.httpClient.get('/api/makes').pipe(map(data=>{return data}));//.subscribe(result=> {return result});
  }
  getFeatures()
  {
    return this.httpClient.get("/api/features").pipe(map(data=>{return data}));
  }
}
