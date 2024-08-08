import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { TodoListCreateItem, TodoListItem } from '../todo-list/models';
import { map } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TodosDataService {
  #client = inject(HttpClient);

  loadTodos() {
    return this.#client
      .get<{ items: TodoListItem[] }>('http://localhost:1337/api/todos')
      .pipe(map((r) => r.items));
  }

  addTodo(itemToAdd: TodoListCreateItem) {
    return this.#client.post<TodoListItem>(
      'http://localhost:1337/api/todos',
      itemToAdd
    );
  }
}

// Any of the "complexity" of "my api returns ridiculous weird data, and I want my Angular app to have a simplified view of this
// shoudl be done here"
