// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-input-error-state-matcher',
//   templateUrl: './input-error-state-matcher.component.html',
//   styleUrls: ['./input-error-state-matcher.component.css']
// })
// export class InputErrorStateMatcherComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }


// import { MatInputModule } from '@angular/material/input';
import {Component} from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

/** @title Input with a custom ErrorStateMatcher */
@Component({
  selector: 'input-error-state-matcher',
  templateUrl: './input-error-state-matcher.component.html',
  styleUrls: ['./input-error-state-matcher.component.css'],
})
export class InputErrorStateMatcherComponent {
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  matcher = new MyErrorStateMatcher();
}
