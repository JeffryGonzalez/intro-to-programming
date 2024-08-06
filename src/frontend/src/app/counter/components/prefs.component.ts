import { Component, inject } from '@angular/core';
import { CounterStore } from '../../services/counter.store';

@Component({
  standalone: true,
  imports: [],
  template: ` <div class="join">
    <button
      (click)="store.setCountBy(1)"
      [disabled]="store.by() === 1"
      class="btn join-item"
    >
      Count By 1
    </button>
    <button
      (click)="store.setCountBy(3)"
      [disabled]="store.by() === 3"
      class="btn join-item"
    >
      Count By 3
    </button>
    <button
      (click)="store.setCountBy(5)"
      [disabled]="store.by() === 5"
      class="btn join-item"
    >
      Count By 5
    </button>
  </div>`,
  styles: ``,
})
export class PrefsComponent {
  store = inject(CounterStore);
}
