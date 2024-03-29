import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'app-title',
	templateUrl: './title.component.html',
	styleUrls: ['./title.component.scss'],
})
export class TitleComponent implements OnInit {

	@Input() iconClass:string = '';
	@Input() iconSecondClass:string = '';
	@Input() title:string = '';
	@Input() link:string = '';
	@Input() buttonAddNew:string = 'visible';

	constructor(private router: Router) {}

	ngOnInit() {}

	AddNew(): void {
		this.router.navigate([`/${this.link.toLowerCase()}/new`])
	}
}
