import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Person } from '../person';
import { Router } from '@angular/router';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-add-update-person',
  templateUrl: './add-update-person.component.html',
  styleUrls: ['./add-update-person.component.css'],
})
export class AddUpdatePersonComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private ps: PersonService
  ) {}

  submitButtonText: string = 'Add';
  protected isUpdate = false;

  ngOnInit() {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);

    const state = this.router.lastSuccessfulNavigation;

    if (
      state &&
      state.extras &&
      state.extras.state &&
      state.extras.state['data']
    ) {
      const person: Person = state.extras.state['data'];
      this.newPersonForm.patchValue({
        dni: person.dni.toString(),
        name: person.name,
        phoneNumber: person.phoneNumber,
        emailAddress: person.emailAddress,
      });

      this.newPersonForm.get('dni')!.disable();
      this.submitButtonText = 'Update';
      this.isUpdate = true;
    } else {
      this.submitButtonText = 'Add';
      this.isUpdate = false;
    }
  }

  newPersonForm = this.fb.group({
    dni: ['', Validators.required],
    name: ['', Validators.required],
    phoneNumber: ['', Validators.required],
    emailAddress: ['', Validators.required],
  });

  protected submit() {
    if (this.newPersonForm.invalid) this.router.navigate(['/error-crud']);

    const person = new Person(
      parseInt(this.newPersonForm.get('dni')!.value!),
      this.newPersonForm.get('name')!.value!,
      this.newPersonForm.get('phoneNumber')!.value!,
      this.newPersonForm.get('emailAddress')!.value!
    );

    if (this.isUpdate) this.updatePerson(person);
    else this.addPerson(person);
  }

  private addPerson(person: Person) {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);
    const observer = {
      next: (data: Person) => {
        const addedPerson: Person = data;
        this.router.navigate(['/people-crud']);
      },
      error: (error: any) => {
        console.error('Error adding person:', error);
      },
    };
    this.ps.addPerson(person).subscribe(observer);
  }

  protected updatePerson(person: Person) {
    if (localStorage.getItem('token') == null)
      this.router.navigate(['/error-crud']);

    const observer = {
      next: (data: Person) => {
        const updatedPerson: Person = data;
        this.router.navigate(['/people-crud']);
      },
      error: (error: any) => {
        console.error('Error updating person:', error);
      },
    };
    this.ps.updatePerson(person).subscribe(observer);
  }

  protected goBack() {
    this.router.navigate(['/people-crud']);
  }
}
