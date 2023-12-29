import { Component } from '@angular/core';
import { Person } from '../person';
import { PersonService } from '../person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-people-crud',
  templateUrl: './people-crud.component.html',
  styleUrls: ['./people-crud.component.css'],
})
export class PeopleCRUDComponent {
  constructor(private ps: PersonService, private router: Router) {}

  people: Person[] = [];
  dataLoaded: boolean = false;
  listPeople: boolean = true;
  isSearching: boolean = false;
  dniInput: number = 0;

  startSearch() {
    this.isSearching = true;
  }

  cancelSearch() {
    this.isSearching = false;
    this.getAllPeople();
  }

  ngOnInit() {
    this.listPeople = true;
    this.getAllPeople();
  }

  protected getAllPeople() {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);

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

  searchByDni() {
    if (!isNaN(this.dniInput)) {
      this.getPersonByDni(this.dniInput);
    }
  }

  protected getPersonByDni(dni: number) {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);

    this.people = [];
    this.listPeople = true;

    const observer = {
      next: (data: Person) => {
        this.people = [];
        this.people.push(data);
      },
      error: (error: any) => {
        console.error('Error fetching person by DNI:', error);
      },
    };

    this.ps.getPersonByDni(dni).subscribe(observer);
  }

  protected addPerson() {
    // if (localStorage.getItem('token') == null)
    //   this.router.navigate(['/error-crud']);
    // const observer = {
    //   next: (data: Person) => {
    //     // ???
    //     const addedPerson: Person = data;
    //   },
    //   error: (error: any) => {
    //     console.error('Error adding person:', error);
    //   },
    // };
    // this.ps.addPerson(person).subscribe(observer);
    //
    /* maybe I can use: <router-outlet></router-outlet>*/
  }

  protected updatePerson(person: Person) {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);

    const observer = {
      next: (data: Person) => {
        // apply logic
        const updatedPerson: Person = data;
      },
      error: (error: any) => {
        console.error('Error updating person:', error);
      },
    };
  }

  protected deletePerson(person: Person) {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);

    const observer = {
      next: (data: Person) => {
        this.getAllPeople();
      },
      error: (error: any) => {
        console.error('Error deleting person:', error);
      },
    };

    this.ps.deletePerson(person.dni).subscribe(observer);
  }

  // Confirm delete
  confirmedDeletions: number[] = [];

  deletePersonConfirmation(person: Person) {
    this.confirmedDeletions.push(person.dni);
  }

  confirmDelete(person: Person) {
    this.deletePerson(person);
    this.confirmedDeletions = this.confirmedDeletions.filter(
      (dni) => dni !== person.dni
    );
  }

  cancelDelete(person: Person) {
    this.confirmedDeletions = this.confirmedDeletions.filter(
      (dni) => dni !== person.dni
    );
  }
}
