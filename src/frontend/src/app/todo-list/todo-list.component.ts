import { JsonPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { TodosStore } from '../services/todos.store';
import { TodoEntryComponent } from './todo-entry.component';
import { TodosListComponent } from './todos-list.component';
@Component({
  standalone: true,
  imports: [TodoEntryComponent, TodosListComponent, JsonPipe],
  template: `
    @if(store.isLoading()) {
    <span class="loading loading-bars loading-md"></span>
    } @else {
    <app-todo-entry (itemAdded)="addThis($event)" />
    <app-list [todos]="items()" />
    }
  `,
  styles: ``,
})
export class TodoListComponent {
  store = inject(TodosStore);
  items = this.store.entities;
  addThis(description: string) {
    this.store.addTodoItem(description);
  }
  constructor() {
    this.store.loadTodos();
  }
}
