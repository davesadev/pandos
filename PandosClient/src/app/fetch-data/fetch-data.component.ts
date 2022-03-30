import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    // url = "http://localhost:7165/";
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient, ) {
    // http.get<WeatherForecast[]>('${this.url}/WeatherForecast').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
  

////////////////////////////////////////


    let token = localStorage.getItem("jwt");
    console.log("this should be the jwt: ${token}"); // debugging
    http.get<WeatherForecast[]>('https://localhost:7165/WeatherForecast', {
      headers: {
        "Authorization": `Bearer ${token}`
      }
    }).subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

    // http.get<WeatherForecast[]>('https://localhost:7165/WeatherForecast').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
     }
  }



interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
