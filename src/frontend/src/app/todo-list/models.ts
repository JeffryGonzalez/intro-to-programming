export type TodoListItem =  {
    id: string;
    description: string;
    completed: boolean;
    priority?: 'Urgent' | 'Future'
}