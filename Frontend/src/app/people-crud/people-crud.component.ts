import { Component } from '@angular/core';
import { Person } from '../person';

@Component({
  selector: 'app-people-crud',
  templateUrl: './people-crud.component.html',
  styleUrls: ['./people-crud.component.css'],
})
export class PeopleCRUDComponent {
  people: Person[] = [];

  ngOnInit(): void {
    this.initializePeople();
  }

  initializePeople() {
    this.people = [
      new Person(123456789, 'John Doe', '555-1234', 'john@example.com'),
      new Person(987654321, 'Jane Smith', '555-5678', 'jane@example.com'),
    ];
  }

  deletePerson(_t18: any) {
    throw new Error('Method not implemented.');
  }
  updatePerson(_t18: any) {
    throw new Error('Method not implemented.');
  }
}
