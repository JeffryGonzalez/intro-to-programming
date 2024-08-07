import { delay, http, HttpResponse } from 'msw';
import { TodoListCreateItem, TodoListItem } from '../app/todo-list/models';

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

  http.post('http://localhost:1337/api/todos', async ({ request }) => {
    const body = (await request.json()) as unknown as TodoListCreateItem;

    const newItem: TodoListItem = {
      ...body,
      id: crypto.randomUUID(),
      completed: false,
    };
    fakeTodos.push(newItem);
    return HttpResponse.json(newItem);
  }),
];

export default handlers;
