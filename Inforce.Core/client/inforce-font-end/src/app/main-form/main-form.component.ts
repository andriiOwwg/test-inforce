import {Component, Input, OnInit} from '@angular/core';
import {NgClass} from "@angular/common";

@Component({
  selector: 'app-main-form',
  standalone: true,
  imports: [
    NgClass
  ],
  templateUrl: './main-form.component.html',
  styleUrl: './main-form.component.scss'
})
export class MainFormComponent implements OnInit{
  @Input() labelText: string = '';
  @Input() for: string = '';
  @Input() classList: string = '';

  ngOnInit() {

    console.log(this.labelText);
    console.log(this.for);
    console.log(this.classList);

  }
}
