import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class FetchDataService {

  constructor(private httpClient: HttpClient) { }

  getUniprotsById(id: string): Observable<Uniprot[]> {
    // const baseUrl: string = 'https://localhost:7165/api/Uniprots/';
    const baseUrl: string = 'https://pandos1.azurewebsites.net/api/uniprots/';

    return this.httpClient.get<Uniprot[]>(baseUrl + id);

    let token = localStorage.getItem("jwt");
    console.log("this should be the jwt: " + token); // debugging
    // http.get<Uniprot[]>('https://localhost:7165/api/Uniprots', { // TODO: what is this value?
    //   headers: {
    //     "Authorization": `Bearer ${token}`
    //   }
    // }).subscribe(result => {
    //   this.uniprots= result;
    // }, error => console.error(error));

    console.log(baseUrl + id);
    // return this.httpClient.get<Uniprot[]>(baseUrl + id);
  }



























  getUniprots() {
    return this.httpClient.get('https://localhost:7165/Uniprots/');
  }

  getSingleUniprot(id: string): Observable<Uniprot> {
    console.log("The value of id is: " + id);
    const baseUrl = 'https://localhost:7165/api/Uniprots/';
    return this.httpClient.get<Uniprot>(baseUrl + id);
  }


  public sendGetReqWithParams(id: string) {
    let idnew: string = id;
    const baseURL = 'https://localhost:7165/api/Uniprots/';
    //              'https://localhost:7165/api/Uniprots/P07550'
    // let params = new HttpParams()
    //   .set('id', id);
    // console.log("id is " + idnew + " aka " + idnew.toString());
    console.log(baseURL + id);
    return this.httpClient.get<Uniprot>(baseURL + idnew);
  }


}
interface Uniprot {
  uniprotId: string;
  accessionNumber: string;
  entryStatus : string;
  sequence: string;
}
