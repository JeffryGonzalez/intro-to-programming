import { delay, http, HttpResponse } from 'msw';
import { TodoListItem } from '../app/todo-list/models';

const fakeTodos: TodoListItem[] = [
  { id: '1', description: 'Clean Kitchen', completed: false },
  { id: '2', description: 'Mow Lawn', completed: false },
  { id: '3', description: 'Mail Check', completed: true },
];

const handlers = [
  http.get('http://localhost:1377/api/todos', async () => {
    await delay(2500);
    return HttpResponse.json(fakeTodos);
  }),
];

export default handlers;
