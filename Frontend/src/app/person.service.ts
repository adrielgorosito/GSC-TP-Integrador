import { Injectable } from '@angular/core';
import { Person } from './person';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient) {}

  private urlBackend = 'http://localhost:5000/api/people';

  getAllPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.urlBackend}`);
  }
}
