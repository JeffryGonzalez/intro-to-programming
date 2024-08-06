import { Component, inject } from '@angular/core';
import { CounterStore } from '../services/counter.store';
import { ResetComponent } from './components/reset.component';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  standalone: true,
  imports: [ResetComponent, RouterOutlet, RouterLink, RouterLinkActive],

  template: `
    <router-outlet />

    <div class="pt-12">
      <a
        routerLink="prefs"
        class="btn btn-primary"
        [routerLinkActive]="['btn-active']"
        >Set Prefs</a
      >
      <a
        routerLink="game"
        class="btn btn-primary"
        [routerLinkActive]="['btn-active']"
        >Play Game</a
      >
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
  store = inject(CounterStore);
}
