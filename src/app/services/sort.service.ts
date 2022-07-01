import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable()
export class SortService
{
    private readonly _http: HttpClient;
    private basePath = 'https://localhost:7081/sorting';
    constructor(http: HttpClient) {
        this._http = http;
    }
    public sortPixels(pixels: number[]): Observable<any>{        
        return this._http.post(this.basePath + '/sortpixels', pixels);
    }
    public getRandomPixels(pixels:number[]):Observable<any>{
        return this._http.post(this.basePath + '/randompixels', pixels);        
    }
}