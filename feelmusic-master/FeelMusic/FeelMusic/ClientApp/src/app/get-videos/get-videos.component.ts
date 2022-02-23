import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { VideoService } from '../services/video.service';

@Component({
  templateUrl: './get-videos.component.html'
})

export class GetVideosComponent {
  public videoList: VideoData[];

  constructor(public http: Http, private _router: Router, private _videoService: VideoService) {
    this.getVideos();
  }

  getVideos() {
    this._videoService.getVideoList().subscribe(
      data => this.videoList = data
    )
  }

  ngOnInit() {
  }
 
}

interface VideoData {
  title: string;
  videoUrl: string;
}  
