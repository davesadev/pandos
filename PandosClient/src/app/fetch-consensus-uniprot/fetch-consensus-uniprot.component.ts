import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FetchDataService } from '../fetch-data.service'


@Component({
  selector: 'fetch-consensus-uniprot',
  templateUrl: './fetch-consensus-uniprot.component.html',
  styleUrls: ['./fetch-consensus-uniprot.component.html']
})
export class FetchConsensusUniprotComponent implements OnInit {

  checked = false;
  indeterminate = false;
  labelPosition: 'before' | 'after' = 'after';
  disabled = false;

  primarySearch = undefined;

  corr_uniprots = false;
  corr_pdbs= false;
  corr_pdb_chains = false;

  singleObjectResult = false; // todo: have this be a factor later when displaying single data point or array

  uniprotID = "";
  searchText = "";
  constructor(http: HttpClient, private fetchDataService: FetchDataService) {
    // let token = localStorage.getItem("jwt");
    // console.log("this should be the jwt: ${token}"); // debugging
    // http.get<Uniprot[]>('https://localhost:7165/api/Uniprots', {
    //   headers: {
    //     "Authorization": `Bearer ${token}`
    //   }
    // }).subscribe(result => {
    //   this.uniprots= result;
    // }, error => console.error(error));
   }

// new attempt
   public uniprots: Uniprot[] = [];
   public uniprot: Uniprot | undefined;


   callGetService(id: string) {
    // debugging
    console.log("the uniprot id sent is: " + id);

    this.fetchDataService.getUniprotsById(id).subscribe(data => {  // todo: is this ever called? or just ngOnInit?
      this.uniprots = data;
    // this.fetchDataService.sendGetReqWithParams(id).subscribe(data => {  // todo: is this ever called? or just ngOnInit?
      // this.uniprot = data;
      console.log(this.uniprots);  // debugging
    })
  }

  // TODO: hard coded service fetches uniprots by id -- need to figure out how to send id using button and text box
  ngOnInit(): void {
    // this.fetchDataService.getUniprotsById('P07550').subscribe(data => {
    //   this.uniprots = data;
    // })
  }
}

interface Uniprot {
  uniprotId: string;
  accessionNumber: string;
  entryStatus : string;
  sequence: string;
}
