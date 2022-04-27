import { Component, OnInit } from '@angular/core';

import { SearchBase } from '@appbaseio/searchbase';

@Component({
  selector: 'app-elastic-search',
  templateUrl: './elastic-search.component.html',
  styleUrls: ['./elastic-search.component.css']
})
export class ElasticSearchComponent implements OnInit {
  index = 'gitxplore-app';
  url = 'https://appbase-demo-ansible-abxiydt-arc.searchbase.io';
  credentials = 'a03a1cb71321:75b6603d-9456-4a5a-af6b-a487b309eb61';

  searchBase: SearchBase | undefined; // SearchBase class from @appbaseio/searchbase package

  constructor() {
    // create searchbase instance
    this.searchBase = new SearchBase({
      index: this.index,
      url: this.url,
      credentials: this.credentials
    });



  }

  ngOnInit(): void {
  }

}
