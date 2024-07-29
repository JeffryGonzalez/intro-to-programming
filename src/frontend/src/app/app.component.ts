import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WelcomeComponent } from "./components/welcome.component";
import { NewIssueComponent } from "./components/new-issue.component";

@Component({
    selector: 'app-root',
    standalone: true,
    template: `
    <main class="container mx-auto">
      <h1>Welcome to the Issues Site</h1>
      <app-new-issue />
    </main>
  `,
    styles: [],
    imports: [RouterOutlet, WelcomeComponent, NewIssueComponent]
})
export class AppComponent {}
