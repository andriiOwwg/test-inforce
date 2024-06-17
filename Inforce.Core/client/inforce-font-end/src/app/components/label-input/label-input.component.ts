import { NgClass } from '@angular/common';
import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-label-input',
  standalone: true,
  imports: [NgClass, ReactiveFormsModule],
  templateUrl: `./label-input.component.html`,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LabelInputComponent {
  @Input() classListWrapper: string = '';

  @Input() labelText: string = '';
  @Input() for: string = '';
  @Input() classList: string = '';

  @Input() controlName: string = '';
  @Input() type: string = 'text';
  @Input() classListInput: string = '';

  @Input() formGroup!: FormGroup;

  get formControl(): FormControl {
    return this.formGroup.controls[this.controlName] as FormControl;
  }
}
