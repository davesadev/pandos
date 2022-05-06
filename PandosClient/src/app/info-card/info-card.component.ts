import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-info-card',
  templateUrl: './info-card.component.html',
  styleUrls: ['./info-card.component.css']
})
export class InfoCardComponent implements OnInit {
  @Input() cardTitle: string | undefined;
  @Input() body: string | undefined;
  @Input() imagePath: string | undefined;
  @Input() imageAltText: string | undefined;
  // @Input() linkForRouter: string | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
