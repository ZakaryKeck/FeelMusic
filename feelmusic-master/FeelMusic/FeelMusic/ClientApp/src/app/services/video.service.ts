import { Injectable, Inject } from '@angular/core';
import * as core from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class VideoService {
  myAppUrl: string = "";

  constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getVideoList() {
    return this._http.get(this.myAppUrl + 'api/video/index')
      .map(res => res.json())
      .catch(this.errorHandler);
  }

  getVideoById(id: number) {
    return this._http.get(this.myAppUrl + "api/video/details/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}  
