// import { Component, OnInit } from '@angular/core';
// import { SearchComponent } from '@appbaseio/searchbase';
// import { ElasticSearchComponent } from '../elastic-search/elastic-search.component';

// @Component({
//   selector: 'app-search-controller',
//   templateUrl: './search-controller.component.html',
//   styleUrls: ['./search-controller.component.css']
// })
// export class SearchControllerComponent implements OnInit {

//   searchComponent: SearchComponent;
//   constructor() {
//     // experimental


//   // Register search component => To render the auto-suggestions
//     this.searchComponent = this.searchBase.register('search-component', {
//       dataField: [
//         {
//           field: 'description',
//           weight: 1
//         },
//         {
//           field: 'description.keyword',
//           weight: 1
//         },
//         {
//           field: 'description.search',
//           weight: 0.1
//         },
//         {
//           field: 'language',
//           weight: 2
//         },
//         {
//           field: 'language.keyword',
//           weight: 2
//         },
//         {
//           field: 'language.search',
//           weight: 0.2
//         },
//         {
//           field: 'name',
//           weight: 5
//         },
//         {
//           field: 'name.keyword',
//           weight: 5
//         },
//         {
//           field: 'name.search',
//           weight: 0.5
//         },
//         {
//           field: 'owner',
//           weight: 1
//         },
//         {
//           field: 'owner.keyword',
//           weight: 1
//         },
//         {
//           field: 'owner.search',
//           weight: 0.1
//         }
//       ],
//       // Source filtering to improve search latency
//       includeFields: [
//         'name', 'description', 'owner', 'fullname', 'language', 'topics'
//       ],
//       size: 5,
//       // To clear the filter values when search query gets changed
//       clearFiltersOnQueryChange: true,
//     });
// }
// ngOnInit(): void {
// }

// }
