import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  styles: [`
  html,
    body {
        background-color: #1a237e;
    }
  `],
  template: `
    <router-outlet></router-outlet>
  `,
})
export class AppComponent {
  title = 'Incident-App | Home';
}
