import {ChangeDetectionStrategy, Component, Input, OnInit, Output} from '@angular/core';
import {NgClass} from "@angular/common";
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";

@Component({
  selector: 'app-main-form',
  standalone: true,
  imports: [
    NgClass,
    ReactiveFormsModule
  ],
  templateUrl: './main-form.component.html',
  styleUrl: './main-form.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MainFormComponent implements OnInit{
  @Input() label: string = '';
  @Input() type: string = 'text';
  @Input() controlName: string = '';
  @Input() formGroup!: FormGroup;

  get formControl(): FormControl {
    return this.formGroup.controls[this.controlName] as FormControl;
  }

  ngOnInit() {

    console.log(this.label);
    console.log(this.controlName);
  }
}
