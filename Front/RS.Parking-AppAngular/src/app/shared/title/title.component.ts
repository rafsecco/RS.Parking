import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'app-title',
	templateUrl: './title.component.html',
	styleUrls: ['./title.component.scss'],
})
export class TitleComponent implements OnInit {

	@Input() title:string = '';
	@Input() iconClass:string = 'bi bi-card-checklist';
	@Input() buttonList:boolean = false;

	constructor(private router: Router) {}

	ngOnInit() {}

	List(): void {
		this.router.navigate([`/${this.title.toLowerCase()}/list`])
	}
}
