import { Component, inject } from '@angular/core';
import { CounterStore } from '../services/counter.store';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-header-fizzbuzz',
  standalone: true,
  imports: [NgClass],
  template: `
    <div class="stat">
      <div class="stat-title">Counter</div>

      @let fbStatus = store.fizzBuzzStatus();
      <div
        class="stat-value"
        [ngClass]="{
          'text-green-500': fbStatus === 'fizz',
          'text-blue-500': fbStatus === 'buzz',
          'text-orange-500': fbStatus === 'fizzbuzz'
        }"
      >
        {{ store.current() }}
      </div>
    </div>
  `,
  styles: ``,
})
export class FizzBuzzHeaderComponent {
  store = inject(CounterStore);
  showRed = false;
  // if it is 'fizz', it should be green text with the count.  text-green-500
  // if it is 'buzz' it should be blue text with the count  text-blue-500
  // if it is 'fizzbuzz' it should be background orange - text-orange-500
  // otherwise, it should just be the count. - no text color at all.
}
