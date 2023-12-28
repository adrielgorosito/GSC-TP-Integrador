import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { User } from '../user';
import { UserService } from '../user.service';
import { PersonService } from '../person.service';
import {
  Router,
  RouterLink,
  RouterLinkActive,
  RouterOutlet,
} from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(
    private fb: FormBuilder,
    private us: UserService,
    private ps: PersonService,
    private router: Router
  ) {}
  // borrar personService, eso se haría en otro .ts

  loginForm = this.fb.group({
    user: ['', Validators.required],
    password: ['', Validators.required],
  });

  submit() {
    if (!this.loginForm.invalid) {
      const username = this.loginForm.get('user')!.value!;
      const password = this.loginForm.get('password')!.value!;

      this.us.getToken(username, password).subscribe(
        (token: string) => {
          // guardar token
          this.router.navigate(['/people-crud']);
        },
        (error) => {
          console.error('Error al obtener el token:', error);
          this.router.navigate(['/error-crud']);
        }
      );
    }
  }
}
