import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-fetch-protein-data',
  templateUrl: './fetch-consensus-uniprot.component.html',
  // styleUrls: ['./fetch-protein-data.component.css']
})
export class FetchConsensusUniprotComponent implements OnInit {

  message = "";

  onClicked(event: any) {
    console.log(event);
    this.message = event;
  }

  searchText = "";
  public uniprots: Uniprot[] = [];
  // public searchText: Uniprot[] = [];
  // double check this

  // /api/Uniprots/{id}

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

///////////////////////////////////////////////////////
//////////////////////  test  /////////////////////////
///////////////////////////////////////////////////////

  // readonly ROOT_URL='https://localhost:7165/api';
  // uniprots:Observable<any>;
  // newUniprots:Observable<any>;

  // getUniprots() {
  //   let params = new HttpParams().set('uniprotID', '1');
  // }

}

interface Uniprot {
  uniprotId: string;
  accessionNumber: string;
  entryStatus : string;
  sequence: string;
}
