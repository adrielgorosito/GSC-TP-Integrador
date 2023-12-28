import { Injectable } from '@angular/core';
import { Person } from './person';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, switchMap } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient, private us: UserService) {}

  private apiPeople = 'http://localhost:5000/api/people';

  public getAllPeople(): Observable<Person[]> {
    return this.us.getToken('admin', '12345').pipe(
      switchMap((tokenResponse: string) => {
        const headers = new HttpHeaders({
          Authorization: `Bearer ${tokenResponse}`,
        });
        return this.http.get<Person[]>(this.apiPeople, { headers });
      })
    );
  }
}
