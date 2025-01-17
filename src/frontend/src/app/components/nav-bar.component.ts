import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TodosStore } from '../services/todos.store';
import { FizzBuzzHeaderComponent } from './fizz-buzz-header.component';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [RouterLink, FizzBuzzHeaderComponent],
  template: `
    <div class="navbar bg-base-100">
      <div class="navbar-start">
        <div class="dropdown">
          <div tabindex="0" role="button" class="btn btn-ghost lg:hidden">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              class="h-5 w-5"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M4 6h16M4 12h8m-8 6h16"
              />
            </svg>
          </div>
          <ul
            tabindex="0"
            class="menu menu-sm dropdown-content bg-base-100 rounded-box z-[1] mt-3 w-52 p-2 shadow"
          >
            <li><a>Item 1</a></li>
            <li>
              <a>Parent</a>
              <ul class="p-2">
                <li><a>Submenu 1</a></li>
                <li><a>Submenu 2</a></li>
              </ul>
            </li>
            <li><a>Item 3</a></li>
          </ul>
        </div>
        <a class="btn btn-ghost text-xl">Help Desk</a>
      </div>
      <div class="navbar-center hidden lg:flex">
        <ul class="menu menu-horizontal px-1">
          <li><a routerLink="new-issue">Create an Issue</a></li>

          <li><a routerLink="issues">See Issues</a></li>
          <li><a routerLink="todo-list">Todo List</a></li>
          <li><a routerLink="counter">Counter</a></li>
        </ul>
      </div>
      <div class="navbar-end">
        <app-header-fizzbuzz />
        <span>
          You have {{ summary().totalItems }} items on your todo list ({{
            summary().completeItems
          }}
          completed, {{ summary().incompleteItems }} incomplete)</span
        >
      </div>
    </div>
  `,
  styles: ``,
})
export class NavBarComponent {
  #store = inject(TodosStore);
  summary = this.#store.getSummary;
}
