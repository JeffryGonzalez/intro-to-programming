import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { TodoListCreateItem, TodoListItem } from '../todo-list/models';

@Injectable({ providedIn: 'root' })
export class TodosDataService {
  #client = inject(HttpClient);

  loadTodos() {
    return this.#client.get<TodoListItem[]>('http://localhost:1377/api/todos');
  }

  addTodo(itemToAdd: TodoListCreateItem) {
    return this.#client.post<TodoListItem>(
      'http://localhost:1337/api/todos',
      itemToAdd
    );
  }
}
