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

  ngOnInit(): void {
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

  protected getPersonByDni(dni: number) {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);

    const observer = {
      next: (data: Person) => {
        // apply logic
      },
      error: (error: any) => {
        console.error('Error fetching person by DNI:', error);
      },
    };

    this.ps.getPersonByDni(dni).subscribe(observer);
  }

  protected addPerson(person: Person) {
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
        // apply logic
        const deletedPerson: Person = data;
      },
      error: (error: any) => {
        console.error('Error deleting person:', error);
      },
    };
  }
}
