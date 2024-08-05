import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import {toSignal} from '@angular/core/rxjs-interop'
type SoftwareItem = { id: string, title: string}
@Component({
  standalone: true,
  selector: 'app-new-issue',
  template: `
    <select class="select select-bordered w-full max-w-xs">
      <option disabled selected>
        What Software Are You Having Problems With
      </option>
      @for(item of software(); track item.id) {
         <option>{{item.title}}</option>
      }
    </select>
  `,
})
export class NewIssueComponent {

     #client = inject(HttpClient);

     
    software = toSignal(this.#client.get<SoftwareItem[]>("http://localhost:1337/api/software"));
}
