import { Routes } from '@angular/router';
import { IssueListComponent } from './components/issue-list.component';
import { NewIssueComponent } from './components/new-issue.component';

export const routes: Routes = [
    {
        path: 'new-issue',
        component: NewIssueComponent
    },
    {
        path: 'issues',
        component: IssueListComponent
    }
];
