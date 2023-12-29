import { Injectable } from '@angular/core';
import { Person } from './person';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, switchMap, throwError } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient, private us: UserService) {}

  private apiPeople = 'http://localhost:5000/api/people';

  public getAllPeople(): Observable<Person[]> {
    const token = localStorage.getItem('token');

    if (!token) {
      return throwError(() => 'Token not available');
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.get<Person[]>(this.apiPeople, { headers });
  }
}
