import { Component } from '@angular/core';
import { Person } from '../person';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-people-crud',
  templateUrl: './people-crud.component.html',
  styleUrls: ['./people-crud.component.css'],
})
export class PeopleCRUDComponent {
  constructor(private ps: PersonService) {}

  people: Person[] = [];
  dataLoaded: boolean = false;

  ngOnInit(): void {
    const observer = {
      next: (data: Person[]) => {
        this.people = data;
      },
      error: (error: any) => {
        console.error('Error fetching people:', error);
      },
    };

    this.ps.getAllPeople().subscribe(observer);
  }

  deletePerson(person: Person) {
    throw new Error('Method not implemented.');
  }
  updatePerson(person: Person) {
    throw new Error('Method not implemented.');
  }
  addPerson() {
    throw new Error('Method not implemented.');
  }
}
