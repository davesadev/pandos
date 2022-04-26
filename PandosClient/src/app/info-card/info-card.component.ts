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
  // @Input() linkForRouter: string | undefined;

// assets\images\Pandos_github_banner.png
  constructor() { }

  ngOnInit(): void {
  }

}
