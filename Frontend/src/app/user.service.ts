import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  private loginUrl = 'http://localhost:5000/api/accounts/login';

  public getToken(username: string, password: string): Observable<string> {
    const credentials = { username, password };
    return this.http.post(this.loginUrl, credentials, { responseType: 'text' });
  }
}
