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

  protected people: Person[] = [];
  protected listPeople: boolean = true;
  protected isSearching: boolean = false;
  protected dniInput: number = 0;

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

  // Search by dni
  searchByDni() {
    if (!isNaN(this.dniInput)) {
      this.getPersonByDni(this.dniInput);
    }
  }

  cancelSearch() {
    this.isSearching = false;
    this.getAllPeople();
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

  // Delete
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

  cancelDelete(person: Person) {
    this.confirmedDeletions = this.confirmedDeletions.filter(
      (dni) => dni !== person.dni
    );
  }

  goToAddUpdate() {
    this.router.navigate(['/add-update-person']);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
