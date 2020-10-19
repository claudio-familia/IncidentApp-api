import { Component, OnInit } from '@angular/core';


@Component({
    selector: 'app-home',	
    template: `
        <app-layout>
            <h1 style="color: white">Home component</h1>
        </app-layout>
    `
})
export class HomeComponent {
	constructor() {
	}
}
