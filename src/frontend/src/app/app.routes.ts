import { Routes } from '@angular/router';
import { IssueListComponent } from './components/issue-list.component';
import { NewIssueComponent } from './components/new-issue.component';
import { TodoListComponent } from './todo-list/todo-list.component';
import { CounterComponent } from './counter/counter.component';
import { CounterStore } from './services/counter.store';

export const routes: Routes = [
    {
        path: 'new-issue',
        component: NewIssueComponent
    },
    {
        path: 'issues',
        component: IssueListComponent
    },
    {
        path: 'todo-list',
        component: TodoListComponent
    },
    {
        path: 'counter',
        component: CounterComponent,
        providers: [CounterStore]
    }
];
