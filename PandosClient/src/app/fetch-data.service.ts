import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class FetchDataService {

  constructor(private httpClient: HttpClient) { }

  getPdbsById(id?: string): Observable<Pdb> {
    const baseUrl: string = 'https://pandos1.azurewebsites.net/api/pdbs/';
    return this.httpClient.get<Pdb>(baseUrl + id);
  }

  getUniprotsById(id?: string): Observable<Uniprot> {
    const baseUrl: string = 'https://pandos1.azurewebsites.net/api/uniprots/';
    return this.httpClient.get<Uniprot>(baseUrl + id);
  }

}
interface Uniprot {
  uniprotId: string;
  accessionNumber: string;
  entryStatus : string;
  sequence: string;
}

// todo -- verify correct
interface Pdb {
  pdbId: string;
  uniprotId : string;
  uniprot: string;
  pdbChains: string;
}

// if using authentication, use parameters of get method below (with tweaking)

/*
*  getUniprotsById(id?: string): Observable<Uniprot> {
    const baseUrl: string = 'https://pandos1.azurewebsites.net/api/uniprots/';
    return this.httpClient.get<Uniprot>(baseUrl + id);
    /*
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

 */
