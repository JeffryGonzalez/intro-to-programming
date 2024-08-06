import { Component, inject } from '@angular/core';
import { CounterStore } from '../../services/counter.store';

@Component({
    selector: 'app-counter-reset',
    standalone: true,
    imports: [],
    template: `
         <div>
        <button [disabled]="store.resetShouldBeDisabled()" (click)="store.reset()" class="btn btn-accent">Reset</button>
      </div>
    `,
    styles: ``
})
export class ResetComponent {
    store = inject(CounterStore);
}