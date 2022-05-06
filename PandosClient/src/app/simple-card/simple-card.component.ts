import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-simple-card',
  templateUrl: './simple-card.component.html',
  styleUrls: ['./simple-card.component.css']
})
export class SimpleCardComponent implements OnInit {

  @Input() cardTitle: string | undefined;
  @Input() body: string | undefined;
// @Input() imagePath: string | undefined;
// @Input() imageAltText: string | undefined;

  constructor() { }

  ngOnInit(): void {

  }

}
