import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(credientials: string) {
    let headers = new HttpHeaders()
      .set("Content-Type", "application/json");
    let token = localStorage.getItem("jwt");
    if (!!token) {
      headers.set("Authorization", `Bearer ${token}`);
    }
    return this.http.post('https://localhost:7165/api/Auth/login', credientials, {
    headers: headers
    });
  }

  // login(credientials: string) {
  //   return this.http.post('https://localhost:7165/api/Auth/login', credientials, {
  //     headers: new HttpHeaders({
  //       "Content-Type": "application/json"
  //     })
  //   });
}
