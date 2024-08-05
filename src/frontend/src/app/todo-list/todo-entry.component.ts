import { Component } from '@angular/core';

@Component({
    selector: 'app-todo-entry',
    standalone: true,
    imports: [],
    template: `
        <form>
      <label class="form-control w-full max-w-xs">
        <div class="label">
          <span class="label-text">What do you need to do?</span>
        
        </div>
        <input
          type="text"
          placeholder="Buy Beer"
          class="input input-bordered w-full max-w-xs"
        />
        
      </label>
    </form>
    `,
    styles: ``
})
export class TodoEntryComponent {

}