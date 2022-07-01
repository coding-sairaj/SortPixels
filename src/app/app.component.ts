import { Component, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { SortService } from './services/sort.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit{
  constructor(private service:SortService){}
  @ViewChild('canvasEl') canvasEl!: ElementRef;
  private context!: CanvasRenderingContext2D;
  ngAfterViewInit() {    
    this.draw();
  }
  sortPixelsInService(){
    var imgData = this.context.getImageData(0, 100, 420, 420);
    this.service.sortPixels(Array.from(imgData.data)).subscribe(result => {
      for(var i=0; i<imgData.data.length;i++)
      {
        imgData.data[i] = result[i];
      }
      this.context.putImageData(imgData, 0, 100);
    });
  }
  getRandomPixels(){
    var imgData = this.context.getImageData(0, 100, 420, 420);
    this.service.getRandomPixels(Array.from(imgData.data)).subscribe(result => {
      for(var i=0; i<imgData.data.length;i++)
      {
        imgData.data[i] = result[i];
      }
      this.context.putImageData(imgData, 0, 100);
    });
  }

  getContext() :CanvasRenderingContext2D {
    this.context = (
      this.canvasEl.nativeElement as HTMLCanvasElement
    ).getContext("2d") as CanvasRenderingContext2D;
    return this.context;
  }
  private draw() {
    this.context = this.getContext();
    this.context.fillStyle = 'lightgrey';
    this.context.fillRect(0, 100, 600, 600);
  }
}
