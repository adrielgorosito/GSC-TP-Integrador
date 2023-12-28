import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { User } from '../user';
import { UserService } from '../user.service';
import { PersonService } from '../person.service';
import { Person } from '../person';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(
    private fb: FormBuilder,
    private us: UserService,
    private ps: PersonService
  ) {}
  // borrar personService, eso se haría en otro .ts

  error: boolean = false;

  loginForm = this.fb.group({
    user: ['', Validators.required],
    password: ['', Validators.required],
  });

  submit() {
    if (!this.loginForm.invalid) {
      const u = new User(
        this.loginForm.get('user')!.value!,
        this.loginForm.get('password')!.value!
      );

      const observer = {
        next: (people: Person[]) => {
          console.log('Personas obtenidas:', people);
        },
        error: (obsError: string) => {
          console.error('Error al obtener personas:', obsError);
        },
      };

      this.ps.getAllPeople().subscribe(observer);
    }
  }
}
