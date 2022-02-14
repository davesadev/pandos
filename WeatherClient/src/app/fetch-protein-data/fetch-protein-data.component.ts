import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-protein-data',
  templateUrl: './fetch-protein-data.component.html',
  styleUrls: ['./fetch-protein-data.component.css']
})
export class FetchProteinDataComponent implements OnInit {
  public pdbs: Pdb[] = [];

  constructor(http: HttpClient, ) {
    let token = localStorage.getItem("jwt");
    console.log("this should be the jwt: ${token}"); // debugging
    http.get<Pdb[]>('https://localhost:7165/Pdbs', { // TODO: what is this value?
      headers: {
        "Authorization": `Bearer ${token}`
      }
    }).subscribe(result => {
      this.pdbs = result;
    }, error => console.error(error)); 
   }

  ngOnInit(): void {
  }

}

interface Pdb {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}