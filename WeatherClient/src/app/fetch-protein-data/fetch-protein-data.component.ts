import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-protein-data',
  templateUrl: './fetch-protein-data.component.html',
  styleUrls: ['./fetch-protein-data.component.css']
})
export class FetchProteinDataComponent implements OnInit {

  message = "";

  onClicked(event: any) {
    console.log(event);
    this.message = event;
  }


  public uniprots: Uniprot[] = [];

  constructor(http: HttpClient, ) {
    let token = localStorage.getItem("jwt");
    console.log("this should be the jwt: ${token}"); // debugging
    http.get<Uniprot[]>('https://localhost:7165/api/Uniprots', { // TODO: what is this value?
      headers: {
        "Authorization": `Bearer ${token}`
      }
    }).subscribe(result => {
      this.uniprots= result;
    }, error => console.error(error)); 
   }

  ngOnInit(): void {
  }

}

interface Uniprot {
  uniprotId: string;
  accessionNumber: string;
  entryStatus : string;
  sequence: string;
}