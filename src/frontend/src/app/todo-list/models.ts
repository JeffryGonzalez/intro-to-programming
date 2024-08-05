export type TodoListItem =  {
    id: string;
    description: string;
    completed: boolean;
    priority?: 'Urgent' | 'Future'
}

export type TodoListSummary = {
    totalItems: number;
    incompleteItems: number;
    completeItems: number;
}