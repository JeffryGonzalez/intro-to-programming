import { Component, inject } from '@angular/core';
import { CounterStore } from '../services/counter.store';

@Component({
  standalone: true,
  imports: [],
  
  template: `
    <div>
 
      <button (click)="store.decrement()" class="btn btn-warning">-</button>
      <span class="text-2xl">{{ store.current()}}</span>
      <button (click)="store.increment()" class="btn btn-primary">+</button>
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
   store = inject(CounterStore);
    
}
