import { Component, ViewChild, ElementRef, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit{
  @ViewChild('canvasEl') canvasEl!: ElementRef;
  title = 'SortPixels';
  private context!: CanvasRenderingContext2D;
  ngAfterViewInit() {    
    this.draw();
  }
  setRandomColor(){
    var imgData = this.context.getImageData(0, 100, 420, 420);
    this.context.putImageData(this.getRandomData(imgData), 0, 100);
  }
  sortPixels(){
    var imgData = this.context.getImageData(0, 100, 420, 420);
    this.context.putImageData(this.sortData(imgData), 0, 100);
  }
  sortData(imgData : ImageData){
    for(var n=0; n<imgData.data.length; n+=4)
    {
      for(var i =0; i<imgData.data.length-n-4; i+=4)
      {
        var curRed = imgData.data[i];
        var curGreen = imgData.data[i+1];
        var curBlue = imgData.data[i+2];
        var curBright = (curRed + curGreen + curBlue) / 3;

        var nextRed = imgData.data[i+4];
        var nextGreen = imgData.data[i+5];
        var nextBlue = imgData.data[i+6];
        var nextBright = (nextRed + nextGreen + nextBlue) / 3;

        if(curBright < nextBright)
        {
          imgData.data[i] = nextRed;
          imgData.data[i+1] = nextGreen;
          imgData.data[i+2] = nextBlue;
          imgData.data[i+4] = curRed;
          imgData.data[i+5] = curGreen;
          imgData.data[i+6] = curBlue;
        }
      }
    }
    return imgData;
  }
  getContext() :CanvasRenderingContext2D {
    this.context = (
      this.canvasEl.nativeElement as HTMLCanvasElement
    ).getContext("2d") as CanvasRenderingContext2D;
    return this.context;
  }
  getRandomData(imgData: ImageData){
    for (var i = 0; i < imgData.data.length; i += 4) {
      imgData.data[i] = this.randomInt(0, 255); // red
      imgData.data[i+1] = this.randomInt(0, 255); // green
      imgData.data[i+2] = this.randomInt(0, 255); // blue
      imgData.data[i+3] = 255; // alpha
    }
    return imgData;
  }
  randomInt(min: number, max: number) : number{
    return Math.floor(Math.random() * (max-min+1)) + min;
  }
  private draw() {
    this.context = this.getContext();
    this.context.fillStyle = 'lightgrey';
    this.context.fillRect(0, 100, 600, 600);
  }
}
