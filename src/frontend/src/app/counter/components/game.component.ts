import { Component, inject } from '@angular/core';
import { ResetComponent } from './reset.component';
import { CounterStore } from '../../services/counter.store';

@Component({
  standalone: true,
  imports: [ResetComponent],
  template: `
    <div>
      <button (click)="store.decrement()" class="btn btn-warning">-</button>
      <span class="text-2xl">{{ store.current() }}</span>
      <button (click)="store.increment()" class="btn btn-primary">+</button>
      <app-counter-reset />
    </div>
  `,
  styles: ``,
})
export class GameComponent {
  store = inject(CounterStore);
}
