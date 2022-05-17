import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FetchDataService } from '../fetch-data.service'


@Component({
  selector: 'fetch-consensus-uniprot',
  templateUrl: './fetch-consensus-uniprot.component.html',
  styleUrls: ['./fetch-consensus-uniprot.component.html']
})
export class FetchConsensusUniprotComponent implements OnInit {
  primarySearch: string | undefined;
  uniprotID = "";
  pdbID = "";
  querying: Boolean = false;



  constructor(http: HttpClient, private fetchDataService: FetchDataService) { }
  ngOnInit(): void {
  }

  public uniprots: Uniprot[] = [];
  public pdbs: Pdb[] = [];



  // GET UNIPROT function -- returns array of uniprot objects
  // sets this.querying before and after query for loading bar
  callServiceGetUniprots(id?: string) {
    this.querying = true;
    this.fetchDataService.getUniprotsById(id).subscribe(data => {
         // if no id passed, don't cast return array to array -- typescript evaluates "" to false -- ignore ts because linter misinterpreting context
      if (!id) { // @ts-ignore
        this.uniprots = data;
      }  // else: looking for specific id, cast result to array for front end parsing
      else {
        this.uniprots = [data];
      }
      console.log(this.uniprots);  // debugging
      this.querying = false;  
    })
  }

  // GET PDB call -- returns array of pdb objects
  // sets this.querying before and after query for loading bar
  callServiceGetPdb(id?: string) {
    this.querying = true;
    this.fetchDataService.getPdbsById(id).subscribe(data => {
      // if no id passed, don't cast return array to array -- typescript evaluates "" to false -- ignore ts because linter misinterpreting context
      if (!id) { // @ts-ignore
        this.pdbs = data;
      }  // else: looking for specific id, cast result to array for front end parsing
      else {
        this.pdbs = [data];
      }
      console.log(this.pdbs);  // debugging
      
      this.querying = false;      
    })
  }

}

interface Uniprot {
  uniprotId: string;
  accessionNumber: string;
  entryStatus : string;
  sequence: string;
}

interface Pdb {
  pdbId: string;
  uniprotId : string;
  uniprot: string;
  pdbChains: string;
}
