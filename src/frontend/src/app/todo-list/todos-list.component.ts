import { Component, inject, input } from '@angular/core';
import { TodoListItem } from './models';
import { TodosStore } from '../services/todos.store';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [],
  template: `
    <section>
      <ul>
        @for(todo of todos(); track todo.id) {
        <li class="card">
          <div class="card-body">
            @switch (todo.priority) { @case ('Urgent') {
            <div class="badge badge-accent">Urgent</div>

            } @case ('Future') {
            <div class="badge badge-neutral">Future</div>

            } }

            <p>
              @if(todo.completed === false) {
              <button class="btn btn-sm btn-error" (click)="store.markTodoComplete(todo)">X</button>
              <span>{{ todo.description }}</span>
              } @else {
              <span class="line-through">{{ todo.description }}</span>
              }
            </p>
          </div>
        </li>
        } @empty { 
          <p>Nothing on your list! Good job! Take a nap!
        }
      </ul>
    </section>
  `,
  styles: ``,
})
export class TodosListComponent {
  todos = input.required<TodoListItem[]>()

  store = inject(TodosStore);
}
