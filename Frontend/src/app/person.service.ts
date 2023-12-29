import { Injectable } from '@angular/core';
import { Person } from './person';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, switchMap, throwError } from 'rxjs';
import { UserService } from './user.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient, private router: Router) {}

  private apiPeople = 'http://localhost:5000/api/people';

  public getAllPeople(): Observable<Person[]> {
    const headers = this.headerToken();
    return this.http.get<Person[]>(this.apiPeople, { headers });
  }

  public getPersonByDni(dni: number): Observable<Person> {
    const headers = this.headerToken();
    return this.http.get<Person>(`${this.apiPeople}/${dni}`, { headers });
  }

  public addPerson(person: Person): Observable<Person> {
    const headers = this.headerToken();
    return this.http.post<Person>(this.apiPeople, person, { headers });
  }

  public deletePerson(dni: number): Observable<Person> {
    const headers = this.headerToken();
    return this.http.delete<Person>(`${this.apiPeople}/${dni}`, { headers });
  }

  public updatePerson(person: Person): Observable<Person> {
    const headers = this.headerToken();
    return this.http.put<Person>(this.apiPeople, person, { headers });
  }

  private headerToken(): HttpHeaders {
    const token = localStorage.getItem('token');

    if (!token) {
      this.router.navigate(['/error-crud']);
      throw new Error('Token not available');
    }

    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }
}
