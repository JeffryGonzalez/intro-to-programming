import { Component, signal } from '@angular/core';
import { TodoEntryComponent } from "./todo-entry.component";
import { TodosListComponent } from "./todos-list.component";
import { TodoListItem } from './models';

@Component({
  standalone: true,
  imports: [TodoEntryComponent, TodosListComponent],
  template: `
 
    <app-todo-entry />
    <app-list [todos]="items()" />
   
  `,
  styles: ``,
})
export class TodoListComponent {

  items =signal<TodoListItem[]>([
    {
      id: '1',
      description: 'Fix Book Shelf',
      completed: false,
    },
    {
      id: '2',
      description: 'Do recall on car',
      completed: false,
      priority: 'Urgent',
    },
    {
      id: '3',
      description: 'Learn TypeScript',
      completed: true,
      priority: 'Future',
    },
  ]);
}
