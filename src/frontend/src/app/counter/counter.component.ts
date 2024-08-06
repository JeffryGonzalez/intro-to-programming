import { Component, inject } from '@angular/core';
import { CounterService } from '../services/counter.service';

@Component({
  standalone: true,
  imports: [],
  template: `
    <div>
      <button (click)="counterService.decrement()" class="btn btn-warning">-</button>
      <span class="text-2xl">{{ current()}}</span>
      <button (click)="counterService.increment()" class="btn btn-primary">+</button>
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
    counterService = inject(CounterService);
    current = this.counterService.getCurrent();
}
