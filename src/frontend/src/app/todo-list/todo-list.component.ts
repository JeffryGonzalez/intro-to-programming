import { Component, signal } from '@angular/core';
import { TodoEntryComponent } from "./todo-entry.component";
import { TodosListComponent } from "./todos-list.component";
import { TodoListItem } from './models';

@Component({
  standalone: true,
  imports: [TodoEntryComponent, TodosListComponent],
  template: `
 
    <app-todo-entry (itemAdded)="addThis($event)" />
    <app-list [todos]="items()" />
   
  `,
  styles: ``,
})
export class TodoListComponent {

  addThis(description: string) {
    const newItem: TodoListItem = {
      id: crypto.randomUUID(),
      description,
      completed: false
    }
    this.items.set([newItem, ...this.items()])
  }
  items = signal<TodoListItem[]>([ ]);
}
