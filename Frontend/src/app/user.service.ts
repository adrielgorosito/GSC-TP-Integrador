import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  private loginUrl = 'http://localhost:5000/api/accounts/login';

  public getToken(user: User): Observable<string> {
    const credentials = { username: user.user, password: user.password };
    return this.http.post(this.loginUrl, credentials, { responseType: 'text' });
  }
}
