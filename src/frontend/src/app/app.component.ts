import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from './components/nav-bar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <app-nav-bar />

    <main class="container mx-auto">
      <router-outlet />
    </main>
  `,
  styles: ['h1 { @apply text-3xl }'],
  imports: [RouterOutlet, NavBarComponent],
})
export class AppComponent {}
