import { Component, output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo-entry',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <form [formGroup]="form" (ngSubmit)="addIt()" >
      <label class="form-control w-full max-w-xs">
        <div class="label">
          <span class="label-text">What do you need to do?</span>
        </div>
        <input
        formControlName="description"
          type="text"
          placeholder="Enter your item here"
          class="input input-bordered w-full max-w-xs"
        />
      </label>
      <button type="submit" class="btn btn-primary">Add To List</button>
    </form>
  `,
  styles: ``,
})
export class TodoEntryComponent {
 itemAdded = output<string>();
  form = new FormGroup({
    description: new FormControl<string>('', { 
      nonNullable: true
    })
  })

  addIt() {
    console.log(this.form.value);
    this.itemAdded.emit(this.form.controls.description.value);
    this.form.reset();
  }

}
