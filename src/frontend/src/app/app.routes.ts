import { Routes } from '@angular/router';
import { IssueListComponent } from './components/issue-list.component';
import { NewIssueComponent } from './components/new-issue.component';
import { TodoListComponent } from './todo-list/todo-list.component';
import { CounterComponent } from './counter/counter.component';
import { CounterStore } from './services/counter.store';
import { GameComponent } from './counter/components/game.component';
import { PrefsComponent } from './counter/components/prefs.component';

export const routes: Routes = [
  {
    path: 'new-issue',
    component: NewIssueComponent,
  },
  {
    path: 'issues',
    component: IssueListComponent,
  },
  {
    path: 'todo-list',
    component: TodoListComponent,
  },
  {
    path: 'counter',
    component: CounterComponent,
    children: [
      {
        path: 'game', // counter/game
        component: GameComponent,
      },
      {
        path: 'prefs', // counter/prefs
        component: PrefsComponent,
      },
      {
        path: '**', // wildcard, two asterisks, not sure why
        redirectTo: 'game',
      },
    ],
  },
];
