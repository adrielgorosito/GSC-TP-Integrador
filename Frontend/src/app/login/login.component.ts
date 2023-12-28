import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { User } from '../user';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(
    private fb: FormBuilder,
    private us: UserService,
    private router: Router
  ) {}
  // borrar personService, eso se haría en otro .ts

  loginForm = this.fb.group({
    user: ['', Validators.required],
    password: ['', Validators.required],
  });

  submit() {
    if (!this.loginForm.invalid) {
      const user = new User(
        this.loginForm.get('user')!.value!,
        this.loginForm.get('password')!.value!
      );

      const observer = {
        next: (token: string) => {
          // guardar token
          this.router.navigate(['/people-crud']);
        },
        error: (error: any) => {
          this.router.navigate(['/error-crud']);
        },
      };

      this.us.getToken(user).subscribe(observer);
    }
  }
}
